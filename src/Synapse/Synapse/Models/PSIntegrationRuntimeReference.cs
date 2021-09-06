﻿// ----------------------------------------------------------------------------------
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

using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSIntegrationRuntimeReference
    {
        public PSIntegrationRuntimeReference(IntegrationRuntimeReference integrationRuntimeReference)
        {
            this.Type = integrationRuntimeReference?.Type;
            this.ReferenceName = integrationRuntimeReference?.ReferenceName;
            this.Parameters = integrationRuntimeReference?.Parameters;
        }

        public IntegrationRuntimeReferenceType? Type { get; set; }

        public string ReferenceName { get; set; }

        public IDictionary<string, object> Parameters { get; set; }
    }
}
