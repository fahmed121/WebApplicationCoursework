using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;
using Org.BouncyCastle.Bcpg.OpenPgp;

public class ItemServices : IItemService
{
    public readonly FastFoodContext _context;

    public ItemServices(FastFoodContext context)
    {
        _context = context;
    }
    async Task<IEnumerable<Item>> IItemService.GetAllItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    async Task IItemService.AddItemAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }

    async Task IItemService.DeleteItemAsync(int ItemID)
    {
        var Item = await _context.Items.FindAsync(ItemID);
        if (Item != null)
        {
            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();
        }
    }



    async Task IItemService.UpdateItemAsync(int ItemID, Item item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    async Task<Item> IItemService.GetItemByIdAsync(int ItemID)
    {
        var item = await _context.Items.FindAsync(ItemID);
        return item;
    }
}