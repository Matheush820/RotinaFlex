using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RotinaFlex.Domain.Entities
{
    public class Usuario
    {
        // Construtor público sem ID (gera automaticamente)
        public Usuario(string nome, string email, string senha, bool preferenciasNotificacoes)
        {
            Id = Guid.NewGuid(); // ID gerado automaticamente aqui
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCadastro = DateTime.Now;
            PreferenciasNotificacoes = preferenciasNotificacoes;
            Tarefas = new List<Tarefas>();
            Recompensas = new List<Recompensa>();
        }

        // Construtor privado para o Entity Framework
        private Usuario() { }

        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome precisa ter menos de 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email não é válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; } = string.Empty;

        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;

        public bool PreferenciasNotificacoes { get; set; } = true;

        public ICollection<Tarefas> Tarefas { get; set; } = new List<Tarefas>();

        public ICollection<Recompensa> Recompensas { get; set; } = new List<Recompensa>();
    }
}
