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
using System.ServiceModel;

namespace Microsoft.VisualStudio.EtwListener.Common.Contracts
{
    /// <summary>
    /// Interface defining the client (Visual Studio) portion of the ETW listener-VS diagnostic viewer contract
    /// </summary>
    internal interface IEtwListenerClient
    {
        /// <summary>
        /// Reports captured ETW events to VS
        /// </summary>
        /// <param name="eventData">Captured event data</param>
        /// <param name="thottled">Indicates whether some captured event data was omitted (dropped) due to excessive inflow rate.
        /// The client has an opportunity to report this fact to the user, who can then try to change ETW provider setup
        /// (e.g. capture only error/warning events)</param>
        [OperationContract(IsOneWay = true)]
        void EtwEventsCaptured(IEnumerable<EtwEventData> eventData, bool thottled);
    }
}
