namespace C4rzf0rs4le;

public partial class ListingDetails : ContentPage
{

    public ListingDetails(Car selecteditem)
    {
        InitializeComponent();
        BindingContext = selecteditem;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    
}