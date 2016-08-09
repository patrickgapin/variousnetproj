namespace MovieStreaming.Common.Messages
{
    public class PlayMovieMessage
    {
        public string MovieTitle { get; private set; }
        public int UserID { get; private set; }

        public PlayMovieMessage(string movieTitle, int userID)
        {
            MovieTitle = movieTitle;
            UserID = userID;
        }
    }
}
