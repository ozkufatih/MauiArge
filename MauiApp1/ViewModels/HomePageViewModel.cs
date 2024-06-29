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
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private string _selectedPortfolio;
        public string SelectedPortfolio
        {
            get => _selectedPortfolio;
            set
            {
                if (_selectedPortfolio != value)
                {
                    _selectedPortfolio = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<PortfolioModel> Portfolios { get; set; }

        public event EventHandler<DoughnutChartModel> SeriesClicked;

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

        public HomePageViewModel()
        {
            Series = new ObservableCollection<ISeries>
            {
                CreatePieSeries(new DoughnutChartModel("Foreign Currency", 1.7)),
                CreatePieSeries(new DoughnutChartModel("Turkish Lira", 27.6)),
                CreatePieSeries(new DoughnutChartModel("Crypto Currency", 70.7))
            };

            Portfolios = new ObservableCollection<PortfolioModel>
            {
                new PortfolioModel { Name = "Portfolyom LA GARDASIM BI BAH LA" },
                new PortfolioModel { Name = "numero uno" }
            };
            SelectedPortfolio = Portfolios.FirstOrDefault()?.Name;
        }

        public void AddValue(DoughnutChartModel model)
        {
            Series.Add(CreatePieSeries(model));
        }

        private PieSeries<double> CreatePieSeries(DoughnutChartModel model)
        {
            var series = new PieSeries<double>
            {
                Values = new double[] { model.Value },
                MaxRadialColumnWidth = 25,
                InnerRadius = 60,
                Name = model.Label,
                Stroke = new SolidColorPaint(SKColor.Parse("#001c3d"))
                {
                    StrokeThickness = 2
                },
                IsHoverable = false,
            };

            series.DataPointerDown += (sender, args) =>
            {
                SeriesClicked?.Invoke(this, model);
            };

            return series;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
