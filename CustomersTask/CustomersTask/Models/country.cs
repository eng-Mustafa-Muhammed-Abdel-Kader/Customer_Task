using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersTask.Models
{
    public class country
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int countryId { get; set; }
        public string countryName { get; set; }

        public ICollection<government> Governments { get; set; }
    }
}
