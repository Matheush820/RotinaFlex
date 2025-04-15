using RotinaFlex.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Recompensa
{
    public Recompensa(Guid usuarioId, string nome, int pontosNecessarios, bool resgatado = false)
    {
        Id = Guid.NewGuid(); // Gera o ID aqui apenas quando você quiser criar uma nova recompensa
        UsuarioId = usuarioId;
        Nome = nome;
        PontosNecessarios = pontosNecessarios;
        Resgatado = resgatado;
    }

    // Construtor privado para o EF
    private Recompensa() { }

    [Key]
    public Guid Id { get; private set; }

    [Required]
    public Guid UsuarioId { get; private set; }

    [Required]
    [MaxLength(100, ErrorMessage = "Nome precisa ter menos de 100 caracteres")]
    public string Nome { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Os pontos necessários devem ser um número positivo")]
    public int PontosNecessarios { get; set; }

    public bool Resgatado { get; set; } = false;

    [ForeignKey("UsuarioId")]
    [JsonIgnore]
    public virtual Usuario Usuario { get; private set; }
}
