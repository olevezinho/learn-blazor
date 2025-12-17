namespace BlazorQuickGridEF.Entities;

public class Equipa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Pontos { get; set; }
    public int Jogos { get; set; }
    public int Vitorias { get; set; }
    public int Empates { get; set; }
    public int Derrotas { get; set; }
    public int SaldoGolos { get; set; }
    public int GolosPro { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool TemChampions { get; set; }
}