namespace CodeGeneration.Model.Classes;

public record BinaryExpression(Expression Left, Expression Right, char Operator) : Expression;