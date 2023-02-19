using Miniinstagram;

using (var db = new MiniinstaContext())
{
    User user = new User()
    {
        Login = "sahib278",
        Pswd = "cavid435"
    };


    Post post = new Post()
    {
        User = user,
        Date = DateTime.Now,
        Text = "test",
        ImgPath = "cdn.insta.org/fg.jpg"

    };

    Tags tag = new Tags()
    {
        Tag = "hhyh"

    };


    
    post.Tags.Add(tag);
    db.Posts.Add(post);
    db.SaveChanges();
}
