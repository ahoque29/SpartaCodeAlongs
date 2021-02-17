using MoqExampleBackEnd.DbModel;
using System.Collections.Generic;

namespace MoqExampleBackEnd
{
    public interface ICatalogItemManager
    {
        string Find(string text);
        CatalogItem FindItem(string text);
        decimal GetPrice(string selectedItem);
        void AddItem(CatalogItem item);
        void AddItems(List<CatalogItem> items);
        bool RemoveItem(string itemName);
    }
}