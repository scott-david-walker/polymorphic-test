using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$t")]
[JsonDerivedType(typeof(Derived), nameof(Derived))]
public class Derived
    : BaseType
{
    public int SomeData { get; set; }
}
        
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$t")]
[JsonDerivedType(typeof(Derived), nameof(Derived))]

public abstract class BaseType
{
    public Guid Id { get; set; }
}

public class SomeEntity
{ 
    [Key]
    public Guid Id { get; set; } 
    [Column(TypeName = "jsonb")]
    public BaseType BaseType { get; set; }
}