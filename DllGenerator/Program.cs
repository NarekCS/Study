using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace DllGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();            
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = "NewMEF.dll";
            CodeCompileUnit compileUnit = BuildNewMefGraph();
            CompilerResults results = codeProvider.CompileAssemblyFromDom(parameters, compileUnit);
        }

        public static CodeCompileUnit BuildNewMefGraph()
        {
            // Create a new CodeCompileUnit to contain 
            // the program graph.
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // Declare a new namespace called Samples.
            CodeNamespace samples = new CodeNamespace("Samples");
            // Add the new namespace to the compile unit.
            compileUnit.Namespaces.Add(samples);

            // Add the new namespace import for the System namespace.
            samples.Imports.AddRange(new[]{ new CodeNamespaceImport("System"), new CodeNamespaceImport("System.Composition") , new CodeNamespaceImport("MEFdlls") });

            // Declare a new type called NewMef.
            CodeTypeDeclaration myclass = new CodeTypeDeclaration("NewMEF");
            // Add the new type to the namespace type collection.
            samples.Types.Add(myclass);

            CodeTypeReference typeRef = new CodeTypeReference("MEFdlls.IMessageSender");
            CodeTypeOfExpression typeofInterface = new CodeTypeOfExpression(typeRef);      
            CodeAttributeDeclaration attribute = new CodeAttributeDeclaration("System.Composition.ExportAttribute");             
            attribute.Arguments.Add(new CodeAttributeArgument(typeofInterface));
            myclass.CustomAttributes.Add(attribute);
            myclass.BaseTypes.Add(typeRef);

            CodeMemberMethod method = new CodeMemberMethod();
            method.Name = "Send";
            method.ReturnType = new CodeTypeReference("System.Void");
            CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression("System.String", "message");
            parameter.Direction = FieldDirection.In;
            method.Parameters.Add(parameter);

            // Create a type reference for the System.Console class.
            CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");

            // Build a Console.WriteLine statement.
            CodeMethodInvokeExpression command = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Runtime dll-ic "));//, new CodePrimitiveExpression(parameter));

            // Add the WriteLine call to the statement collection.
            method.Statements.Add(command);
            myclass.Members.Add(method);
            // Build another Console.WriteLine statement.
            CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Press the Enter key to continue."));   

            return compileUnit;
        }
    }
}
