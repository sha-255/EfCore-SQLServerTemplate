using System.ComponentModel.DataAnnotations;

namespace tst1
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
