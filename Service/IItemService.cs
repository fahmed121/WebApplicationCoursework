using WebApplicationCourseWork.Models;
using System.Collections.Generic;


public interface IItemService
{
    Task <IEnumerable <Item>>GetAllItemsAsync();
    Task<Item> GetItemByIdAsync(int ItemID);
    Task AddItemAsync(Item item);
    Task UpdateItemAsync(int ItemID, Item Item);
    Task DeleteItemAsync(int ItemID);
}