using Akka.Actor;
using AkkaNetDemo.Messages;
using System.Collections.Generic;

namespace AkkaNetDemo
{
    /// <summary>
    ///     An object the describes a Stock Broker. A StockBroker will
    ///     use an <see cref="FloorTrader" /> to execute a trade.
    /// </summary>
    public class Aggregatetables : ReceiveActor
    {
        private IActorRef originalSender;
        private ISet<IActorRef> refs;

        /// <summary>
        ///     This overrideen method provides the behavior a StockBroker executes
        ///     upon receipt of a message. If the <see cref="c4" /> message's
        ///     <see cref="TradeType" /> = TradeType.Sell, the StockBroker
        ///     creates a Sell <see cref="FloorTrader" /> and calls
        ///     <see cref="UntypedActor" />.Forward() to pass the Trade message
        ///     on.
        ///     If the Trade is TradeType.Buy, a Buy Floor Trader is created and
        ///     the Trade message is forwarded.
        /// </summary>
        /// <param name="message">The <see cref="c4" /> message to process</param>
        // protected override void OnReceive(object message)
        public Aggregatetables()
         {
            // var worker = system.ActorOf(Props.Create(() => new WorkerActor()));
            var worker= Context.ActorOf(Props.Create(() => new FloorTrader()), "SellFloorTrader");
            // var worker2 = system.ActorOf(Props.Create(() => new WorkerActor()));
            var worker2 = Context.ActorOf(Props.Create(() => new FloorTrader()), "BuyFloorTrader");
            var worker3 = Context.ActorOf(Props.Create(() => new FloorTrader()), "BuyFloor3Trader");
            var worker4 = Context.ActorOf(Props.Create(() => new FloorTrader()), "BuyFloor4Trader");
            var worker5 = Context.ActorOf(Props.Create(() => new FloorTrader()), "BuyFloor5Trader");
            List<IActorRef> cc = new List<IActorRef>();
            cc.Add(worker);
            cc.Add(worker2);
            cc.Add(worker3);
            cc.Add(worker4);
            cc.Add(worker5);
            refs = new HashSet<IActorRef>(cc);
            Receive<List<iner>>(x =>
            {


                originalSender = Sender;
                foreach (var aref in refs)
                {

                    //var g = x.ElementAt<ReceiveTimeout>(i);
                    //Console.WriteLine("aref" + aref);
                    //Console.WriteLine("g" + g);
                    job1 jj = new job1(7);
                    aref.Tell(jj);
                   // i++;
                }

                Become(Aggregating);
            });
            //if (trade != null)
            //{
            //    //Make sure you are processing only open trades
            //    if (trade.TradeStatus.Equals(TradeStatus.Open))
            //    {
            //        if (trade.TradeType.Equals(TradeType.Sell))
            //        {
            //            //create the Sell FloorTrader and forward the message
            //            var sellTrader = Context.ActorOf(Props.Create(() => new FloorTrader()), "SellFloorTrader");
            //            sellTrader.Forward(trade);
            //        }
            //        else
            //        {
            //            //create the Buy FloorTrader and forward the message
            //            var buyTrader = Context.ActorOf(Props.Create(() => new FloorTrader()), "BuyFloorTrader");
            //            buyTrader.Forward(trade);
            //        }
            //    }
            //}

        }
        private void Aggregating()
        {
            var replies = new List<c4>();
            // when timeout occurred, we reply with what we've got so far
          //  Receive<ReceiveTimeout>(_ => ReplyAndStop(replies));
            Receive<c4>(x =>
            {
                if (refs.Remove(Sender)) replies.Add(x);
                if (refs.Count == 0) ReplyAndStop(replies);
            });


           // string g ="dfdf";
        }

        private void ReplyAndStop(List<c4> replies)
        {
            //originalSender.Tell(new AggregatedReply<T>(replies));
            replies[0].Shares = replies[0].Shares + replies[1].Shares;
            originalSender.Tell(replies[0]);
            Context.Stop(Self);
        }

    }
}