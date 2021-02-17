using System.Collections.Generic;
using System.Linq;
using MoqExampleBackEnd.DbModel;

namespace MoqExampleBackEnd
{
	public class CatalogItemManager : ICatalogItemManager
	{
		private ExampleContext _dbContext;

		public CatalogItemManager(ExampleContext dbContext)
		{
			_dbContext = dbContext;
		}

		public virtual string Find(string text)
		{
			var item = FindItem(text);
			return item == null ? string.Empty : item.Name;
		}

		public virtual CatalogItem FindItem(string text)
		{
			if (text == null || text == "") return null;
			text = text.ToLower();
			return _dbContext.CatalogItems.Where(
					c => c.Name.ToLower().StartsWith(text)).FirstOrDefault();
		}

		public decimal GetPrice(string selectedItemName)
		{
			var item = FindItem(selectedItemName);
			return item == null ? 0.00m : item.Price;
		}

		public void AddItem(CatalogItem item)
		{
			_dbContext.CatalogItems.Add(item);
			_dbContext.SaveChanges();
		}

		public void AddItems(List<CatalogItem> items)
		{
			_dbContext.CatalogItems.AddRange(items);
			_dbContext.SaveChanges();
		}

		public bool RemoveItem(string itemName)
		{
			var item = FindItem(itemName);
			if (item != null)
			{
				_dbContext.Remove(item);
				_dbContext.SaveChanges();
				return true;
			}
			return false;
		}
	}
}