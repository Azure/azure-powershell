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
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
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
            this.ID = network.ID;
            this.Name = network.Name;
            this.Type = network.Type;
            this.FabricObjectID = network.FabricObjectID;
            this.FabricType = network.FabricType;
            this.ServerId = network.ServerID;
            this.VmNetworkSubnetList = network.VmNetworkSubnetList;
        }

        #region Properties
        /// <summary>
        /// Gets or sets name of the Network.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Network ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Fabric object Id.
        /// </summary>
        public string FabricObjectID { get; set; }

        /// <summary>
        /// Gets or sets Server Id.
        /// </summary>
        public string ServerId { get; set; }

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
        public IList<VmNetworkSubnetDetails> VmNetworkSubnetList { get; set; }
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
            this.PrimaryServerId = networkMapping.PrimaryServerId;
            this.PrimaryNetworkId = networkMapping.PrimaryNetworkId;
            this.PrimaryNetworkName = networkMapping.PrimaryNetworkName;
            this.RecoveryServerId = networkMapping.RecoveryServerId;
            this.RecoveryNetworkId = networkMapping.RecoveryNetworkId;
            this.RecoveryNetworkName = networkMapping.RecoveryNetworkName;
            this.PairingStatus = networkMapping.PairingStatus;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Primary server Id.
        /// </summary>
        public string PrimaryServerId { get; set; }

        /// <summary>
        /// Gets or sets Primary network Id.
        /// </summary>
        public string PrimaryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Primary network name.
        /// </summary>
        public string PrimaryNetworkName { get; set; }

        /// <summary>
        /// Gets or sets Recovery server Id.
        /// </summary>
        public string RecoveryServerId { get; set; }

        /// <summary>
        /// Gets or sets Recovery network Id.
        /// </summary>
        public string RecoveryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Recovery network name.
        /// </summary>
        public string RecoveryNetworkName { get; set; }

        /// <summary>
        /// Gets or sets pairing status.
        /// </summary>
        public string PairingStatus { get; set; }
        #endregion
    }
}