// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the Sql ElasticPool resource settings.</summary>
    public partial class SqlElasticPoolResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ISqlElasticPoolResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ISqlElasticPoolResourceSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettings __resourceSettings = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ResourceSettings();

        /// <summary>
        /// The resource type. For example, the value can be Microsoft.Compute/virtualMachines.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettingsInternal)__resourceSettings).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettingsInternal)__resourceSettings).ResourceType = value ; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ISqlElasticPoolResourceSettingsTags _tag;

        /// <summary>Gets or sets the Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ISqlElasticPoolResourceSettingsTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.SqlElasticPoolResourceSettingsTags()); set => this._tag = value; }

        /// <summary>Gets or sets the target resource group name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string TargetResourceGroupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettingsInternal)__resourceSettings).TargetResourceGroupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettingsInternal)__resourceSettings).TargetResourceGroupName = value ?? null; }

        /// <summary>Gets or sets the target Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string TargetResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettingsInternal)__resourceSettings).TargetResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettingsInternal)__resourceSettings).TargetResourceName = value ?? null; }

        /// <summary>Backing field for <see cref="ZoneRedundant" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ZoneRedundant? _zoneRedundant;

        /// <summary>Defines the zone redundant resource setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ZoneRedundant? ZoneRedundant { get => this._zoneRedundant; set => this._zoneRedundant = value; }

        /// <summary>Creates an new <see cref="SqlElasticPoolResourceSettings" /> instance.</summary>
        public SqlElasticPoolResourceSettings()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resourceSettings), __resourceSettings);
            await eventListener.AssertObjectIsValid(nameof(__resourceSettings), __resourceSettings);
        }
    }
    /// Defines the Sql ElasticPool resource settings.
    public partial interface ISqlElasticPoolResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettings
    {
        /// <summary>Gets or sets the Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ISqlElasticPoolResourceSettingsTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ISqlElasticPoolResourceSettingsTags Tag { get; set; }
        /// <summary>Defines the zone redundant resource setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines the zone redundant resource setting.",
        SerializedName = @"zoneRedundant",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ZoneRedundant) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ZoneRedundant? ZoneRedundant { get; set; }

    }
    /// Defines the Sql ElasticPool resource settings.
    internal partial interface ISqlElasticPoolResourceSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IResourceSettingsInternal
    {
        /// <summary>Gets or sets the Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ISqlElasticPoolResourceSettingsTags Tag { get; set; }
        /// <summary>Defines the zone redundant resource setting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ZoneRedundant? ZoneRedundant { get; set; }

    }
}