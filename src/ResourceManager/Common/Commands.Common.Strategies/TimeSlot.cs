namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// TimeSlot is a node of a singly linked list of TimeSlots.
    /// The last node of the list is always an empty time slot
    /// - Duration = 0.
    /// - Next = null.
    /// - TaskCount = 0.
    /// </summary>
    public sealed class TimeSlot
    {
        public int Duration { get; private set; }

        public int TaskCount { get; private set; }

        public TimeSlot Next { get; private set; }

        public bool IsLast => Next == null;

        public TimeSlot() : this(0, 0, null) { }

        TimeSlot(int duration, int taskCount, TimeSlot next)
        {
            Duration = duration;
            TaskCount = taskCount;
            Next = next;
        }

        public TimeSlot AddTask(int duration)
        {
            if (duration <= 0)
            {
                return this;
            }
            else if (Next == null)
            {                
                Next = new TimeSlot();
                Duration = duration;
                TaskCount = 1;
                return Next;
            }
            else if (duration < Duration)
            {
                Next = new TimeSlot(Duration - duration, TaskCount, Next);
                Duration = duration;
                TaskCount++;
                return Next;
            }
            else // if (Duration <= duration)
            {
                TaskCount++;
                return Next.AddTask(duration - Duration);
            }
        }

        public double GetTaskProgress(int duration)
            => duration <= Duration || Next == null 
                ? GetTimeSlotProgress(duration)
                : GetTimeSlotProgress(Duration) + Next.GetTaskProgress(duration - Duration);

        double GetTimeSlotProgress(double duration)
            => duration / TaskCount;
    }
}
