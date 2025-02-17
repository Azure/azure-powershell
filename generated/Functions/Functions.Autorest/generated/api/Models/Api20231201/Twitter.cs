// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The configuration settings of the Twitter provider.</summary>
    public partial class Twitter :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitter,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// <code>false</code> if the Twitter provider should not be enabled despite the set registration; otherwise, <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Internal Acessors for Registration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistration Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterInternal.Registration { get => (this._registration = this._registration ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.TwitterRegistration()); set { {_registration = value;} } }

        /// <summary>Backing field for <see cref="Registration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistration _registration;

        /// <summary>The configuration settings of the app registration for the Twitter provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistration Registration { get => (this._registration = this._registration ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.TwitterRegistration()); set => this._registration = value; }

        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RegistrationConsumerKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistrationInternal)Registration).ConsumerKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistrationInternal)Registration).ConsumerKey = value ?? null; }

        /// <summary>
        /// The app setting name that contains the OAuth 1.0a consumer secret of the Twitter
        /// application used for sign-in.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RegistrationConsumerSecretSettingName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistrationInternal)Registration).ConsumerSecretSettingName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistrationInternal)Registration).ConsumerSecretSettingName = value ?? null; }

        /// <summary>Creates an new <see cref="Twitter" /> instance.</summary>
        public Twitter()
        {

        }
    }
    /// The configuration settings of the Twitter provider.
    public partial interface ITwitter :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// <code>false</code> if the Twitter provider should not be enabled despite the set registration; otherwise, <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>false</code> if the Twitter provider should not be enabled despite the set registration; otherwise, <code>true</code>.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        This setting is required for enabling Twitter Sign-In.
        Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in",
        SerializedName = @"consumerKey",
        PossibleTypes = new [] { typeof(string) })]
        string RegistrationConsumerKey { get; set; }
        /// <summary>
        /// The app setting name that contains the OAuth 1.0a consumer secret of the Twitter
        /// application used for sign-in.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The app setting name that contains the OAuth 1.0a consumer secret of the Twitter
        application used for sign-in.",
        SerializedName = @"consumerSecretSettingName",
        PossibleTypes = new [] { typeof(string) })]
        string RegistrationConsumerSecretSettingName { get; set; }

    }
    /// The configuration settings of the Twitter provider.
    internal partial interface ITwitterInternal

    {
        /// <summary>
        /// <code>false</code> if the Twitter provider should not be enabled despite the set registration; otherwise, <code>true</code>.
        /// </summary>
        bool? Enabled { get; set; }
        /// <summary>The configuration settings of the app registration for the Twitter provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITwitterRegistration Registration { get; set; }
        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        string RegistrationConsumerKey { get; set; }
        /// <summary>
        /// The app setting name that contains the OAuth 1.0a consumer secret of the Twitter
        /// application used for sign-in.
        /// </summary>
        string RegistrationConsumerSecretSettingName { get; set; }

    }
}