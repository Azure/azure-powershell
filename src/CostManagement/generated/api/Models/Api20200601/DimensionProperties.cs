namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    public partial class DimensionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>Dimension category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Category { get => this._category; }

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private string[] _data;

        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] Data { get => this._data; set => this._data = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Dimension description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="FilterEnabled" /> property.</summary>
        private bool? _filterEnabled;

        /// <summary>Filter enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public bool? FilterEnabled { get => this._filterEnabled; }

        /// <summary>Backing field for <see cref="GroupingEnabled" /> property.</summary>
        private bool? _groupingEnabled;

        /// <summary>Grouping enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public bool? GroupingEnabled { get => this._groupingEnabled; }

        /// <summary>Internal Acessors for Category</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.Category { get => this._category; set { {_category = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for FilterEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.FilterEnabled { get => this._filterEnabled; set { {_filterEnabled = value;} } }

        /// <summary>Internal Acessors for GroupingEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.GroupingEnabled { get => this._groupingEnabled; set { {_groupingEnabled = value;} } }

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Total</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.Total { get => this._total; set { {_total = value;} } }

        /// <summary>Internal Acessors for UsageEnd</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.UsageEnd { get => this._usageEnd; set { {_usageEnd = value;} } }

        /// <summary>Internal Acessors for UsageStart</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal.UsageStart { get => this._usageStart; set { {_usageStart = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Total" /> property.</summary>
        private int? _total;

        /// <summary>Total number of data for the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public int? Total { get => this._total; }

        /// <summary>Backing field for <see cref="UsageEnd" /> property.</summary>
        private global::System.DateTime? _usageEnd;

        /// <summary>Usage end.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? UsageEnd { get => this._usageEnd; }

        /// <summary>Backing field for <see cref="UsageStart" /> property.</summary>
        private global::System.DateTime? _usageStart;

        /// <summary>Usage start.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? UsageStart { get => this._usageStart; }

        /// <summary>Creates an new <see cref="DimensionProperties" /> instance.</summary>
        public DimensionProperties()
        {

        }
    }
    public partial interface IDimensionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>Dimension category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Dimension category.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"data",
        PossibleTypes = new [] { typeof(string) })]
        string[] Data { get; set; }
        /// <summary>Dimension description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Dimension description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Filter enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Filter enabled.",
        SerializedName = @"filterEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FilterEnabled { get;  }
        /// <summary>Grouping enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Grouping enabled.",
        SerializedName = @"groupingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GroupingEnabled { get;  }
        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The link (url) to the next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Total number of data for the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total number of data for the dimension.",
        SerializedName = @"total",
        PossibleTypes = new [] { typeof(int) })]
        int? Total { get;  }
        /// <summary>Usage end.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Usage end.",
        SerializedName = @"usageEnd",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? UsageEnd { get;  }
        /// <summary>Usage start.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Usage start.",
        SerializedName = @"usageStart",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? UsageStart { get;  }

    }
    public partial interface IDimensionPropertiesInternal

    {
        /// <summary>Dimension category.</summary>
        string Category { get; set; }

        string[] Data { get; set; }
        /// <summary>Dimension description.</summary>
        string Description { get; set; }
        /// <summary>Filter enabled.</summary>
        bool? FilterEnabled { get; set; }
        /// <summary>Grouping enabled.</summary>
        bool? GroupingEnabled { get; set; }
        /// <summary>The link (url) to the next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>Total number of data for the dimension.</summary>
        int? Total { get; set; }
        /// <summary>Usage end.</summary>
        global::System.DateTime? UsageEnd { get; set; }
        /// <summary>Usage start.</summary>
        global::System.DateTime? UsageStart { get; set; }

    }
}