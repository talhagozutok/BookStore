using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

// Positional record
public record BookDtoForUpdate : BookDtoForManipulation
{
    [Required]
    public int Id { get; set; }
};
