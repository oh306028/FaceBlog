namespace App.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }



        public AppUser WrittenBy { get; set; }
        public int UserId { get; set; } 



        public int PostId { get; set; }
        virtual public Post Post { get; set; }
    }
}
