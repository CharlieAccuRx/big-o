using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace BigO
{
    [TestFixture]
    public class Tests
    {
        [TestCase(new int[] { }, false)]
        [TestCase(new[] { 0 }, false)]
        [TestCase(new[] { 0, 1 }, false)]
        [TestCase(new[] { 0, 0 }, true)]
        [TestCase(new[] { 0, 0, 0 }, true)]
        [TestCase(new[] { 0, 0, 1 }, true)]
        public void Test(int[] numbers, bool expectedResult)
        {
            // Act
            var result = Algorithm.DoesArrayContainDuplicates(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void SpeedTest()
        {
            var inputSize = 100_000;
            var iterations = 250;

            _RunAlgorithmAndLogTime(Algorithm.DoesArrayContainDuplicates, iterations, inputSize);
        }

        private static void _RunAlgorithmAndLogTime(Func<int[], bool> runAlgorithm, int iterations, int inputSize)
        {
            var stopwatch = new Stopwatch();
            var random = new Random();
            var timesTaken = new long[iterations];

            for (var i = 0; i < iterations; i++)
            {
                var numbers = Enumerable.Repeat(0, inputSize).Select(_ => random.Next()).ToArray();

                stopwatch.Reset();
                stopwatch.Start();
                runAlgorithm(numbers);

                timesTaken[i] = stopwatch.ElapsedTicks;
            }

            var averageMilliseconds = Enumerable.Average(timesTaken) / TimeSpan.TicksPerMillisecond;

            Console.WriteLine($"{runAlgorithm.Method.Name}: Took on average {averageMilliseconds}ms");
        }
    }

}