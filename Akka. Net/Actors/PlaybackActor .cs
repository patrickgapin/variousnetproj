using System;
using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    /// <summary>
    /// Not using Behaviors.
    /// </summary>
    public class PlaybackActor : ReceiveActor
    {
        private string currentlyWatching;

        public PlaybackActor()
        {
            Console.WriteLine("Creating a ReceivePlaybackActor");

            Context.ActorOf(Props.Create<UserCoordinatorActor>(), "UserCoordinator");
            Context.ActorOf(Props.Create<PlaybackStatisticsActor>(), "PlaybackStatistics");

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
        }

        private void StartPlayingMovie(string movieTitle)
        {
            currentlyWatching = movieTitle;
            ColorConsole.WriteLineYellow("User is currently watching {0}", currentlyWatching);
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

        #region Lifecycle hooks
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
            ColorConsole.WriteLineGreen("PlaybackActor PreRestart because exception of type '{0}' was thrown: ", reason.GetType());
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {           
            ColorConsole.WriteLineGreen("PlaybackActor PostRestart because exception of type '{0}' was thrown: ", reason.GetType());
            base.PostRestart(reason);
        }

        #endregion
    }
}
