using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_employees")]
public class Employee
{
    //NIK
    [Key, Column("nik", TypeName = "nchar(5)")]
    public string NIK { get; set; }

    //First Name
    [Required, Column("first_name"), MaxLength(50)]
    public string FirstName { get; set; }

    //Last Name
    [Column("last_name"), MaxLength(50)]
    public string? LastName { get; set; }
    
    //Birth Date
    [Required, Column("birthdate")]
    public DateTime Birthdate { get; set; }

    //Gender
    [Required, Column("gender")]
    public GenderEnum Gender { get; set; }

    //Hiring Date
    [Required, Column("hiring_date")]
    public DateTime HiringDate { get; set; } = DateTime.Now;

    //Email
    [Required, Column("email"), MaxLength(50)]
    public string Email { get; set; }

    //Phone Number
    [Column("phone_number"), MaxLength(20)]
    public string? PhoneNumber { get; set; }
    
    //Manager Id
    [Column("manager_id", TypeName = "nchar(5)")]
    public string? ManagerId { get; set; }


    // Kardinalitas
    [JsonIgnore]
    public ICollection<Profiling>? Profilings { get; set; }

    [JsonIgnore]
    public Account? Account { get; set; }

    [JsonIgnore]
    public ICollection<Employee>? Employees { get; set; }

    [JsonIgnore]
    public Employee? Manager { get; set; }
}

public enum GenderEnum
{
    Male,
    Female
}

