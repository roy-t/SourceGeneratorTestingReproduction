using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using SourceGenerator;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestApp;

internal class SourceGeneratorTests
{
    [Test]
    public async Task Execute_Generates_File()
    {
        var harness = new CSharpSourceGeneratorTest<FileGenerator, TUnitVerifier>();

        var expected = SourceText.From("""
            using System;
            
            namespace SourceGenerator
            {
                public class GeneratedClass
                {
            
                }
            }
            """,
            Encoding.UTF8);
        harness.TestState.GeneratedSources.Add(("GeneratedClass.g.cs", expected));
        await harness.RunAsync();
    }


    internal class TUnitVerifier : IVerifier
    {
        public void Empty<T>(string collectionName, IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public void Equal<T>(T expected, T actual, string? message = null)
        {
            throw new NotImplementedException();
        }

        [DoesNotReturn]
        public void Fail(string? message = null)
        {
            throw new NotImplementedException();
        }

        public void False([DoesNotReturnIf(true)] bool assert, string? message = null)
        {
            throw new NotImplementedException();
        }

        public void LanguageIsSupported(string language)
        {
            throw new NotImplementedException();
        }

        public void NotEmpty<T>(string collectionName, IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public IVerifier PushContext(string context)
        {
            throw new NotImplementedException();
        }

        public void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T>? equalityComparer = null, string? message = null)
        {
            throw new NotImplementedException();
        }

        public void True([DoesNotReturnIf(false)] bool assert, string? message = null)
        {
            throw new NotImplementedException();
        }
    }
}
