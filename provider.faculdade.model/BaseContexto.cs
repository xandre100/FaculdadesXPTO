using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provider.faculdade.model.dal
{
    public class BaseContexto : DbContext
    {
        public BaseContexto() : base("FaculdadesDBEntities")
        {

        }
    }
}
