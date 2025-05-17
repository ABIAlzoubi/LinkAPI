using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Common
{
    public interface IDbContext
    {
        IDbConnection Connection { get; }

    }
}
