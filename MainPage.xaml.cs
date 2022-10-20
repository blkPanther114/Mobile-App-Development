using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerApp
{
    public partial class MainPage : ContentPage
    {
        public static Customers ActiveCustomerList;

        public MainPage()
        {
            InitializeComponent();

            // Create a customer list to work with
            ActiveCustomerList = Customers.MakeTestCustomers();

            this.lstCustomerList.ItemsSource = ActiveCustomerList.CustomerList;
        }

        private async void lstCustomerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            
            Customer selectedCustomer = e.SelectedItem as Customer;
            
            //keep track the selected item and store it at App class
            App thisApp = Application.Current as App;
            thisApp.ActiveCustomer = selectedCustomer;

            await Navigation.PushAsync(new CustomerDetailsPage(selectedCustomer));

            ((ListView)sender).SelectedItem = null; // clears the 'selected' background
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddingCustomer());
        }

        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            string searchedName = this.txtSearchBox.Text;

            var selectedCustomers = from Customer cust in ActiveCustomerList.CustomerList
                                      where cust.Name.Contains(searchedName)
                                      select cust;

            this.lstCustomerList.ItemsSource = selectedCustomers;
        }

        public List<Customer> FindCustomer(string custName) {
            List<Customer> result = new List<Customer>();

            foreach (Customer cust in ActiveCustomerList.CustomerList)
            {
                if (cust.Name.Contains(custName))
                {
                    result.Add(cust);
                }
            }
            return result;
        }

        private void lstCustomerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
