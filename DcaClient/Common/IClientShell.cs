namespace DcaClient.Common;

public interface IClientShell
{
    Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters);
    Task DisplayAlert(string title, string message, string cancel);
    Task DisplaySnackbar(string message);
}