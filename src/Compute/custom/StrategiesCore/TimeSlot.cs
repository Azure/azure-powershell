// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// TimeSlot is a node of a singly linked list of TimeSlots.
    /// The last node of the list is always an empty time slot:
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
            else if (IsLast)
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
            => IsLast
                ? duration
            : duration <= Duration
                ? GetTimeSlotProgress(duration)
                : GetTimeSlotProgress(Duration) + Next.GetTaskProgress(duration - Duration);

        double GetTimeSlotProgress(double duration)
            => duration / TaskCount;
    }
}
