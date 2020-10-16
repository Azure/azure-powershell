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
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
#endif
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Represents base class for Resource Manager cmdlets
    /// </summary>
    public abstract class AzureRMCmdlet : AzurePSCmdlet
    {
        protected ServiceClientTracingInterceptor _serviceClientTracingInterceptor;
        IAzureContextContainer _profile;

        public const int MAX_NUMBER_OF_TOKENS_ALLOWED_IN_AUX_HEADER = 3;
        public const string AUX_HEADER_NAME = "x-ms-authorization-auxiliary";
        public const string AUX_TOKEN_PREFIX = "Bearer";
        public const string AUX_TOKEN_APPEND_CHAR = ";";
        public const string WriteDebugKey = "WriteDebug";
        public const string WriteVerboseKey = "WriteVerbose";
        public const string WriteWarningKey = "WriteWarning";
        public const string EnqueueDebugKey = "EnqueueDebug";

        /// <summary>
        /// Creates new instance from AzureRMCmdlet and add the RPRegistration handler.
        /// </summary>
        public AzureRMCmdlet()
        {
        }

        /// <summary>
        /// Gets or sets the global profile for ARM cmdlets.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias("AzContext", "AzureRmContext", "AzureCredential")]
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

        protected IDictionary<String, List<String>> GetAuxilaryAuthHeaderFromResourceIds(List<String> resourceIds)
        {
            IDictionary<String, List<String>> auxHeader = null;

            //Get the subscriptions from the resource Ids
            var subscriptionIds = resourceIds.Select(rId => (new ResourceIdentifier(rId))?.Subscription)?.Distinct();

            //Checxk if we have access to all the subscriptions
            var subscriptionList = CheckAccessToSubscriptions(subscriptionIds);

            //get all the non default tenant ids for the subscriptions
            var nonDeafultTenantIds = subscriptionList?.Select(s => s.GetTenant())?.Distinct()?.Where(t => t != DefaultContext.Tenant.GetId().ToString());

            if ((nonDeafultTenantIds != null) && (nonDeafultTenantIds.Count() > 0))
            {
                // WE can only fill in tokens for 3 tennats in the aux header, if tehre are more tenants fail now
                if (nonDeafultTenantIds.Count() > MAX_NUMBER_OF_TOKENS_ALLOWED_IN_AUX_HEADER)
                {
                    throw new ArgumentException("Number of tenants (tenants other than the one in the current context), that the requested resources belongs to, exceeds maximum allowed number of " + MAX_NUMBER_OF_TOKENS_ALLOWED_IN_AUX_HEADER);
                }

                //get the tokens for each tenant and prepare the string in the following format :
                //"Header Value :: Bearer <auxiliary token1>;EncryptedBearer <auxiliary token2>; Bearer <auxiliary token3>"

                var tokens = nonDeafultTenantIds.Select(t => (new StringBuilder(AUX_TOKEN_PREFIX).Append(" ").Append(GetTokenForTenant(t)?.AccessToken))?.ToString())?.ConcatStrings(AUX_TOKEN_APPEND_CHAR);

                auxHeader = new Dictionary<String, List<String>>();

                List<string> headerValues = new List<string>(1);
                headerValues.Add(tokens);
                auxHeader.Add(AUX_HEADER_NAME, headerValues);
            }

            return auxHeader;
        }

        private List<IAzureSubscription> CheckAccessToSubscriptions(IEnumerable<string> subscriptions)
        {
            var subscriptionsNotInDefaultProfile = subscriptions.ToList().Except(DefaultProfile.Subscriptions.Select(s => s.GetId().ToString()).ToList());

            List<IAzureSubscription> subscriptionObjects = DefaultProfile.Subscriptions.Where(s => subscriptions.Contains(s.GetId().ToString())).ToList();
            if (subscriptionsNotInDefaultProfile.Any())
            {
                //So we didnt find some subscriptions in the default profile..
                //this does not mean that the user does not have access to the subs, it just menas that the local context did not have them
                //We gotta now call into the subscription RP and see if the user really does not have access to these subscriptions

                var result = Utilities.SubscriptionAndTenantHelper.GetTenantsForSubscriptions(subscriptionsNotInDefaultProfile.ToList(), DefaultContext);

                if (result.Count < subscriptionsNotInDefaultProfile.Count())
                {
                    var subscriptionsNotFoundAtAll = subscriptionsNotInDefaultProfile.ToList().Except(result.Keys);
                    //Found subscription(s) the user does not have acess to... throw exception
                    StringBuilder message = new StringBuilder();

                    message.Append(" The user does not have access to the following subscription(s) : ");
                    subscriptionsNotFoundAtAll.ForEach(s => message.Append(" " + s));
                    throw new AuthenticationException(message.ToString());
                }
                else
                {
                    subscriptionObjects.AddRange(result.Values);
                }
            }

            return subscriptionObjects;
        }


        private IAccessToken GetTokenForTenant(string tenantId)
        {
            return Utilities.SubscriptionAndTenantHelper.AcquireAccessToken(DefaultContext.Account,
                DefaultContext.Environment,
                tenantId);
        }

        protected override string DataCollectionWarning
        {
            get
            {
                return Resources.ARMDataCollectionMessage;
            }
        }

        /// <summary>
        /// Whether this cmdlet requires default context.
        /// If false, the logic of referencing default context would be omitted.
        /// </summary>
        protected virtual bool RequireDefaultContext() { return true; }

        /// <summary>
        /// Return a default context safely if it is available, without throwing if it is not setup
        /// </summary>
        /// <param name="context">The default context</param>
        /// <returns>True if there is a valid default context, false otherwise</returns>
        public virtual bool TryGetDefaultContext(out IAzureContext context)
        {
            bool result = false;
            context = null;

            if (DefaultProfile != null && DefaultProfile.DefaultContext != null && DefaultProfile.DefaultContext.Account != null)
            {
                context = DefaultProfile.DefaultContext;
                result = true;
            }

            return result;
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
                    throw new PSInvalidOperationException(Resources.RunConnectAccount);
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
            bool force, string continueMessage, string processMessage, Action action, Func<bool> promptForContinuation = null)
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

        protected override void InitializeQosEvent()
        {
            base.InitializeQosEvent();

            IAzureContext context;
            _qosEvent.Uid = "defaultid";
            if (RequireDefaultContext() && TryGetDefaultContext(out context))
            {
                _qosEvent.SubscriptionId = context.Subscription?.Id;
                _qosEvent.TenantId = context.Tenant?.Id;
                if(context.Account != null && !String.IsNullOrWhiteSpace(context.Account.Id))
                {
                    _qosEvent.Uid = MetricHelper.GenerateSha256HashString(context.Account.Id.ToString());
                }
            }
        }

        protected override void LogCmdletStartInvocationInfo()
        {
            base.LogCmdletStartInvocationInfo();
            IAzureContext context;
            if (RequireDefaultContext()
                && TryGetDefaultContext(out context)
                && context.Account != null
                && context.Account.Id != null)
            {
                WriteDebugWithTimestamp(string.Format("using account id '{0}'...",
                context.Account.Id));
            }
        }

        protected override void SetupDebuggingTraces()
        {
            ServiceClientTracing.IsEnabled = true;
            base.SetupDebuggingTraces();
            _serviceClientTracingInterceptor = _serviceClientTracingInterceptor
                ?? new ServiceClientTracingInterceptor(DebugMessages, _matchers);
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
            InitializeEventHandlers();
            AzureSession.Instance.ClientFactory.RemoveHandler(typeof(RPRegistrationDelegatingHandler));
            IAzureContext context;
            if (RequireDefaultContext()
                && TryGetDefaultContext(out context)
                && context.Account != null
                && context.Subscription != null)
            {
                AzureSession.Instance.ClientFactory.AddHandler(new RPRegistrationDelegatingHandler(
                    () =>
                    {
                        var client = new ResourceManagementClient(
                            context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager));
                        client.SubscriptionId = context.Subscription.Id;
                        return client;
                    },
                    s => DebugMessages.Enqueue(s)));
            }

            base.BeginProcessing();
        }

        public List<T> TopLevelWildcardFilter<T>(string resourceGroupName, string name, IEnumerable<T> resources)
        {
            IEnumerable<T> output = resources;
            if (HasProperty<T>("ResourceId") || HasProperty<T>("Id"))
            {
                string idProperty = HasProperty<T>("ResourceId") ? "ResourceId" : "Id";
                if (!string.IsNullOrEmpty(resourceGroupName))
                {
                    WildcardPattern pattern = new WildcardPattern(resourceGroupName, WildcardOptions.IgnoreCase);
                    output = output.Select(t => new { Id = new ResourceIdentifier((string)GetPropertyValue(t, idProperty)), Resource = t })
                                   .Where(p => IsMatch(p.Id, "ResourceGroupName", pattern))
                                   .Select(r => r.Resource);
                }

                if (!string.IsNullOrEmpty(name))
                {
                    string[] parts = name.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    List<WildcardPattern> patterns = new List<WildcardPattern>();
                    parts.ForEach(p => patterns.Add(new WildcardPattern(p, WildcardOptions.IgnoreCase)));
                    if (parts.Length == 1)
                    {
                        output = output.Select(t => new { Id = new ResourceIdentifier((string)GetPropertyValue(t, idProperty)), Resource = t })
                                     .Where(p => IsMatch(p.Id, "ResourceName", patterns.Last()))
                                     .Select(r => r.Resource);
                    }
                    else if (parts.Length == 2)
                    {
                        output = output.Select(t => new { Id = new ResourceIdentifier((string)GetPropertyValue(t, idProperty)), Resource = t })
                            .Where(p => IsMatch(p.Id, "ResourceName", patterns.Last()) && IsParentNameMatch(p.Id, patterns.First()))
                            .Select(r => r.Resource);
                    }
                }
            }
            else
            {
                // if ResourceGroupName property, filter resource group
                if (HasProperty<T>("ResourceGroupName") && !string.IsNullOrEmpty(resourceGroupName))
                {
                    WildcardPattern pattern = new WildcardPattern(resourceGroupName, WildcardOptions.IgnoreCase);
                    output = output.Where(t => IsMatch(t, "ResourceGroupName", pattern));
                }

                // if Name property, filter name
                if (HasProperty<T>("Name") && !string.IsNullOrEmpty(name))
                {
                    WildcardPattern pattern = new WildcardPattern(name, WildcardOptions.IgnoreCase);
                    output = output.Where(t => IsMatch(t, "Name", pattern));
                }
            }

            return output.ToList();
        }

        public List<T> SubResourceWildcardFilter<T>(string name, IEnumerable<T> resources)
        {
            return TopLevelWildcardFilter(null, name, resources);
        }

        private bool HasProperty<T>(string property)
        {
            return typeof(T).GetProperty(property) != null;
        }

        private object GetPropertyValue<T>(T resource, string property)
        {
            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(property);
            if (pi != null)
            {
                return pi.GetValue(resource, null);
            }

            return null;
        }

        private bool IsMatch<T>(T resource, string property, WildcardPattern pattern)
        {
            var value = (string)GetPropertyValue(resource, property);
            return !string.IsNullOrEmpty(value) && pattern.IsMatch(value);
        }

        private bool IsParentNameMatch<T>(T resource, WildcardPattern pattern)
        {
            string value = (string)GetPropertyValue(resource, "ParentResource");
            if (!string.IsNullOrEmpty(value))
            {
                int parentNameStartIdx = value.LastIndexOf('/');
                if (parentNameStartIdx > 0)
                {
                    value = value.Substring(parentNameStartIdx + 1);
                }
                return !string.IsNullOrEmpty(value) && pattern.IsMatch(value);
            }
            return false;
        }

        public bool ShouldListBySubscription(string resourceGroupName, string name)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return true;
            }
            else if (WildcardPattern.ContainsWildcardCharacters(resourceGroupName))
            {
                return true;
            }

            return false;
        }

        public bool ShouldListByResourceGroup(string resourceGroupName, string name)
        {
            if (!string.IsNullOrEmpty(resourceGroupName) && !WildcardPattern.ContainsWildcardCharacters(resourceGroupName))
            {
                if (string.IsNullOrEmpty(name) || WildcardPattern.ContainsWildcardCharacters(name))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ShouldGetByName(string resourceGroupName, string name)
        {
            if (!string.IsNullOrEmpty(resourceGroupName) && !WildcardPattern.ContainsWildcardCharacters(resourceGroupName))
            {
                if (!string.IsNullOrEmpty(name) && !WildcardPattern.ContainsWildcardCharacters(name))
                {
                    return true;
                }
            }

            return false;
        }

        private event EventHandler<StreamEventArgs> _writeDebugEvent;
        private event EventHandler<StreamEventArgs> _writeVerboseEvent;
        private event EventHandler<StreamEventArgs> _writeWarningEvent;
        private event EventHandler<StreamEventArgs> _enqueueDebugEvent;

        private void InitializeEventHandlers()
        {
            _writeDebugEvent -= WriteDebugSender;
            _writeDebugEvent += WriteDebugSender;
            _writeVerboseEvent -= WriteVerboseSender;
            _writeVerboseEvent += WriteVerboseSender;
            _writeWarningEvent -= WriteWarningSender;
            _writeWarningEvent += WriteWarningSender;
            _enqueueDebugEvent -= EnqueueDebugSender;
            _enqueueDebugEvent += EnqueueDebugSender;
            AzureSession.Instance.RegisterComponent(WriteDebugKey, () => _writeDebugEvent, true);
            AzureSession.Instance.RegisterComponent(WriteVerboseKey, () => _writeVerboseEvent, true);
            AzureSession.Instance.RegisterComponent(WriteWarningKey, () => _writeWarningEvent, true);
            AzureSession.Instance.RegisterComponent(EnqueueDebugKey, () => _enqueueDebugEvent, true);
        }

        private void WriteDebugSender(object sender, StreamEventArgs args)
        {
            WriteDebug(args.Message);
        }

        private void WriteVerboseSender(object sender, StreamEventArgs args)
        {
            WriteVerbose(args.Message);
        }

        private void WriteWarningSender(object sender, StreamEventArgs args)
        {
            WriteWarning(args.Message);
        }

        private void EnqueueDebugSender(object sender, StreamEventArgs args)
        {
            DebugMessages.Enqueue(args.Message);
        }
    }
}
