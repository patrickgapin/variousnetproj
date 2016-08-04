using System;
using Akka.Actor;
using Akka.Net.Messages;

namespace Akka.Net
{
    public class ReceivePlaybackActor : ReceiveActor
    {
        public ReceivePlaybackActor()
        {
            Console.WriteLine("Creating a ReceivePlaybackActor");

            //Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message));

            //Only handles messsage if userID is 42
            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message), message => message.UserID == 42);
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            Console.WriteLine("[Receive Actor] Received movie title " + message.MovieTitle);
            Console.WriteLine("[Receive Actor] Received user ID " + message.UserID);
        }
    }
}
