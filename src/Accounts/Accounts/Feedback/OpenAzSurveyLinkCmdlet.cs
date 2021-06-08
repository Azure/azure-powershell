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

using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Survey
{
    [Cmdlet(VerbsCommon.Open, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SurveyLink"), OutputType(typeof(void))]
    public class OpenAzSurveyLinkCmdlet : AzureRMCmdlet
    {
        private const string _surveyLinkFormat = "https://aka.ms/azpssurvey?Q_CHL=INTERCEPT";

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteInformation(new HostInformationMessage() { Message = $"Opening the default browser to {_surveyLinkFormat}" }, new string[] { "PSHOST" });
            Process.Start(new ProcessStartInfo() { FileName = _surveyLinkFormat, UseShellExecute = true});
        }
    }
}
