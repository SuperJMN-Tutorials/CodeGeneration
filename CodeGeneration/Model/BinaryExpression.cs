namespace CodeGeneration.Model;

public record BinaryExpression(Expression Left, Expression Right, Operator Operator) : Expression;