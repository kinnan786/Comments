namespace Comments.Web.Models
{
    public class General
    {
        private int _totalCommentsAndRepliesLikes;

        public General()
        {
            MostActiveUsers = 0;
            Comments = 0;
            Love = 0;
            PeopleInConversation = 0;
            Sad = 0;
            Shares = 0;
            Wow = 0;
            Like = 0;
            Angry = 0;
            Replies = 0;
            RepliesLikes = 0;
            CommentsLikes = 0;
        }

        public int MostActiveUsers { get; set; }
        public int PeopleInConversation { get; set; }
        public int Comments { get; set; }
        public int Shares { get; set; }
        public int Like { get; set; }
        public int Love { get; set; }
        public int Haha { get; set; }
        public int Wow { get; set; }
        public int Angry { get; set; }
        public int Sad { get; set; }
        public int Replies { get; set; }
        public int RepliesLikes { get; set; }
        public int CommentsLikes { get; set; }
    }
}