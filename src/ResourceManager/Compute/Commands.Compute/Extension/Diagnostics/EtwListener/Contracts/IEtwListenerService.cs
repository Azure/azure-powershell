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

using System.ServiceModel;

namespace Microsoft.VisualStudio.EtwListener.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(IEtwListenerClient), SessionMode = SessionMode.Required)]
    internal interface IEtwListenerService
    {
        [OperationContract]
        string GetSessionToken();

        [OperationContract(IsInitiating = false)]
        [FaultContract(typeof(TraceEventSessionCreationFault))]
        [FaultContract(typeof(ListenerServiceAuthenticationFault))]
        void StartSession(ListenerSessionConfiguration sessionConfiguration, string sessionToken);

        [OperationContract(IsInitiating = false)]
        [FaultContract(typeof(TraceEventSessionCreationFault))]
        [FaultContract(typeof(ListenerServiceAuthenticationFault))]
        void UpdateSession(ListenerSessionConfiguration sessionConfiguration, string sessionToken);

        [OperationContract(IsInitiating = false)]
        [FaultContract(typeof(ListenerServiceAuthenticationFault))]
        bool HeartBeat(string sessionToken);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void EndSession(string sessionToken);

    }
}
