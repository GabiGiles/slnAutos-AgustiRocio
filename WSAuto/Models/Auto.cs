using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WSAuto.Models
{
    [Table("Vehiculo")]
    public class Auto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [MaxLength(50)]
        public string Marca { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [MaxLength(50)]
        public string Modelo { get; set; }
        [Column(TypeName = "Varchar")]
        [MaxLength(50)]
        public string Color { get; set; }
        [Column(TypeName = "Money")]
        public decimal Precio { get; set; }
    }
}
