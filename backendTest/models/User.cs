using System.ComponentModel.DataAnnotations;

namespace BackendTest.Models
{
    public class User
    {
        [Key]
        
        public int  UserId { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string UserMail { get; set; }

        [Required, MaxLength(50)]
        public string UserPassword { get; set; }

        [Required]
        public string UserType { get; set; }



        public User() { }

        public User(int  userId, string userName, string userMail, string userPassword, string userType)
        {
            UserId = userId;
            UserName = userName;
            UserMail = userMail;
            UserPassword = userPassword;
            UserType = userType;
        }
    }
}