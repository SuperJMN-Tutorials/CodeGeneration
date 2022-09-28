namespace CodeGeneration.Model;

public record AssignmentExpression(IdentifierExpression Identifier, Expression Expression) : Expression;