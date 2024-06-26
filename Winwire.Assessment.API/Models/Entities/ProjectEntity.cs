using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Winwire.Assessment.API.Models.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int ProjectId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ProjectName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(1000)")]
        public string ProjectDescription { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string ProjectVersion { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string ProjectType { get; set; } = string.Empty;
    }
}
