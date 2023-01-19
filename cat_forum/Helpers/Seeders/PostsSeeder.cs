using cat_forum.Data;
using cat_forum.Models;

namespace cat_forum.Helpers.Seeders
{
    public class PostsSeeder
    {
        public readonly CatForumContext _catForumContext;

        public PostsSeeder(CatForumContext catForumContext)
        {
            _catForumContext = catForumContext;
        }

        public void SeedIntialPosts()
        {
            if (!_catForumContext.ForumPosts.Any())
            {
                var post1 = new ForumPost
                {
                    Title = "Generic Post Title",
                    Content = "Insert average cat enjoyer text here"
                };

                var post2 = new ForumPost
                {
                    Title = "This is a sample",
                    Content = "Cats rule the world"
                };

                _catForumContext.Add(post1);
                _catForumContext.Add(post2);

                _catForumContext.SaveChanges();
            }
        }
    }
}
