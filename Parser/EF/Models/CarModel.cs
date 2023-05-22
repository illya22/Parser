using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EF.Models
{
    public class CarModel
    {
        [Key]
        public int ID { get; set; }
        public string ModelName { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public string Configuration { get; set; }
        //FK
        public int ConfigurationInfoID { get; set; }
        public ConfigurationInfo ConfigurationInfo { get; set; }


    }
}
