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
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore
{
    public class InvokeCommandCmdletInfo : CmdletsInfo
    {
        public InvokeCommandCmdletInfo(Uri connUri, PSCredential cred, ScriptBlock script)
        {
            cmdletName = "Invoke-Command";

            cmdletParams = new List<CmdletParam>();

            if (connUri != null)
            {
                cmdletParams.Add(new CmdletParam("ConnectionUri", connUri));
            }

            if (cred != null)
            {
                cmdletParams.Add(new CmdletParam("Credential", cred));
            }

            if (script != null)
            {
                cmdletParams.Add(new CmdletParam("ScriptBlock", script));
            }
        }
    }
}