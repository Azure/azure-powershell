﻿using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSqlPool : PSSynapseTrackedResource
    {
        public PSSynapseSqlPool(string resourceGroupName, string workspaceName, SqlPool sqlPool)
            : base(sqlPool?.Location, sqlPool?.Id, sqlPool?.Name, sqlPool?.Type, sqlPool?.Tags)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.Sku = sqlPool?.Sku != null ? new PSSynapseSku(sqlPool.Sku) : null;
            this.MaxSizeBytes = sqlPool?.MaxSizeBytes;
            this.Collation = sqlPool?.Collation;
            this.SourceDatabaseId = sqlPool?.SourceDatabaseId;
            this.RecoverableDatabaseId = sqlPool?.RecoverableDatabaseId;
            this.ProvisioningState = sqlPool?.ProvisioningState;
            this.Status = sqlPool?.Status;
            this.CreateMode = sqlPool?.CreateMode;
            this.CreationDate = sqlPool?.CreationDate;

            if (sqlPool?.RestorePointInTime != null)
            {
                this.RestorePointInTime = DateTime.Parse(sqlPool.RestorePointInTime);
            }
        }

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the workspace
        /// </summary>
        public string WorkspaceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the SQL pool
        /// </summary>
        public string SqlPoolName 
        {
            get
            {
                return this.Name;
            }

            set
            {
                this.Name = value;
            }
        }

        /// <summary>
        /// Gets the name of the SQL pool
        /// </summary>
        [Hidden]
        public override string Name { get; protected set; }

        /// <summary>
        /// Gets SQL pool SKU
        /// </summary>
        public PSSynapseSku Sku { get; set; }

        /// <summary>
        /// Gets maximum size in bytes
        /// </summary>
        public long? MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets collation mode
        /// </summary>
        public string Collation { get; set; }

        /// <summary>
        /// Gets source database to create from
        /// </summary>
        public string SourceDatabaseId { get; set; }

        /// <summary>
        /// Gets backup database to restore from
        /// </summary>
        public string RecoverableDatabaseId { get; set; }

        /// <summary>
        /// Gets resource state
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets resource status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets snapshot time to restore
        /// </summary>
        public System.DateTime? RestorePointInTime { get; set; }

        /// <summary>
        /// Gets what is this?
        /// </summary>
        public string CreateMode { get; set; }

        /// <summary>
        /// Gets date the SQL pool was created
        /// </summary>
        public System.DateTime? CreationDate { get; set; }
    }
}