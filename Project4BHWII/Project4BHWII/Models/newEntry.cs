using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4BHWII.Models
{
    public enum EntryType {Text, SaveGame,notSpecified};
    public class newEntry
    {

       public string UserName { get; set; }
       public string Titel { get; set; }
       public string Entry { get; set; }
       public string UploadDataURL { get; set; }
       public EntryType EntryType { get; set; }


        public newEntry() : this("", "", "", null, EntryType.notSpecified) { }

        public newEntry(string username,string titel, string entry, string uplaodData, EntryType entryType)
        {
            this.UserName = username;
            this.Titel = titel;
            this.Entry = entry;
            this.UploadDataURL = uplaodData;
            this.EntryType = entryType; 
        }
       
    }
}