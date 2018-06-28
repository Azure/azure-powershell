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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest
{
    public class TimeSlotTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddTest()
        {
            var first = new TimeSlot();

            Assert.Equal(0, first.Duration);
            Assert.Equal(0, first.TaskCount);
            Assert.Equal(null, first.Next);

            var next = first.AddTask(50);

            Assert.Equal(50, first.Duration);
            Assert.Equal(1, first.TaskCount);
            Assert.Equal(next, first.Next);

            Assert.Equal(10.0, first.GetTaskProgress(10));

            Assert.Equal(0, next.Duration);
            Assert.Equal(0, next.TaskCount);
            Assert.Equal(null, next.Next);

            var next2 = first.AddTask(50);

            Assert.Equal(50, first.Duration);
            Assert.Equal(2, first.TaskCount);
            Assert.Equal(next2, first.Next);
            Assert.Equal(next, first.Next);

            Assert.Equal(20.0, first.GetTaskProgress(40));

            Assert.Equal(0, next2.Duration);
            Assert.Equal(0, next2.TaskCount);
            Assert.Equal(null, next2.Next);

            var next3 = first.AddTask(30);
            Assert.Equal(30, first.Duration);
            Assert.Equal(3, first.TaskCount);
            Assert.Equal(next3, first.Next);

            Assert.Equal(3.0, first.GetTaskProgress(9));

            Assert.Equal(20, next3.Duration);
            Assert.Equal(2, next3.TaskCount);
            Assert.Equal(next2, next3.Next);
            Assert.Equal(next, next3.Next);

            Assert.Equal(10.0 + 5, first.GetTaskProgress(40));

            Assert.Equal(0, next2.Duration);
            Assert.Equal(0, next2.TaskCount);
            Assert.Equal(null, next2.Next);

            var next4 = first.AddTask(75);
            Assert.Equal(25, next2.Duration);
            Assert.Equal(1, next2.TaskCount);
            Assert.Equal(next4, next2.Next);

            Assert.Equal((30.0 / 4) + (20.0 / 3) + 20, first.GetTaskProgress(70));

            Assert.Equal(0, next4.Duration);
            Assert.Equal(0, next4.TaskCount);
            Assert.Equal(null, next4.Next);
        }
    }
}
