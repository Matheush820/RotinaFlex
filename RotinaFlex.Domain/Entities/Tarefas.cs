using RotinaFlex.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RotinaFlex.Domain.Entities
{
    public class Tarefas
    {
        // Construtor público (com ID gerado automaticamente)
        public Tarefas(Guid usuarioId, string titulo, string descricao, Categoria categoria, DateTime dataHora, Recorrencia recorrencia)
        {
            Id = Guid.NewGuid(); // Gera novo GUID
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            Categoria = categoria;
            DataHora = dataHora;
            Recorrencia = recorrencia;
        }

        // Construtor privado para o EF
        private Tarefas() { }

        [Key]
        public Guid Id { get; private set; }

        [ForeignKey("UsuarioId")]
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        public Guid UsuarioId { get; private set; }

        [Required(ErrorMessage = "O Título é obrigatório")]
        [MaxLength(180, ErrorMessage = "O Título precisa ter menos de 180 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MaxLength(500, ErrorMessage = "A Descrição precisa ter menos de 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Categoria é obrigatória")]
        public Categoria Categoria { get; set; } = Categoria.Outros;

        [Required(ErrorMessage = "A Data e Hora são obrigatórias")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "A Recorrência é obrigatória")]
        public Recorrencia Recorrencia { get; set; } = Recorrencia.Nenhuma;

    }
}
