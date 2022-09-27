namespace CodeGeneration.Model;

public record BinaryExpression(Expression Left, Expression Right, char Operator) : Expression;