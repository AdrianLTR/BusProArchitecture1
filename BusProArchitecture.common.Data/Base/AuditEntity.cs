using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProArchitecture.common.Data.Base
{
    public abstract class AuditEntity<TType> : BaseEntity<TType>
    {

        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserMod { get; set; }

        public int? UserDeleted { get; set; }

       

        public bool Deleted { get; set; }

        public DateTime FechaCreacion { get; set; }
       
        

    }


}
