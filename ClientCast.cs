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

    public partial class Client
    {
        public int CountListClientService
        {
            get
            {
                return ClientService.Count();
            }
        }
    }

    public partial class Client
    {
        public decimal SumClientService
        {
            get
            {
                return ClientService.Select(i => i.Service).Sum(i=>i.Price);
            }
        }
    }

    public partial class Client
    {
        public string ColorClientService
        {
            get
            {
                return SumClientService > 500 ? "Green" : "Red";
            }
        }
    }

    public partial class ClientService
    {
        public List<ClientServiceDocument> ListClient
        {
            get
            {
                return ClientServiceDocument.ToList();
            }
        }
    }

    public partial class ClientService
    {
        public int CountListClient
        {
            get
            {
                return ClientServiceDocument.ToList().Count();
            }
        }
    }
}
