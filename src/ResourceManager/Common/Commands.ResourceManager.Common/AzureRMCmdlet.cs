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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Threading;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Represents base class for Resource Manager cmdlets
    /// </summary>
    public abstract class AzureRMCmdlet : AzurePSCmdlet
    {
        protected ServiceClientTracingInterceptor _serviceClientTracingInterceptor;
        IAzureContextContainer _profile;

        /// <summary>
        /// Creates new instance from AzureRMCmdlet and add the RPRegistration handler.
        /// </summary>
        public AzureRMCmdlet()
        {
        }

        /// <summary>
        /// Gets or sets the global profile for ARM cmdlets.
        /// </summary>
        public IAzureContextContainer DefaultProfile
        {
            get
            {
                if (_profile != null)
                {
                    return _profile;
                }
                if (AzureRmProfileProvider.Instance == null)
                {
                    throw new InvalidOperationException(Resources.ProfileNotInitialized);
                }

                return AzureRmProfileProvider.Instance.Profile;
            }
            set
            {
                _profile = value;
            }
        }

        /// <summary>
        /// Gets the current default context.
        /// </summary>
        protected override IAzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null || DefaultProfile.DefaultContext == null || DefaultProfile.DefaultContext.Account == null)
                {
                    throw new PSInvalidOperationException("Run Login-AzureRmAccount to login.");
                }

                return DefaultProfile.DefaultContext;
            }
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
        
        /// <summary>
        /// Prompt for confirmation for the specified change to the specified ARM resource
        /// </summary>
        /// <param name="resourceType">The resource type</param>
        /// <param name="resourceName">The resource name for the changed reource</param>
        /// <param name="resourceGroupName">The resource group containign the changed resource</param>
        /// <param name="processMessage">A description of the change to the resource</param>
        /// <param name="action">The code action to perform if confirmation is successful</param>
        protected void ConfirmResourceAction(string resourceType, string resourceName, string resourceGroupName,
            string processMessage, Action action)
        {
            ConfirmAction(processMessage, string.Format(Resources.ResourceConfirmTarget,
                resourceType, resourceName, resourceGroupName), action);
        }

        /// <summary>
        /// Prompt for confirmation for the specified change to the specified ARM resource
        /// </summary>
        /// <param name="resourceType">The resource type</param>
        /// <param name="resourceName">The resource name for the changed reource</param>
        /// <param name="resourceGroupName">The resource group containign the changed resource</param>
        /// <param name="force">True if Force parameter was passed</param>
        /// <param name="continueMessage">The message to display in a ShouldContinue prompt, if offered</param>
        /// <param name="processMessage">A description of the change to the resource</param>
        /// <param name="action">The code action to perform if confirmation is successful</param>
        /// <param name="promptForContinuation">Predicate to determine whether a ShouldContinue prompt is necessary</param>
        protected void ConfirmResourceAction(string resourceType, string resourceName, string resourceGroupName,
            bool force, string continueMessage, string processMessage, Action action, Func<bool> promptForContinuation = null )
        {
            ConfirmAction(force, continueMessage, processMessage, string.Format(Resources.ResourceConfirmTarget,
                resourceType, resourceName, resourceGroupName), action, promptForContinuation);
        }

        /// <summary>
        /// Prompt for confirmation for the specified change to the specified ARM resource
        /// </summary>
        /// <param name="resourceId">The identity of the resource to be changed</param>
        /// <param name="actionName">A description of the change to the resource</param>
        /// <param name="action">The code action to perform if confirmation is successful</param>
        protected void ConfirmResourceAction(string resourceId, string actionName, Action action)
        {
            ConfirmAction(actionName, string.Format(Resources.ResourceIdConfirmTarget,
                resourceId), action);
        }

        /// <summary>
        /// Prompt for confirmation for the specified change to the specified ARM resource
        /// </summary>
        /// <param name="resourceId">The identity of the resource to be changed</param>
        /// <param name="force">True if Force parameter was passed</param>
        /// <param name="continueMessage">The message to display in a ShouldContinue prompt, if offered</param>
        /// <param name="actionName">A description of the change to the resource</param>
        /// <param name="action">The code action to perform if confirmation is successful</param>
        /// <param name="promptForContinuation">Predicate to determine whether a ShouldContinue prompt is necessary</param>
        protected void ConfirmResourceAction(string resourceId, bool force, string continueMessage, string actionName, 
            Action action, Func<bool> promptForContinuation = null)
        {
            ConfirmAction(force, continueMessage, actionName, string.Format(Resources.ResourceIdConfirmTarget,
                resourceId), action, promptForContinuation);
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

            if (this.DefaultProfile != null &&
                this.DefaultProfile.DefaultContext != null &&
                this.DefaultProfile.DefaultContext.Account != null &&
                this.DefaultProfile.DefaultContext.Account.Id != null)
            {
                _qosEvent.Uid = MetricHelper.GenerateSha256HashString(
                    this.DefaultProfile.DefaultContext.Account.Id.ToString());
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
                AzureSession.Instance.ClientFactory.RemoveHandler(typeof(RPRegistrationDelegatingHandler));
            }
        }

        protected override void BeginProcessing()
        {
            AzureSession.Instance.ClientFactory.RemoveHandler(typeof(RPRegistrationDelegatingHandler));
            if (DefaultContext != null && DefaultContext.Subscription != null)
            {
                AzureSession.Instance.ClientFactory.AddHandler(new RPRegistrationDelegatingHandler(
                    () =>
                    {
                        var client = new ResourceManagementClient(
                            DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
                        client.SubscriptionId = DefaultContext.Subscription.Id;
                        return client;
                    },
                    s => DebugMessages.Enqueue(s)));
            }

            base.BeginProcessing();
        }
    }
}
