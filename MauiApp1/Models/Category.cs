using System.Collections.ObjectModel;

namespace MauiApp1.Models
{
    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Asset> Assets { get; set; }
    }
}
