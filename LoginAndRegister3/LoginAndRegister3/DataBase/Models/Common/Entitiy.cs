using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Models.Common
{
    public abstract class Entitiy<TId>
    {
        public TId Id { get; set; }
    }
}
