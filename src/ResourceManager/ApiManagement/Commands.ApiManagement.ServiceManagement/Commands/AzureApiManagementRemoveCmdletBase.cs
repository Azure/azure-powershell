//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using System.Management.Automation;

    abstract public class AzureApiManagementRemoveCmdletBase : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional. Default value is false.")]
        public SwitchParameter PassThru { get; set; }

        public abstract string ActionWarning { get; }

        public abstract string ActionDescription { get; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (!ShouldProcess(
                    ActionDescription,
                    ActionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            ExecuteRemoveLogic();

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        protected abstract void ExecuteRemoveLogic();
    }
}