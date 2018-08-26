﻿using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Azure.Commands.Reservations.Models;
using System.Management.Automation;
using Newtonsoft.Json;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Reservation", DefaultParameterSetName = Constants.ParameterSetNames.CommandParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSReservation))]
    public class PatchReservation : AzureReservationsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        public Guid ReservationOrderId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        public Guid ReservationId { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter("Single", "Shared")]
        [ValidateNotNullOrEmpty]
        public string AppliedScopeType { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public string AppliedScope { get; set; }

        [Parameter(Mandatory = false)]
        [PSArgumentCompleter("On", "Off", "NotSupported")]
        [ValidateNotNullOrEmpty]
        public string InstanceFlexibility { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSReservation Reservation { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.ObjectParameterSet))
            {
                string[] name = Reservation.Name.Split('/');
                ReservationOrderId = new Guid(name[0]);
                ReservationId = new Guid(name[1]);
            }

            var resourceInfo = $"Reservation {ReservationId} in order {ReservationOrderId}";
            if (ShouldProcess(resourceInfo, "Update"))
            {
                Patch Patch;
                if (AppliedScope != null)
                {
                    //Pre-register for Microsoft.Compute
                    string subscriptionId = ValidateAndGetAppliedSubscription();
                    PreRegister(subscriptionId);

                    Patch = new Patch(AppliedScopeType, new List<string>() { AppliedScope }, InstanceFlexibility);
                }
                else
                {
                    Patch = new Patch(AppliedScopeType, instanceFlexibility: InstanceFlexibility);
                }
                var response = new PSReservation(AzureReservationAPIClient.Reservation.Update(ReservationOrderId.ToString(), ReservationId.ToString(), Patch));
                WriteObject(response);
            }
        }

        private void PreRegister(string subscriptionId)
        {
            try
            {
                IAzureContext context;
                if (TryGetDefaultContext(out context)
                    && context.Account != null
                    && context.Subscription != null)
                {
                    var client = new ResourceManagementClient(
                                context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                                AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager));
                    client.SubscriptionId = subscriptionId;

                    string ComputeProviderNamespace = "Microsoft.Compute";
                    var maxRetryCount = 10;

                    var provider = client.Providers.Get(ComputeProviderNamespace);
                    if (provider.RegistrationState != RegistrationState.Registered)
                    {
                        short retryCount = 0;
                        do
                        {
                            if (retryCount++ > maxRetryCount)
                            {
                                throw new TimeoutException();
                            }
                            provider = client.Providers.Register(ComputeProviderNamespace);
                            TestMockSupport.Delay(2000);
                        } while (provider.RegistrationState != RegistrationState.Registered);
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message?.IndexOf("does not have authorization") >= 0 && e.Message?.IndexOf("register/action",
                        StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    throw new CloudException(e.Message);
                }
            }
        }

        private string ValidateAndGetAppliedSubscription()
        {
            string subscriptionId = AppliedScope;
            string prefix = "/subscriptions/";
            if (subscriptionId.IndexOf(prefix, StringComparison.InvariantCultureIgnoreCase) >= 0
                && subscriptionId.Length > prefix.Length)
            {
                subscriptionId = subscriptionId.Substring(prefix.Length);
            }

            Guid result;
            if (Guid.TryParse(subscriptionId, out result))
            {
                return result.ToString();
            }
            else
            {
                throw new PSArgumentException("Invalid applied scope provided");
            }
        }
    }
}
