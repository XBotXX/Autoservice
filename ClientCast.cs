using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice
{
    public partial class Client
    {
        public int Count
        {
            get
            {
                return ClientService.Count();
            }
        }
    }

    public partial class Client
    {
        public DateTime? LastService
        {
            get
            {
                return ClientService.LastOrDefault()?.DateTimeStart;
            }
        }
    }

    public partial class Client
    {
        public List<Tag> ListTag
        {
            get
            {
                return ClientTag.Select(i => i.Tag).ToList();
            }
        }
    }
}
