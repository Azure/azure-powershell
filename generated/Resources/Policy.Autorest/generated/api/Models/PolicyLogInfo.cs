// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy log info.</summary>
    public partial class PolicyLogInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal
    {

        /// <summary>Backing field for <see cref="PolicyAssignmentId" /> property.</summary>
        private string _policyAssignmentId;

        /// <summary>The policy assignment Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAssignmentId { get => this._policyAssignmentId; set => this._policyAssignmentId = value; }

        /// <summary>Backing field for <see cref="PolicyAssignmentName" /> property.</summary>
        private string _policyAssignmentName;

        /// <summary>The policy assignment name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAssignmentName { get => this._policyAssignmentName; set => this._policyAssignmentName = value; }

        /// <summary>Backing field for <see cref="PolicyAssignmentScope" /> property.</summary>
        private string _policyAssignmentScope;

        /// <summary>The policy assignment scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAssignmentScope { get => this._policyAssignmentScope; set => this._policyAssignmentScope = value; }

        /// <summary>Backing field for <see cref="PolicyAssignmentVersion" /> property.</summary>
        private string _policyAssignmentVersion;

        /// <summary>The policy assignment version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAssignmentVersion { get => this._policyAssignmentVersion; set => this._policyAssignmentVersion = value; }

        /// <summary>Backing field for <see cref="PolicyDefinitionEffect" /> property.</summary>
        private string _policyDefinitionEffect;

        /// <summary>The policy definition action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyDefinitionEffect { get => this._policyDefinitionEffect; set => this._policyDefinitionEffect = value; }

        /// <summary>Backing field for <see cref="PolicyDefinitionId" /> property.</summary>
        private string _policyDefinitionId;

        /// <summary>The policy definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyDefinitionId { get => this._policyDefinitionId; set => this._policyDefinitionId = value; }

        /// <summary>Backing field for <see cref="PolicyDefinitionName" /> property.</summary>
        private string _policyDefinitionName;

        /// <summary>The policy definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyDefinitionName { get => this._policyDefinitionName; set => this._policyDefinitionName = value; }

        /// <summary>Backing field for <see cref="PolicyDefinitionReferenceId" /> property.</summary>
        private string _policyDefinitionReferenceId;

        /// <summary>The policy definition instance Id inside a policy set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyDefinitionReferenceId { get => this._policyDefinitionReferenceId; set => this._policyDefinitionReferenceId = value; }

        /// <summary>Backing field for <see cref="PolicyDefinitionVersion" /> property.</summary>
        private string _policyDefinitionVersion;

        /// <summary>The policy definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyDefinitionVersion { get => this._policyDefinitionVersion; set => this._policyDefinitionVersion = value; }

        /// <summary>Backing field for <see cref="PolicySetDefinitionId" /> property.</summary>
        private string _policySetDefinitionId;

        /// <summary>The policy set definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicySetDefinitionId { get => this._policySetDefinitionId; set => this._policySetDefinitionId = value; }

        /// <summary>Backing field for <see cref="PolicySetDefinitionName" /> property.</summary>
        private string _policySetDefinitionName;

        /// <summary>The policy set definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicySetDefinitionName { get => this._policySetDefinitionName; set => this._policySetDefinitionName = value; }

        /// <summary>Backing field for <see cref="PolicySetDefinitionVersion" /> property.</summary>
        private string _policySetDefinitionVersion;

        /// <summary>The policy set definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicySetDefinitionVersion { get => this._policySetDefinitionVersion; set => this._policySetDefinitionVersion = value; }

        /// <summary>Creates an new <see cref="PolicyLogInfo" /> instance.</summary>
        public PolicyLogInfo()
        {

        }
    }
    /// The policy log info.
    public partial interface IPolicyLogInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The policy assignment Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment Id.",
        SerializedName = @"policyAssignmentId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyAssignmentId { get; set; }
        /// <summary>The policy assignment name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment name.",
        SerializedName = @"policyAssignmentName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyAssignmentName { get; set; }
        /// <summary>The policy assignment scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment scope.",
        SerializedName = @"policyAssignmentScope",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyAssignmentScope { get; set; }
        /// <summary>The policy assignment version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment version.",
        SerializedName = @"policyAssignmentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyAssignmentVersion { get; set; }
        /// <summary>The policy definition action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition action.",
        SerializedName = @"policyDefinitionEffect",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyDefinitionEffect { get; set; }
        /// <summary>The policy definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition Id.",
        SerializedName = @"policyDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyDefinitionId { get; set; }
        /// <summary>The policy definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition name.",
        SerializedName = @"policyDefinitionName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyDefinitionName { get; set; }
        /// <summary>The policy definition instance Id inside a policy set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition instance Id inside a policy set.",
        SerializedName = @"policyDefinitionReferenceId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyDefinitionReferenceId { get; set; }
        /// <summary>The policy definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition version.",
        SerializedName = @"policyDefinitionVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyDefinitionVersion { get; set; }
        /// <summary>The policy set definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition Id.",
        SerializedName = @"policySetDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicySetDefinitionId { get; set; }
        /// <summary>The policy set definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition name.",
        SerializedName = @"policySetDefinitionName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicySetDefinitionName { get; set; }
        /// <summary>The policy set definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition version.",
        SerializedName = @"policySetDefinitionVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicySetDefinitionVersion { get; set; }

    }
    /// The policy log info.
    internal partial interface IPolicyLogInfoInternal

    {
        /// <summary>The policy assignment Id.</summary>
        string PolicyAssignmentId { get; set; }
        /// <summary>The policy assignment name.</summary>
        string PolicyAssignmentName { get; set; }
        /// <summary>The policy assignment scope.</summary>
        string PolicyAssignmentScope { get; set; }
        /// <summary>The policy assignment version.</summary>
        string PolicyAssignmentVersion { get; set; }
        /// <summary>The policy definition action.</summary>
        string PolicyDefinitionEffect { get; set; }
        /// <summary>The policy definition Id.</summary>
        string PolicyDefinitionId { get; set; }
        /// <summary>The policy definition name.</summary>
        string PolicyDefinitionName { get; set; }
        /// <summary>The policy definition instance Id inside a policy set.</summary>
        string PolicyDefinitionReferenceId { get; set; }
        /// <summary>The policy definition version.</summary>
        string PolicyDefinitionVersion { get; set; }
        /// <summary>The policy set definition Id.</summary>
        string PolicySetDefinitionId { get; set; }
        /// <summary>The policy set definition name.</summary>
        string PolicySetDefinitionName { get; set; }
        /// <summary>The policy set definition version.</summary>
        string PolicySetDefinitionVersion { get; set; }

    }
}