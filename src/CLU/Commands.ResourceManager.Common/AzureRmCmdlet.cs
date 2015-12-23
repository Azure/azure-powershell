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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Represents base class for Resource Manager cmdlets
    /// </summary>
    public abstract class AzureRMCmdlet : AzurePSCmdlet
    {
        public const string ProfileVariable = "_azpsh_profile";

        /// <summary>
        /// Gets or sets the global profile for ARM cmdlets.
        /// </summary>
        public AzureRMProfile DefaultProfile { get; set; }

        /// <summary>
        /// Gets the current default context.
        /// </summary>
        protected override AzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null || DefaultProfile.Context == null)
                {
                    throw new PSInvalidOperationException(Resources.ProfileCannotBeNull);
                }

                return DefaultProfile.Context;
            }
        }

        protected override void BeginProcessing()
        {
            // Deserialize session variables
            var sessionProfile = GetSessionVariableValue<PSAzureProfile>(AzurePowerShell.ProfileVariable, (PSAzureProfile)(new AzureRMProfile()));
            if (sessionProfile != null)
            {
                DefaultProfile = DefaultProfile?? sessionProfile;
            }
            base.BeginProcessing();
            //TODO:  Add back RP automatic registration
            //ClientFactory.AddHandler(new RPRegistrationDelegatingHandler(
            //               () => new ResourceManagementClient(
            //                   AuthenticationFactory.GetSubscriptionCloudCredentials(DefaultContext, AzureEnvironment.Endpoint.ResourceManager),
            //                   DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)),
            //               s => _debugMessages.Enqueue(s)));

        }

        protected override void EndProcessing()
        {
            SetSessionVariable(AzurePowerShell.ProfileVariable, ((PSAzureProfile)DefaultProfile));
            //ClientFactory.RemoveHandler(typeof(RPRegistrationDelegatingHandler));
            base.EndProcessing();
        }

        protected override void SaveDataCollectionProfile()
        {
            if (_dataCollectionProfile == null)
            {
                InitializeDataCollectionProfile();
            }

            string fileFullPath = Path.Combine(AzurePowerShell.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
            var contents = JsonConvert.SerializeObject(_dataCollectionProfile);
            if (!DataStore.DirectoryExists(AzurePowerShell.ProfileDirectory))
            {
                DataStore.CreateDirectory(AzurePowerShell.ProfileDirectory);
            }
            DataStore.WriteFile(fileFullPath, contents);
            WriteWarning(string.Format(Resources.DataCollectionSaveFileInformation, fileFullPath));
        }

        protected override void PromptForDataCollectionProfileIfNotExists()
        {
            // Initialize it from the environment variable or profile file.
            InitializeDataCollectionProfile();

            if (!_dataCollectionProfile.EnableAzureDataCollection.HasValue && CheckIfInteractive())
            {
                WriteWarning(Resources.DataCollectionPrompt);

                const double timeToWaitInSeconds = 60;
                var status = string.Format(Resources.DataCollectionConfirmTime, timeToWaitInSeconds);
                ProgressRecord record = new ProgressRecord(0, Resources.DataCollectionActivity, status);

                var startTime = DateTime.Now;
                var endTime = DateTime.Now;
                //double elapsedSeconds = 0;

                //while (!this.Host.UI.RawUI.KeyAvailable && elapsedSeconds < timeToWaitInSeconds)
                //{
                //    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                //    endTime = DateTime.Now;

                //    elapsedSeconds = (endTime - startTime).TotalSeconds;
                //    record.PercentComplete = ((int)elapsedSeconds * 100 / (int)timeToWaitInSeconds);
                //    WriteProgress(record);
                //}

                bool enabled = false;
                //if (this.Host.UI.RawUI.KeyAvailable)
                //{
                //    KeyInfo keyInfo = this.Host.UI.RawUI.ReadKey(ReadKeyOptions.NoEcho | ReadKeyOptions.AllowCtrlC | ReadKeyOptions.IncludeKeyDown);
                //    enabled = (keyInfo.Character == 'Y' || keyInfo.Character == 'y');
                //}

                _dataCollectionProfile.EnableAzureDataCollection = enabled;

                WriteWarning(enabled ? Resources.DataCollectionConfirmYes : Resources.DataCollectionConfirmNo);

                SaveDataCollectionProfile();
            }
        }

        protected override void InitializeQosEvent()
        {
            //QosEvent = new AzurePSQoSEvent()
            //{
            //    CmdletType = this.GetType().Name,
            //    IsSuccess = true,
            //};

            //if (this.Context != null && this.Context.Subscription != null)
            //{
            //    QosEvent.Uid = MetricHelper.GenerateSha256HashString(
            //        this.Context.Subscription.Id.ToString());
            //}
            //else
            //{
            //    QosEvent.Uid = "defaultid";
            //}
        }
    }
}
