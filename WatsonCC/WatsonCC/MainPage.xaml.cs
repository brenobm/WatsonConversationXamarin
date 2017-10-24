using WatsonCC.Services;
using WatsonCC.ViewModel;
using Xamarin.Forms;

namespace WatsonCC
{
    public partial class MainPage : ContentPage
	{
        private MessageWatsonViewModel ViewModel => BindingContext as MessageWatsonViewModel;

        public MainPage()
		{
			InitializeComponent();

            var service = new WatsonServiceBroker();

            BindingContext = new MessageWatsonViewModel(service);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel?.LoadAsync();
        }
    }
}
