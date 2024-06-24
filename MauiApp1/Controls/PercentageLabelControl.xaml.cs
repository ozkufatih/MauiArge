
namespace MauiApp1.Controls
{
    public partial class PercentageLabelControl : ContentView
    {
        public static readonly BindableProperty PercentageTextProperty = BindableProperty.Create(
            nameof(PercentageText),
            typeof(string),
            typeof(PercentageLabelControl),
            default(string),
            propertyChanged: OnPercentageTextChanged);

        public string PercentageText
        {
            get => (string)GetValue(PercentageTextProperty);
            set => SetValue(PercentageTextProperty, value);
        }

        public PercentageLabelControl()
        {
            InitializeComponent();
        }

        private static void OnPercentageTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PercentageLabelControl)bindable;
            control.UpdateTextAndColor();
        }

        private void UpdateTextAndColor()
        {
            if (double.TryParse(PercentageText.Replace("%", ""), out double percentage))
            {
                string text = $"{Math.Abs(percentage)}%";
                PercentageLabel.Text = text;
                PercentageLabel.TextColor = percentage >= 0 ? Color.FromArgb("#7ebc66") : Color.FromArgb("#ff0000");
            }
        }
    }
}