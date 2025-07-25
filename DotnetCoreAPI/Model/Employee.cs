using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetCoreAPI.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(100,MinimumLength = 5)]
        public required string Name { get; set; }
        public required DateTime JoiningDate {  get; set; }
        public required double Salary {  get; set; }
        [DefaultValue(false)]
        [JsonIgnore]
        public bool IsDeleted {  get; set; }
        [AllowedValues("Male","Female",ErrorMessage = "Gender Value is not acceptable")]
        public string? Gender { get; set; }
        [Range(18,60,ErrorMessage ="Age must be between 18 and 60")]
        public int? Age { get; set; }
    }
}
