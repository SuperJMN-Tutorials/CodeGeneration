using CodeGeneration.Model;
using CodeGeneration.Model.Classes;

namespace CodeGeneration;

public class IntermediateCodeGenerator
{
    public GenerationResult Generate(AssignmentExpression assignment)
    {
        var r = new NamedReference(assignment.Identifier.Identifier);
        var g = Generate(r, assignment.Expression);

        return new GenerationResult(r, g.Codes.Concat(new[] { new Code(r, g.Reference, null, '=') }));
    }

    private GenerationResult Generate(Reference r, Expression expression)
    {
        return expression switch
        {
            BinaryExpression bex => Generate(bex),
            ConstantExpression cex => Generate(cex),
            _ => throw new NotSupportedException(),
        };
    }

    private GenerationResult Generate(ConstantExpression cex)
    {
        return new GenerationResult();
    }

    private GenerationResult Generate(BinaryExpression bex)
    {
        var a = Generate(bex.Left);
        var b = Generate(bex.Right);

        var r = new DynamicReference();
        var codes = a.Codes.Concat(b.Codes).Concat(new[] { new Code(r, a.Reference, b.Reference, bex.Operator) }).ToArray();
        return new GenerationResult(r, codes);
    }

    private GenerationResult Generate(IdentifierExpression bex)
    {
        var r = new DynamicReference();
        return new GenerationResult(r, new[] { new Code(r, new NamedReference(bex.Identifier), null, '=') });
    }

    private GenerationResult Generate(Expression expression)
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