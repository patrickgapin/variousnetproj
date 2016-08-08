using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Helpers
{
    public static class Constants
    {
        public const string MovieStreamActorSystem = "MovieStreamActorSystem";

        public static class Commands
        {
            public const string Play = "Play";
            public const string Stop = "Stop";
            public const string Exit = "Exit";
        }

        public static class ActorsNames
        {
            public const string MovieStreamActorSystem = "MovieStreamActorSystem";
            public const string Playback = "Playback";
            public const string UserCoordinator = "UserCoordinator";
            public const string MoviePlayCounter = "MoviePlayCounter";
        }

        public static class ActorsSelectionPaths
        {                        
            public const string UserCoordinator = "/user/Playback/UserCoordinator";
            public const string MoviePlayCounter = "/user/Playback/PlaybackStatistics/MoviePlayCounter";
            
        }
    }
}
