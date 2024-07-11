using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Address
    {
        [Key]
        public int Id  { get; set; }


        [MaxLength(15)]
        [Required]
        public string Country { get; set; }
        [MaxLength(25)]
        [Required]
        public string City { get; set; }

        [MaxLength(20)]
        [Required]
        public string Street { get; set; }



        //User
        public int UserId { get; set; }
        virtual public AppUser User{ get; set; }    


    }
}
