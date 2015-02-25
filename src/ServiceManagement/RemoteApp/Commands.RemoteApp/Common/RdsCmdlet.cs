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

using Hyak.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Security.Principal;


namespace Microsoft.Azure.Management.RemoteApp.Models
{

    public class TrackingResult
    {
        public string TrackingId { get; set; }

        public TrackingResult(OperationResultWithTrackingId operation)
        {
            TrackingId = operation.TrackingId;
        }
    }
}

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{


    public abstract partial class RdsCmdlet : AzurePSCmdlet
    {
        [ThreadStatic]
        internal static Job theJob;

        private IRemoteAppManagementClient client = null;

        public IRemoteAppManagementClient Client
        {
            get
            {
                if (client == null)
                {
                    client = AzureSession.ClientFactory.CreateClient<RemoteAppManagementClient>(Profile.Context, AzureEnvironment.Endpoint.ServiceManagement);
                    client.RdfeNamespace = "remoteapp";

                    // Read the namespace if defined as an environment variable from the session configuration
                    string rdfeNamespace = Environment.GetEnvironmentVariable("rdfeNamespace");

                    if (!string.IsNullOrWhiteSpace(rdfeNamespace))
                    {
                        client.RdfeNamespace = rdfeNamespace;
                    }
                }

                return client;
            }

            set
            {
                client = value;  // Test Hook
            }
        }

        protected WildcardPattern Wildcard { get; set; }

        protected bool UseWildcard
        {
            get { return Wildcard != null; }
        }

        protected bool ExactMatch { get; set;}

        public RdsCmdlet()
        {
            Wildcard = null;
            ExactMatch = false;
            theJob = null;
        }

        internal void VerifySessionIsElevated()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal securityPrincipal = new WindowsPrincipal(identity);
            WindowsBuiltInRole Admin = WindowsBuiltInRole.Administrator;

            if (securityPrincipal.IsInRole(Admin) == false)
            {
                throw new RemoteAppServiceException("This cmdlet must be run in an elevated Powershell session", ErrorCategory.InvalidOperation);
            }

        }

        internal Collection<PSObject> CallPowershell(string script)
        {
            Collection<PSObject> pipeLineObjects = null;

            System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create();
            ps.AddScript(script);

            pipeLineObjects = ps.Invoke();

            if (ps.HadErrors)
            {
                throw ps.Streams.Error[0].Exception;
            }

            return pipeLineObjects;
        }

        internal Collection<T> CallPowershellWithReturnType<T>(string script)
        {
            Collection<PSObject> pipeLineObjects = null;
            Collection<T> result = new Collection<T>();

            System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create();
            ps.AddScript(script);

            pipeLineObjects = ps.Invoke();

            if (ps.HadErrors)
            {
                throw ps.Streams.Error[0].Exception;
            }

            foreach (PSObject obj in pipeLineObjects)
            {
                T item = LanguagePrimitives.ConvertTo<T>(obj);
                result.Add(item);
            }

            return result;
        }

        protected void CreateWildcardPattern(string name)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(name))
                {
                    ExactMatch = !WildcardPattern.ContainsWildcardCharacters(name);

                    Wildcard = new WildcardPattern(name, WildcardOptions.IgnoreCase);
                }
            }
            catch (WildcardPatternException e)
            {
                ErrorRecord er = new ErrorRecord(e, "", ErrorCategory.InvalidArgument, Wildcard);
                ThrowTerminatingError(er);
            }
        }

        protected Collection FindCollection(string CollectionName)
        {
            CollectionResult response = null;

            response = CallClient(() => Client.Collections.Get(CollectionName), Client.Collections);

            if (response != null)
            {
                if (response.Collection == null)
                {
                    ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        String.Format("Collection {0} does not exist",
                                            CollectionName),
                                        String.Empty,
                                        Client.Principals,
                                        ErrorCategory.ObjectNotFound
                    );

                    WriteError(er);
                }
                else if (!String.Equals(response.Collection.Status, "Active", StringComparison.OrdinalIgnoreCase))
                {
                    ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                        String.Format("Collection {0} is not in the Active state",
                            response.Collection.Name),
                        String.Empty,
                        Client.Principals,
                        ErrorCategory.InvalidOperation
                    );

                    WriteError(er);
                }
            }

            return response.Collection;
        }

        protected void RegisterSubscriptionWithRdfeForRemoteApp()
        {
            System.Threading.CancellationToken cancelationToken = new System.Threading.CancellationToken();

            // register the subscription with RDFE to use the RemoteApp resource
            Microsoft.WindowsAzure.Management.ManagementClient mgmtClient = 
                AzureSession.ClientFactory.CreateClient<Microsoft.WindowsAzure.Management.ManagementClient>(Profile.Context, AzureEnvironment.Endpoint.ServiceManagement);

            try
            {
                AzureOperationResponse azureOperationResponse = mgmtClient.Subscriptions.RegisterResourceAsync(Client.RdfeNamespace, cancelationToken).Result;
            }
            catch (Exception e)
            {
                // Handle if this or the inner exception is of type CloudException
                CloudException ce = e as CloudException;

                if (ce == null)
                {
                    ce = e.InnerException as CloudException;
                }

                if (ce != null)
                {
                    // ignore the 'ConflictError' which is returned if the subscription is already registered for the resource
                    if (ce.Error.Code != "ConflictError")
                    {
                        HandleCloudException(mgmtClient.Subscriptions, ce);
                    }
                }
                else
                {
                    ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromException(e, String.Empty, mgmtClient.Subscriptions, ErrorCategory.NotSpecified);

                    ThrowTerminatingError(er);
                }
            }

        }

        protected T CallClient<T>(Func<T> func, object targetObject) where T : AzureOperationResponse
        {
            T response = default(T);

            try
            {
                response = func();
            }
            catch (Exception e)
            {
                // Handle if this or the inner exception is of type CloudException
                CloudException ce = e as CloudException;
                ErrorRecord er = null;

                if (ce == null)
                {
                    ce = e.InnerException as CloudException;
                }

                if (ce != null)
                {
                    HandleCloudException(targetObject, ce);
                }
                else
                {
                    er = RemoteAppCollectionErrorState.CreateErrorRecordFromException(e, String.Empty, targetObject, ErrorCategory.NotSpecified);

                    ThrowTerminatingError(er);
                }
            }

            return response;
        }

        private void HandleCloudException(object targetObject, CloudException e)
        {
            CloudRecordState cloudRecord = RemoteAppCollectionErrorState.CreateErrorStateFromCloudException(e, String.Empty, targetObject);
            if (cloudRecord.state.type == ExceptionType.NonTerminating)
            {
                WriteError(cloudRecord.er);
            }
            else
            {
                ThrowTerminatingError(cloudRecord.er);
            }
        }

        protected T CallClient_ThrowOnError<T>(Func<T> func) where T : AzureOperationResponse
        {
            T response = default(T);

            response = func();

            return response;
        }

        protected void WriteTrackingId(OperationResultWithTrackingId response)
        {

            WriteVerboseWithTimestamp("Please use the following tracking id with Get-AzureRemoteAppOperationResult cmdlet:");
            WriteObject(response.TrackingId, true);
        }
    }
}
