namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>
    /// Plan for solution object supported by the OperationsManagement resource provider.
    /// </summary>
    public partial class SolutionPlan :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlan,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName).
        /// SolutionType part is case sensitive. For third party solution, it can be anything.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Product" /> property.</summary>
        private string _product;

        /// <summary>
        /// name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>.
        /// This is case sensitive
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Product { get => this._product; set => this._product = value; }

        /// <summary>Backing field for <see cref="PromotionCode" /> property.</summary>
        private string _promotionCode;

        /// <summary>promotionCode, Not really used now, can you left as empty</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string PromotionCode { get => this._promotionCode; set => this._promotionCode = value; }

        /// <summary>Backing field for <see cref="Publisher" /> property.</summary>
        private string _publisher;

        /// <summary>Publisher name. For gallery solution, it is Microsoft.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Publisher { get => this._publisher; set => this._publisher = value; }

        /// <summary>Creates an new <see cref="SolutionPlan" /> instance.</summary>
        public SolutionPlan()
        {

        }
    }
    /// Plan for solution object supported by the OperationsManagement resource provider.
    public partial interface ISolutionPlan :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName).
        /// SolutionType part is case sensitive. For third party solution, it can be anything.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName). SolutionType part is case sensitive. For third party solution, it can be anything.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>.
        /// This is case sensitive
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>. This is case sensitive",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string Product { get; set; }
        /// <summary>promotionCode, Not really used now, can you left as empty</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"promotionCode, Not really used now, can you left as empty",
        SerializedName = @"promotionCode",
        PossibleTypes = new [] { typeof(string) })]
        string PromotionCode { get; set; }
        /// <summary>Publisher name. For gallery solution, it is Microsoft.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Publisher name. For gallery solution, it is Microsoft.",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string Publisher { get; set; }

    }
    /// Plan for solution object supported by the OperationsManagement resource provider.
    internal partial interface ISolutionPlanInternal

    {
        /// <summary>
        /// name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName).
        /// SolutionType part is case sensitive. For third party solution, it can be anything.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>.
        /// This is case sensitive
        /// </summary>
        string Product { get; set; }
        /// <summary>promotionCode, Not really used now, can you left as empty</summary>
        string PromotionCode { get; set; }
        /// <summary>Publisher name. For gallery solution, it is Microsoft.</summary>
        string Publisher { get; set; }

    }
}