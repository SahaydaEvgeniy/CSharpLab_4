namespace CSharpLab_4_Task2
{
    internal class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public List<string> Comments { get; set; }

        public Post(int id, string text)
        {
            Id = id;
            Text = text;
            Likes = 0;
            Comments = new List<string>();
        }

        public void AddLike()
        {
            Likes++;
        }

        public void AddComment(string nickname, string text)
        {
            Comments.Add(nickname + ": " + text);
        }
    }
}
