namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>List jobs response</summary>
    public partial class ListJobsResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IListJobsResponse,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IListJobsResponseInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>link to next batch of jobs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse[] _value;

        /// <summary>Job list</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListJobsResponse" /> instance.</summary>
        public ListJobsResponse()
        {

        }
    }
    /// List jobs response
    public partial interface IListJobsResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>link to next batch of jobs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"link to next batch of jobs",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Job list</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job list",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse[] Value { get; set; }

    }
    /// List jobs response
    internal partial interface IListJobsResponseInternal

    {
        /// <summary>link to next batch of jobs</summary>
        string NextLink { get; set; }
        /// <summary>Job list</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse[] Value { get; set; }

    }
}