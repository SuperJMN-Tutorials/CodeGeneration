using CodeGeneration.Model;
using Xunit.Abstractions;

namespace CodeGeneration.Tests
{
    public class CodeGenerationTests
    {
        private readonly ITestOutputHelper output;

        public CodeGenerationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Simple_test()
        {
            var add = new BinaryExpression(new IdentifierExpression("b"), new IdentifierExpression("c"), '+');
            var mult = new BinaryExpression(add, new IdentifierExpression("e"), '*');
            var assignment = new AssignmentExpression(new IdentifierExpression("a"), mult);

            var instructions = new IntermediateCodeGenerator().Generate(assignment);
            instructions.Codes.ToCodeFormatContent().ToList().ForEach(s => output.WriteLine(s));
        }
    }
}