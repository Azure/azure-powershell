namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>This class represents the script action task details.</summary>
    public partial class ScriptActionTaskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IScriptActionTaskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IScriptActionTaskDetailsInternal,
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

        /// <summary>Backing field for <see cref="IsPrimarySideScript" /> property.</summary>
        private bool? _isPrimarySideScript;

        /// <summary>A value indicating whether it is a primary side script or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsPrimarySideScript { get => this._isPrimarySideScript; set => this._isPrimarySideScript = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Output" /> property.</summary>
        private string _output;

        /// <summary>The output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Output { get => this._output; set => this._output = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>The path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Creates an new <see cref="ScriptActionTaskDetails" /> instance.</summary>
        public ScriptActionTaskDetails()
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
    /// This class represents the script action task details.
    public partial interface IScriptActionTaskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails
    {
        /// <summary>A value indicating whether it is a primary side script or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether it is a primary side script or not.",
        SerializedName = @"isPrimarySideScript",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPrimarySideScript { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The output.",
        SerializedName = @"output",
        PossibleTypes = new [] { typeof(string) })]
        string Output { get; set; }
        /// <summary>The path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }

    }
    /// This class represents the script action task details.
    internal partial interface IScriptActionTaskDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal
    {
        /// <summary>A value indicating whether it is a primary side script or not.</summary>
        bool? IsPrimarySideScript { get; set; }
        /// <summary>The name.</summary>
        string Name { get; set; }
        /// <summary>The output.</summary>
        string Output { get; set; }
        /// <summary>The path.</summary>
        string Path { get; set; }

    }
}