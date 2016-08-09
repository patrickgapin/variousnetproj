using System;
using Akka.Actor;
using MovieStreaming.Common.Messages;
using MovieStreaming.Common.Helpers;
using MovieStreaming.Common.Exceptions;
using MovieStreaming.Common;

namespace MovieStreaming.Common.Actors
{
    public class PlaybackStatisticsActor : ReceiveActor
    {
        public PlaybackStatisticsActor()
        {
            Context.ActorOf(Props.Create<MoviePlayCounterActor>(), Constants.ActorsNames.MoviePlayCounter);
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                exception =>
                {
                    if (exception is SimulatedCorruptStateException){return Directive.Restart;}
                    if (exception is SimulatedTerribleMovieException) { return Directive.Resume; }
                    return Directive.Restart;
                });
        }

        #region Lifecycle hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineWhite("PlaybackStatisticsActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineWhite("PlaybackStatisticsActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("PlaybackStatisticsActor PreRestart because exception of type '{0}' was thrown: ", reason.GetType());
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("PlaybackStatisticsActor PostRestart because exception of type '{0}' was thrown: ", reason.GetType());
            base.PostRestart(reason);
        }

        #endregion
    }
}
