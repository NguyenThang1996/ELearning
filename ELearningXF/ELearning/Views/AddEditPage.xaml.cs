using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ELearning.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditPage : ContentPage
    {
        public AddEditPage()
        {
            try
            {
                InitializeComponent();
            }

            catch (Exception ex) { }
        }        
    }
}