using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Composition;
using System.IO;

namespace DLLgeneratorFramework
{[Export]
    class Program
    {
        static void Main(string[] args)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = false;           
            parameters.ReferencedAssemblies.Add("netstandard.dll");
            parameters.ReferencedAssemblies.Add("System.Composition.AttributedModel.dll");
            parameters.ReferencedAssemblies.Add("MEFdlls.dll");
            parameters.OutputAssembly = "C:/temp/NewMEF.dll";            
            CodeCompileUnit compileUnit = BuildNewMefGraph();
            string sourceFile = "NewMEF." + provider.FileExtension;           

          
            using (StreamWriter sw = new StreamWriter(sourceFile, false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw,
                    new CodeGeneratorOptions());
                tw.Close();
            }
            CompilerResults results = provider.CompileAssemblyFromDom(parameters, compileUnit);
             var s = results.PathToAssembly;
        }
        public static CodeCompileUnit BuildNewMefGraph()
        {            
            CodeCompileUnit compileUnit = new CodeCompileUnit();
          
            CodeNamespace myNamespase = new CodeNamespace("Samples");
           
            compileUnit.Namespaces.Add(myNamespase);            
          
            myNamespase.Imports.AddRange(new[] { new CodeNamespaceImport("System"), 
                                                 new CodeNamespaceImport("System.Composition"),
                                                 new CodeNamespaceImport("MEFdlls") });
            
            CodeTypeDeclaration myClass = new CodeTypeDeclaration("EmailSender");   

            CodeTypeReference typeRef = new CodeTypeReference("MEFdlls.IMessageSender");
            CodeTypeOfExpression typeofInterface = new CodeTypeOfExpression(typeRef);
            CodeAttributeDeclaration attribute = new CodeAttributeDeclaration("System.Composition.ExportAttribute");
            attribute.Arguments.Add(new CodeAttributeArgument(typeofInterface));
            myClass.CustomAttributes.Add(attribute);
            myClass.BaseTypes.Add(typeRef);
            myNamespase.Types.Add(myClass);

            CodeMemberMethod method = new CodeMemberMethod();
            method.Name = "Send";           
            method.ReturnType = new CodeTypeReference("System.Void");
            method.Attributes = MemberAttributes.Final | MemberAttributes.Public;
            CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression(typeof(string), "message");
            parameter.Direction = FieldDirection.In;
            method.Parameters.Add(parameter);

            
            CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");           
            CodeArgumentReferenceExpression codeArgumentReferenceExpression = new CodeArgumentReferenceExpression("message");
           
            CodeMethodInvokeExpression command1 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "Write",                
                codeArgumentReferenceExpression);
            CodeMethodInvokeExpression command2 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression(" Runtime dll-ic"));
          
            method.Statements.Add(command1);
            method.Statements.Add(command2);
            myClass.Members.Add(method);
           
            return compileUnit;
        }
    }
}
