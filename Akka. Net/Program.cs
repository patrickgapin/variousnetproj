using Akka.Actor;
using Akka.Net.Messages;
using System;
using System.Linq;

namespace Akka.Net
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;
        private const string ActorName = "MovieStreamActorSystem";

        static void Main(string[] args)
        {
            ManageUntypeActor();
            ManageReceiveActor();

            PrintEmptyLines();

            Console.ReadLine();

            TerminateActorSystem();
        }

        private static void ManageUntypeActor()
        {
            MovieStreamingActorSystem = ActorSystem.Create(ActorName);
            Console.WriteLine("Actor system created");

            var playbackActorProps = Props.Create<PlaybackActor>();

            var playbackActorReference = MovieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");            
            playbackActorReference.Tell("Akka.NET: The Movie");
            playbackActorReference.Tell(42);
            playbackActorReference.Tell('c');

            var playMovieMessage = new PlayMovieMessage("My Movie", 56);
            playbackActorReference.Tell(playMovieMessage);            
        }

        private static void ManageReceiveActor()
        {
            var receivePlaybackActorProps = Props.Create<ReceivePlaybackActor>();
            var receivePlaybackActorReference = MovieStreamingActorSystem.ActorOf(receivePlaybackActorProps, "ReceivePlaybackActor");
            var otherMessage = new PlayMovieMessage("My Movie", 56);
            receivePlaybackActorReference.Tell(otherMessage);

            receivePlaybackActorReference.Tell(new PlayMovieMessage("Movie 42", 42));
        }

        private static void TerminateActorSystem()
        {
            MovieStreamingActorSystem.Terminate();
        }

        private static void PrintEmptyLines()
        {
            Enumerable.Range(0, 5).ToList().ForEach(x => Console.WriteLine());
        }
    }
}
