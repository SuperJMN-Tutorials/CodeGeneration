using CodeGeneration.Model;

namespace CodeGeneration.Tests;

public class CodeGenerationTests
{
    [Fact]
    public void Simple_test()
    {
        // Arrange
        var add = new BinaryExpression(new IdentifierExpression("b"), new IdentifierExpression("c"), Operator.Add);
        var mult = new BinaryExpression(add, new IdentifierExpression("e"), Operator.Multiply);
        var assignment = new AssignmentExpression(new IdentifierExpression("a"), mult);
        var sut = new IntermediateCodeGenerator();

        // Act
        var instructions = sut.Generate(assignment);

        // Assert
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