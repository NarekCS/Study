using MEFdlls;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace MEF
{
    class Program
    {
        [ImportMany]         
        public static IEnumerable<IMessageSender> MessageSenders { get; set; }
        void Compose()
        {
            var executableLocation = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "Plugins");
            var assemblies = Directory
                        .GetFiles(path, "*.dll", SearchOption.AllDirectories)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);                        
            var configuration = new ContainerConfiguration().WithAssemblies(assemblies);
            using (CompositionHost container = configuration.CreateContainer())
            {
                MessageSenders = container.GetExports<IMessageSender>();
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Compose();
            foreach (var messageSenders in MessageSenders)
            {
                messageSenders.Send("Hello MEF");
            }
        }
    }
}
