using CodeGeneration.Model;
using CodeGeneration.Model.Classes;

namespace CodeGeneration;

public class IntermediateCodeGenerator
{
    public Fragment Generate(AssignmentExpression assignment)
    {
        var reference = new NamedReference(assignment.Identifier.Identifier);
        var expressionFragment = Generate(reference, assignment.Expression);

        var code = new Code(reference, expressionFragment.Reference, null, '=');
        return new Fragment(reference, expressionFragment.Codes.Concat(new[] {code}));
    }

    private Fragment Generate(Reference r, Expression expression)
    {
        return expression switch
        {
            BinaryExpression bex => Generate(bex),
            ConstantExpression cex => Generate(cex),
            _ => throw new NotSupportedException(),
        };
    }

    private Fragment Generate(ConstantExpression cex)
    {
        var placeholder = new Placeholder();
        return new Fragment(placeholder, new Code(placeholder, new ConstantReference(cex.Constant), null, '='));
    }

    private Fragment Generate(BinaryExpression bex)
    {
        var left = Generate(bex.Left);
        var right = Generate(bex.Right);

        var placeholder = new Placeholder();
        var code = new Code(placeholder, left.Reference, right.Reference, bex.Operator);
        return new Fragment(placeholder, left.Codes.Concat(right.Codes).Concat(new[] {code}));
    }

    private Fragment Generate(IdentifierExpression bex)
    {
        var placeholder = new Placeholder();
        var code = new Code(placeholder, new NamedReference(bex.Identifier), null, '=');
        return new Fragment(placeholder, code);
    }

    private Fragment Generate(Expression expression)
    {
        return expression switch
        {
            BinaryExpression bex => Generate(bex),
            ConstantExpression cex => Generate(cex),
            IdentifierExpression iex => Generate(iex),
            _ => throw new NotSupportedException(),
        };
    }
}

internal class ConstantReference : Reference
{
    public int Constant { get; }

    public ConstantReference(int constant)
    {
        Constant = constant;
    }
}