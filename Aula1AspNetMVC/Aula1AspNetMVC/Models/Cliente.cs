 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1AspNetMVC.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150,ErrorMessage ="Máximo de caracteres excedido")]
        [MinLength(2,ErrorMessage ="Mínimo de 2 caracteres")]
        [DisplayName("Nome do Cliente")]
        [Required(ErrorMessage ="Preencher o campo nome")]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de caracteres excedido")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        [DisplayName("Sobrenome do Cliente")]
        [Required(ErrorMessage = "Preencher o campo sobrenome")]
        public string Sobrenome { get; set; }
        [ScaffoldColumn(false)] // ignora essa coluna no processo de criação do scaffold
        public DateTime DataCadastro { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de caracteres excedido")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Preencher o campo E-mail")]
        [EmailAddress(ErrorMessage ="E-mail em formato inválido")]
        public string Email { get; set; }
    }
}