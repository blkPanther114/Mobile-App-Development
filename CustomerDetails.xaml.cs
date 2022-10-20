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
    public partial class CustomerDetailsPage : ContentPage
    {
        //private Customer SelectedCustomer;
        private CustomerView view;

        public CustomerDetailsPage(Customer c)
        {
            InitializeComponent();

            //SelectedCustomer = c;
            view = new CustomerView();
            view.Load(c);

            //tblCustomerDetails.BindingContext = SelectedCustomer;
            tblCustomerDetails.BindingContext = view;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            App thisApp = Application.Current as App;
            // Copy the data from the viewmodel into the active customer
            view.Save(ref thisApp.ActiveCustomer);

            // Find the customer in the list
            int pos = MainPage.ActiveCustomerList.CustomerList.IndexOf(thisApp.ActiveCustomer);
            // Remove it
            MainPage.ActiveCustomerList.CustomerList.RemoveAt(pos);

            // Put it back again - to force a change
            MainPage.ActiveCustomerList.CustomerList.Insert(pos, thisApp.ActiveCustomer);

            await Navigation.PopAsync();
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}