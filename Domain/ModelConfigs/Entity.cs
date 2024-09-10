using System.ComponentModel.DataAnnotations;

namespace Domain.ModelConfigs;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}
