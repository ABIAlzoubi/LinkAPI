using Dapper;
using Link.Core.Common;
using Link.Core.DTO;
using Link.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Infra.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbContext _dbContext;
        public ContactRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddNewContact(decimal u_id, decimal Contact_id) 
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("Contact_id", Contact_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.AddNewContact", dp, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ContactsDto>> GetAllContacts(decimal u_id) 
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<ContactsDto>("HomeScreen_Package.GetAllContacts", dp, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task DeleteContact(decimal u_id, decimal Contact_id)
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("Contact_id", Contact_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.DeleteContact", dp, commandType: CommandType.StoredProcedure);
        }
    }
}
