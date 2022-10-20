using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NavTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        private async void btnNext_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Page2());
            Page2 anotherpage = new Page2();
            anotherpage.person.RecievedFirst = this.txtFirstName.Text;
            anotherpage.person.RecievedLast = this.txtLastName.Text;
            anotherpage.DisplayData();

            await Navigation.PushModalAsync(anotherpage);
        }
    }
}
