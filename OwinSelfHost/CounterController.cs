Feature 10
Conlict with Feature 10

using System.Threading;
using System.Web.Http;
using Metrics;
using Timer = Metrics.Timer;

namespace OwinSelfHost
{
    public class CounterController : ApiController
    {
        private static int _gaugeValue;
        private static readonly Counter Counter = Metric.Counter("Counter.Counter", Unit.Items);
        private readonly Meter _meter = Metric.Meter("Errors", Unit.Items, TimeUnit.Minutes);
        private readonly Histogram _histogram = Metric.Histogram("Search Results", Unit.Items);


        [HttpGet]
        public int GetGauge(int value)
        {
            _gaugeValue = value;

            Metric.Gauge("Counter.Gauge", () => _gaugeValue, Unit.Items);

            return value;
        }

        [HttpGet]
        public int IncrementCounter()
        {
            Counter.Increment();

            return 0;
        }

        [HttpGet]
        public int DecrementCounter()
        {
            Counter.Decrement();

            return 0;
        }

        [HttpGet]
        public void Meter()
        {
            _meter.Mark();
        }

        [HttpGet]
        public int Histrogram(string documentId, int itemCount)
        {
            _histogram.Update(itemCount, documentId);

            return 0;
        }

        private readonly Timer _timer = Metric.Timer("Counter.Timer", Unit.Requests);

        [HttpGet]
        public int Timer(string documentId, int sleep)
        {
            using (_timer.NewContext(documentId))
            {
                Thread.Sleep(sleep);

                return 0;
            }
        }
    }
}