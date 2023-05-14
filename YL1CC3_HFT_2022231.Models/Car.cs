using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YL1CC3_HFT_2022231.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(10)]
        public string Model { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public virtual Brand Brand { get; set; }

        public int BrandId { get; set; }
        [NotMapped]
        public virtual ICollection<Rent> Rents { get; set; }
        public Car()
        {

        }
    }
}
