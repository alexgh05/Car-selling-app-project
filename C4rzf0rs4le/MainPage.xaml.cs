namespace C4rzf0rs4le
{
    public partial class MainPage : ContentPage
    {
        string username { get; set; }
        string phonenr { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageView(); // Set the BindingContext to an instance of MainPageView
            MessagingCenter.Subscribe<LogIn, string>(this, "Ok", (sender, usrname_phone) =>
            {
                string[] usr=usrname_phone.Split('|');
                this.username = usr[0];
                this.phonenr = usr[1];
                LogIn.IsVisible = false;
                SignUp.IsVisible = false;
                Listsale.IsVisible = true;
                Listsale.IsEnabled = true;
                Userlistings.IsVisible = true;
                Userlistings.IsEnabled = true;
            
            });
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void LogIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());
        }

        private async void Search_Clicked(object sender, EventArgs e)
        {
            List<Car> selectedCars = new List<Car>();
            selectedCars = lview.ItemsSource.Cast<Car>().ToList();
            await Navigation.PushAsync(new SearchPage(selectedCars));
        }

        private async void Listsale_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddListingPage(username, phonenr));
            MessagingCenter.Subscribe<AddListingPage, Car>(this, "AddListing", (sender, newCar) =>
            {
                BindingContext = new MainPageView();
            });
        }

        private async void lview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Car selectedItem = e.SelectedItem as Car;
            await Navigation.PushAsync(new ListingDetails(selectedItem));
        }

        private async void Userlistings_Clicked(object sender, EventArgs e)
        {
            List<Car> selectedCars = new List<Car>();
            List<Car> usersCars = new List<Car>();
            selectedCars = lview.ItemsSource.Cast<Car>().ToList();
            foreach (Car car in selectedCars)
            {
                if (car.username == this.username)
                {
                    usersCars.Add(car);
                }
            }
            await Navigation.PushAsync(new Userslistings(usersCars));
        }
    }
}
