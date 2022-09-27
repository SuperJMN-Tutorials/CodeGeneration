namespace CodeGeneration.Model.Classes;

public static class CodeMixin
{
    public static IEnumerable<string> ToReadableList(this IEnumerable<Code> codes)
    {
        var map = new Dictionary<DynamicReference, string>();

        return codes.Select(code => Format(code, map));
    }

    private static string Format(Code code, Dictionary<DynamicReference, string> map)
    {
        if (code.Right is null)
        {
            return $"{GetReferenceName(code.Destination, map)} {code.Operator} {GetReferenceName(code.Left, map)} {GetReferenceName(code.Right, map)}";
        }

        return $"{GetReferenceName(code.Destination, map)} = {GetReferenceName(code.Left, map)} {code.Operator} {GetReferenceName(code.Right, map)}";
    }

    private static string GetReferenceName(Reference? reference, IDictionary<DynamicReference, string> map)
    {
        if (reference is null)
        {
            return "";
        }

        return reference switch
        {
            DynamicReference dynamicReference => map.GetOrCreate(dynamicReference, () => "T" + map.Count),
            NamedReference namedReference => namedReference.Value,
            _ => throw new ArgumentOutOfRangeException(nameof(reference))
        };
    }
}