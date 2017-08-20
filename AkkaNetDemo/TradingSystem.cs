using System;
using System.Threading.Tasks;
using Akka.Actor;
using AkkaNetDemo.Messages;
using System.Diagnostics;
using System.Collections.Generic;

namespace AkkaNetDemo
{
    /// <summary>
    /// This class is the root level System for Stock Trading. 
    /// </summary>
    public class CalcService
    {
        /// <summary>
        /// This method starts the trade messaging process. A
        /// top level Akka.NET <see cref="ActorSystem"/> object,
        /// tradingSystem is created. Also, a <see cref="Start"/> message
        /// is defined. The ActorSystem creates the <see cref="Aggregatetables"/> to
        /// execute the trade.
        /// 
        /// NOTICE: The StockBroker uses <see cref="UntypedActor"/>.Ask(message) to
        /// execute the trade. <see cref="UntypedActor"/>.Ask(message) returns the
        /// underlying <see cref="Task"/> doing the asking. We'll Task.Wait() for the
        /// ask to complete. The response <see cref="Start"/> message of the trade 
        /// will be reflected in the Task.Result
        /// </summary>
        /// <param name="ticker">The ticker symbol of the stock you want to trade</param>
        /// <param name="shares">The number of shares to trade</param>
        /// <param name="tradeType">Describes the trade to
        /// execute.<see cref="TradeType"/>.Buy or TradeType.Sell.</param>
        /// <returns>The response <see cref="Start"/> message</returns>
        public static c4 Start(List<iner> iiner)
        {
           var timeTaken = Stopwatch.StartNew();



            

            //Create the ActorSystem
            var tradingSystem = ActorSystem.Create("CalcSystem");
            //Create the StockBroker
            var broker = tradingSystem.ActorOf(Props.Create(() => new Aggregatetables()), "TableAggregator");
            //Create the Trade message
          //  var trade = new Messages.c4(ticker, shares, tradeType,TradeStatus.Open,Guid.NewGuid());
            //Send the Trade message to the broker by way of an Ask(message). We want the underlying Task. 
            //Notice also that in Ask we are providing the Trade message as a generic type. This
            //is how the Task knows how to pass the response Trade message out to the caller

            var v = new inputt("HP", 44, TradeType.Buy, DateTime.Now);
            var gg = new iner("99");
            var task = broker.Ask<c4>(iiner);
            //Wait for the Task to complete. The task is completed upon the Broker receiving
            //response Trade message.
            task.Wait();
           timeTaken.Stop();
            //Console.WriteLine("time "+timeTaken.ElapsedMilliseconds.ToString());

            task.Result.Message = timeTaken.ElapsedMilliseconds.ToString();


            // timeTaken.Stop();


            //Return the response Trade message.
            return task.Result;
        }
    }
}
