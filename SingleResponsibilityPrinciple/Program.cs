using System;
using System.Reflection;

using SingleResponsibilityPrinciple.AdoNet;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {

            //  Updated URLTradeDataProvider object instead of a  StreamTradeDataProvider and pass the new data provider to the TradeProcessor
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SingleResponsibilityPrinciple.trades.txt");
            string urlData = "http://faculty.css.edu/tgibbons/trades4.txt";

            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            var tradeURLProvider = new URLTradeDataProvider(urlData);
            var tradeMapper = new SimpleTradeMapper();
            var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            var tradeStorage = new AdoNetTradeStorage(logger);        

            var tradeProcessor = new TradeProcessor(tradeURLProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

           






            Console.ReadKey();
        }
    }
}
