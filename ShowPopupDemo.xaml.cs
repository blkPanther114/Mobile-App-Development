using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace PopupApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowPopupDemo : PopupPage
    {
		public ShowPopupDemo ()
		{
			InitializeComponent ();
		}
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}