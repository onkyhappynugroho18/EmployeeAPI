using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_universities")]
public class University
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(100)]
    public string Name { get; set; }

    // Kardinalitas
    [JsonIgnore]
    public ICollection<Education>? Educations { get; set;}
}
