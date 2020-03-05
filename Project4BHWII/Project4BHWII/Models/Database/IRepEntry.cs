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
        bool Insert(newEntry Entry);
        bool Delete(int id);
        bool Update(int id, newEntry UpdatedEntry);
        List<newEntry> allEntries();
        
    }
}
