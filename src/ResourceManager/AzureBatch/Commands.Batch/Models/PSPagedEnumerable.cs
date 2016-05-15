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

using Microsoft.Azure.Batch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Batch.Models
{
    internal class PSPagedEnumerable<T1, T2> : IPagedEnumerable<T1>
        where T1 : class
        where T2 : class
    {
        internal IPagedEnumerable<T2> omPagedEnumerable;
        private Func<T2, T1> mappingFunction;

        internal PSPagedEnumerable(IPagedEnumerable<T2> omPagedEnumerable, Func<T2, T1> mappingFunction)
        {
            if (omPagedEnumerable == null)
            {
                throw new ArgumentNullException("omAsyncEnumerable");
            }
            this.omPagedEnumerable = omPagedEnumerable;

            if (mappingFunction == null)
            {
                throw new ArgumentNullException("mappingFunction");
            }
            this.mappingFunction = mappingFunction;
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new PSPagedEnumerator<T1, T2>(this.omPagedEnumerable.GetPagedEnumerator(), this.mappingFunction);
        }

        // IEnumerable<T>
        public IEnumerator<T1> GetEnumerator()
        {
            return new PSPagedEnumerator<T1, T2>(this.omPagedEnumerable.GetPagedEnumerator(), this.mappingFunction);
        }

        // IPagedEnumerable
        public IPagedEnumerator<T1> GetPagedEnumerator()
        {
            return new PSPagedEnumerator<T1, T2>(this.omPagedEnumerable.GetPagedEnumerator(), this.mappingFunction);
        }

        internal static IEnumerable<T1> CreateWithMaxCount(
            IPagedEnumerable<T2> omAsyncEnumerable, Func<T2, T1> mappingFunction, int maxCount, Action logMaxCount = null)
        {
            PSPagedEnumerable<T1, T2> asyncEnumerable = new PSPagedEnumerable<T1, T2>(omAsyncEnumerable, mappingFunction);

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

    internal class PSPagedEnumerator<T1, T2> : IPagedEnumerator<T1>, IEnumerator<T1>
        where T1 : class
        where T2 : class
    {
        internal IPagedEnumerator<T2> omEnumerator;
        private Func<T2, T1> mappingFunction;

        internal PSPagedEnumerator(IPagedEnumerator<T2> omEnumerator, Func<T2, T1> mappingFunction)
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

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return this.omEnumerator.MoveNextAsync(cancellationToken);
        }

        public Task ResetAsync(CancellationToken cancellationToken)
        {
            return this.omEnumerator.ResetAsync(cancellationToken);
        }

        public void Reset()
        {
            ((IEnumerator<T2>)this.omEnumerator).Reset();
        }

        public void Dispose()
        {
            this.omEnumerator.Dispose();
        }
    }
}
