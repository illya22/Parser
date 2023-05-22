using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EF.Models
{
    public class PartSubGroup
    {
        [Key]
        public int ID { get; set; }
        public string PartGroupName { get; set; }
        //one to many relationship
        public ICollection<PartGroup> PartGroups { get; set; }

    }
}
