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

using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSSignalRKeys
    {
        public string Name { get; }

        public string PrimaryKey { get; }

        public string PrimaryConnectionString { get; }

        public string SecondaryKey { get; }

        public string SecondaryConnectionString { get; }

        public PSSignalRKeys(string name, SignalRKeys obj)
        {
            Name = name;
            PrimaryKey = obj.PrimaryKey;
            PrimaryConnectionString = obj.PrimaryConnectionString;
            SecondaryKey = obj.SecondaryKey;
            SecondaryConnectionString = obj.SecondaryConnectionString;
        }
    }
}
