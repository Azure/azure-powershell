namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a transformation.</summary>
    public partial class TransformationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Query" /> property.</summary>
        private string _query;

        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Query { get => this._query; set => this._query = value; }

        /// <summary>Backing field for <see cref="StreamingUnit" /> property.</summary>
        private int? _streamingUnit;

        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? StreamingUnit { get => this._streamingUnit; set => this._streamingUnit = value; }

        /// <summary>Creates an new <see cref="TransformationProperties" /> instance.</summary>
        public TransformationProperties()
        {

        }
    }
    /// The properties that are associated with a transformation.
    public partial interface ITransformationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"query",
        PossibleTypes = new [] { typeof(string) })]
        string Query { get; set; }
        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the number of streaming units that the streaming job uses.",
        SerializedName = @"streamingUnits",
        PossibleTypes = new [] { typeof(int) })]
        int? StreamingUnit { get; set; }

    }
    /// The properties that are associated with a transformation.
    internal partial interface ITransformationPropertiesInternal

    {
        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Query { get; set; }
        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        int? StreamingUnit { get; set; }

    }
}