using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model.Models
{
    public class MarcaModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "Marca")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "País de Fundação")]
        public string PaisFundacao { get; set; }

        [Required]
        [Display(Name = "Nome do fundador")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        public string NomeFundador { get; set; }

        [Required]
        [Display(Name = "Dia da fundação")]
        [DataType(DataType.Date)]
        public DateTime DiaFundacao { get; set; }

        //[JsonIgnore]
        public List<CarroModel> Carros { get; set; }
    }
}
