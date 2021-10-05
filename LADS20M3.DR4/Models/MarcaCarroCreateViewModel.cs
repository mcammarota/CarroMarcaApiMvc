using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace LADS20M3.DR4.Models
{
    public class MarcaCarroCreateViewModel
    {
        public int Id { get; set; }

        [Remote(action: "CheckModelo", controller: "Carro")]
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
        public int? MarcaId { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "Marca")]
        public string? Nome { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "País de Fundação")]
        public string? PaisFundacao { get; set; }

        [Display(Name = "Nome do fundador")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        public string? NomeFundador { get; set; }

        [Display(Name = "Dia da fundação")]
        [DataType(DataType.Date)]
        public DateTime? DiaFundacao { get; set; }
    }
}
