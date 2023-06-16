using CommunityToolkit.Maui.Alerts;

namespace DcaClient.Common;

public class ClientShell : IClientShell
{
    public async Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(state, parameters);
    }

    public async Task DisplayAlert(string title, string message, string cancel)
    {
        await Shell.Current.CurrentPage.DisplayAlert(title, message, cancel);
    }

    public async Task DisplaySnackbar(string message)
    {
        await Shell.Current.CurrentPage.DisplaySnackbar(message);
    }
}
