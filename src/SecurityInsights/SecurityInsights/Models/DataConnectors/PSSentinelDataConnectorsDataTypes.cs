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
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors
{
    public class PSSentinelDataConnectorDataType
    {

        public PSSentinelDataConnectorDataTypeCommon Alerts { get; set; }

        public PSSentinelDataConnectorDataTypeCommon DiscoveryLogs { get; set; }

        public PSSentinelDataConnectorDataTypeCommon Indicators { get; set; }

        public PSSentinelDataConnectorDataTypeCommon Logs { get; set; }

        public PSSentinelDataConnectorDataTypeCommon SharePoint { get; set; }

        public PSSentinelDataConnectorDataTypeCommon Exchange { get; set; }

    }
}
