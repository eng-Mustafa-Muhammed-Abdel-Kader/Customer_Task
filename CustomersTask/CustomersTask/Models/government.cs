using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersTask.Models
{
    public class government
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int governmentId { get; set; }
        public string governmentName { get; set; }
        public int countryId { get; set; }

        [ForeignKey(nameof(countryId))]
        public country Country { get; set; }

        public ICollection<customer> Customers { get; set; }
    }
}
