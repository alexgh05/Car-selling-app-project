

namespace C4rzf0rs4le;

public partial class SearchPage : ContentPage
{
    string make;
    string model;
    string color;
    string pricemin;
    string pricemax;
    int yearmin;
    int yearmax;
    int hpmin;
    int hpmax;
    string mileage;
    List<Car> cars = new List<Car>();
    List<Car> filteredCars = new List<Car>();
    public SearchPage(List<Car> carz)
    {
        cars = carz;
        InitializeComponent();
    }

    private async void SearchButton_Clicked(object sender, EventArgs e)
    {
        // Initialize lists to store search criteria
        List<Func<Car, bool>> criteria = new List<Func<Car, bool>>();

        // Add criteria based on user input
        if (MakeEntry.Text != "Make" && !string.IsNullOrEmpty(MakeEntry.Text))
        {
            make = MakeEntry.Text;
            criteria.Add(car => car.make == make);
        }

        if (ModelEntry.Text != "Model" && !string.IsNullOrEmpty(ModelEntry.Text))
        {
            model = ModelEntry.Text;
            criteria.Add(car => car.model == model);
        }

        if (ColorEntry.Text != "Color" && !string.IsNullOrEmpty(ColorEntry.Text))
        {
            color = ColorEntry.Text;
            criteria.Add(car => car.color == color);
        }

        if (HPEntry.Text != "Minimum HP" && !string.IsNullOrEmpty(HPEntry.Text))
        {
            hpmin = Convert.ToInt32(HPEntry.Text);
            criteria.Add(car => Convert.ToInt32(car.hp) >= hpmin);
        }

        if (HPEntry2.Text != "Maximum HP" && !string.IsNullOrEmpty(HPEntry2.Text))
        {
            hpmax = Convert.ToInt32(HPEntry2.Text);
            criteria.Add(car => Convert.ToInt32(car.hp) <= hpmax);
        }

        if (MileageEntry.Text != "Mileage" && !string.IsNullOrEmpty(MileageEntry.Text))
        {
            mileage = MileageEntry.Text;
            criteria.Add(car => car.mileage == mileage);
        }

        if (PriceEntry.Text != "Minimum price" && !string.IsNullOrEmpty(PriceEntry.Text))
        {
            pricemin = PriceEntry.Text;
            criteria.Add(car => Convert.ToInt32(car.price) >= Convert.ToInt32(pricemin));
        }

        if (PriceEntry2.Text != "Maximum price" && !string.IsNullOrEmpty(PriceEntry2.Text))
        {
            pricemax = PriceEntry2.Text;
            criteria.Add(car => Convert.ToInt32(car.price) <= Convert.ToInt32(pricemax));
        }

        if (YearEntry.Text != "Starting year" && !string.IsNullOrEmpty(YearEntry.Text))
        {
            yearmin = Convert.ToInt32(YearEntry.Text);
            criteria.Add(car => car.make_year >= yearmin);
        }

        if (YearEntry2.Text != "Ending year" && !string.IsNullOrEmpty(YearEntry2.Text))
        {
            yearmax = Convert.ToInt32(YearEntry2.Text);
            criteria.Add(car => car.make_year <= yearmax);
        }
        //add items based on criteria to the list
        foreach(var item in criteria)
        {
            filteredCars = cars.Where(item).ToList();
        }

        await Navigation.PushAsync(new ListingPage(filteredCars));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}