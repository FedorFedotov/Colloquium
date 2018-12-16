using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class AuditoryVM
    {

        public string auditory_name;

        public string auditory_address;

        public AuditoryVM(Auditory aud)
        {
            this.auditory_name = aud.AuditoryName;
            this.auditory_address = aud.AuditoryAdress;
        }

        public AuditoryVM()
        {
        }

    }
}

