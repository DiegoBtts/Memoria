using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Memoria.Models
{
    public class GameImage
    {
        [Key]
        public int IdImage { get; set; }

        [DisplayName("Nombre del Juego")]
        public string Name { get; set; }
        public byte[] Portada { get; set; }
        [DisplayName("Imagen 1")]
        public byte[] Image0 { get; set; }
        [DisplayName("Imagen 2")]
        public byte[] Image1 { get; set; }
        [DisplayName("Imagen 3")]
        public byte[] Image2 { get; set; }
        [DisplayName("Imagen 4")]
        public byte[] Image3 { get; set; }
        [DisplayName("Imagen 5")]
        public byte[] Image4 { get; set; }
        [DisplayName("Imagen 6")]
        public byte[] Image5 { get; set; }
        [DisplayName("Imagen 7")]
        public byte[] Image6 { get; set; }
        [DisplayName("Imagen 8")]
        public byte[] Image7 { get; set; }
        [DisplayName("Imagen 9")]
        public byte[] Image8 { get; set; }
        [DisplayName("Imagen 10")]
        public byte[] Image9 { get; set; }
    }
}