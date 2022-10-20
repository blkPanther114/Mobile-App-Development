using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddingCustomer : ContentPage
	{
        private List<string> imageList;
        private string selectedImage = "";

        public AddingCustomer ()
		{
			InitializeComponent ();

            imageList = new List<string>();

            imageList.Add("business.png");
            imageList.Add("composer.png");
            imageList.Add("doctor.png");
            imageList.Add("farmer.png");
            imageList.Add("patrol.png");
            imageList.Add("student.png");

            this.pckChangeImage.ItemsSource = imageList;
        }

        private void pckChangeImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker imgPicker = sender as Picker;

            int index = imgPicker.SelectedIndex;

            if (index >=0)
            {
                this.selectedImage = imageList[index];
                this.imgCustomerImage.Source = imageList[index];
            }
            else
            {
                this.imgCustomerImage.Source = null;
            }
        }

        private void btnAddCustomer_Clicked(object sender, EventArgs e)
        {
            string name = this.txtNameCustomer.Text;
            string address = string.Format("{0}'s address", this.txtNameCustomer.Text);
            
            Customer newCust = new Customer(name, address, Customers.IdCustomer++, selectedImage);
            MainPage.ActiveCustomerList.CustomerList.Add(newCust);
        }
    }
}