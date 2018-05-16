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

using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{ 
    public class AzureHttpRetryPolicy : RetryPolicy<HttpStatusCodeErrorDetectionStrategy>
    {
        private const int DefaultNumberOfAttempts = 3;
        private static readonly TimeSpan DefaultBackoffDelta = new TimeSpan(0, 0, 10);
        private static readonly TimeSpan DefaultMaxBackoff = new TimeSpan(0, 0, 10);
        private static readonly TimeSpan DefaultMinBackoff = new TimeSpan(0, 0, 1);
        private static readonly RetryStrategy DefaultStrategy = new ExponentialBackoffRetryStrategy(
                DefaultNumberOfAttempts,
                DefaultMinBackoff,
                DefaultMaxBackoff,
                DefaultBackoffDelta);

        public AzureHttpRetryPolicy() : base(DefaultStrategy)
        {
        }

        public override TResult ExecuteAction<TResult>(Func<TResult> func)
        {
            while (true)
            {
                try
                {
                    return base.ExecuteAction(func);
                }
                catch (TaskCanceledException)
                {
                    Thread.Sleep(DefaultMinBackoff);
                }
            }
        }
    }
}
