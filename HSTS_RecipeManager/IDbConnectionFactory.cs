using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTS_RecipeManager
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
