namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class ConcurrentTaskProgress
    {
        public TimeSlot TimeSlot { get; }

        public int Begin { get; }

        public ConcurrentTaskProgress(TimeSlot timeSlot, int begin)
        {
            TimeSlot = timeSlot;
            Begin = begin;
        }

        public ConcurrentTaskProgress AddTask(int duration)
            => new ConcurrentTaskProgress(TimeSlot.AddTask(duration), Begin + duration);
    }
}
