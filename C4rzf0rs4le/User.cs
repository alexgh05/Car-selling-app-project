using System.ComponentModel.DataAnnotations;

namespace C4rzf0rs4le
{
    public class User
    {
      [Key]  public string Username {  get; set; }
        public string Userpasswd { get; set; }
        public string User_Email{ get; set; }
        public string Userphone {  get; set; }
    }
}