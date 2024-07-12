using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class UpdateViewModel
    {
       
        public string? FirstName { get; set; }
 
        public string? LastName { get; set; }



        //most important data
        public string? UserName { get; set; }

       
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

       
        [DataType(DataType.Password)]
        public string? Password { get; set; }
     
    
        


        public DateTime? DateOfbirth { get; set; }


        public string? Country { get; set; }        
        public string? City { get; set; }       
        public string? Street { get; set; }
    }
}
