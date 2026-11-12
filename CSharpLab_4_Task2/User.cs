    namespace CSharpLab_4_Task2
    {
        internal class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Nickname { get; set; }

            public List<Post> Posts { get; set; }

            public User(string name, string email, string nickname)
            {
                Name = name;
                Email = email;
                Nickname = nickname;
                Posts = new List<Post>();
            }
        }
    }
