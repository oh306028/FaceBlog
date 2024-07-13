namespace App.Models
{
    public class Post
    {
        public int Id { get; set; }


        public string Content { get; set; }     
        public DateTime CreatedDate { get; set; }
        public int Likes { get; set; }  




        public int UserId { get; set; }
        virtual public AppUser Createdby { get; set; }

        virtual public List<Comment> Comments { get; set; } = new List<Comment>();



    }
}
