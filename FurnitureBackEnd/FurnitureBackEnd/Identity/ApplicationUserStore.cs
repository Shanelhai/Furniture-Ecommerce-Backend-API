using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FurnitureBackEnd.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
          : base(context)
        {

        }
    }
}
