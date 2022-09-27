namespace CodeGeneration.Model.Classes;

public record AssignmentExpression(IdentifierExpression Identifier, Expression Expression) : Expression;