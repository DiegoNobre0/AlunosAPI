using _AlunosAPI.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _AlunosAPI.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Coloque um nome menor")]
        public string? Nome { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Formato do E-mail errado.")]
        [StringLength(80, ErrorMessage = "Adicione um E-mail menor")]
        public string? Email { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        [ValidationCPF]
        public string? CPF { get; set; }
    }
}
