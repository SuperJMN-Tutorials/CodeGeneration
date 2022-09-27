namespace CodeGeneration.Model.Classes;

public record Code(Reference Destination, Reference Left, Reference? Right, char Operator);