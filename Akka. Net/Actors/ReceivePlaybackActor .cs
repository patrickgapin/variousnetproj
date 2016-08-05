using System;
using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    /// <summary>
    /// Not using Behaviors.
    /// </summary>
    public class ReceivePlaybackActor : ReceiveActor
    {
        private string currentlyWatching;

        public ReceivePlaybackActor()
        {
            Console.WriteLine("Creating a ReceivePlaybackActor");

            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message));

            //Only handles messsage if userID is 42
            //Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message), message => message.UserID == 42);

            Receive<StopMovieMessage>(message => HandleStopMovieMessage(message));
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            if (currentlyWatching != null)
            {
                ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping existing one");
                return;
            }

            StartPlayingMovie(message.MovieTitle);
            Console.WriteLine();
        }

        private void StartPlayingMovie(string movieTitle)
        {
            currentlyWatching = movieTitle;
            ColorConsole.WriteLineYellow(string.Format("User is currently watching {0}", currentlyWatching));
        }

        private void HandleStopMovieMessage(StopMovieMessage message)
        {
            if (currentlyWatching == null)
            {
                ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing");
                return;
            }

            StopPlayingCurrentMovie();
        }

        private void StopPlayingCurrentMovie()
        {
            ColorConsole.WriteLineYellow(string.Format("User has stoppped watching {0}", currentlyWatching));
            currentlyWatching = null;
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("PlaybackActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("PlaybackActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("PlaybackActor PreRestart because: " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("PlaybackActor PostRestart because: " + reason);
            base.PostRestart(reason);
        }
    }
}
