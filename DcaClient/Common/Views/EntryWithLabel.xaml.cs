namespace DcaClient.Common.Views;

public partial class EntryWithLabel : ContentView
{
    public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(EntryWithLabel), string.Empty);
    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), typeof(string), typeof(EntryWithLabel), string.Empty, BindingMode.TwoWay, propertyChanged: OnEntryTextChanged);

    public string LabelText
    {
        get => (string)GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }

    private static void OnEntryTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var entryWithLabel = (EntryWithLabel)bindable;
        // Property changed implementation goes here
    }

    public EntryWithLabel()
    {
        InitializeComponent();
    }
}