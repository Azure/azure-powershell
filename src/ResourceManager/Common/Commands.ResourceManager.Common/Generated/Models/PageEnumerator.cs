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

namespace Microsoft.Azure.Internal.Subscriptions.Models
{
    public class PageEnumerator : IEnumerator<Subscription>
    {
        private ISubscriptionClient _client;
        private IEnumerator<Subscription> _currentEnumerator;
        private string _nextPageLink;

        public PageEnumerator(ISubscriptionClient client)
        {
            IPage<Subscription> tempPage = client.Subscriptions.List();
            _client = client;
            _currentEnumerator = tempPage.GetEnumerator();
            _nextPageLink = tempPage.NextPageLink;
        }

        public Subscription Current
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
            if (_currentEnumerator.MoveNext())
            {
                return true;
            }

            if (_nextPageLink == null)
            {
                return false;
            }

            IPage<Subscription> tempPage = _client.Subscriptions.ListNext(_nextPageLink);
            _currentEnumerator = tempPage.GetEnumerator();
            _nextPageLink = tempPage.NextPageLink;
            return this.MoveNext();
        }

        public void Reset()
        {
            IPage<Subscription> tempPage = _client.Subscriptions.List();
            _currentEnumerator = tempPage.GetEnumerator();
            _nextPageLink = tempPage.NextPageLink;
        }
    }
}
