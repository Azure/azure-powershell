namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The database project summary class.</summary>
    public partial class DatabaseProjectSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseProjectSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseProjectSummaryInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary __projectSummary = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ProjectSummary();

        /// <summary>Gets or sets the extended summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary ExtendedSummary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).ExtendedSummary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).ExtendedSummary = value ?? null /* model class */; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).InstanceType; }

        /// <summary>Gets or sets the time when summary was last refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public global::System.DateTime? LastSummaryRefreshedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).LastSummaryRefreshedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).LastSummaryRefreshedTime = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).InstanceType = value; }

        /// <summary>Gets or sets the state of refresh summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string RefreshSummaryState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).RefreshSummaryState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).RefreshSummaryState = value ?? null; }

        /// <summary>Creates an new <see cref="DatabaseProjectSummary" /> instance.</summary>
        public DatabaseProjectSummary()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__projectSummary), __projectSummary);
            await eventListener.AssertObjectIsValid(nameof(__projectSummary), __projectSummary);
        }
    }
    /// The database project summary class.
    public partial interface IDatabaseProjectSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary
    {

    }
    /// The database project summary class.
    internal partial interface IDatabaseProjectSummaryInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal
    {

    }
}