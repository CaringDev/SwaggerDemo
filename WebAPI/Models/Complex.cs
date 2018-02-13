using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerDemo.WebAPI.Models
{
    public enum UserGroupPlatform
    {
        MeetUp,
        Conference,
        LinkedIn,
        Xing,
        Sharepoint
    }

    [Flags]
    public enum Financing
    {
        None = 0,
        Sponsored = 1,
        SelfFunded = 2,
        Paid = 4
    }

    /// <summary>
    /// An arbitrarily complex type
    /// </summary>
    public class Complex
    {
        public DateTimeOffset Timestamp { get; set; }

        [Required]
        public UserGroupPlatform Location { get; set; }

        public Financing EntryFee { get; set; }
    }
}
