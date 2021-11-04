using Chirpel2._0_Common.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirpel2._0_Common.Interfaces.Data
{
    public interface IUserData: IGenericData<UserModel>
    {
        UserModel? GetById(string id);
        UserModel? GetByName(string name);
        UserModel? GetByEmail(string email);
    }        
}
