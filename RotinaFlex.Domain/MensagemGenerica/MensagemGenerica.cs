using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Domain.MensagemGenerica;
public class MensagemGenerica
{
    public bool Success { get; set; }
    public bool IsFailure => !Success;
    public string Mensagem { get; set; } = string.Empty;

    public MensagemGenerica(bool success, string mensagem)
    {
        Success = success;
        Mensagem = mensagem;
    }

    public static MensagemGenerica Result() => new MensagemGenerica(true, string.Empty);

    public override string ToString()
    {
        return Success ? "Sucesso" : Mensagem;
    }
}
