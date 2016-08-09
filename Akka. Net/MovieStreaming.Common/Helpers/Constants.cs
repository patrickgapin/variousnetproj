
namespace MovieStreaming.Common.Helpers
{
    public static class Constants
    {        
        public static class Commands
        {
            public const string Play = "Play";
            public const string Stop = "Stop";
            public const string Exit = "Exit";
        }

        public static class ActorsNames
        {
            //public const string MovieStreamActorSystem = "MovieStreamActorSystem";
            public const string MovieStreamingActorSystem = "MovieStreamingActorSystem";
            public const string Playback = "Playback";
            public const string UserCoordinator = "UserCoordinator";
            public const string MoviePlayCounter = "MoviePlayCounter";
            public const string PlaybackStatistics = "PlaybackStatistics";
        }

        public static class ActorsSelectionPaths
        {                        
            public const string UserCoordinator = "/user/Playback/UserCoordinator";
            public const string MoviePlayCounter = "/user/Playback/PlaybackStatistics/MoviePlayCounter";
            
        }

        public static class Remote
        {
            public const string MovieStreamingActorSystem = "MovieStreamingActorSystem";
        }
    }
}
