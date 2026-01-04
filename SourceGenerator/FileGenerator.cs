using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace SourceGenerator;

public class FileGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static postInitializationContext =>
        {
            postInitializationContext.AddEmbeddedAttributeDefinition();
            var builder = new StringBuilder();
            var code = """
            using System;

            namespace SourceGenerator
            {
                public class GeneratedClass
                {

                }
            }
            """;

            var source = SourceText.From(code, Encoding.UTF8);
            postInitializationContext.AddSource("GeneratedClass.g.cs", source);
        });
    }
}
