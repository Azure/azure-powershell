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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Azure Site Recovery Network.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRNetwork
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRNetwork" /> class.
        /// </summary>
        public ASRNetwork()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRNetwork" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="network">Network object</param>
        public ASRNetwork(
            Network network)
        {
            this.ID = network.Id;
            this.Name = network.Name;
            this.Type = network.Type;
            this.FriendlyName = network.Properties.FriendlyName;
            this.FabricType = network.Properties.FabricType;
            this.VmNetworkSubnetList = network.Properties.Subnets;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets friendly name of the Network.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets name of the Network.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Network ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Type of Network.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets Fabric object  type.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        ///     Gets or sets VM Network subnets.
        /// </summary>
        public IList<Subnet> VmNetworkSubnetList { get; set; }

        #endregion
    }

    /// <summary>
    ///     Azure Site Recovery Logical Network.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRLogicalNetwork
    {
        #region Properties

        /// <summary>
        ///     Gets or sets friendly name of the Network.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets name of the Network.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Network ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Type of Network.
        /// </summary>
        public string Type { get; set; }

        #endregion
    }

    /// <summary>
    ///     Azure Site Recovery Network Mapping.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRNetworkMapping
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRNetworkMapping" /> class.
        /// </summary>
        public ASRNetworkMapping()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRNetworkMapping" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="networkMapping">Network mapping object</param>
        public ASRNetworkMapping(
            NetworkMapping networkMapping)
        {
            this.ID = networkMapping.Id;
            this.Name = networkMapping.Name;
            this.FriendlyName = networkMapping.Name;
            this.PrimaryNetworkId = networkMapping.Properties.PrimaryNetworkId;
            this.PrimaryNetworkFriendlyName = networkMapping.Properties.PrimaryNetworkFriendlyName;
            this.PrimaryFabricFriendlyName = networkMapping.Properties.PrimaryFabricFriendlyName;
            this.RecoveryNetworkId = networkMapping.Properties.RecoveryNetworkId;
            this.RecoveryNetworkFriendlyName = networkMapping.Properties
                .RecoveryNetworkFriendlyName;
            this.RecoveryFabricFriendlyName = networkMapping.Properties.RecoveryFabricFriendlyName;
            this.PairingStatus = networkMapping.Properties.State;
            this.FabricSpecificNetworkMappingDetails =
                ASRFabricSpecificNetworkMappingDetails.Load(networkMapping);
        }

        /// <summary>
        ///     Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id: " + this.ID);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("FriendlyName: " + this.FriendlyName);
            sb.AppendLine("PrimaryNetworkId: " + this.PrimaryNetworkId);
            sb.AppendLine("PrimaryNetworkFriendlyName: " + this.PrimaryNetworkFriendlyName);
            sb.AppendLine("PrimaryFabricFriendlyName: " + this.PrimaryFabricFriendlyName);
            sb.AppendLine("RecoveryNetworkId: " + this.RecoveryNetworkId);
            sb.AppendLine("RecoveryNetworkFriendlyName: " + this.RecoveryNetworkFriendlyName);
            sb.AppendLine("RecoveryFabricFriendlyName: " + this.RecoveryFabricFriendlyName);
            sb.AppendLine("PairingStatus: " + this.PairingStatus);

            var fabricSpecificDetails = this.FabricSpecificNetworkMappingDetails.ToString();
            if (!string.IsNullOrEmpty(fabricSpecificDetails))
            {
                sb.AppendLine(fabricSpecificDetails);
            }

            return sb.ToString();
        }

        #region Properties

        /// <summary>
        ///     Gets or sets Mapping Id.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Mapping Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Mapping Friendly Name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Primary network Id.
        /// </summary>
        public string PrimaryNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets Primary network friendly name.
        /// </summary>
        public string PrimaryNetworkFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets primary fabric friendly name.
        /// </summary>
        public string PrimaryFabricFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Recovery network Id.
        /// </summary>
        public string RecoveryNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets Recovery network friendly name.
        /// </summary>
        public string RecoveryNetworkFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets recovery fabric friendly name.
        /// </summary>
        public string RecoveryFabricFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets pairing status.
        /// </summary>
        public string PairingStatus { get; set; }

        /// <summary>
        ///     Fabric specific network mapping details.
        /// </summary>
        public ASRFabricSpecificNetworkMappingDetails FabricSpecificNetworkMappingDetails
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    ///     Fabric specific details
    /// </summary>
    public abstract class ASRFabricSpecificNetworkMappingDetails
    {
        /// <summary>
        ///     Loads fabric specific details for network mapping.
        /// </summary>
        /// <param name="networkMapping">Network mapping response from API.</param>
        /// <returns></returns>
        public static ASRFabricSpecificNetworkMappingDetails Load(
            NetworkMapping networkMapping)
        {
            if (networkMapping.Properties.FabricSpecificSettings is
                AzureToAzureNetworkMappingSettings)
            {
                return ASRAzureToAzureNetworkMappingDetails.LoadFabricDetails(networkMapping);
            }

            if (networkMapping.Properties.FabricSpecificSettings is VmmToAzureNetworkMappingSettings
            )
            {
                return ASRVmmToAzureNetworkMappingDetails.LoadFabricDetails(networkMapping);
            }

            if (networkMapping.Properties.FabricSpecificSettings is VmmToVmmNetworkMappingSettings)
            {
                return ASRVmmToVmmNetworkMappingDetails.LoadFabricDetails(networkMapping);
            }

            throw new InvalidOperationException(Resources.NetworkMappingNotFound);
        }
    }

    /// <summary>
    ///     Vmm to Vmm specific properties for network mapping.
    /// </summary>
    public class ASRVmmToVmmNetworkMappingDetails : ASRFabricSpecificNetworkMappingDetails
    {
        /// <summary>
        ///     Loads e2e specific details for network mapping.
        /// </summary>
        /// <param name="networkMapping">Network mapping response from API.</param>
        /// <returns></returns>
        public static ASRFabricSpecificNetworkMappingDetails LoadFabricDetails(
            NetworkMapping networkMapping)
        {
            var e2ESpecificDetails =
                networkMapping.Properties.FabricSpecificSettings as VmmToVmmNetworkMappingSettings;
            if (e2ESpecificDetails == null)
            {
                throw new InvalidOperationException(Resources.InvalidNetworkMappingDetails);
            }

            return new ASRVmmToVmmNetworkMappingDetails();
        }

        /// <summary>
        ///     Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            return sb.ToString();
        }
    }

    /// <summary>
    ///     Vmm to Azure specific properties for network mapping.
    /// </summary>
    public class ASRVmmToAzureNetworkMappingDetails : ASRFabricSpecificNetworkMappingDetails
    {
        /// <summary>
        ///     Loads e2a specific details for network mapping.
        /// </summary>
        /// <param name="networkMapping">Network mapping response from API.</param>
        /// <returns></returns>
        public static ASRFabricSpecificNetworkMappingDetails LoadFabricDetails(
            NetworkMapping networkMapping)
        {
            var e2ASpecificDetails =
                networkMapping.Properties
                    .FabricSpecificSettings as VmmToAzureNetworkMappingSettings;
            if (e2ASpecificDetails == null)
            {
                throw new InvalidOperationException(Resources.InvalidNetworkMappingDetails);
            }

            return new ASRVmmToAzureNetworkMappingDetails();
        }

        /// <summary>
        ///     Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            return sb.ToString();
        }
    }

    /// <summary>
    ///     Azure to Azure specific properties for network mapping.
    /// </summary>
    public class ASRAzureToAzureNetworkMappingDetails : ASRFabricSpecificNetworkMappingDetails
    {
        /// <summary>
        ///     Loads a2a specific details for network mapping.
        /// </summary>
        /// <param name="networkMapping">Network mapping response from API.</param>
        /// <returns></returns>
        public static ASRFabricSpecificNetworkMappingDetails LoadFabricDetails(
            NetworkMapping networkMapping)
        {
            var a2ASpecificDetails =
                networkMapping.Properties.FabricSpecificSettings as
                    AzureToAzureNetworkMappingSettings;
            if (a2ASpecificDetails == null)
            {
                throw new InvalidOperationException(Resources.InvalidNetworkMappingDetails);
            }

            return new ASRAzureToAzureNetworkMappingDetails
            {
                PrimaryNetworkLocation = a2ASpecificDetails.PrimaryFabricLocation,
                RecoveryNetworkLocation = a2ASpecificDetails.RecoveryFabricLocation
            };
        }

        /// <summary>
        ///     Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("PrimaryNetworkLocation: " + this.PrimaryNetworkLocation);
            sb.AppendLine("RecoveryNetworkLocation: " + this.RecoveryNetworkLocation);
            return sb.ToString();
        }

        #region Azure to Azure network mapping specific properties

        /// <summary>
        ///     Gets or sets primary network location.
        /// </summary>
        public string PrimaryNetworkLocation { get; set; }

        /// <summary>
        ///     Gets or sets recovery network location.
        /// </summary>
        public string RecoveryNetworkLocation { get; set; }

        #endregion
    }
}
