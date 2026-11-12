
namespace CSharpLab_4_Task2
{
    internal class SocialNetwork
    {
        public List<User> Users { get; set; } = new List<User>();

        private int nextPostId = 1;

        public void CreatePost(User user, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Текст поста не може бути порожнім.");
                return;
            }

            Post post = new Post(nextPostId, text);
            nextPostId++;

            user.Posts.Add(post);

            Console.WriteLine("Пост створено! ID: " + post.Id);
        }

        public void DeletePost(User user, int postId)
        {
            foreach (Post post in user.Posts)
            {
                if (post.Id == postId)
                {
                    user.Posts.Remove(post);
                    Console.WriteLine("Пост видалено!");
                    return;
                }
            }

            Console.WriteLine("Ваш пост не знайдено.");
        }

        public void ShowPosts(User user)
        {
            Console.WriteLine("\nПублікації користувача @" + user.Nickname);

            if (user.Posts.Count == 0)
            {
                Console.WriteLine("Публікацій немає.");
                return;
            }

            int shown = 0;

            for (int i = user.Posts.Count - 1; i >= 0 && shown < 5; i--)
            {
                Post post = user.Posts[i];

                Console.WriteLine("\nID: " + post.Id);
                Console.WriteLine("Текст: " + post.Text);
                Console.WriteLine("Лайків: " + post.Likes);

                Console.WriteLine("Коментарі:");

                if (post.Comments.Count == 0)
                {
                    Console.WriteLine("Немає коментарів.");
                }

                foreach (string comment in post.Comments)
                {
                    Console.WriteLine(" - " + comment);
                }

                shown++;
            }
        }

        public void LikePost(User author, int postId)
        {
            foreach (Post post in author.Posts)
            {
                if (post.Id == postId)
                {
                    post.AddLike();
                    Console.WriteLine("Лайк поставлено!");
                    return;
                }
            }

            Console.WriteLine("Пост не знайдено.");
        }

        public void CommentPost(
            User author, int postId, User commenter, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Коментар не може бути порожнім.");
                return;
            }

            foreach (Post post in author.Posts)
            {
                if (post.Id == postId)
                {
                    post.AddComment(commenter.Nickname, text);
                    Console.WriteLine("Коментар додано!");
                    return;
                }
            }

            Console.WriteLine("Пост не знайдено.");
        }
    }
}
