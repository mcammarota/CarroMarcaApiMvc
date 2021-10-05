using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model.Models
{
    public class CarroModel
    {
        public int Id { get; set; }
        
        [Remote(action: "CheckModelo", controller: "Carro", AdditionalFields = nameof(Id))]
        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int Portas { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "Câmbio")]
        public string Cambio { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "Direção")]
        public string Direcao { get; set; }

        [Display(Name = "Dia de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime Lancamento { get; set; }


        public int MarcaId { get; set; }
        public MarcaModel Marca { get; set; }
    }
}
