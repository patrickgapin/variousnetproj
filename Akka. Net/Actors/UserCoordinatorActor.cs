using System;
using Akka.Actor;
using MovieStreaming.Messages;
using System.Collections.Generic;

namespace MovieStreaming.Actors
{
    public class UserCoordinatorActor : ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> users;

        public UserCoordinatorActor()
        {
            users = new Dictionary<int, IActorRef>();

            Receive<PlayMovieMessage>(message =>
            {
                CreateChildUserIfNotExists(message.UserID);
                var childActorReference = users[message.UserID];
                childActorReference.Tell(message);
            });

            Receive<StopMovieMessage>(message =>
            {
                CreateChildUserIfNotExists(message.UserID);
                var childActorReference = users[message.UserID];
                childActorReference.Tell(message);
            });
        }

        private void CreateChildUserIfNotExists(int userID)
        {
            if (!users.ContainsKey(userID))
            {
                var actor = Props.Create(() => new UserActor(userID));
                var newChildActorReference = Context.ActorOf(actor, "User" + userID);

                // var newChildActorReference = Context.ActorOf(Props.Create(() => new UserActor(userID)), "User" + userID);

                users[userID] = newChildActorReference;

                ColorConsole.WriteLineCyan("UserCoordinatorActor created new child UserActor for {0} (Total Users: {1}", userID, users.Count);
            }
        }

        #region Lifecycle hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PreRestart because: " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PostRestart because: " + reason);
            base.PostRestart(reason);
        }

        #endregion
    }
}
