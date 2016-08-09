using Akka.Actor;
using MovieStreaming.Common.Messages;
using System;
using System.Collections.Generic;
using MovieStreaming.Common.Exceptions;
using MovieStreaming.Common;

namespace MovieStreaming.Common.Actors
{
    public class MoviePlayCounterActor : ReceiveActor
    {
        private readonly Dictionary<string, int> moviePlayCounts;

        public MoviePlayCounterActor()
        {
            moviePlayCounts = new Dictionary<string, int>();

            Receive<IncrementPlayCountMessage>(message => HandleIncrementMessage(message));
        }

        private void HandleIncrementMessage(IncrementPlayCountMessage message)
        {
            if (moviePlayCounts.ContainsKey(message.MovieTitle)) { moviePlayCounts[message.MovieTitle]++; }
            else { moviePlayCounts[message.MovieTitle] = 1; }

            //Simulate some bugs
            if (moviePlayCounts[message.MovieTitle] > 3) { throw new SimulatedCorruptStateException(); }

            if (message.MovieTitle.Contains("bad")) { throw new SimulatedTerribleMovieException(); }


            ColorConsole.WriteLineMagenta("MoviePlayCounterActor '{0}' has been watched {1} times", message.MovieTitle, moviePlayCounts[message.MovieTitle]);
        }

        #region Lifecycle hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("MoviePlayCounterActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("MoviePlayCounterActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("MoviePlayCounterActor PreRestart because exception of type '{0}' was thrown: ", reason.GetType());
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {           
            ColorConsole.WriteLineGreen("MoviePlayCounterActor PostRestart because exception of type '{0}' was thrown: ", reason.GetType());
            base.PostRestart(reason);
        }

        #endregion
    }
}