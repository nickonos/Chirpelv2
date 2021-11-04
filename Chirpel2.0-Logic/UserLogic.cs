using Chirpel2._0_Common.Interfaces.Auth;
using Chirpel2._0_Common.Interfaces.Data;
using Chirpel2._0_Common.Models;
using Chirpel2._0_Common.Models.DataModels;
using System.Security.Claims;

namespace Chirpel2._0_Logic
{
    public class UserLogic
    {
        private readonly IUserData _userData;
        private readonly IJWTService _jwtService;
        public UserLogic(IUserData userData, IJWTService jwtService)
        {
            _userData = userData;
            _jwtService = jwtService;
        }

        public string Register(string name, string email, string password)
        {
            if (_userData.GetByName(name) != null)
                throw new HttpException(409, new HttpMessage("Username already in use"));

            if (_userData.GetByEmail(email) != null)
                throw new HttpException(409, new HttpMessage("Email already in use"));

            UserModel user = new(name, email, password);
            _userData.Add(user);
            return _jwtService.GenerateToken(new JWTContainerModel() { Claims = new Claim[] {new Claim(ClaimTypes.Name, user.Id.ToString()) } });
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _userData.GetAll();
        }

        public UserModel? GetByName(string name)
        {
            return _userData.GetByName(name);
        }

        public UserModel? GetByEmail(string email)
        {
            return _userData.GetByEmail(email);
        }

        public UserModel? GetById(string id)
        {
            return _userData.GetById(id);
        }
    }
}
