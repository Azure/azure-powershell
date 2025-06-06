// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Bot channel resource definition</summary>
    public partial class ConnectionSetting :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSetting,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Resource();

        /// <summary>Client Id associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ClientId = value ?? null; }

        /// <summary>Client Secret associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ClientSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ClientSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ClientSecret = value ?? null; }

        /// <summary>Entity Tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Etag = value ?? null; }

        /// <summary>Specifies the resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Id; }

        /// <summary>Required. Gets or sets the Kind of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Kind = value ?? null; }

        /// <summary>Specifies the location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.ConnectionSettingProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for SettingId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingInternal.SettingId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).SettingId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).SettingId = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.ISku Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal.Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Sku = value; }

        /// <summary>Internal Acessors for SkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).SkuTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).SkuTier = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for Zone</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal.Zone { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Zone; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Zone = value; }

        /// <summary>Specifies the name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Name; }

        /// <summary>Service Provider Parameters associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingParameter> Parameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Parameter = value ?? null /* arrayOf */; }

        /// <summary>Id associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string PropertiesId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Id = value ?? null; }

        /// <summary>Name associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Name = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingProperties _property;

        /// <summary>The set of properties specific to bot channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.ConnectionSettingProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>Scopes associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Scope { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Scope; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).Scope = value ?? null; }

        /// <summary>Service Provider Display Name associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ServiceProviderDisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ServiceProviderDisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ServiceProviderDisplayName = value ?? null; }

        /// <summary>Service Provider Id associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ServiceProviderId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ServiceProviderId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).ServiceProviderId = value ?? null; }

        /// <summary>Setting Id set by the service for the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string SettingId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingPropertiesInternal)Property).SettingId; }

        /// <summary>Gets or sets the SKU of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.ISku Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Sku = value ?? null /* model class */; }

        /// <summary>The sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).SkuName = value ?? null; }

        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).SkuTier; }

        /// <summary>Contains resource tags defined as key/value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Tag = value ?? null /* model class */; }

        /// <summary>Specifies the type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Type; }

        /// <summary>Entity zones</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<string> Zone { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal)__resource).Zone; }

        /// <summary>Creates an new <see cref="ConnectionSetting" /> instance.</summary>
        public ConnectionSetting()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Bot channel resource definition
    public partial interface IConnectionSetting :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResource
    {
        /// <summary>Client Id associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Client Id associated with the Connection Setting.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>Client Secret associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Client Secret associated with the Connection Setting",
        SerializedName = @"clientSecret",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecret { get; set; }
        /// <summary>Service Provider Parameters associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Service Provider Parameters associated with the Connection Setting",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingParameter) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingParameter> Parameter { get; set; }
        /// <summary>Id associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Id associated with the Connection Setting.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesId { get; set; }
        /// <summary>Name associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name associated with the Connection Setting.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesName { get; set; }
        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Provisioning state of the resource",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>Scopes associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Scopes associated with the Connection Setting",
        SerializedName = @"scopes",
        PossibleTypes = new [] { typeof(string) })]
        string Scope { get; set; }
        /// <summary>Service Provider Display Name associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Service Provider Display Name associated with the Connection Setting",
        SerializedName = @"serviceProviderDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderDisplayName { get; set; }
        /// <summary>Service Provider Id associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Service Provider Id associated with the Connection Setting",
        SerializedName = @"serviceProviderId",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderId { get; set; }
        /// <summary>Setting Id set by the service for the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Setting Id set by the service for the Connection Setting.",
        SerializedName = @"settingId",
        PossibleTypes = new [] { typeof(string) })]
        string SettingId { get;  }

    }
    /// Bot channel resource definition
    internal partial interface IConnectionSettingInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IResourceInternal
    {
        /// <summary>Client Id associated with the Connection Setting.</summary>
        string ClientId { get; set; }
        /// <summary>Client Secret associated with the Connection Setting</summary>
        string ClientSecret { get; set; }
        /// <summary>Service Provider Parameters associated with the Connection Setting</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingParameter> Parameter { get; set; }
        /// <summary>Id associated with the Connection Setting.</summary>
        string PropertiesId { get; set; }
        /// <summary>Name associated with the Connection Setting.</summary>
        string PropertiesName { get; set; }
        /// <summary>The set of properties specific to bot channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IConnectionSettingProperties Property { get; set; }
        /// <summary>Provisioning state of the resource</summary>
        string ProvisioningState { get; set; }
        /// <summary>Scopes associated with the Connection Setting</summary>
        string Scope { get; set; }
        /// <summary>Service Provider Display Name associated with the Connection Setting</summary>
        string ServiceProviderDisplayName { get; set; }
        /// <summary>Service Provider Id associated with the Connection Setting</summary>
        string ServiceProviderId { get; set; }
        /// <summary>Setting Id set by the service for the Connection Setting.</summary>
        string SettingId { get; set; }

    }
}