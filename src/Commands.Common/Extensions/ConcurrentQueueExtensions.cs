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

using System.Collections.Concurrent;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class ConcurrentQueueExtensions
    {
        private const int Capacity = 500;
        public static void CheckAndEnqueue(this ConcurrentQueue<string> queue, string item)
        {
            if (queue == null || item == null)
            {
                return;
            }
            lock (queue)
            {
                while (queue.Count >= Capacity)
                {
                    string result;
                    queue.TryDequeue(out result);
                }
                queue.Enqueue(item);
            }
        }
    }
}
