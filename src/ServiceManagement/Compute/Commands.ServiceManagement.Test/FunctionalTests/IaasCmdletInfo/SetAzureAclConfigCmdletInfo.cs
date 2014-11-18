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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class SetAzureAclConfigCmdletInfo : CmdletsInfo
    {
        public SetAzureAclConfigCmdletInfo(string aclConfig, NetworkAclObject aclObj, int? order, string aclAction, string remoteSubnet, string desc, int? ruleId)
        {
            this.cmdletName = Utilities.SetAzureAclConfigCmdletName;

            switch(aclConfig)
            {
            case "AddRule" : 
                    this.cmdletParams.Add(new CmdletParam(aclConfig));
                    this.cmdletParams.Add(new CmdletParam("ACL", aclObj));
                    this.cmdletParams.Add(new CmdletParam("Action", aclAction));
                    this.cmdletParams.Add(new CmdletParam("RemoteSubnet", remoteSubnet));

                    if (order.HasValue)
                    {
                        this.cmdletParams.Add(new CmdletParam("Order", order));
                    }
                    if (desc != null)
                    {
                        this.cmdletParams.Add(new CmdletParam("Description", desc));
                    }                    
                    break;
                                
                case "RemoveRule" : 
                    this.cmdletParams.Add(new CmdletParam(aclConfig));
                    this.cmdletParams.Add(new CmdletParam("ACL", aclObj));
                    this.cmdletParams.Add(new CmdletParam("RuleID", ruleId));
                    break;
                                
                case "SetRule" : 
                    this.cmdletParams.Add(new CmdletParam(aclConfig));
                    this.cmdletParams.Add(new CmdletParam("ACL", aclObj));
                    this.cmdletParams.Add(new CmdletParam("RuleID", ruleId));

                    if (order.HasValue)
                    {
                        this.cmdletParams.Add(new CmdletParam("Order", order));
                    }
                    if (aclAction != null)
                    {
                        this.cmdletParams.Add(new CmdletParam("Action", aclAction));
                    }
                    if (remoteSubnet != null)
                    {
                        this.cmdletParams.Add(new CmdletParam("RemoteSubnet", remoteSubnet));
                    }
                    if (desc != null)
                    {
                        this.cmdletParams.Add(new CmdletParam("Description", desc));
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
