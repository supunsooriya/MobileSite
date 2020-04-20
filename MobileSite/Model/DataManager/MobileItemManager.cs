using MobileSite.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileSite.Model.DataManager
{
    public class MobileItemManager : IDataRepository<MobileItem>
    {
        readonly MobileItemContext _mobileItemContext;

        public MobileItemManager(MobileItemContext context)
        {
            _mobileItemContext = context;
        }

        public IEnumerable<MobileItem> GetAll()
        {
            return _mobileItemContext.MobileItem.ToList();
        }

        public MobileItem Get(long id)
        {
            return _mobileItemContext.MobileItem
                  .FirstOrDefault(e => e.ItemId == id);
        }

        public void Add(MobileItem entity)
        {
            _mobileItemContext.MobileItem.Add(entity);
            _mobileItemContext.SaveChanges();
        }

        public void Update(MobileItem mobileItem, MobileItem entity)
        {
            mobileItem.ItemId = entity.ItemId;
            mobileItem.ImagePath = entity.ImagePath;
            mobileItem.Name = entity.Name;
            mobileItem.Para = entity.Para;

            _mobileItemContext.SaveChanges();
        }

        public void Delete(MobileItem mobileItem)
        {
            _mobileItemContext.MobileItem.Remove(mobileItem);
            _mobileItemContext.SaveChanges();
        }
    }
}
