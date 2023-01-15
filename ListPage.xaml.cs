namespace Cosmetice;

using Bumptech.Glide.Load.Resource.Bitmap;
using Cosmetice.Models;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Cosmetice)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveCosmeticeAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Cosmetice)BindingContext;
        await App.Database.DeleteCosmeticeAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((Cosmetice)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
}