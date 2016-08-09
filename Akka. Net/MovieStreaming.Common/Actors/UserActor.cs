using System;
using Akka.Actor;
using MovieStreaming.Common.Messages;
using MovieStreaming.Common;
using MovieStreaming.Common.Helpers;

namespace MovieStreaming.Common.Actors
{
    /// <summary>
    /// Using Behaviors.
    /// </summary>
    public class UserActor : ReceiveActor
    {
        private string currentlyWatching;
        public int UserID { get; private set; }

        public UserActor(int userID)
        {
            UserID = userID;

            Console.WriteLine("Creating a UserActor");

            ColorConsole.WriteLineCyan("Setting initial behavior to stopped");
            Stopped();
        }

        private void Playing()
        {
            // Defines what happens when we receive a PlayMovieMessage while we are in a Playing state.
            Receive<PlayMovieMessage>(message => ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping existing one"));

            // Defines what happens when we receive a StopMovieMessage while we are in a Playing state.
            Receive<StopMovieMessage>(message => StopPlayingCurrentMovie());

            ColorConsole.WriteLineYellow("UserActor {0} has now become Playing", UserID.ToString());
        }

        private void Stopped()
        {
            // Defines what happens when we receive a PlayMovieMessage while we are in a Stopped state.
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));

            // Defines what happens when we receive a StopMovieMessage while we are in a Stopped state.
            Receive<StopMovieMessage>(message =>            
                ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing")
            );
            
            ColorConsole.WriteLineYellow("UserActor {0} has now become Stopped", UserID);            
        }

        private void StartPlayingMovie(string movieTitle)
        {
            currentlyWatching = movieTitle;
            ColorConsole.WriteLineYellow("User {0} is currently watching {1}", UserID, currentlyWatching);

            Context.ActorSelection(Constants.ActorsSelectionPaths.MoviePlayCounter).Tell(new IncrementPlayCountMessage(movieTitle));

            // Switch Actor behavior from 'Stopped' to 'Playing'
            Become(Playing);
        }

        private void StopPlayingCurrentMovie()
        {
            ColorConsole.WriteLineYellow("User {0} has stoppped watching {1}", UserID, currentlyWatching);
            currentlyWatching = null;

            // Switch Actor behavior from 'Playing' to 'Stopped'
            Become(Stopped);
        }

        protected override void PreStart() { ColorConsole.WriteLineYellow("UserActor {0} PreStart", UserID); }

        protected override void PostStop() { ColorConsole.WriteLineYellow("UserActor {0} PostStop", UserID); }

        protected override void PreRestart(Exception reason, object message)
        {            
            ColorConsole.WriteLineGreen("UserActor {0} PreRestart because exception of type '{1}' was thrown: ", UserID, reason.GetType());
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {            
            ColorConsole.WriteLineGreen("UserActor {0} PostRestart because exception of type '{1}' was thrown: ", UserID, reason.GetType());
            base.PostRestart(reason);
        }
    }
}
