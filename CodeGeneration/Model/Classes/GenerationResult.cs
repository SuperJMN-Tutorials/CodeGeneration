namespace CodeGeneration.Model.Classes;

public class GenerationResult
{
    public GenerationResult()
    {
    }

    public GenerationResult(Reference reference, IEnumerable<Code> codes)
    {
        Reference = reference;
        Codes = codes;
    }

    public Reference Reference { get; }
    public IEnumerable<Code> Codes { get; }
}