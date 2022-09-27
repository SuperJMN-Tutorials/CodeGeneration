namespace CodeGeneration.Model.Classes;

public class NamedReference : Reference
{
    public string Value { get; }

    public NamedReference(string value)
    {
        Value = value;
    }
}