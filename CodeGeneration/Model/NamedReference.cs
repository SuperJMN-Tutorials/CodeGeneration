using CodeGeneration.Model.Classes;

namespace CodeGeneration.Model;

public class NamedReference : Reference
{
    public NamedReference(string value)
    {
        Value = value;
    }

    public string Value { get; }
}