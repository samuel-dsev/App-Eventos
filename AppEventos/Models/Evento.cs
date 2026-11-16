using System.Globalization;

namespace AppEventos.Models;

public sealed class Evento
{
    public string Nome { get; set; } = "";
    public DateTime? DataInicio { get; set; } = DateTime.Today;
    public DateTime? DataTermino { get; set; } = DateTime.Today;
    public string Local { get; set; } = "";

    // Entry fornece texto, inclusive enquanto a digitação ainda está incompleta.
    public string ParticipantesInformados { get; set; } = "";
    public string CustoInformado { get; set; } = "";
    public int NumeroParticipantes { get; private set; }
    public decimal CustoPorParticipante { get; private set; }

    public TimeSpan Duracao => DataInicio is DateTime inicio && DataTermino is DateTime termino
        ? termino.Date - inicio.Date
        : TimeSpan.Zero;

    public string DuracaoFormatada => Duracao.Days == 1 ? "1 dia" : $"{Duracao.Days} dias";
    public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;

    public string? Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            return "Informe o nome do evento.";

        if (string.IsNullOrWhiteSpace(Local))
            return "Informe o local do evento.";

        if (DataInicio is null || DataTermino is null)
            return "Informe as datas de início e de término.";

        if (Duracao < TimeSpan.Zero)
            return "A data de término deve ser igual ou posterior à data de início.";

        if (!int.TryParse(ParticipantesInformados, out int participantes) || participantes <= 0)
            return "Informe um número inteiro de participantes maior que zero.";

        string custoDigitado = CustoInformado?.Trim().Replace(',', '.') ?? "";
        int separador = custoDigitado.IndexOf('.');
        if (!decimal.TryParse(custoDigitado, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal custo)
            || (separador >= 0 && custoDigitado.Length - separador - 1 > 2))
            return "Informe um custo válido em reais, com até duas casas decimais. Para um evento gratuito, use 0.";

        try
        {
            _ = participantes * custo;
        }
        catch (OverflowException)
        {
            return "O custo total ultrapassa o limite de cálculo. Revise os valores informados.";
        }

        NumeroParticipantes = participantes;
        CustoPorParticipante = custo;
        return null;
    }
}
