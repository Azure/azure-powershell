// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>List of Dimension.</summary>
    public partial class Dimension :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimension,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Resource();

        /// <summary>Dimension category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Category { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Category; }

        /// <summary>Dimension data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> Data { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Data; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Data = value ?? null /* arrayOf */; }

        /// <summary>Dimension description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Description; }

        /// <summary>ETag of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string ETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).ETag; }

        /// <summary>Filter enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public bool? FilterEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).FilterEnabled; }

        /// <summary>Grouping enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public bool? GroupingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).GroupingEnabled; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Id; }

        /// <summary>Location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Location; }

        /// <summary>Internal Acessors for Category</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.Category { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Category; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Category = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for FilterEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.FilterEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).FilterEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).FilterEnabled = value; }

        /// <summary>Internal Acessors for GroupingEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.GroupingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).GroupingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).GroupingEnabled = value; }

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.NextLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).NextLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).NextLink = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionProperties Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.DimensionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Total</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.Total { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Total; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Total = value; }

        /// <summary>Internal Acessors for UsageEnd</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.UsageEnd { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).UsageEnd; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).UsageEnd = value; }

        /// <summary>Internal Acessors for UsageStart</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionInternal.UsageStart { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).UsageStart; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).UsageStart = value; }

        /// <summary>Internal Acessors for ETag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal.ETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).ETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).ETag = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal.Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Sku</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal.Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Sku = value; }

        /// <summary>Internal Acessors for Tag</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceTags Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal.Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Tag = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Name; }

        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string NextLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).NextLink; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionProperties _property;

        /// <summary>Dimension properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.DimensionProperties()); set => this._property = value; }

        /// <summary>SKU of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Sku; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Tag; }

        /// <summary>Total number of data for the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public int? Total { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).Total; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal)__resource).Type; }

        /// <summary>Usage end.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? UsageEnd { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).UsageEnd; }

        /// <summary>Usage start.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? UsageStart { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionPropertiesInternal)Property).UsageStart; }

        /// <summary>Creates an new <see cref="Dimension" /> instance.</summary>
        public Dimension()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// List of Dimension.
    public partial interface IDimension :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResource
    {
        /// <summary>Dimension category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Dimension category.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get;  }
        /// <summary>Dimension data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Dimension data.",
        SerializedName = @"data",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Data { get; set; }
        /// <summary>Dimension description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Dimension description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Filter enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Filter enabled.",
        SerializedName = @"filterEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FilterEnabled { get;  }
        /// <summary>Grouping enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Grouping enabled.",
        SerializedName = @"groupingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GroupingEnabled { get;  }
        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The link (url) to the next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Total number of data for the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Total number of data for the dimension.",
        SerializedName = @"total",
        PossibleTypes = new [] { typeof(int) })]
        int? Total { get;  }
        /// <summary>Usage end.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Usage end.",
        SerializedName = @"usageEnd",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? UsageEnd { get;  }
        /// <summary>Usage start.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Usage start.",
        SerializedName = @"usageStart",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? UsageStart { get;  }

    }
    /// List of Dimension.
    public partial interface IDimensionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IResourceInternal
    {
        /// <summary>Dimension category.</summary>
        string Category { get; set; }
        /// <summary>Dimension data.</summary>
        System.Collections.Generic.List<string> Data { get; set; }
        /// <summary>Dimension description.</summary>
        string Description { get; set; }
        /// <summary>Filter enabled.</summary>
        bool? FilterEnabled { get; set; }
        /// <summary>Grouping enabled.</summary>
        bool? GroupingEnabled { get; set; }
        /// <summary>The link (url) to the next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>Dimension properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IDimensionProperties Property { get; set; }
        /// <summary>Total number of data for the dimension.</summary>
        int? Total { get; set; }
        /// <summary>Usage end.</summary>
        global::System.DateTime? UsageEnd { get; set; }
        /// <summary>Usage start.</summary>
        global::System.DateTime? UsageStart { get; set; }

    }
}