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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public abstract class AzureSMCmdlet : AzurePSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "In-memory profile.")]
        public AzureSMProfile Profile { get; set; }

        /// <summary>
        /// Sets the current profile - the profile used when no Profile is explicitly passed in.  Should be used only by
        /// Profile cmdlets and tests that need to set up a particular profile
        /// </summary>
        public static AzureSMProfile CurrentProfile
        {
            private get
            {
                return AzureSMProfileProvider.Instance.Profile;
            }

            set
            {
                AzureSMProfileProvider.Instance.Profile = value;
            }
        }


        protected override AzureContext DefaultContext { get { return CurrentProfile.Context; } }

        static AzureSMCmdlet()
        {
            if (!TestMockSupport.RunningMocked)
            {
                AzureSession.ClientFactory.AddAction(new RPRegistrationAction());
                AzureSession.DataStore = new DiskDataStore();
            }
        }

        protected override void SaveDataCollectionProfile()
        {
            if (_dataCollectionProfile == null)
            {
                InitializeDataCollectionProfile();
            }

            string fileFullPath = Path.Combine(AzureSession.ProfileDirectory, AzurePSDataCollectionProfile.DefaultFileName);
            var contents = JsonConvert.SerializeObject(_dataCollectionProfile);
            AzureSession.DataStore.WriteFile(fileFullPath, contents);
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
                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                    endTime = DateTime.Now;

                    elapsedSeconds = (endTime - startTime).TotalSeconds;
                    record.PercentComplete = ((int)elapsedSeconds * 100 / (int)timeToWaitInSeconds);
                    WriteProgress(record);
                }

                bool enabled = false;
                if (this.Host.UI.RawUI.KeyAvailable)
                {
                    KeyInfo keyInfo = this.Host.UI.RawUI.ReadKey(ReadKeyOptions.NoEcho | ReadKeyOptions.AllowCtrlC | ReadKeyOptions.IncludeKeyDown);
                    enabled = (keyInfo.Character == 'Y' || keyInfo.Character == 'y');
                }

                _dataCollectionProfile.EnableAzureDataCollection = enabled;

                WriteWarning(enabled ? Resources.DataCollectionConfirmYes : Resources.DataCollectionConfirmNo);

                SaveDataCollectionProfile();
            }
        }

        protected override void InitializeQosEvent()
        {
            var commandAlias = this.GetType().Name;
            if (this.MyInvocation != null && this.MyInvocation.MyCommand != null)
            {
                commandAlias = this.MyInvocation.MyCommand.Name;
            }

            _qosEvent = new AzurePSQoSEvent()
            {
                CommandName = commandAlias,
                ModuleName = this.GetType().Assembly.GetName().Name,
                ModuleVersion = this.GetType().Assembly.GetName().Version.ToString(),
                ClientRequestId = this._clientRequestId,
                SessionId = _sessionId,
                IsSuccess = true,
            };

            if (this.MyInvocation != null && this.MyInvocation.BoundParameters != null)
            {
                _qosEvent.Parameters = string.Join(" ",
                    this.MyInvocation.BoundParameters.Keys.Select(
                        s => string.Format(CultureInfo.InvariantCulture, "-{0} ***", s)));
            }

            if (this.DefaultContext != null &&
                this.DefaultContext.Account != null &&
                this.DefaultContext.Account.Id != null)
            {
                _qosEvent.Uid = MetricHelper.GenerateSha256HashString(
                    this.DefaultContext.Account.Id.ToString());
            }
            else
            {
                _qosEvent.Uid = "defaultid";
            }
        }

        /// <summary>
        /// Cmdlet begin process. Write to logs, setup Http Tracing and initialize profile
        /// </summary>
        protected override void BeginProcessing()
        {
            InitializeProfile();
            base.BeginProcessing();
        }

        /// <summary>
        /// Ensure that there is a profile for the command
        /// </summary>
        protected virtual void InitializeProfile()
        {
            if (Profile == null)
            {
                Profile = AzureSMProfileProvider.Instance.Profile;
            }
            else
            {
                AzureSMProfileProvider.Instance.SetTokenCacheForProfile(Profile);
            }
        }

        protected override void LogCmdletStartInvocationInfo()
        {
            base.LogCmdletStartInvocationInfo();
            if (DefaultContext != null && DefaultContext.Account != null
                && DefaultContext.Account.Id != null)
            {
                WriteDebugWithTimestamp(string.Format("using account id '{0}'...",
                    DefaultContext.Account.Id));
            }
        }

        protected override void LogCmdletEndInvocationInfo()
        {
            base.LogCmdletEndInvocationInfo();
            string message = string.Format("{0} end processing.", this.GetType().Name);
            WriteDebugWithTimestamp(message);
        }
    }
}
