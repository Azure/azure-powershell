// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Extensions;

    /// <summary>Elastic traffic filter object</summary>
    public partial class ElasticTrafficFilter :
        Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilter,
        Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilterInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Origin(Microsoft.Azure.PowerShell.Cmdlets.Elastic.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Id of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Origin(Microsoft.Azure.PowerShell.Cmdlets.Elastic.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="IncludeByDefault" /> property.</summary>
        private bool? _includeByDefault;

        /// <summary>IncludeByDefault for the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Origin(Microsoft.Azure.PowerShell.Cmdlets.Elastic.PropertyOrigin.Owned)]
        public bool? IncludeByDefault { get => this._includeByDefault; set => this._includeByDefault = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Origin(Microsoft.Azure.PowerShell.Cmdlets.Elastic.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Region" /> property.</summary>
        private string _region;

        /// <summary>Region of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Origin(Microsoft.Azure.PowerShell.Cmdlets.Elastic.PropertyOrigin.Owned)]
        public string Region { get => this._region; set => this._region = value; }

        /// <summary>Backing field for <see cref="Rule" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilterRule> _rule;

        /// <summary>Rules in the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Origin(Microsoft.Azure.PowerShell.Cmdlets.Elastic.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilterRule> Rule { get => this._rule; set => this._rule = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Origin(Microsoft.Azure.PowerShell.Cmdlets.Elastic.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ElasticTrafficFilter" /> instance.</summary>
        public ElasticTrafficFilter()
        {

        }
    }
    /// Elastic traffic filter object
    public partial interface IElasticTrafficFilter :
        Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.IJsonSerializable
    {
        /// <summary>Description of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Description of the elastic filter",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Id of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Id of the elastic filter",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>IncludeByDefault for the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"IncludeByDefault for the elastic filter",
        SerializedName = @"includeByDefault",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludeByDefault { get; set; }
        /// <summary>Name of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the elastic filter",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Region of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Region of the elastic filter",
        SerializedName = @"region",
        PossibleTypes = new [] { typeof(string) })]
        string Region { get; set; }
        /// <summary>Rules in the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Rules in the elastic filter",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilterRule) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilterRule> Rule { get; set; }
        /// <summary>Type of the elastic filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of the elastic filter",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Elastic.PSArgumentCompleterAttribute("ip", "azure_private_endpoint")]
        string Type { get; set; }

    }
    /// Elastic traffic filter object
    internal partial interface IElasticTrafficFilterInternal

    {
        /// <summary>Description of the elastic filter</summary>
        string Description { get; set; }
        /// <summary>Id of the elastic filter</summary>
        string Id { get; set; }
        /// <summary>IncludeByDefault for the elastic filter</summary>
        bool? IncludeByDefault { get; set; }
        /// <summary>Name of the elastic filter</summary>
        string Name { get; set; }
        /// <summary>Region of the elastic filter</summary>
        string Region { get; set; }
        /// <summary>Rules in the elastic filter</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilterRule> Rule { get; set; }
        /// <summary>Type of the elastic filter</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Elastic.PSArgumentCompleterAttribute("ip", "azure_private_endpoint")]
        string Type { get; set; }

    }
}