using CodeGeneration.Model;
using Xunit.Abstractions;

namespace CodeGeneration.Tests;

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
        var format = string.Join(Environment.NewLine, instructions.Codes.ToCodeFormatContent());
        var expected = @"T0 = b 
                            T1 = c 
                            T2 = T0 + T1
                            T3 = e 
                            T4 = T2 * T3
                            a = T4 ";

        Assert.Equal(expected.RemoveWhitespace(), format.RemoveWhitespace());
    }
}