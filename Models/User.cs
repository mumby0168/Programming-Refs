namespace Programming_Reference_Website.Models
{
    public class User : ModelBase
    {

        public string FreindlyName { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public byte[] Salt { get; set; } 
    }
}