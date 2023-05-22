using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EF.Models
{
    public class PartGroup
    {
        [Key]
        public int ID { get; set; }
        public string PartGroupName { get; set; }
        //FK
        public int SubPartGroupID { get; set; }
        //many to one relationship
        public PartSubGroup PartSubGroup { get; set; }
        public ICollection<ConfigurationInfo> ConfigurationInfos { get; set; }
       
    }
}
