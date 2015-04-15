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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Batch;

namespace Microsoft.Azure.Commands.Batch.Models
{
    internal class PSAsyncEnumerable<T1, T2> : IEnumerableAsyncExtended<T1>
        where T1 : class
        where T2 : class
    {
        internal IEnumerableAsyncExtended<T2> omAsyncEnumerable;
        private Func<T2, T1> mappingFunction;

        internal PSAsyncEnumerable(IEnumerableAsyncExtended<T2> omAsyncEnumerable, Func<T2, T1> mappingFunction)
        {
            if (omAsyncEnumerable == null)
            {
                throw new ArgumentNullException("omAsyncEnumerable");
            }
            this.omAsyncEnumerable = omAsyncEnumerable;

            if (mappingFunction == null)
            {
                throw new ArgumentNullException("mappingFunction");
            }
            this.mappingFunction = mappingFunction;
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new PSAsyncEnumerator<T1, T2>(omAsyncEnumerable.GetAsyncEnumerator(), this.mappingFunction);
        }

        // IEnumerable<T>
        public IEnumerator<T1> GetEnumerator()
        {
            return new PSAsyncEnumerator<T1, T2>(omAsyncEnumerable.GetAsyncEnumerator(), this.mappingFunction);
        }

        // IEnumerableAsyncExtended
        public IAsyncEnumerator<T1> GetAsyncEnumerator()
        {
            return new PSAsyncEnumerator<T1, T2>(omAsyncEnumerable.GetAsyncEnumerator(), this.mappingFunction);
        }

        internal static IEnumerable<T1> CreateWithMaxCount(
            IEnumerableAsyncExtended<T2> omAsyncEnumerable, Func<T2, T1> mappingFunction, int maxCount, Action logMaxCount = null)
        {
            PSAsyncEnumerable<T1, T2> asyncEnumerable = new PSAsyncEnumerable<T1, T2>(omAsyncEnumerable, mappingFunction);

            if (maxCount <= 0)
            {
                return asyncEnumerable;
            }
            else
            {
                if (logMaxCount != null)
                {
                    logMaxCount();
                }
                return asyncEnumerable.Take(maxCount);
            }
        }
    }

    internal class PSAsyncEnumerator<T1, T2> : IAsyncEnumerator<T1>, IEnumerator<T1>
        where T1 : class
        where T2 : class
    {
        internal IAsyncEnumerator<T2> omEnumerator;
        private Func<T2, T1> mappingFunction;

        internal PSAsyncEnumerator(IAsyncEnumerator<T2> omEnumerator, Func<T2, T1> mappingFunction)
        {
            if (omEnumerator == null)
            {
                throw new ArgumentNullException("omEnumerator");
            }
            this.omEnumerator = omEnumerator;

            if (mappingFunction == null)
            {
                throw new ArgumentNullException("mappingFunction");
            }
            this.mappingFunction = mappingFunction;
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public T1 Current
        {
            get
            {
                return this.mappingFunction(this.omEnumerator.Current);
            }
        }

        public bool MoveNext()
        {
            return ((IEnumerator<T2>)this.omEnumerator).MoveNext();
        }

        public Task<bool> MoveNextAsync()
        {
            return this.omEnumerator.MoveNextAsync();
        }

        public void Reset()
        {
            this.omEnumerator.Reset();
        }

        public void Dispose()
        {
            this.omEnumerator.Dispose();
        }
    }
}
