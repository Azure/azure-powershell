// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.App.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Extensions;

    /// <summary>
    /// Configuration properties that define the mutable settings of a Container App SourceControl
    /// </summary>
    public partial class GithubActionConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.IGithubActionConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.IGithubActionConfigurationInternal
    {

        /// <summary>Backing field for <see cref="AzureCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentials _azureCredentials;

        /// <summary>AzureCredentials configurations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentials AzureCredentials { get => (this._azureCredentials = this._azureCredentials ?? new Microsoft.Azure.PowerShell.Cmdlets.App.Models.AzureCredentials()); set => this._azureCredentials = value; }

        /// <summary>Client Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public string AzureCredentialsClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).ClientId = value ?? null; }

        /// <summary>Client Secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public System.Security.SecureString AzureCredentialsClientSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).ClientSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).ClientSecret = value ?? null; }

        /// <summary>Kind of auth github does for deploying the template</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public string AzureCredentialsKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).Kind = value ?? null; }

        /// <summary>Subscription Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public string AzureCredentialsSubscriptionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).SubscriptionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).SubscriptionId = value ?? null; }

        /// <summary>Tenant Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public string AzureCredentialsTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentialsInternal)AzureCredentials).TenantId = value ?? null; }

        /// <summary>Backing field for <see cref="ContextPath" /> property.</summary>
        private string _contextPath;

        /// <summary>Context path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public string ContextPath { get => this._contextPath; set => this._contextPath = value; }

        /// <summary>Backing field for <see cref="GithubPersonalAccessToken" /> property.</summary>
        private System.Security.SecureString _githubPersonalAccessToken;

        /// <summary>One time Github PAT to configure github environment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public System.Security.SecureString GithubPersonalAccessToken { get => this._githubPersonalAccessToken; set => this._githubPersonalAccessToken = value; }

        /// <summary>Backing field for <see cref="Image" /> property.</summary>
        private string _image;

        /// <summary>Image name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public string Image { get => this._image; set => this._image = value; }

        /// <summary>Internal Acessors for AzureCredentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentials Microsoft.Azure.PowerShell.Cmdlets.App.Models.IGithubActionConfigurationInternal.AzureCredentials { get => (this._azureCredentials = this._azureCredentials ?? new Microsoft.Azure.PowerShell.Cmdlets.App.Models.AzureCredentials()); set { {_azureCredentials = value;} } }

        /// <summary>Internal Acessors for RegistryInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfo Microsoft.Azure.PowerShell.Cmdlets.App.Models.IGithubActionConfigurationInternal.RegistryInfo { get => (this._registryInfo = this._registryInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.App.Models.RegistryInfo()); set { {_registryInfo = value;} } }

        /// <summary>Backing field for <see cref="OS" /> property.</summary>
        private string _oS;

        /// <summary>Operation system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public string OS { get => this._oS; set => this._oS = value; }

        /// <summary>Backing field for <see cref="PublishType" /> property.</summary>
        private string _publishType;

        /// <summary>Code or Image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public string PublishType { get => this._publishType; set => this._publishType = value; }

        /// <summary>Backing field for <see cref="RegistryInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfo _registryInfo;

        /// <summary>Registry configurations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfo RegistryInfo { get => (this._registryInfo = this._registryInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.App.Models.RegistryInfo()); set => this._registryInfo = value; }

        /// <summary>registry secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public System.Security.SecureString RegistryInfoRegistryPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfoInternal)RegistryInfo).RegistryPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfoInternal)RegistryInfo).RegistryPassword = value ?? null; }

        /// <summary>registry server Url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public string RegistryInfoRegistryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfoInternal)RegistryInfo).RegistryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfoInternal)RegistryInfo).RegistryUrl = value ?? null; }

        /// <summary>registry username.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Inlined)]
        public string RegistryInfoRegistryUserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfoInternal)RegistryInfo).RegistryUserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfoInternal)RegistryInfo).RegistryUserName = value ?? null; }

        /// <summary>Backing field for <see cref="RuntimeStack" /> property.</summary>
        private string _runtimeStack;

        /// <summary>Runtime stack</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public string RuntimeStack { get => this._runtimeStack; set => this._runtimeStack = value; }

        /// <summary>Backing field for <see cref="RuntimeVersion" /> property.</summary>
        private string _runtimeVersion;

        /// <summary>Runtime version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public string RuntimeVersion { get => this._runtimeVersion; set => this._runtimeVersion = value; }

        /// <summary>Creates an new <see cref="GithubActionConfiguration" /> instance.</summary>
        public GithubActionConfiguration()
        {

        }
    }
    /// Configuration properties that define the mutable settings of a Container App SourceControl
    public partial interface IGithubActionConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.IJsonSerializable
    {
        /// <summary>Client Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Client Id.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string AzureCredentialsClientId { get; set; }
        /// <summary>Client Secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Client Secret.",
        SerializedName = @"clientSecret",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AzureCredentialsClientSecret { get; set; }
        /// <summary>Kind of auth github does for deploying the template</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Kind of auth github does for deploying the template",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string AzureCredentialsKind { get; set; }
        /// <summary>Subscription Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Subscription Id.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string AzureCredentialsSubscriptionId { get; set; }
        /// <summary>Tenant Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Tenant Id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string AzureCredentialsTenantId { get; set; }
        /// <summary>Context path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Context path",
        SerializedName = @"contextPath",
        PossibleTypes = new [] { typeof(string) })]
        string ContextPath { get; set; }
        /// <summary>One time Github PAT to configure github environment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"One time Github PAT to configure github environment",
        SerializedName = @"githubPersonalAccessToken",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString GithubPersonalAccessToken { get; set; }
        /// <summary>Image name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Image name",
        SerializedName = @"image",
        PossibleTypes = new [] { typeof(string) })]
        string Image { get; set; }
        /// <summary>Operation system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Operation system",
        SerializedName = @"os",
        PossibleTypes = new [] { typeof(string) })]
        string OS { get; set; }
        /// <summary>Code or Image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Code or Image",
        SerializedName = @"publishType",
        PossibleTypes = new [] { typeof(string) })]
        string PublishType { get; set; }
        /// <summary>registry secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"registry secret.",
        SerializedName = @"registryPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString RegistryInfoRegistryPassword { get; set; }
        /// <summary>registry server Url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"registry server Url.",
        SerializedName = @"registryUrl",
        PossibleTypes = new [] { typeof(string) })]
        string RegistryInfoRegistryUrl { get; set; }
        /// <summary>registry username.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"registry username.",
        SerializedName = @"registryUserName",
        PossibleTypes = new [] { typeof(string) })]
        string RegistryInfoRegistryUserName { get; set; }
        /// <summary>Runtime stack</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Runtime stack",
        SerializedName = @"runtimeStack",
        PossibleTypes = new [] { typeof(string) })]
        string RuntimeStack { get; set; }
        /// <summary>Runtime version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Runtime version",
        SerializedName = @"runtimeVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RuntimeVersion { get; set; }

    }
    /// Configuration properties that define the mutable settings of a Container App SourceControl
    internal partial interface IGithubActionConfigurationInternal

    {
        /// <summary>AzureCredentials configurations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAzureCredentials AzureCredentials { get; set; }
        /// <summary>Client Id.</summary>
        string AzureCredentialsClientId { get; set; }
        /// <summary>Client Secret.</summary>
        System.Security.SecureString AzureCredentialsClientSecret { get; set; }
        /// <summary>Kind of auth github does for deploying the template</summary>
        string AzureCredentialsKind { get; set; }
        /// <summary>Subscription Id.</summary>
        string AzureCredentialsSubscriptionId { get; set; }
        /// <summary>Tenant Id.</summary>
        string AzureCredentialsTenantId { get; set; }
        /// <summary>Context path</summary>
        string ContextPath { get; set; }
        /// <summary>One time Github PAT to configure github environment</summary>
        System.Security.SecureString GithubPersonalAccessToken { get; set; }
        /// <summary>Image name</summary>
        string Image { get; set; }
        /// <summary>Operation system</summary>
        string OS { get; set; }
        /// <summary>Code or Image</summary>
        string PublishType { get; set; }
        /// <summary>Registry configurations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryInfo RegistryInfo { get; set; }
        /// <summary>registry secret.</summary>
        System.Security.SecureString RegistryInfoRegistryPassword { get; set; }
        /// <summary>registry server Url.</summary>
        string RegistryInfoRegistryUrl { get; set; }
        /// <summary>registry username.</summary>
        string RegistryInfoRegistryUserName { get; set; }
        /// <summary>Runtime stack</summary>
        string RuntimeStack { get; set; }
        /// <summary>Runtime version</summary>
        string RuntimeVersion { get; set; }

    }
}