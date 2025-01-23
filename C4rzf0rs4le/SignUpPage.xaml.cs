
using C4rzf0rs4le.VideoUploadAPI;
using System.Text.RegularExpressions;

namespace C4rzf0rs4le;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
        InitializeComponent();
	}

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Signupbutton_Clicked(object sender, EventArgs e)
    {
       
        using (var context = new UsersContext())
        {
            try
            {
                var newUser = new usersdatas
                {
                    Username = Entryusername.Text,
                    User_Email = EntryEmail.Text,
                    Userpasswd = EnterPasswd.Text,
                    Userphone=Enterphone.Text
                   
                };
                foreach(usersdatas usr in context.Users)
                {
                    if(usr.Username==newUser.Username)
                    {
                        await DisplayAlert("Warning", "Username already exists", "Ok");
                        
                        return;
                    }
                    if(usr.User_Email==newUser.User_Email)
                    {
                        await DisplayAlert("Warning", "Email already exists", "Ok");
                       
                        return;
                    }
                    if (usr.Userphone == newUser.Userphone)
                    {
                        await DisplayAlert("Warning", "Phone number already exists", "Ok");
                        return;
                    }
                    
                }
                // Check if all fields are completed before adding the user
                if (Entryusername.Text != null && EnterPasswd.Text != null && EntryEmail.Text != null &&Enterphone.Text!=null)
                {
                    if(Entryusername.Text.Length < 3)
                    {
                        await DisplayAlert("Warning", "Username must be at least 3 characters long", "Ok");
                        return;
                    }
                    if (EnterPasswd.Text.Length < 6)
                    {
                        await DisplayAlert("Warning", "Password must be at least 6 characters long", "Ok");
                        return;
                    }
                    if (Enterphone.Text.Length != 10)
                    {
                        await DisplayAlert("Warning", "Phone number must be 10 characters long", "Ok");
                        return;
                    }
                    if (!Regex.IsMatch(EntryEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    {
                        await DisplayAlert("Warning", "Invalid email", "Ok");
                        return;
                    }
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    await DisplayAlert("Success", "User added successfully!", "OK");
                }
                else
                {
                    await DisplayAlert("Fields not completed", "Please complete all the fields", "Ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
            }
        }

        // Navigate back after completing the operation
        await Navigation.PopAsync();
    }

}