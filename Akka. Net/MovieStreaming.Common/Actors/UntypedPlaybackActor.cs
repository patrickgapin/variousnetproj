﻿using System;
using Akka.Actor;
using MovieStreaming.Common.Messages;

namespace MovieStreaming.Common.Actors
{
    public class UntypePlaybackActor : UntypedActor
    {
        public UntypePlaybackActor()
        {
            Console.WriteLine("Creating a PlaybackActor");
        }

        protected override void OnReceive(object message)
        {
            if (message is string) { Console.WriteLine("Received movie title " + message); }
            else if (message is int) { Console.WriteLine("Received user ID " + message); }
            else if (message is PlayMovieMessage)
            {
                var passedMessage = message as PlayMovieMessage;
                Console.WriteLine("Received movie title " + passedMessage.MovieTitle);
                Console.WriteLine("Received user ID " + passedMessage.UserID);
            }
            else { Unhandled(message); };
        }
    }
}
