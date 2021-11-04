using Chirpel2._0_Common.Interfaces.Context;
using Chirpel2._0_Common.Interfaces.Data;
using Chirpel2._0_Common.Models.DataModels;

namespace Chirpel2._0_Data
{
    public class UserData : GenericData<UserModel>,  IUserData
    {
        public UserData(IChirpelContext dbContext) : base(dbContext)
        {
        }

        public UserModel? GetById(string id)
        {
            return _dbContext.User.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public UserModel? GetByName(string name)
        {
            return _dbContext.User.FirstOrDefault(x => x.Name == name);
        }

        public UserModel? GetByEmail(string email)
        {
            return _dbContext.User.FirstOrDefault(x => x.Email == email);
        }
    }
}
