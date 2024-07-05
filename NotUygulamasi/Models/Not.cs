using System;
using System.ComponentModel.DataAnnotations;

namespace NotUygulamasi.Models
{
    public class Not
    {
        [Key]
        public int NotId { get; set; }

        [Required]
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

        public DateTime? SonDuzenlemeTarihi { get; set; }

        public bool TamamlanmaDurumu { get; set; } = false;
    }
}
