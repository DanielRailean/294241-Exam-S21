using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Player
    {
        
        //could have used composite keys with name and shirt number -> OnModelCreating
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name{get; set; }
        [Range(1,99)]
        public int ShirtNumber{get; set; }
        public decimal Salary{get; set; }
        public int GoalsThisSeason{get; set; }
        [Required]
        public string Position{get; set; }
        [ForeignKey("TeamName")]
        public string TeamRefTeamName { get; set; }
    }
}