using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.EF.Models;

namespace Parser.EF.Models
{
    public class ConfigurationInfo
    {
        [Key]
        public int ID { get; set; }
        public string Engine1 { get; set; }
        public string Body { get; set; }
        public string Grade { get; set; }
        public string ATM_MTM { get; set; }
        public string GearShiftType { get; set; }
        public string CAB { get; set; }
        public string TransmissionModel { get; set; }
        public string LoadingCapacity { get; set; }
        //FK 
        public int PartGroupID { get; set; }
        // many to one relationship
        public PartGroup PartGroup { get; set; }
        public ICollection<CarModel> CarModels { get; set; }
        
    }
}
