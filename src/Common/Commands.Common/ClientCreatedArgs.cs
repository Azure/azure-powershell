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
using System.Net.Http;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class ClientCreatedArgs : EventArgs
    {
        public object CreatedClient { get; set; }

        public Type ClientType { get; set; }

        public void AddHandlerToClient(DelegatingHandler handler)
        {
#if !NETSTANDARD1_6
            var withHandlerMethod = ClientType.GetMethod("WithHandler", new[] { typeof(DelegatingHandler) });
#else
            var withHandlerMethod = ClientType.GetTypeInfo().GetMethod("WithHandler", new[] { typeof(DelegatingHandler) });
#endif
            CreatedClient = withHandlerMethod.Invoke(CreatedClient, new object[] { handler });
        }
    }
}
