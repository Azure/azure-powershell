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

using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class IndexRangeComparer : IEqualityComparer<IndexRange>
    {
        public bool Equals(IndexRange first, IndexRange second)
        {
            return first.Equals(second);
        }

        public int GetHashCode(IndexRange range)
        {
            var hash = 17 + range.StartIndex.GetHashCode();
            hash = hash * 17 + range.EndIndex.GetHashCode();
            return hash;
        }
    }
}