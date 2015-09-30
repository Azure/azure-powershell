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

using System;
using System.Management.Automation;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Selects Microsoft Azure profile.
    /// </summary>
    [Cmdlet(VerbsCommon.Select, "AzureRMProfile"), OutputType(typeof(PSAzureProfile))]
    public class SelectAzureRMProfileCommand : AzureRMCmdlet
    {
        internal const string InMemoryProfileParameterSet = "InMemoryProfile";
        internal const string ProfileFromDiskParameterSet = "ProfileFromDisk";

        [Parameter(ParameterSetName = InMemoryProfileParameterSet, Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public AzureRMProfile Profile { get; set; }

        [Parameter(ParameterSetName = ProfileFromDiskParameterSet, Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string Path { get; set; }

        protected override void BeginProcessing()
        {
            // Do not access the DefaultContext when loading a profile
        }

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrEmpty(Path))
            {
                AzureRMCmdlet.DefaultProfile = new AzureRMProfile(Path);
            }
            else
            {
                AzureRMCmdlet.DefaultProfile = Profile;
            }

            if (AzureRMCmdlet.DefaultProfile == null)
            {
                throw new ArgumentException(Resources.AzureProfileMustNotBeNull);
            }

            WriteObject((PSAzureProfile)AzureRMCmdlet.DefaultProfile);
        }
    }
}
