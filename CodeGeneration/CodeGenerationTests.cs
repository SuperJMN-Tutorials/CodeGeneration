using CodeGeneration.Model;
using CodeGeneration.Model.Classes;
using Xunit.Abstractions;

namespace CodeGeneration
{
    public class CodeGenerationTests
    {
        private readonly ITestOutputHelper output;

        public CodeGenerationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            var p = new AssignmentExpression(new IdentifierExpression("a"),
                new BinaryExpression(
                    new BinaryExpression(new IdentifierExpression("b"), new IdentifierExpression("c"), '+'),
                    new IdentifierExpression("e"),
                    '*'));

            var instructions = new IntermediateCodeGenerator().Generate(p);
            instructions.Codes.ToReadableList().ToList().ForEach(s => output.WriteLine(s));
            //instructions.Codes.Select(x => x.AsInstruction()).ToList().ForEach(s => output.WriteLine(s));
        }
    }
}