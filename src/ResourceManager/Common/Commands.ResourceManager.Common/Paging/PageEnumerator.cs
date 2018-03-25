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

using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Paging
{
    public class PageEnumerator<T> : IEnumerator<T>
    {
        private Func<IPage<T>> _list;
        private Func<string, IPage<T>> _listNext;
        private ulong _first;
        private ulong _skip;

        private IEnumerator<T> _currentEnumerator;
        private string _nextPageLink;

        public PageEnumerator(Func<IPage<T>> list, Func<string, IPage<T>> listNext, ulong first, ulong skip)
        {
            _list = list;
            _listNext = listNext;
            _first = first;
            _skip = skip;

            IPage<T> tempPage = _list();
            _currentEnumerator = tempPage.GetEnumerator();
            _nextPageLink = tempPage.NextPageLink;

            while (_skip > 0 && _currentEnumerator.MoveNext())
            {
                _skip--;
            }
        }

        public T Current
        {
            get
            {
                return _currentEnumerator.Current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            // SubscriptionClient is disposed later
        }

        public bool MoveNext()
        {
            if (_first == 0)
            {
                return false;
            }

            if (_currentEnumerator.MoveNext())
            {
                _first--;
                return true;
            }

            if (_nextPageLink == null)
            {
                return false;
            }

            IPage<T> tempPage = _listNext(_nextPageLink);
            _currentEnumerator = tempPage.GetEnumerator();
            _nextPageLink = tempPage.NextPageLink;
            return this.MoveNext();
        }

        public void Reset()
        {
            IPage<T> tempPage = _list();
            _currentEnumerator = tempPage.GetEnumerator();
            _nextPageLink = tempPage.NextPageLink;
        }
    }
}
