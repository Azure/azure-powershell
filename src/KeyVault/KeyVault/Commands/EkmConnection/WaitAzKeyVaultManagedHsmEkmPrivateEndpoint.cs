using Azure;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    [CmdletPreview(KeyVaultEkmConnectionCmdletBase.PrivateLinkPreviewMessage)]
    [Cmdlet(VerbsLifecycle.Wait, "AzKeyVaultManagedHsmEkmPrivateEndpoint", DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmPrivateEndpoint))]
    public class WaitAzKeyVaultManagedHsmEkmPrivateEndpoint : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of the EKM private endpoint to poll.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Provisioning state to wait for. Defaults to Succeeded; provisioning is distinct from provider approval.")]
        [ValidateNotNullOrEmpty]
        public string ProvisioningState { get; set; } = "Succeeded";

        [Parameter(HelpMessage = "Private Link Service connection status to wait for, independently of provisioning.")]
        [ValidateSet("Pending", "Approved", "Rejected", "Disconnected")]
        public string ConnectionStatus { get; set; }

        [Parameter(HelpMessage = "Wait until the endpoint exists, regardless of provisioning or approval state.")]
        [Alias("Exists")]
        public SwitchParameter Exist { get; set; }

        [Parameter(HelpMessage = "Wait until retrieving the endpoint returns NotFound.")]
        public SwitchParameter Deleted { get; set; }

        [Parameter(HelpMessage = "Custom condition evaluated with the current endpoint in the pipeline variable.")]
        public ScriptBlock Until { get; set; }

        [Parameter(HelpMessage = "Maximum time in seconds to wait for the requested condition.")]
        [ValidateRange(1, int.MaxValue)]
        [Alias("TimeoutSeconds")]
        public int Timeout { get; set; } = 3600;

        [Parameter(HelpMessage = "Delay in seconds between polls.")]
        [ValidateRange(1, 3600)]
        [Alias("IntervalSeconds")]
        public int Interval { get; set; } = 30;

        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();
            EkmConnectionHelper.ValidatePrivateEndpointName(Name);
            int conditions = (Exist ? 1 : 0) + (Deleted ? 1 : 0) + (ConnectionStatus != null ? 1 : 0) + (Until != null ? 1 : 0);
            if (conditions > 1 || (conditions != 0 && MyInvocation.BoundParameters.ContainsKey(nameof(ProvisioningState))))
            {
                throw new AzPSArgumentException("Specify only one wait condition.", nameof(ProvisioningState));
            }

            var elapsed = Stopwatch.StartNew();
            while (true)
            {
                CancellationToken.ThrowIfCancellationRequested();
                PSKeyVaultEkmPrivateEndpoint endpoint = null;
                try
                {
                    endpoint = Track2DataClient.GetManagedHsmEkmPrivateEndpoint(HsmName, Name, CancellationToken).SingleOrDefault();
                }
                catch (RequestFailedException exception) when (exception.Status == 404)
                {
                    if (Deleted)
                    {
                        return;
                    }
                }

                if (endpoint != null && !Deleted)
                {
                    bool complete;
                    if (Until != null)
                    {
                        var variables = new List<PSVariable> { new PSVariable("_", endpoint) };
                        var result = Until.InvokeWithContext(null, variables, endpoint);
                        complete = result.Count > 0 && LanguagePrimitives.IsTrue(result[result.Count - 1]);
                    }
                    else if (ConnectionStatus != null)
                    {
                        complete = string.Equals(ConnectionStatus, endpoint.PrivateLinkServiceConnectionState?.Status, StringComparison.OrdinalIgnoreCase);
                        if (!complete && (endpoint.PrivateLinkServiceConnectionState?.Status == "Rejected" || endpoint.PrivateLinkServiceConnectionState?.Status == "Disconnected"))
                        {
                            throw new AzPSInvalidOperationException("The Private Link Service connection was rejected or disconnected.");
                        }
                    }
                    else
                    {
                        complete = Exist || string.Equals(ProvisioningState, endpoint.ProvisioningState, StringComparison.OrdinalIgnoreCase);
                    }
                    if (complete)
                    {
                        WriteObject(endpoint);
                        return;
                    }
                    if (endpoint.ProvisioningState == "Failed")
                    {
                        throw new AzPSInvalidOperationException("The EKM private endpoint provisioning operation failed.");
                    }
                }

                double remainingSeconds = Timeout - elapsed.Elapsed.TotalSeconds;
                if (remainingSeconds <= 0)
                {
                    throw new AzPSInvalidOperationException("Timed out waiting for the EKM private endpoint condition.");
                }
                if (CancellationToken.WaitHandle.WaitOne(TimeSpan.FromSeconds(Math.Min(Interval, remainingSeconds))))
                {
                    CancellationToken.ThrowIfCancellationRequested();
                }
            }
        }
    }
}