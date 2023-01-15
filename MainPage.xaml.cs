namespace Cosmetice;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void btnNnav_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ListEntryPage());
	}
}

