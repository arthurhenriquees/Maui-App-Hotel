
namespace MauiAppHotel;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.Sobre), typeof(Views.Sobre));
    }
}
