using CodeGeneration.Model.Classes;

namespace CodeGeneration.Model;

public record Code(Reference Destination, Reference Left, Reference? Right, char Operator);