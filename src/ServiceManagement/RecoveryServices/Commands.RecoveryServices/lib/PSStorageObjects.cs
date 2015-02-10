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
    /// Azure Site Recovery Storage.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRStorage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRStorage" /> class.
        /// </summary>
        public ASRStorage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRStorage" /> class with required
        /// parameters.
        /// </summary>
        /// <param name="storage">Storage object</param>
        public ASRStorage(Storage storage)
        {
            this.ID = storage.ID;
            this.Name = storage.Name;
            this.Type = storage.Type;
            this.FabricObjectID = storage.FabricObjectID;
            this.FabricType = storage.FabricType;
            this.ServerId = storage.ServerID;

            if (this.Type == StorageType.Pool.ToString())
            {
                this.StoragePools = storage.StoragePools;
            }
        }

        /// <summary>
        /// Storage Type.
        /// </summary>
        public enum StorageType
        {
            /// <summary>
            /// Unknown type.
            /// </summary>
            Other = 0,

            /// <summary>
            /// Classification type.
            /// </summary>
            Classification,

            /// <summary>
            /// Pool type.
            /// </summary>
            Pool,
        }

        #region Properties
        /// <summary>
        /// Gets or sets name of the Storage.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Storage ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Fabric object ID.
        /// </summary>
        public string FabricObjectID { get; set; }

        /// <summary>
        /// Gets or sets Server Id.
        /// </summary>
        public string ServerId { get; set; }

        /// <summary>
        /// Gets or sets to Type of Storage.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Fabric type.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        /// Gets or sets storage pools for storage arrays.
        /// </summary>
        public IList<StoragePool> StoragePools { get; set; }

        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Storage Mapping.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRStorageMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRStorageMapping" /> class.
        /// </summary>
        public ASRStorageMapping()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRStorageMapping" /> class with required
        /// parameters.
        /// </summary>
        /// <param name="storageMapping">Storage mapping object</param>
        public ASRStorageMapping(StorageMapping storageMapping)
        {
            this.PrimaryServerId = storageMapping.PrimaryServerId;
            this.PrimaryStorageId = storageMapping.PrimaryStorageId;
            this.PrimaryStorageName = storageMapping.PrimaryStorageName;
            this.RecoveryServerId = storageMapping.RecoveryServerId;
            this.RecoveryStorageId = storageMapping.RecoveryStorageId;
            this.RecoveryStorageName = storageMapping.RecoveryStorageName;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Primary server Id.
        /// </summary>
        public string PrimaryServerId { get; set; }

        /// <summary>
        /// Gets or sets Primary storage Id.
        /// </summary>
        public string PrimaryStorageId { get; set; }

        /// <summary>
        /// Gets or sets Primary storage name.
        /// </summary>
        public string PrimaryStorageName { get; set; }

        /// <summary>
        /// Gets or sets Recovery server Id.
        /// </summary>
        public string RecoveryServerId { get; set; }

        /// <summary>
        /// Gets or sets Recovery storage Id.
        /// </summary>
        public string RecoveryStorageId { get; set; }

        /// <summary>
        /// Gets or sets Recovery storage name.
        /// </summary>
        public string RecoveryStorageName { get; set; }
        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Storage Pool Mapping.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRStoragePoolMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRStoragePoolMapping" /> class.
        /// </summary>
        public ASRStoragePoolMapping()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRStoragePoolMapping" /> class with required
        /// parameters.
        /// </summary>
        /// <param name="storagePoolMapping">Storage mapping object</param>
        public ASRStoragePoolMapping(StoragePoolMapping storagePoolMapping)
        {
            this.PrimaryServerId = storagePoolMapping.PrimaryServerId;
            this.PrimaryStoragePoolId = storagePoolMapping.PrimaryStoragePoolId;
            this.PrimaryStoragePoolName = storagePoolMapping.PrimaryStoragePoolName;
            this.RecoveryServerId = storagePoolMapping.RecoveryServerId;
            this.RecoveryStoragePoolId = storagePoolMapping.RecoveryStoragePoolId;
            this.RecoveryStoragePoolName = storagePoolMapping.RecoveryStoragePoolName;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Primary server Id.
        /// </summary>
        public string PrimaryServerId { get; set; }

        /// <summary>
        /// Gets or sets Primary storage pool Id.
        /// </summary>
        public string PrimaryStoragePoolId { get; set; }

        /// <summary>
        /// Gets or sets Primary storage pool name.
        /// </summary>
        public string PrimaryStoragePoolName { get; set; }

        /// <summary>
        /// Gets or sets Recovery server Id.
        /// </summary>
        public string RecoveryServerId { get; set; }

        /// <summary>
        /// Gets or sets Recovery storage pool Id.
        /// </summary>
        public string RecoveryStoragePoolId { get; set; }

        /// <summary>
        /// Gets or sets Recovery storage pool name.
        /// </summary>
        public string RecoveryStoragePoolName { get; set; }
        #endregion
    }
}
