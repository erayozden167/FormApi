using System.ComponentModel.DataAnnotations;

namespace App.FormApi.Models
{
    public class User
    {
        public long Id { get; set; } 
        public string? Name { get; set; }
        public string? SurName { get; set; }
        //[DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
    }
}
