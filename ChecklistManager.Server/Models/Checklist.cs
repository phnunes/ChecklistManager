using System.ComponentModel.DataAnnotations.Schema;

namespace ChecklistManager.Server.Models
{
    public class Checklist
    {
        public int ChecklistID { get; set; }
        public bool Tires { get; set; }
        public bool Lights { get; set; }
        public bool Breaks { get; set; }
        public bool Engine { get; set; }
        public bool Electric { get; set; }
        public string? Observation { get; set; }

        public int VehicleID { get; set; }

        [ForeignKey("VehicleID")]
        public virtual Vehicle? Vehicle { get; set; }
    }
}
