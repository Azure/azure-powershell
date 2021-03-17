namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>This class represents the manual action task details.</summary>
    public partial class ManualActionTaskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IManualActionTaskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IManualActionTaskDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails __taskTypeDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TaskTypeDetails();

        /// <summary>The type of task details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)__taskTypeDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)__taskTypeDetails).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="Instruction" /> property.</summary>
        private string _instruction;

        /// <summary>The instructions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Instruction { get => this._instruction; set => this._instruction = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Observation" /> property.</summary>
        private string _observation;

        /// <summary>The observation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Observation { get => this._observation; set => this._observation = value; }

        /// <summary>Creates an new <see cref="ManualActionTaskDetails" /> instance.</summary>
        public ManualActionTaskDetails()
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
            await eventListener.AssertNotNull(nameof(__taskTypeDetails), __taskTypeDetails);
            await eventListener.AssertObjectIsValid(nameof(__taskTypeDetails), __taskTypeDetails);
        }
    }
    /// This class represents the manual action task details.
    public partial interface IManualActionTaskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails
    {
        /// <summary>The instructions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The instructions.",
        SerializedName = @"instructions",
        PossibleTypes = new [] { typeof(string) })]
        string Instruction { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The observation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The observation.",
        SerializedName = @"observation",
        PossibleTypes = new [] { typeof(string) })]
        string Observation { get; set; }

    }
    /// This class represents the manual action task details.
    internal partial interface IManualActionTaskDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal
    {
        /// <summary>The instructions.</summary>
        string Instruction { get; set; }
        /// <summary>The name.</summary>
        string Name { get; set; }
        /// <summary>The observation.</summary>
        string Observation { get; set; }

    }
}