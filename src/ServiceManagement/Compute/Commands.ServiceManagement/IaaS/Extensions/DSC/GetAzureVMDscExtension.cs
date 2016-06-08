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

using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Gets the settings of the DSC extension on a particular VM.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        DscExtensionCmdletCommonBase.VirtualMachineDscExtensionCmdletNoun),
    OutputType(typeof(VirtualMachineDscExtensionContext))]
    public class GetAzureVMDscExtensionCommand : VirtualMachineExtensionCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }

        private void ExecuteCommand()
        {
            extensionName = DscExtensionCmdletConstants.ExtensionPublishedName;
            publisherName = DscExtensionCmdletConstants.ExtensionPublishedNamespace;

            List<ResourceExtensionReference> extensionRefs = GetPredicateExtensionList();
            WriteObject(
                extensionRefs == null ? null : extensionRefs.Select(
                r =>
                {
                    GetExtensionValues(r);
                    DscExtensionPublicSettings extensionPublicSettings = null;
                    try
                    {
                        extensionPublicSettings = DscExtensionSettingsSerializer.DeserializePublicSettings(PublicConfiguration);
                    }
                    catch (JsonException e)
                    {
                        this.ThrowTerminatingError(
                            new ErrorRecord(
                                new JsonException(
                                    String.Format(
                                        CultureInfo.CurrentUICulture,
                                        Properties.Resources.AzureVMDscWrongSettingsFormat,
                                        PublicConfiguration),
                                    e),
                                string.Empty,
                                ErrorCategory.ParserError,
                                null));
                    }
                    var context = new VirtualMachineDscExtensionContext
                    {
                        ExtensionName = r.Name,
                        Publisher = r.Publisher,
                        ReferenceName = r.ReferenceName,
                        Version = r.Version,
                        State = r.State,
                        RoleName = VM.GetInstance().RoleName,
                        PublicConfiguration = PublicConfiguration,
                        PrivateConfiguration = SecureStringHelper.GetSecureString(PrivateConfiguration)
                    };

                    if (extensionPublicSettings == null)
                    {
                        context.ModulesUrl = string.Empty;
                        context.ConfigurationFunction = string.Empty;
                        context.Properties = null;
                    }
                    else
                    {
                        context.ModulesUrl = extensionPublicSettings.ModulesUrl;
                        context.ConfigurationFunction = extensionPublicSettings.ConfigurationFunction;
                        if (extensionPublicSettings.Properties != null)
                        {
                            context.Properties =
                                new Hashtable(extensionPublicSettings.Properties.ToDictionary(x => x.Name, x => x.Value));
                        }
                    }

                    return context;
                }
                
                ).FirstOrDefault());
        }
    }
}

