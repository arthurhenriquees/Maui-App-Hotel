namespace MauiAppHotel.Models;

public class Hospedagem
{
    public Quarto QuartoEscolhido { get; set; } = null!;
    public int Qtd_adultos { get; set; }
    public int Qtd_criancas { get; set; }

    public DateTime DataCheckin { get; set; }
    public DateTime DataCheckout { get; set; }

    public int Estadia
    {
        get => DataCheckout.Subtract(DataCheckin).Days;
    }

    public double TotalHospedagem
    {
        get
            {
                double total_adultos = Qtd_adultos * QuartoEscolhido.ValorAdultos;
                double total_criancas = Qtd_criancas * QuartoEscolhido.ValorCriancas;

                return (total_adultos + total_criancas) * Estadia;
            }
    }
}
