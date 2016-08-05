using System;
using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    public class PlaybackActor : UntypedActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a PlaybackActor");
        }

        protected override void OnReceive(object message)
        {
            if (message is string) { Console.WriteLine("Received movie title " + message); }
            else if (message is int) { Console.WriteLine("Received user ID " + message); }
            else if (message is PlayMovieMessage)
            {
                var passedMessage = message as PlayMovieMessage;
                Console.WriteLine("Received movie title " + passedMessage.MovieTitle);
                Console.WriteLine("Received user ID " + passedMessage.UserID);
            }
            else { Unhandled(message); };
        }
    }
}
