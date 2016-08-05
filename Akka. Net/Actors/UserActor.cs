using System;
using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    /// <summary>
    /// Using Behaviors.
    /// </summary>
    public class UserActor : ReceiveActor
    {
        private string currentlyWatching;

        public UserActor()
        {
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

            ColorConsole.WriteLineCyan("UserActor has now become Playing");
            Console.WriteLine();
        }

        private void Stopped()
        {
            // Defines what happens when we receive a PlayMovieMessage while we are in a Stopped state.
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));

            // Defines what happens when we receive a StopMovieMessage while we are in a Stopped state.
            Receive<StopMovieMessage>(message =>            
                ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing")
            );

            ColorConsole.WriteLineCyan("UserActor has now become Stopped");
            Console.WriteLine();
        }

        private void StartPlayingMovie(string movieTitle)
        {
            currentlyWatching = movieTitle;
            ColorConsole.WriteLineYellow(string.Format("User is currently watching {0}", currentlyWatching));

            // Switch Actor behavior from 'Stopped' to 'Playing'
            Become(Playing);
        }

        private void StopPlayingCurrentMovie()
        {
            ColorConsole.WriteLineYellow(string.Format("User has stoppped watching {0}", currentlyWatching));
            currentlyWatching = null;

            // Switch Actor behavior from 'Playing' to 'Stopped'
            Become(Stopped);
        }

        protected override void PreStart() { ColorConsole.WriteLineGreen("UserActor PreStart"); }

        protected override void PostStop() { ColorConsole.WriteLineGreen("UserActor PostStop"); }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("UserActor PreRestart because: " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("UserActor PostRestart because: " + reason);
            base.PostRestart(reason);
        }
    }
}
