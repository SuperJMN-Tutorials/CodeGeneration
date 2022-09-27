using CodeGeneration.Model.Classes;

namespace CodeGeneration.Model;

public class NamedReference : Reference
{
    public string Value { get; }

    public NamedReference(string value)
    {
        Value = value;
    }
}