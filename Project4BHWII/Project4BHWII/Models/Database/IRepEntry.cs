using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4BHWII.Models.Database
{

    interface IRepEntry
    {
        void Open();
        void Close();
        bool Insert(Entry Entry, string Username);
        bool Delete(int id);
        bool Update(int id, Entry UpdatedEntry);
        List<Entry> allEntries();
        
    }
}
