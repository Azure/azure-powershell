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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.Azure.Internal.Subscriptions.Models
{
    public class PageEnumerable : IEnumerable<Subscription>, IDisposable
    {
        private ISubscriptionClient _client;

        public PageEnumerable(ISubscriptionClient client)
        {
            _client = client;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing )
            {
                ISubscriptionClient client = Interlocked.Exchange(ref _client, null);
                if (client!= null)
                {
#if DEBUG
                    if (!TestMockSupport.RunningMocked)
                    {
#endif
                        client.Dispose();
#if DEBUG
                    }
#endif
                }
            }
        }

        public IEnumerator<Subscription> GetEnumerator()
        {
            return new PageEnumerator(_client);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
