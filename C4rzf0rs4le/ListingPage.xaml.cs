namespace C4rzf0rs4le;

public partial class ListingPage : ContentPage
{
	List<Car> cars;

    public ListingPage(List<Car> carsz)
	{
        cars = carsz;
        InitializeComponent();
        BindingContext = new ListingPageView(carsz);
    }

    private async void lview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Car selectedItem = e.SelectedItem as Car;
        await Navigation.PushAsync(new ListingDetails(selectedItem));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}