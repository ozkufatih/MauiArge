namespace MauiApp1.Models
{
    // Basic model for the doughnut chart
    public class DoughnutChartModel
    {
        public string Label { get; set; }

        public double Value { get; set; }

        public DoughnutChartModel(string label, double value)
        {
            Label = label;
            Value = value;
        }
    }
}
