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
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    /// <summary>
    /// Class to enable automatic retry of TaskCanceledExsceptions.
    /// Note that this follows the calling pattern in PowerShell, which does not pass cancellation tokens from
    /// the base cmdlet
    /// </summary>
    public class CancelRetryHandler : DelegatingHandler, ICloneable
    {
        static readonly string[] TestModeLiveValues = { "Record", "None", "Live" };
        const string TestModeVariableKey = "Azure_Test_Mode";
        public CancelRetryHandler()
        {
            WaitInterval = TimeSpan.Zero;
        }
        public CancelRetryHandler(TimeSpan waitInterval, int maxTries)
        {
            WaitInterval = waitInterval;
            MaxTries = maxTries;
        }

        public TimeSpan WaitInterval { get; set; } = TimeSpan.Zero;

        public int MaxTries { get; set; } = 3;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int tries = 0;
            do
            {
                using (var source = new CancellationTokenSource())
                {
                    try
                    {
                        return await base.SendAsync(request, source.Token).ConfigureAwait(false);
                    }
                    catch (TaskCanceledException) when (tries++ < MaxTries)
                    {
                        SleepIfRunningLive(WaitInterval);
                    }
                }
            }
            while (true);
        }

        void SleepIfRunningLive(TimeSpan timeSpan)
        {
            var testModeSetting = Environment.GetEnvironmentVariable(TestModeVariableKey);
            if (string.IsNullOrWhiteSpace(testModeSetting) || TestModeLiveValues.Any( v => string.Equals(v, testModeSetting, StringComparison.OrdinalIgnoreCase)))
            {
                Thread.Sleep(timeSpan);
            }
        }

        public object Clone()
        {
            return new CancelRetryHandler(WaitInterval, MaxTries);
        }
    }
}
