using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ELearning.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPage : ContentPage
    {
        public ViewPage()
        {
            try
            {
                InitializeComponent();
            }

            catch (Exception ex) { }
        }        
    }
}