//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autoservice
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductHistory
    {
        public int IdProductHistory { get; set; }
        public Nullable<int> IdProduct { get; set; }
        public Nullable<int> IdClientService { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual ClientService ClientService { get; set; }
        public virtual Product Product { get; set; }
    }
}