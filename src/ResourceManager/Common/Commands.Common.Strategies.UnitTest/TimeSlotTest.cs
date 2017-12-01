using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest
{
    [TestClass]
    public class TimeSlotTest
    {
        [TestMethod]
        public void AddTest()
        {
            var first = new TimeSlot();

            Assert.AreEqual(0, first.Duration);
            Assert.AreEqual(0, first.TaskCount);
            Assert.AreEqual(null, first.Next);

            var next = first.AddTask(50);

            Assert.AreEqual(50, first.Duration);
            Assert.AreEqual(1, first.TaskCount);
            Assert.AreEqual(next, first.Next);

            Assert.AreEqual(10.0, first.GetTaskProgress(10));

            Assert.AreEqual(0, next.Duration);
            Assert.AreEqual(0, next.TaskCount);
            Assert.AreEqual(null, next.Next);

            var next2 = first.AddTask(50);

            Assert.AreEqual(50, first.Duration);
            Assert.AreEqual(2, first.TaskCount);
            Assert.AreEqual(next2, first.Next);
            Assert.AreEqual(next, first.Next);

            Assert.AreEqual(20.0, first.GetTaskProgress(40));

            Assert.AreEqual(0, next2.Duration);
            Assert.AreEqual(0, next2.TaskCount);
            Assert.AreEqual(null, next2.Next);

            var next3 = first.AddTask(30);
            Assert.AreEqual(30, first.Duration);
            Assert.AreEqual(3, first.TaskCount);
            Assert.AreEqual(next3, first.Next);

            Assert.AreEqual(3.0, first.GetTaskProgress(9));

            Assert.AreEqual(20, next3.Duration);
            Assert.AreEqual(2, next3.TaskCount);
            Assert.AreEqual(next2, next3.Next);
            Assert.AreEqual(next, next3.Next);

            Assert.AreEqual(10.0 + 5, first.GetTaskProgress(40));

            Assert.AreEqual(0, next2.Duration);
            Assert.AreEqual(0, next2.TaskCount);
            Assert.AreEqual(null, next2.Next);

            var next4 = first.AddTask(75);
            Assert.AreEqual(25, next2.Duration);
            Assert.AreEqual(1, next2.TaskCount);
            Assert.AreEqual(next4, next2.Next);

            Assert.AreEqual((30.0 / 4) + (20.0 / 3) + 20, first.GetTaskProgress(70));

            Assert.AreEqual(0, next4.Duration);
            Assert.AreEqual(0, next4.TaskCount);
            Assert.AreEqual(null, next4.Next);
        }
    }
}
