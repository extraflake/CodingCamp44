using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Repositories.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
