using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YL1CC3_HFT_2022231.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Interval
        {
            get
            {
                return (End - Start).Days;
            }
        }

        public int CarId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Car Car { get; set; }

        public Rent()
        {

        }
    }
}
