//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Donate4Life
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersFavourites
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DonorId { get; set; }
    
        public virtual Donors Donors { get; set; }
        public virtual Users Users { get; set; }
    }
}
