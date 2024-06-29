namespace MauiApp1.Models
{
    public class PortfolioModel
    {
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set => _id = value == Guid.Empty ? Guid.NewGuid() : value;
        }

        public string Name { get; set; }

        public PortfolioModel()
        {
            _id = Guid.NewGuid();
        }
    }
}
