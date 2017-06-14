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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    public abstract partial class RdsCmdlet : AzureSMCmdlet
    {

        public new void WriteObject(object sendToPipeline)
        {
            if (theJob != null)
            {
                theJob.Output.Add(PSObject.AsPSObject(sendToPipeline));
            }
            else
            {
                this.CommandRuntime.WriteObject(sendToPipeline);
            }
        }

        public new void WriteError(ErrorRecord errorRecord)
        {
            if (theJob != null)
            {
                theJob.Error.Add(errorRecord);
            }
            else
            {
                this.CommandRuntime.WriteError(errorRecord);
            }
        }

        public new void WriteVerbose(string text)
        {
            if (theJob != null)
            {
                theJob.Verbose.Add(new VerboseRecord(text));
            }
            else
            {
                this.CommandRuntime.WriteVerbose(text);
            }
        }

        public new void WriteWarning(string text)
        {
            if (theJob != null)
            {
                theJob.Warning.Add(new WarningRecord(text));
            }
            else
            {
                this.CommandRuntime.WriteWarning(text);
            }
        }
    }
}
