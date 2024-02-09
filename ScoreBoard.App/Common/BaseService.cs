using ScoreBoard.App.Abstract;
using ScoreBoard.Domain.Common;

namespace ScoreBoard.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }
        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            else
                lastId = 0;

            return lastId;
        }
        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

    }
}
