using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_tr_profilings")]
public class Profiling
{
    [Key, Column("id")]
    public int id { get; set; }

    [Required, Column("employee_nik", TypeName = "nchar(5)")]
    public string EmployeeNIK { get; set; }

    [Required, Column("education_id")]
    public int EducationId { get; set; }

    // Relasi & Kardinalitas
    [JsonIgnore]
    [ForeignKey(nameof(EducationId))]
    public Education? Education { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(EmployeeNIK))]
    public Employee? Employee { get; set; }
}
