using Bumptech.Glide.Load.Resource.Bitmap;
using Cosmetice.Models;

namespace Cosmetice;

public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}
    _database = new SQLiteAsyncConnection(dbPath);
    _database.CreateTableAsync<Cosmetice>().Wait();
    _database.CreateTableAsync<Product>().Wait();
    _database.CreateTableAsync<ListProduct>().Wait();
}
public Task<List<Cosmetice> GetCosmeticeAsync()
{
    return _database.Table<Cosmetice>().ToListAsync();
}
public Task<Cosmetice> GetCosmeticeAsync(int id)
{
    return _database.Table<Retete>()
    .Where(i => i.ID == id)
   .FirstOrDefaultAsync();
}
public Task<int> SaveCosmeticeAsync(Cosmetice slist)
{
    if (slist.ID != 0)
    {
        return _database.UpdateAsync(slist);
    }
    else
    {
        return _database.InsertAsync(slist);
    }
}
public Task<int> DeleteCosmeticeAsync(Cosmetice slist)
{
    return _database.DeleteAsync(slist);
}
public Task<int> SaveProductAsync(Product product)
{
    if (product.ID != 0)
    {
        return _database.UpdateAsync(product);
    }
    else
    {
        return _database.InsertAsync(product);
    }
}
public Task<int> DeleteProductAsync(Product product)
{
    return _database.DeleteAsync(product);
}
public Task<List<Product>> GetProductsAsync()
{
    return _database.Table<Product>().ToListAsync();
}
public Task<int> SaveListProductAsync(ListProduct listp)
{
    if (listp.ID != 0)
    {
        return _database.UpdateAsync(listp);
    }
    else
    {
        return _database.InsertAsync(listp);
    }
}
public Task<List<Product>> GetListProductsAsync(int cosmeticeid)
{
    return _database.QueryAsync<Product>(
    "select P.ID, P.Description from Product P"
    + " inner join ListProduct LP"
    + " on P.ID = LP.ProductID where LP.CosmeticeID = ?",
    cosmeticeid);
}
