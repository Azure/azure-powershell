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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PsAadOrApiKeyAuthOption
    {
        [Ps1Xml(Label = "AadAuthFailureMode", Target = ViewControl.List, Position = 0)]
        public PSAadAuthFailureMode? AadAuthFailureMode { get; set; }

        public static explicit operator PsAadOrApiKeyAuthOption(DataPlaneAadOrApiKeyAuthOption v)
        {
            AadAuthFailureMode? aadAuthFailureMode = v?.AadAuthFailureMode;

            if (v == null)
            {
                return null;
            }
            else if (aadAuthFailureMode.HasValue)
            {
                return new PsAadOrApiKeyAuthOption
                {
                    AadAuthFailureMode = (PSAadAuthFailureMode)aadAuthFailureMode.Value
                };
            }
            else
            {
                return new PsAadOrApiKeyAuthOption();
            }
        }

        public static explicit operator DataPlaneAadOrApiKeyAuthOption(PsAadOrApiKeyAuthOption v)
        {
            PSAadAuthFailureMode? aadAuthFailureMode = v?.AadAuthFailureMode;

            if (v == null)
            {
                return null;
            }
            else if (aadAuthFailureMode.HasValue)
            {
                return new DataPlaneAadOrApiKeyAuthOption
                {
                    AadAuthFailureMode = (AadAuthFailureMode)aadAuthFailureMode.Value
                };
            }
            else
            {
                return new DataPlaneAadOrApiKeyAuthOption();
            }
        }
    }
}
