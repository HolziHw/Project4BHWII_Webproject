using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4BHWII.Models
{
    public class Session
    {
        public int Id { get; set; }
        public String UserName { get; set; }

        public Session() : this(0,"Guest") { }

        public Session(int Id,String UserName)
        {
            this.Id = Id;
            this.UserName = UserName;
        }

     
    }
}