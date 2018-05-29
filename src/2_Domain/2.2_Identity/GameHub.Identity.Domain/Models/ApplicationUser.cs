
using Microsoft.AspNetCore.Identity;

namespace GameHub.Identity.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ImagePath { get; private set; }
        
        #region Constructors

        public ApplicationUser()
        { }

        public ApplicationUser(string userName, string passwordHash)
        {
            this.UserName = userName;
            this.PasswordHash = passwordHash;
        }

        public ApplicationUser(string userName, string passwordHash, string imagePath)
        {
            this.UserName = userName;
            this.PasswordHash = passwordHash;
            this.ImagePath = imagePath;
        }

        #endregion

        public void UpdatePasswordHash(string newPassword)
        { this.PasswordHash = newPassword; }
        
    }
}