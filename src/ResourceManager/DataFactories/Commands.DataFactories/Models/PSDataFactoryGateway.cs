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

using Microsoft.Azure.Management.DataFactories.Models;
using System;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    public class PSDataFactoryGateway
    {
        private readonly Gateway _gateway;

        public PSDataFactoryGateway()
        {
            _gateway = new Gateway { Properties = new GatewayProperties() };
        }

        public PSDataFactoryGateway(Gateway gateway)
        {
            if (gateway == null)
            {
                throw new ArgumentNullException("gateway");
            }

            _gateway = gateway;
        }

        public string Name
        {
            get { return _gateway.Name; }
            set { _gateway.Name = value; }
        }

        public string Description
        {
            get { return _gateway.Properties.Description; }
            set { _gateway.Properties.Description = value; }
        }

        public string Version
        {
            get { return _gateway.Properties.Version; }
            internal set { _gateway.Properties.Version = value; }
        }

        public string Status
        {
            get { return _gateway.Properties.Status; }
            internal set { _gateway.Properties.Status = value; }
        }

        public string VersionStatus
        {
            get { return _gateway.Properties.VersionStatus; }
            internal set { _gateway.Properties.VersionStatus = value; }
        }

        public DateTime? CreateTime
        {
            get { return _gateway.Properties.CreateTime; }
            internal set { _gateway.Properties.CreateTime = value; }
        }

        public DateTime? RegisterTime
        {
            get { return _gateway.Properties.RegisterTime; }
            internal set { _gateway.Properties.RegisterTime = value; }
        }

        public DateTime? LastConnectTime
        {
            get { return _gateway.Properties.LastConnectTime; }
            internal set { _gateway.Properties.LastConnectTime = value; }
        }

        public DateTime? ExpiryTime
        {
            get { return _gateway.Properties.ExpiryTime; }
            internal set { _gateway.Properties.ExpiryTime = value; }
        }

        public string ProvisioningState
        {
            get { return _gateway.Properties == null ? string.Empty : _gateway.Properties.ProvisioningState; }
        }

        public string Key
        {
            get { return _gateway.Properties.Key; }
            set { _gateway.Properties.Key = value; }
        }

        public Gateway ToGatewayDefinition()
        {
            return _gateway;
        }
    }
}
