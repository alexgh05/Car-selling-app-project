

namespace C4rzf0rs4le;

public partial class Userslistings : ContentPage
{
   
	
    public Userslistings(List<Car> userscars)
	{
		InitializeComponent();
		BindingContext = new ListingPageView(userscars);
	}

    private async void Back_button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}