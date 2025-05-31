using Dapper;
using Link.Core.Common;
using Link.Core.DTO;
using Link.Core.Repository;
using Link.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Infra.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IDbContext _dbContext;
        public ProfileRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUserProfile(linkUserDto profile)
        {
            var dp = new DynamicParameters();
            dp.Add("p_username", profile.USERNAME, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_phone_number", profile.PHONE_NUMBER, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_email", profile.EMAIL, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_password", profile.HASHEDPASSWORD, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_profile_pic", profile.PROFILEPIC, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.CreateUser", dp, commandType: CommandType.StoredProcedure);
        }
        public async Task<linkUserDto> GetUserProfile(decimal user_id)
        {
            var dp = new DynamicParameters();
            dp.Add("p_userid", user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<linkUserDto>("HomeScreen_Package.GetProfile", dp, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public async Task UpdateUserProfile(linkUserDto profile) 
        {
            var dp = new DynamicParameters();
            dp.Add("p_userid", profile.USERID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("p_username", CheckStringEmpty.IsEmptyOrPlaceholder(profile.USERNAME) ? DBNull.Value : profile.USERNAME, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_phone_number", CheckStringEmpty.IsEmptyOrPlaceholder(profile.PHONE_NUMBER) ? DBNull.Value : profile.PHONE_NUMBER, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_email", CheckStringEmpty.IsEmptyOrPlaceholder(profile.EMAIL) ? DBNull.Value : profile.EMAIL, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_password", CheckStringEmpty.IsEmptyOrPlaceholder(profile.HASHEDPASSWORD) ? DBNull.Value : profile.HASHEDPASSWORD, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_profile_pic", CheckStringEmpty.IsEmptyOrPlaceholder(profile.PROFILEPIC) ? DBNull.Value : profile.PROFILEPIC, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_is_active", CheckStringEmpty.IsEmptyOrPlaceholder(profile.IS_ACTIVE) ? DBNull.Value : profile.IS_ACTIVE, dbType: DbType.String, direction: ParameterDirection.Input);
            
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.UpdateUserProfile", dp, commandType: CommandType.StoredProcedure);

        }
    }
}
