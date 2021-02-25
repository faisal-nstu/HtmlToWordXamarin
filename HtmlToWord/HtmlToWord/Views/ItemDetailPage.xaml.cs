using HtmlToWord.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HtmlToWord.Views
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