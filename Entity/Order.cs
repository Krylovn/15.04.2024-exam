//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace zvuk.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public int AlbumID { get; set; }
        public int StatusID { get; set; }
        public System.DateTime Dateoffeeding { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Status Status { get; set; }
    }
}
