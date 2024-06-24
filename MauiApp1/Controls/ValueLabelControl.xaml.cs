namespace MauiApp1.Controls
{
    public partial class ValueLabelControl : ContentView
    {
        public static readonly BindableProperty ValueTextProperty = BindableProperty.Create(
            nameof(ValueText),
            typeof(string),
            typeof(ValueLabelControl),
            default(string),
            propertyChanged: OnValueTextChanged);

        public string ValueText
        {
            get => (string)GetValue(ValueTextProperty);
            set => SetValue(ValueTextProperty, value);
        }

        public ValueLabelControl()
        {
            InitializeComponent();
        }

        private static void OnValueTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ValueLabelControl)bindable;
            control.UpdateTextAndColor();
        }

        private void UpdateTextAndColor()
        {
            if (double.TryParse(ValueText, out double value))
            {
                ValueLabel.Text = ValueText;
                ValueLabel.TextColor = value >= 0 ? Color.FromArgb("#7ebc66") : Color.FromArgb("#ff0000");
            }
        }
    }
}
