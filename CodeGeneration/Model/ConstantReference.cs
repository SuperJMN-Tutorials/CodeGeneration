using CodeGeneration.Model.Classes;

namespace CodeGeneration.Model;

internal class ConstantReference : Reference
{
    public ConstantReference(int constant)
    {
        Constant = constant;
    }

    public int Constant { get; }
}