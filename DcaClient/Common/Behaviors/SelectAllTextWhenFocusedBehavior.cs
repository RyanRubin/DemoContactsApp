namespace DcaClient.Common.Behaviors;

public class SelectAllTextOnFocusedBehavior : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry entry)
    {
        entry.Focused += Entry_Focused;
        base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        entry.Focused -= Entry_Focused;
        base.OnDetachingFrom(entry);
    }

    private async void Entry_Focused(object? sender, FocusEventArgs e)
    {
        if (sender is null)
        {
            return;
        }

        var entry = (Entry)sender;

        if (string.IsNullOrEmpty(entry.Text))
        {
            return;
        }

        await Task.Delay(100);
        entry.CursorPosition = 0;
        entry.SelectionLength = entry.Text.Length;
    }
}
