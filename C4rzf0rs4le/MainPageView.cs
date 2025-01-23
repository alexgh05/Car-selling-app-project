using C4rzf0rs4le.VideoUploadAPI;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace C4rzf0rs4le
{
    public class MainPageView : BindableObject
    {
        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged();
            }
        }

        public MainPageView()
        {
            Cars = new ObservableCollection<Car>();
            InitializeCars();
        }

        private async void InitializeCars()
        {
            try
            {
                string apiUrl = "http://localhost:5134/api/VideoListings/getvid";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var listings = JsonConvert.DeserializeObject<List<userslisting>>(content);

                    foreach (var listing in listings)
                    {
                        var car = new Car
                        {
                            username = listing.Username,
                            phoneNumber = listing.Phone_number,
                            make = listing.Make,
                            model = listing.Model,
                            color = listing.Color,
                            make_year = listing.Make_year,
                            hp = listing.Horsepower,
                            mileage = listing.Mileage,
                            video_director = listing.Video_path,
                            price=listing.Price
                        };

                        Cars.Add(car);
                    }

                    Console.WriteLine($"Loaded {Cars.Count} cars."); // Log the count of cars loaded
                }
                else
                {
                    Console.WriteLine("API Error: Unable to fetch video listings.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }
    }
}
