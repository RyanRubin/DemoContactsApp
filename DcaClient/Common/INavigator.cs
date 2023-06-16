namespace DcaClient.Common;

public interface INavigator
{
    Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters);
}