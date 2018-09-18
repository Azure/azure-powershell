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

using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    internal static class IndexRangeHelper
    {
        public static IEnumerable<IndexRange> ChunkRangesBySize(IEnumerable<IndexRange> extents, int pageSizeInBytes)
        {
            var extentRanges = extents.SelectMany(e => e.PartitionBy(pageSizeInBytes));
            var extentQueue = new Queue<IndexRange>(extentRanges);

            if (extentQueue.Count == 0)
            {
                yield break;
            }

            // move to next start position
            do
            {
                var result = extentQueue.Dequeue();
                while (result.Length < pageSizeInBytes && extentQueue.Count > 0)
                {
                    var nextRange = extentQueue.Peek();
                    if (!nextRange.Abuts(result))
                    {
                        break;
                    }
                    var mergedRange = nextRange.Merge(result);
                    if (mergedRange.Length <= pageSizeInBytes)
                    {
                        result = mergedRange;
                        extentQueue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                yield return result;
            } while (extentQueue.Count > 0);
        }

    }
}