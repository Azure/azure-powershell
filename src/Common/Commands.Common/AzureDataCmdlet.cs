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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Host;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class AzureDataCmdlet : AzurePSCmdlet
    {
        protected override IAzureContext DefaultContext
        {
            get
            {
                if (RMProfile != null && RMProfile.DefaultContext != null && RMProfile.DefaultContext.Environment != null)
                {
                    return RMProfile.DefaultContext;
                }

                if (SMProfile == null || SMProfile.DefaultContext == null)
                {
                    throw new InvalidOperationException(Resources.NoCurrentContextForDataCmdlet);
                }

                return SMProfile.DefaultContext;
            }
        }

        public IAzureContextContainer SMProfile
        {
            get
            {
                IAzureContextContainer result = null;
                if (AzureSMProfileProvider.Instance != null)
                {
                    result = AzureSMProfileProvider.Instance.Profile;
                }

                return result;
            }
        }

        public IAzureContextContainer RMProfile
        {
            get
            {
                IAzureContextContainer result = null;
                if (AzureRmProfileProvider.Instance != null)
                {
                    result = AzureRmProfileProvider.Instance.Profile;
                }

                return result;
            }
        }

        protected override void SaveDataCollectionProfile()
        {
            if (_dataCollectionProfile == null)
            {
                InitializeDataCollectionProfile();
            }

            string fileFullPath = Path.Combine(AzureSession.Instance.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
            var contents = JsonConvert.SerializeObject(_dataCollectionProfile);
            if (!AzureSession.Instance.DataStore.DirectoryExists(AzureSession.Instance.ProfileDirectory))
            {
                AzureSession.Instance.DataStore.CreateDirectory(AzureSession.Instance.ProfileDirectory);
            }
            AzureSession.Instance.DataStore.WriteFile(fileFullPath, contents);
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
                double elapsedSeconds = 0;

                while (!this.Host.UI.RawUI.KeyAvailable && elapsedSeconds < timeToWaitInSeconds)
                {
                    TestMockSupport.Delay(10 * 1000);
                    endTime = DateTime.Now;

                    elapsedSeconds = (endTime - startTime).TotalSeconds;
                    record.PercentComplete = ((int)elapsedSeconds * 100 / (int)timeToWaitInSeconds);
                    WriteProgress(record);
                }

                bool enabled = false;
                if (this.Host.UI.RawUI.KeyAvailable)
                {
                    KeyInfo keyInfo =
                        this.Host.UI.RawUI.ReadKey(ReadKeyOptions.NoEcho | ReadKeyOptions.AllowCtrlC |
                                                   ReadKeyOptions.IncludeKeyDown);
                    enabled = (keyInfo.Character == 'Y' || keyInfo.Character == 'y');
                }

                _dataCollectionProfile.EnableAzureDataCollection = enabled;

                WriteWarning(enabled ? Resources.DataCollectionConfirmYes : Resources.DataCollectionConfirmNo);

                SaveDataCollectionProfile();
            }
        }
        protected override void InitializeQosEvent()
        {
        }

        /// <summary>
        /// Guards execution of the given action using ShouldProcess and ShouldContinue.  The optional 
        /// useSHouldContinue predicate determines whether SHouldContinue should be called for this 
        /// particular action (e.g. a resource is being overwritten). By default, both 
        /// ShouldProcess and ShouldContinue will be executed.  Cmdlets that use this method overload 
        /// must have a force parameter.
        /// </summary>
        /// <param name="force">Do not ask for confirmation</param>
        /// <param name="continueMessage">Message to describe the action</param>
        /// <param name="processMessage">Message to prompt after the active is performed.</param>
        /// <param name="target">The target name.</param>
        /// <param name="action">The action code</param>
        protected override void ConfirmAction(bool force, string continueMessage, string processMessage, string target,
            Action action)
        {
            ConfirmAction(force, continueMessage, processMessage, target, action, () => true);
        }


    }
}
