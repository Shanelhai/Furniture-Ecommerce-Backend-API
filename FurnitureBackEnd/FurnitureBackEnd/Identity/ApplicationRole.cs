using Microsoft.AspNetCore.Identity;

namespace FurnitureBackEnd.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

    }
}
