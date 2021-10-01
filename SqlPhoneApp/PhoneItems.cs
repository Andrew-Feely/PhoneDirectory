using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPhoneApp
{
    public class PhoneItems
    {
        private List<DirectoryItem> allItems = new List<DirectoryItem>();

        public List<DirectoryItem> GetAll()
        {
            allItems = PhoneItemDA.GetAll();

            return allItems;
        }

        public void Add(DirectoryItem directoryItem)
        {
           
            // add the new item to the database

            PhoneItemDA.Add(directoryItem);
            allItems.Add(directoryItem);
        }

        internal void Edit(DirectoryItem selectedItem)
        {
            PhoneItemDA.Edit(selectedItem);
        }

        internal void Delete(DirectoryItem directoryItem)
        {
            // remove from local collection
            allItems.Remove(directoryItem);

            PhoneItemDA.Delete(directoryItem);
        }
    }
}
