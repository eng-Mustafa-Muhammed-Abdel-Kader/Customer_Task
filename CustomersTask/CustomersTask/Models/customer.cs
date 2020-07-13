using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersTask.Models
{
    public class customer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string Gender { get; set; }
        public string stateMarried { get; set; }
        public string street { get; set; }
        public int governmentId { get; set; }

        [ForeignKey(nameof(governmentId))]
        public government Government { get; set; }
    }
}
