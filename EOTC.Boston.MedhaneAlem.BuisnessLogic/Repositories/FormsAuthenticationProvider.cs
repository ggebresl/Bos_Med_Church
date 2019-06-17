using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

using EOTC.Boston.MedhaneAlem.BuisnessLogic.Interfaces;
using EOTC.Boston.MedhaneAlem.DataLayer;
namespace EOTC.Boston.MedhaneAlem.BuisnessLogic.Repositories
{
    public class FormsAuthenticationProvider : IAuthentication
    {
        private readonly DBContext context = new DBContext();

        public bool Authenticate(string username, string password, out UserLogin returnedResult,
            out Member memResult, out Role roleRsult)
        {
            UserLogin result = context.UserLogins.FirstOrDefault(u => u.UserID == username &&
                                                          u.Password == password);
            Member mResult;

            if (result == null)
            {
                returnedResult = null;
                memResult = null;
                roleRsult = null;
                return false;
            }
            else
            {
                returnedResult = result;
                mResult = context.Members.FirstOrDefault(m => m.MemberId == result.MemberID);
                memResult = mResult;
                //Find the RoleId of the User from from role table
                roleRsult = context.Roles.FirstOrDefault(r => r.RoleID == mResult.RoleID);

            }
            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}