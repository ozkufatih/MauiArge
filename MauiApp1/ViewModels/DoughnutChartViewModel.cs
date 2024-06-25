using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using MauiApp1.Models;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModels
{
    public class DoughnutChartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ISeries> _series;
        public ObservableCollection<ISeries> Series
        {
            get => _series;
            set
            {
                _series = value;
                OnPropertyChanged();
            }
        }

        public DoughnutChartViewModel()
        {
            Series = new ObservableCollection<ISeries>
            {
                CreatePieSeries(new DoughnutChartModel("Foreign Currency", 1.7)),
                CreatePieSeries(new DoughnutChartModel("Turkish Lira", 27.6)),
                CreatePieSeries(new DoughnutChartModel("Crypto Currency", 70.7))
            };
        }

        public void AddValue(DoughnutChartModel model)
        {
            Series.Add(CreatePieSeries(model));
        }

        private PieSeries<double> CreatePieSeries(DoughnutChartModel model)
        {

            return new PieSeries<double>
            {
                Values = [model.Value],
                MaxRadialColumnWidth = 25,
                InnerRadius = 60,
                Name = model.Label,
                Stroke = new SolidColorPaint(SKColor.Parse("#001c3d"))
                {
                    StrokeThickness = 2
                },
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
