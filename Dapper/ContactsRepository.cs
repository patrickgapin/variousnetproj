using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using Model.Entities;

namespace DapperSample
{
    public class ContactsRepository: IContactsRepository
    {
        IDbConnection Db;

        public Contact Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact GetFullContact(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact contact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", value: contact.Id, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            parameters.Add("@FirstName", contact.FirstName);
            parameters.Add("@LastName", contact.LastName);

            this.Db.Execute("", parameters, commandType: CommandType.StoredProcedure);
        }

        public Contact Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
