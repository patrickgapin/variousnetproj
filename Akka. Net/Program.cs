using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Messages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStreaming
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;
        private const string ActorName = "MovieStreamActorSystem";

        static void Main(string[] args)
        {
            StartSystem();
            //ManageUntypeActor();
            ManageActors();

            //PrintEmptyLines();

            // press enter to shutdown the system
            Console.ReadKey();

            TerminateActorSystem();

            
            // press enter to stop console application
            Console.ReadKey();
        }

        private static void StartSystem()
        {
            MovieStreamingActorSystem = ActorSystem.Create(ActorName);
            Console.WriteLine("Actor system created");
        }

        private static void ManageUntypeActor()
        {


            var playbackActorProps = Props.Create<PlaybackActor>();

            var playbackActorReference = MovieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");            
            playbackActorReference.Tell("Akka.NET: The Movie");
            playbackActorReference.Tell(42);
            playbackActorReference.Tell('c');

            var playMovieMessage = new PlayMovieMessage("My Movie", 56);
            playbackActorReference.Tell(playMovieMessage);            
        }

        private static void ManageActors()
        {
            var receivePlaybackActorProps = Props.Create<ReceivePlaybackActor>();
            var receivePlaybackActorReference = MovieStreamingActorSystem.ActorOf(receivePlaybackActorProps, "ReceivePlaybackActor");

            var userActorProps = Props.Create<UserActor>();
            var userActorReference = MovieStreamingActorSystem.ActorOf(userActorProps, "UserActor");

            //receivePlaybackActorReference.Tell(PoisonPill.Instance);
            Console.ReadKey();
            Console.WriteLine("Sending a PlayMovieMessage (Africa: The Return)");
            userActorReference.Tell(new PlayMovieMessage("Africa: The Return", 56));

            Console.ReadKey();
            Console.WriteLine("Sending a PlayMovieMessage (Children are Love)");
            userActorReference.Tell(new PlayMovieMessage("Children are Love", 42));
            //receivePlaybackActorReference.Tell(new PlayMovieMessage("Why do that", 146));
            //receivePlaybackActorReference.Tell(new PlayMovieMessage("One is Great", 1));

            Console.ReadKey();
            Console.WriteLine("Sending a StopMovieMessage");
            userActorReference.Tell(new StopMovieMessage());

            Console.ReadKey();
            Console.WriteLine("Sending another StopMovieMessage");
            userActorReference.Tell(new StopMovieMessage());
        }


        private static void TerminateActorSystem()
        {
            MovieStreamingActorSystem.Terminate();

            MovieStreamingActorSystem.AwaitTermination();
            Console.WriteLine("Actor System shutown");
            //MovieStreamingActorSystem.WhenTerminated. = new Task(SystemIsTerminated);
        }

        private static void SystemIsTerminated()
        {
            Console.WriteLine("Actor System shutown");
        }

        private static void PrintEmptyLines()
        {
            Enumerable.Range(0, 5).ToList().ForEach(x => Console.WriteLine());
        }
    }
}
