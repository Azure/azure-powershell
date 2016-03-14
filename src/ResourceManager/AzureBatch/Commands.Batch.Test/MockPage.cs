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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Batch.Test
{
    public class MockPage<T> : IPage<T>, IEnumerable<T>, IEnumerable
    {
        private readonly IList<T> items;

        public MockPage(IList<T> items = null)
        {
            this.items = items;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (items == null) ? Enumerable.Empty<T>().GetEnumerator() : items.GetEnumerator();
        }

        public string NextPageLink { get; private set; }
    }
}
