namespace DcaClient.Common;

public class Navigator : INavigator
{
    private readonly Shell shell;

    public Navigator(Shell shell)
    {
        this.shell = shell;
    }

    public async Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters)
    {
        await shell.GoToAsync(state, parameters);
    }
}
