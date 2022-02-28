using Asp.Net.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.DataAccess
{
    public class DefaultAccess: IDefaultInterface
    {
        protected DbContext Context { get; private set; }
        public DefaultAccess(DbContext context) 
        {
            this.Context = context;
        }
    }
}
