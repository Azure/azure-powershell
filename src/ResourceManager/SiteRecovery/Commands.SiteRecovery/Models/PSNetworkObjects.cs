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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Azure Site Recovery Network.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRNetwork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRNetwork" /> class.
        /// </summary>
        public ASRNetwork()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRNetwork" /> class with required
        /// parameters.
        /// </summary>
        /// <param name="network">Network object</param>
        public ASRNetwork(Network network)
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
        /// Gets or sets friendly name of the Network.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets name of the Network.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Network ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Type of Network.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Fabric object  type.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        /// Gets or sets VM Network subnets.
        /// </summary>
        public IList<Subnet> VmNetworkSubnetList { get; set; }
        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Logical Network.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRLogicalNetwork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRNetwork" /> class.
        /// </summary>
        public ASRLogicalNetwork()
        {
        }

        #region Properties
        /// <summary>
        /// Gets or sets friendly name of the Network.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets name of the Network.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Network ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Type of Network.
        /// </summary>
        public string Type { get; set; }
        #endregion
    }
    /// <summary>
    /// Azure Site Recovery Network Mapping.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRNetworkMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRNetworkMapping" /> class.
        /// </summary>
        public ASRNetworkMapping()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRNetworkMapping" /> class with required
        /// parameters.
        /// </summary>
        /// <param name="networkMapping">Network mapping object</param>
        public ASRNetworkMapping(NetworkMapping networkMapping)
        {
            this.ID = networkMapping.Id;
            this.Name = networkMapping.Name;
            this.FriendlyName = networkMapping.Name;
            this.PrimaryNetworkId = networkMapping.Id.Substring(0, networkMapping.Id.IndexOf("/replicationNetworkMappings"));
            this.PrimaryNetworkFriendlyName = networkMapping.Properties.PrimaryNetworkFriendlyName;
            this.RecoveryNetworkId = networkMapping.Properties.RecoveryNetworkId;
            this.RecoveryNetworkFriendlyName = networkMapping.Properties.RecoveryNetworkFriendlyName;
            this.PairingStatus = networkMapping.Properties.PairingStatus;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Mapping Id.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Mapping Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Mapping Friendly Name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Primary network Id.
        /// </summary>
        public string PrimaryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Primary network friendly name.
        /// </summary>
        public string PrimaryNetworkFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Recovery network Id.
        /// </summary>
        public string RecoveryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Recovery network friendly name.
        /// </summary>
        public string RecoveryNetworkFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets pairing status.
        /// </summary>
        public string PairingStatus { get; set; }
        #endregion
    }
}