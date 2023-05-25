using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trang_Granville
{
    public class user
    {
        public int userId;
        public string userName;
        public string password;
        public byte active;
        public DateTime createDate;
        public string createdBy;
        public DateTime lastUpdate;
        public string lastUpdateBy;

        public user(int ID, string UserName, string Password, int Active, DateTime CreateDate, string CreatedBy, DateTime LastUpdate, string UpdateBy)
        {
            userId = ID;
            userName = UserName;
            password = Password;
            active = (byte)Active;
            createDate = CreateDate;
            createdBy = CreatedBy;
            lastUpdate = LastUpdate;
            lastUpdateBy = UpdateBy;
        }

    }
}
