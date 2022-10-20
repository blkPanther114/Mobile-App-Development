using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavTest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
        public PersonInfo person;

        public Page2 ()
		{
			InitializeComponent ();
            person = new PersonInfo();
        }

        public void DisplayData()
        {
            this.lblFirst.Text = person.RecievedFirst;
            this.lblLast.Text = person.RecievedLast;
        }

        private async void btnPrev_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            await Navigation.PopModalAsync();
        }
    }
}