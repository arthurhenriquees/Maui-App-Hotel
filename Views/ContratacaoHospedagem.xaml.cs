using MauiAppHotel.Models;
namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {
        new Quarto { Nome = "Suíte Master", ValorAdultos = 225.5, ValorCriancas = 200.3},
        new Quarto { Nome = "Suíte Luxo", ValorAdultos = 200.5, ValorCriancas = 180.3},
        new Quarto { Nome = "Suíte Simples", ValorAdultos = 150.5, ValorCriancas = 120.3},
        new Quarto { Nome = "Suíte Econômica", ValorAdultos = 100.5, ValorCriancas = 80.3}
    };
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;

        dp_checkin.MinimumDate = DateTime.Now;
        dp_checkin.MaximumDate = DateTime.Now.AddMonths(3);

        dp_checkout.MinimumDate = DateTime.Now.AddDays(1);
        dp_checkout.MaximumDate = DateTime.Now.AddMonths(4);

    }

    private async void btn_sobre_Clicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Sobre));
    }

    private void dp_checkin_DateSelected(object? sender, DateChangedEventArgs e)
    {
        dp_checkout.MinimumDate =  e.NewDate?.AddDays(1);
    }

    private async void Button_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (dp_checkin.Date == null || dp_checkout.Date == null)
                {
                    await DisplayAlertAsync("Atenção", "Selecione as datas de check-in e check-out.", "OK");
                    return;
                }

                Hospedagem h = new()
                {
                    Qtd_adultos = Convert.ToInt32(stp_adultos.Value),
                    Qtd_criancas = Convert.ToInt32(stp_criancas.Value),
                    QuartoEscolhido = (Quarto)pck_quarto.SelectedItem,
                    DataCheckin = dp_checkin.Date.Value,
                    DataCheckout = dp_checkout.Date.Value,
                };

                await Navigation.PushAsync(new HospedagemContratada
                {
                    BindingContext = h
                });
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Erro detalhado", ex.ToString(), "OK");
            }
        }
}
