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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Threading;
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Represents base class for Resource Manager cmdlets
    /// </summary>
    public abstract class AzureRMCmdlet : AzurePSCmdlet
    {
        protected ServiceClientTracingInterceptor _serviceClientTracingInterceptor;
        /// <summary>
        /// Static constructor for AzureRMCmdlet.
        /// </summary>
        static AzureRMCmdlet()
        {
            if (!TestMockSupport.RunningMocked)
            {
                AzureSession.DataStore = new DiskDataStore();
            }          
        }

        /// <summary>
        /// Creates new instance from AzureRMCmdlet and add the RPRegistration handler.
        /// </summary>
        public AzureRMCmdlet()
        {
            AzureSession.ClientFactory.RemoveHandler(typeof(RPRegistrationDelegatingHandler));
            AzureSession.ClientFactory.AddHandler(new RPRegistrationDelegatingHandler(
                () => new ResourceManagementClient(
                    AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(DefaultContext, AzureEnvironment.Endpoint.ResourceManager),
                    DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)),
                s => DebugMessages.Enqueue(s)));
        }

        /// <summary>
        /// Gets or sets the global profile for ARM cmdlets.
        /// </summary>
        public AzureRMProfile DefaultProfile
        {
            get { return AzureRmProfileProvider.Instance.Profile; }
            set { AzureRmProfileProvider.Instance.Profile = value; }
        }

        /// <summary>
        /// Gets the current default context.
        /// </summary>
        protected override AzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null || DefaultProfile.Context == null)
                {
                    throw new PSInvalidOperationException("Run Login-AzureRmAccount to login.");
                }

                return DefaultProfile.Context;
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
            if (!AzureSession.DataStore.DirectoryExists(AzureSession.ProfileDirectory))
            {
                AzureSession.DataStore.CreateDirectory(AzureSession.ProfileDirectory);
            }
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
            if(this.MyInvocation != null && this.MyInvocation.MyCommand != null)
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

            if (this.DefaultProfile != null && 
                this.DefaultProfile.Context != null &&
                this.DefaultProfile.Context.Account != null &&
                this.DefaultProfile.Context.Account.Id != null)
            {
                _qosEvent.Uid = MetricHelper.GenerateSha256HashString(
                    this.DefaultProfile.Context.Account.Id.ToString());
            }
            else
            {
                _qosEvent.Uid = "defaultid";
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

        protected override void SetupDebuggingTraces()
        {
            ServiceClientTracing.IsEnabled = true;
            base.SetupDebuggingTraces();
            _serviceClientTracingInterceptor = _serviceClientTracingInterceptor 
                ?? new ServiceClientTracingInterceptor(DebugMessages);
             ServiceClientTracing.AddTracingInterceptor(_serviceClientTracingInterceptor);
        }

        protected override void TearDownDebuggingTraces()
        {
            ServiceClientTracingInterceptor.RemoveTracingInterceptor(_serviceClientTracingInterceptor);
            _serviceClientTracingInterceptor = null;
            base.TearDownDebuggingTraces();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && _serviceClientTracingInterceptor != null)
            {
                ServiceClientTracingInterceptor.RemoveTracingInterceptor(_serviceClientTracingInterceptor);
                _serviceClientTracingInterceptor = null;
                AzureSession.ClientFactory.RemoveHandler(typeof(RPRegistrationDelegatingHandler));
            }
        }
    }
}
