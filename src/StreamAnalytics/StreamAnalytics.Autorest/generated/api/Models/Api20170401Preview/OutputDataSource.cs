namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes the data source that output will be written to.</summary>
    public partial class OutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal
    {

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="OutputDataSource" /> instance.</summary>
        public OutputDataSource()
        {

        }
    }
    /// Describes the data source that output will be written to.
    public partial interface IOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Describes the data source that output will be written to.
    internal partial interface IOutputDataSourceInternal

    {
        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Type { get; set; }

    }
}