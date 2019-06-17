using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EOTC.Boston.MedhaneAlem.DataLayer;
namespace EOTC.Boston.MedhaneAlem.BuisnessLogic.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> Members { get; }
        void SaveMember(Member member);
        Member DeleteMember(int memberID);
        void SaveUserLogin(UserLogin userlogin);
        void DeleteUserLogin(UserLogin userlogin, int memberID);
       
    }
}
