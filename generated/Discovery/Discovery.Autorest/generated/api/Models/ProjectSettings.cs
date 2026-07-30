// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Settings schema for the project</summary>
    public partial class ProjectSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettingsInternal
    {

        /// <summary>Backing field for <see cref="BehaviorPreference" /> property.</summary>
        private string _behaviorPreference;

        /// <summary>Default preferences to guide AI behaviors in this project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string BehaviorPreference { get => this._behaviorPreference; set => this._behaviorPreference = value; }

        /// <summary>Creates an new <see cref="ProjectSettings" /> instance.</summary>
        public ProjectSettings()
        {

        }
    }
    /// Settings schema for the project
    public partial interface IProjectSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>Default preferences to guide AI behaviors in this project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Default preferences to guide AI behaviors in this project.",
        SerializedName = @"behaviorPreferences",
        PossibleTypes = new [] { typeof(string) })]
        string BehaviorPreference { get; set; }

    }
    /// Settings schema for the project
    internal partial interface IProjectSettingsInternal

    {
        /// <summary>Default preferences to guide AI behaviors in this project.</summary>
        string BehaviorPreference { get; set; }

    }
}