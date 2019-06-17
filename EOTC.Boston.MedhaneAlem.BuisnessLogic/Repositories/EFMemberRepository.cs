using EOTC.Boston.MedhaneAlem.BuisnessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using EOTC.Boston.MedhaneAlem.DataLayer;
namespace EOTC.Boston.MedhaneAlem.BuisnessLogic.Repositories
{
    public class EFMemberRepository : IMemberRepository
    {
        private readonly DBContext context = new DBContext();
        public IEnumerable<Member> Members
        {
            get { return context.Members; }
        }
        public void SaveMember(Member mem)
        {
            // If MemberID is zero, it means that this is a new Member
            try
            { 
              if (mem.MemberId == 0)
              {
                context.Members.Add(mem);
                mem.CreateDate = DateTime.Now;
                mem.UpdateDate = DateTime.Now;
                context.SaveChanges();
                }
                else //this an existing record, but need to be modified
                 {
                     context.Members.Add(mem);
                     mem.CreateDate = DateTime.Now;
                     mem.UpdateDate = DateTime.Now;
                     context.SaveChanges();
                 }
              }
             catch (Exception ex)
                {
                    //log error to database or send email to admin- to be done
                    Console.WriteLine("Error : {0}", ex.Message);
                }
            }
        public void SaveUserLogin(UserLogin userlogin)
        {

            try
            {
                if (userlogin.ID == 0)
                {
                    context.UserLogins.Add(userlogin);
                    context.SaveChanges();
                }
                else //this an existing record, but need to be modified
                {
                    context.UserLogins.Add(userlogin);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //log error to database or send email to admin- to be done
                Console.WriteLine("Error : {0}", ex.Message);
            }
        }

        public void DeleteUserLogin(UserLogin userlogin, int memberID)
        {
            try
            {

                if (userlogin != null)
                {
                    context.UserLogins.Remove(userlogin);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //log error to database or send email to admin- to be done
                Console.WriteLine("Error : {0}", ex.Message);
               
            }
        }
        public Member DeleteMember(int memberID)
        {
            Member dbEntry;
            try
            {
                dbEntry = context.Members.Find(memberID);
               
                if (dbEntry != null)
                {
                    if (dbEntry.UserLogins.Count >= 1)
                    {
                        DeleteUserLogin(dbEntry.UserLogins.FirstOrDefault(), memberID);
                    }
                    context.Members.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //log error to database or send email to admin- to be done
                Console.WriteLine("Error : {0}", ex.Message);
                return null;
            }
            return dbEntry;

        }


    }
}

