using Asp.Net.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.DataAccess
{
    public class SubAccess :DefaultAccess, ISubInterface
    {
        public SubAccess(DbContext dbContext): base (dbContext) 
        {

        }
    }
}
