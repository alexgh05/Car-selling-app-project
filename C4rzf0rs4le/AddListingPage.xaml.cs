using C4rzf0rs4le.VideoUploadAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace C4rzf0rs4le
{
    public partial class AddListingPage : ContentPage
    {
        string make;
        string model;
        string km;
        int an;
        string videopath;
        string username;
        string phone_number;
        string color;
        string hp;
        string price;
        public AddListingPage(string usr,string phonenr)
        {
            InitializeComponent();
            this.username = usr;
            this.phone_number = phonenr;
        }

        private async void Addvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Pick a video",
                    FileTypes = FilePickerFileType.Videos
                });

                if (result != null)
                {
                    videopath = result.FullPath;
                    await DisplayAlert("Video Selected", "Video path: " + videopath, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred while picking the video: " + ex.Message, "OK");
            }
        }

        private async void AddListingButton_Clicked(object sender, EventArgs e)
        {
            make = EntryMarca.Text;
            model = EntryModel.Text;
            an = Convert.ToInt32(EntryAn.Text);
            km = EntryKM.Text;
            hp = EntryHP.Text;
            color = EntryColor.Text;
            price = EntryPrice.Text;
            var newListing = new userslisting
            {
                Username = username,
                Phone_number = phone_number,
                Make = make,
                Model = model,
                Color = color,
                Make_year = an,
                Horsepower = hp,
                Mileage = km,
                Video_path = videopath,
                Price = price
            };
            
            var apiUrl = "http://localhost:5134/api/VideoListings/upload"; // Replace with your actual API URL
            using (var client = new HttpClient())
            {
                try
                {
                    // Create a MultipartFormDataContent object
                    var multipartContent = new MultipartFormDataContent();

                    // Add the video file content
                    if (File.Exists(videopath))
                    {
                        var videoContent = new StreamContent(File.OpenRead(videopath));
                        videoContent.Headers.ContentType = MediaTypeHeaderValue.Parse("video/mp4");
                        multipartContent.Add(videoContent, "file", Path.GetFileName(videopath));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Video file not found.", "OK");
                        return;
                    }

                    // Add each field individually to the form data
                    multipartContent.Add(new StringContent(newListing.Username), "Username");
                    multipartContent.Add(new StringContent(newListing.Phone_number), "Phone_number");
                    multipartContent.Add(new StringContent(newListing.Make), "Make");
                    multipartContent.Add(new StringContent(newListing.Model), "Model");
                    multipartContent.Add(new StringContent(newListing.Color), "Color");
                    multipartContent.Add(new StringContent(newListing.Make_year.ToString()), "Make_year");
                    multipartContent.Add(new StringContent(newListing.Horsepower), "Horsepower");
                    multipartContent.Add(new StringContent(newListing.Mileage), "Mileage");
                    multipartContent.Add(new StringContent(newListing.Video_path), "Video_path");
                    multipartContent.Add(new StringContent(newListing.Price), "Price");

                    // Send the request
                    var response = await client.PostAsync(apiUrl, multipartContent);
                    if (response.IsSuccessStatusCode)
                    {


                        await DisplayAlert("Success", "Listing added successfully!", "OK");
                      
                        await Navigation.PopAsync();
                        MessagingCenter.Send<AddListingPage, Car>(this, "AddListing", new Car
                        {
                            username = newListing.Username,
                            phoneNumber = newListing.Phone_number,
                            make = newListing.Make,
                            model = newListing.Model,
                            color = newListing.Color,
                            make_year = newListing.Make_year,
                            hp = newListing.Horsepower,
                            mileage = newListing.Mileage,
                            video_director = newListing.Video_path,
                            price = newListing.Price
                        });
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        await DisplayAlert("Error", $"Failed to add listing. Server response: {responseContent}", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
