namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>This class represents the inline workflow task details.</summary>
    public partial class InlineWorkflowTaskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInlineWorkflowTaskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInlineWorkflowTaskDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails __groupTaskDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.GroupTaskDetails();

        /// <summary>The child tasks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[] ChildTask { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)__groupTaskDetails).ChildTask; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)__groupTaskDetails).ChildTask = value ?? null /* arrayOf */; }

        /// <summary>The type of task details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)__groupTaskDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)__groupTaskDetails).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="WorkflowId" /> property.</summary>
        private string[] _workflowId;

        /// <summary>The list of child workflow ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] WorkflowId { get => this._workflowId; set => this._workflowId = value; }

        /// <summary>Creates an new <see cref="InlineWorkflowTaskDetails" /> instance.</summary>
        public InlineWorkflowTaskDetails()
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
            await eventListener.AssertNotNull(nameof(__groupTaskDetails), __groupTaskDetails);
            await eventListener.AssertObjectIsValid(nameof(__groupTaskDetails), __groupTaskDetails);
        }
    }
    /// This class represents the inline workflow task details.
    public partial interface IInlineWorkflowTaskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails
    {
        /// <summary>The list of child workflow ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of child workflow ids.",
        SerializedName = @"workflowIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] WorkflowId { get; set; }

    }
    /// This class represents the inline workflow task details.
    internal partial interface IInlineWorkflowTaskDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal
    {
        /// <summary>The list of child workflow ids.</summary>
        string[] WorkflowId { get; set; }

    }
}