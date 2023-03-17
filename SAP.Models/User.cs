using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string LoginId { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool EmailConfirmed { get; set;}
        public string SecurityStamp { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string AuthenticationKey { get; set; }
        public string AuthRecoveryCodes { get; set; }
        public bool TwoFactorAuthEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool LockOutEnabled { get; set; }
        public DateTime? LockOutEnd { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string NormalizedEmail { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public int StatusId { get; set; }

    }
}
