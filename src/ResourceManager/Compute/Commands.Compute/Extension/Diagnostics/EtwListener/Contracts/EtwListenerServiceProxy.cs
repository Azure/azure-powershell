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

using System.Diagnostics;

namespace Microsoft.VisualStudio.EtwListener.Common.Contracts
{
    /// <summary>
    /// Etw listener service expects the client to get the session token, 
    /// then send this token in all further requests to mitigate the replay attack.
    /// This is a proxy class that holds the session token and add it to all further requests.
    /// </summary>
    internal class EtwListenerServiceProxy
    {
        private readonly IEtwListenerService etwListenerService;
        private readonly string sessionToken;

        public EtwListenerServiceProxy(IEtwListenerService etwListenerService, string sessionToken)
        {
            Debug.Assert(etwListenerService != null, $"{nameof(etwListenerService)} should not be null");
            Debug.Assert(!string.IsNullOrEmpty(sessionToken), $"{nameof(sessionToken)} should not be null or empty");

            this.etwListenerService = etwListenerService;
            this.sessionToken = sessionToken;
        }

        public void StartSession(ListenerSessionConfiguration sessionConfiguration)
        {
            this.etwListenerService.StartSession(sessionConfiguration, this.sessionToken);
        }

        public bool HeartBeat()
        {
            return this.etwListenerService.HeartBeat(this.sessionToken);
        }

        public void UpdateSession(ListenerSessionConfiguration sessionConfiguration)
        {
            this.etwListenerService.UpdateSession(sessionConfiguration, this.sessionToken);
        }

        public void EndSession()
        {
            this.etwListenerService.EndSession(this.sessionToken);
        }

    }
}
