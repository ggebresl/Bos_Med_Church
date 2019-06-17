using EOTC.Boston.MedhaneAlem.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EOTC.Boston.MedhaneAlem.BuisnessLogic.Interfaces
{
    public interface IAuthentication
    {
        bool Authenticate(string username, string password, out UserLogin returnedResult,
            out Member memResult, out Role roleRsult);
        bool Logout();
    }
}
