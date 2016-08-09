using Akka.Actor;
using MovieStreaming.Common;
using MovieStreaming.Common.Helpers;

namespace MovieStreaming.Remote
{
    class Program
    {        
        static void Main(string[] args)
        {
            ColorConsole.WriteLineGray("Creating remote actor system [MovieStreamingActorSystem]");
            var remoteSystem = ActorSystem.Create(Constants.Remote.MovieStreamingActorSystem);                        
        }
        
    }
}
