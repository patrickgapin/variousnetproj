using Akka.Actor;
using MovieStreaming.Common.Actors;
using MovieStreaming.Common;
using MovieStreaming.Common.Helpers;
using MovieStreaming.Common.Messages;
using System;
using System.Linq;

namespace MovieStreaming
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            StartSystem();
            // ManageUntypeActor();

            // Use [ManageActors()] to manage actors.
            // ManageActors();

            ManageHieararchy();

            // PrintEmptyLines();

            // press enter to shutdown the system
            //Console.ReadKey();

            //TerminateActorSystem();

            // press enter to stop console application
            //Console.ReadKey();
        }

        private static void StartSystem()
        {
            ColorConsole.WriteLineGray("Creating MovieStreamActorSystem");
            MovieStreamingActorSystem = ActorSystem.Create(Constants.ActorsNames.MovieStreamingActorSystem);
        }

        private static void ManageUntypeActor()
        {
            var playbackActorProps = Props.Create<UntypePlaybackActor>();

            var playbackActorReference = MovieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");
            playbackActorReference.Tell("Akka.NET: The Movie");
            playbackActorReference.Tell(42);
            playbackActorReference.Tell('c');

            var playMovieMessage = new PlayMovieMessage("My Movie", 56);
            playbackActorReference.Tell(playMovieMessage);
        }

        private static void ManageHieararchy()
        {
            ColorConsole.WriteLineGray("Creating actor supervisor hierarchy");
            MovieStreamingActorSystem.ActorOf(Props.Create<PlaybackActor>(), Constants.ActorsNames.Playback);            

            do
            {
                //ShortPause();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                ColorConsole.WriteLineGray("Enter a command (play/stop/exit) and hit Enter");
                var command = Console.ReadLine();

                if (command.StartsWith(Constants.Commands.Play, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = int.Parse(command.Split(',')[1]);
                    var movieTitle = command.Split(',')[2];
                    var message = new PlayMovieMessage(movieTitle, userId);
                    MovieStreamingActorSystem.ActorSelection(Constants.ActorsSelectionPaths.UserCoordinator).Tell(message);
                }

                if (command.StartsWith(Constants.Commands.Stop, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = int.Parse(command.Split(',')[1]);
                    var message = new StopMovieMessage(userId);
                    MovieStreamingActorSystem.ActorSelection(Constants.ActorsSelectionPaths.UserCoordinator).Tell(message);
                }
                if (command.StartsWith(Constants.Commands.Exit, StringComparison.InvariantCultureIgnoreCase))
                {
                    TerminateActorSystem();
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            } while (true);
        }

        private void ShortPause()
        {
            throw new NotImplementedException();
        }

        private static void ManageActors()
        {
            var receivePlaybackActorProps = Props.Create<PlaybackActor>();
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
