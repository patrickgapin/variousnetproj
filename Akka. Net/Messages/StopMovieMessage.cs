namespace MovieStreaming.Messages
{
    public class StopMovieMessage
    {
        public int UserID { get; private set; }

        public StopMovieMessage(int userId)
        {
            UserID = userId;
        }

        public StopMovieMessage()
        {
        }
    }
}
