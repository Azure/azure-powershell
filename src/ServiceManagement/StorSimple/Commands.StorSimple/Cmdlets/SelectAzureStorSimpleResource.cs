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
using System.Linq;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Exceptions;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// this commandlet will set a particular resource to the current context
    /// </summary>
    [Cmdlet(VerbsCommon.Select, "AzureStorSimpleResource"),OutputType(typeof(StorSimpleResourceContext))]
    public class SelectAzureStorSimpleResource : StorSimpleCmdletBase
    {
        private string resourceName;
        /// <summary>
        /// Name of the resource that needs to be selected
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceName
        {
            get { return this.resourceName; }
            set { this.resourceName = value; }
        }

        private string registrationKey;

        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string RegistrationKey
        {
            get { return this.registrationKey; }
            set { this.registrationKey = value; }
        }

        protected override void BeginProcessing()
        {
            //we dont have to verify that resource is selected
            return;
        }

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteVerbose(Resources.ResourceContextInitializeMessage);
                var resCred = StorSimpleClient.GetResourceDetails(resourceName);
                if (resCred == null)
                {
                    this.WriteVerbose(Resources.NotFoundMessageResource);
                    throw new StorSimpleResourceNotFoundException();
                }
                
                StorSimpleClient.SetResourceContext(resCred);
                var deviceInfos = StorSimpleClient.GetAllDevices();
                if (!deviceInfos.Any())
                {
                    StorSimpleClient.ResetResourceContext();
                    throw new NoDeviceRegisteredException();
                }

                //now check for the key
                if (string.IsNullOrEmpty(RegistrationKey))
                {
                    this.WriteVerbose(Resources.RegistrationKeyNotPassedMessage);
                }
                else
                {
                    this.WriteVerbose(Resources.RegistrationKeyPassedMessage);
                    EncryptionCmdLetHelper.PersistCIK(this, resCred.ResourceId, StorSimpleClient.ParseCIKFromRegistrationKey(RegistrationKey));
                }
                EncryptionCmdLetHelper.ValidatePersistedCIK(this, resCred.ResourceId);
                this.WriteVerbose(Resources.SecretsValidationCompleteMessage);

                this.WriteVerbose(Resources.SuccessMessageSetResourceContext);
                var currentContext = StorSimpleClient.GetResourceContext();
                this.WriteObject(currentContext);
            }
            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
