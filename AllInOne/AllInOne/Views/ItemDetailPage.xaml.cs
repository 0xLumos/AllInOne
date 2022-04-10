using AllInOne.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AllInOne.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

        }
    }
}