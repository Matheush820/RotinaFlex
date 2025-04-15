using RotinaFlex.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Relatorio
{
    public Relatorio(Guid usuarioId, Periodo periodo, int tarefasConcluidas, int pontosAcumuldos)
    {
        Id = Guid.NewGuid(); // só é gerado quando o dev criar na mão
        UsuarioId = usuarioId;
        Periodo = periodo;
        TarefasConcluidas = tarefasConcluidas;
        PontosAcumuldos = pontosAcumuldos;
    }

    // Construtor privado para o EF
    private Relatorio() { }

    [Key]
    public Guid Id { get; private set; }

    [Required]
    [ForeignKey("Usuario")]
    public Guid UsuarioId { get; private set; }

    [Required]
    public Periodo Periodo { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "As Tarefas devem ser um número positivo")]
    public int TarefasConcluidas { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Os Pontos devem ser um número positivo")]
    public int PontosAcumuldos { get; set; }
}
