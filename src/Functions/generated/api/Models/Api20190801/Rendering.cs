namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Instructions for rendering the data</summary>
    public partial class Rendering :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRendering,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRenderingInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the data that will help it be interpreted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Title" /> property.</summary>
        private string _title;

        /// <summary>Title of data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Title { get => this._title; set => this._title = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType? _type;

        /// <summary>Rendering Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Rendering" /> instance.</summary>
        public Rendering()
        {

        }
    }
    /// Instructions for rendering the data
    public partial interface IRendering :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Description of the data that will help it be interpreted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the data that will help it be interpreted",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Title of data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Title of data",
        SerializedName = @"title",
        PossibleTypes = new [] { typeof(string) })]
        string Title { get; set; }
        /// <summary>Rendering Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Rendering Type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType? Type { get; set; }

    }
    /// Instructions for rendering the data
    internal partial interface IRenderingInternal

    {
        /// <summary>Description of the data that will help it be interpreted</summary>
        string Description { get; set; }
        /// <summary>Title of data</summary>
        string Title { get; set; }
        /// <summary>Rendering Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType? Type { get; set; }

    }
}