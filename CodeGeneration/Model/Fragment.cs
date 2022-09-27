using CodeGeneration.Model.Classes;

namespace CodeGeneration.Model;

public class Fragment
{
    public Fragment(Code code) : this(new Placeholder(), code)
    {
    }

    public Fragment(Reference reference, Code code) : this(reference, new[] {code})
    {
    }

    public Fragment(Reference reference, IEnumerable<Code> codes)
    {
        Reference = reference;
        Codes = codes;
    }

    public Reference Reference { get; }
    public IEnumerable<Code> Codes { get; }
}