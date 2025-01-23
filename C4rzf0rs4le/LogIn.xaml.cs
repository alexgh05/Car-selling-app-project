

using C4rzf0rs4le.VideoUploadAPI;

namespace C4rzf0rs4le;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();
		initUser();
	}
	List<usersdatas> users= new List<usersdatas>();
    string username = "0";
	string phonenr = "0";
    private void initUser()
	{
		using(var context =new UsersContext())
		{
			var usrs= context.Users.ToList();
			foreach(var user in usrs)
			{
				var loginusr = new usersdatas
				{
					User_Email = user.User_Email,
					Username=user.Username,
					Userpasswd = user.Userpasswd,
					Userphone=user.Userphone
				};
				users.Add(loginusr);
			}
		}
	}
    private async void LogInButton_Clicked(object sender, EventArgs e)
    {
        bool found = false;
		
        foreach (usersdatas usr in users)
        {
			if (usr.User_Email == EmailEntryBox.Text && usr.Username == UsernameEntryBox.Text && usr.Userpasswd == PasswordEntryBox.Text)
			{
                phonenr = usr.Userphone;
                username = usr.Username;
				found = true;
				break;
			}
        }
		
        if (username!="0"&&phonenr!="0")
        {
			MessagingCenter.Send<LogIn,string>(this,"Ok",username+"|"+phonenr);
			await Navigation.PopAsync();
        }
        else
        {
			await DisplayAlert("Warning", "Wrong password, email, or username", "Ok");
		}
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}