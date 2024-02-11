using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIEMS.Models
{
    [Table("DeptMaster")]
    public class DeptMaster
    {
        [Key]
        public int DeptCode { get; set; }

        public string? DeptName { get; set; } = null!;

        private ICollection<EmpProfile>? empProfiles;

        // Ignoring EmpProfiles property for serialization
        [JsonIgnore]
        public virtual ICollection<EmpProfile>? EmpProfiles
        {
            get { return empProfiles; }
            set { empProfiles = value; }
        }

        // Custom getter to display "ok" if EmpProfiles is null
        public string EmpProfilesStatus
        {
            get { return EmpProfiles == null ? "ok" : "not null"; }
        }
    }
}
