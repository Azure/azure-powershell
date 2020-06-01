namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Performance monitor sample in a set.</summary>
    public partial class PerfMonSample :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSampleInternal
    {

        /// <summary>Backing field for <see cref="InstanceName" /> property.</summary>
        private string _instanceName;

        /// <summary>Name of the server on which the measurement is made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InstanceName { get => this._instanceName; set => this._instanceName = value; }

        /// <summary>Backing field for <see cref="Time" /> property.</summary>
        private global::System.DateTime? _time;

        /// <summary>Point in time for which counter was measured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? Time { get => this._time; set => this._time = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private double? _value;

        /// <summary>Value of counter at a certain time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PerfMonSample" /> instance.</summary>
        public PerfMonSample()
        {

        }
    }
    /// Performance monitor sample in a set.
    public partial interface IPerfMonSample :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of the server on which the measurement is made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the server on which the measurement is made.",
        SerializedName = @"instanceName",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceName { get; set; }
        /// <summary>Point in time for which counter was measured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Point in time for which counter was measured.",
        SerializedName = @"time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Time { get; set; }
        /// <summary>Value of counter at a certain time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value of counter at a certain time.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(double) })]
        double? Value { get; set; }

    }
    /// Performance monitor sample in a set.
    internal partial interface IPerfMonSampleInternal

    {
        /// <summary>Name of the server on which the measurement is made.</summary>
        string InstanceName { get; set; }
        /// <summary>Point in time for which counter was measured.</summary>
        global::System.DateTime? Time { get; set; }
        /// <summary>Value of counter at a certain time.</summary>
        double? Value { get; set; }

    }
}