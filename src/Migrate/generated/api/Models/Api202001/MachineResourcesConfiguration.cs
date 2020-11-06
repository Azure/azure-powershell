namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class MachineResourcesConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineResourcesConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IMachineResourcesConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Cpu" /> property.</summary>
        private int? _cpu;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? Cpu { get => this._cpu; set => this._cpu = value; }

        /// <summary>Backing field for <see cref="CpuSpeed" /> property.</summary>
        private int? _cpuSpeed;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? CpuSpeed { get => this._cpuSpeed; set => this._cpuSpeed = value; }

        /// <summary>Backing field for <see cref="CpuSpeedAccuracy" /> property.</summary>
        private string _cpuSpeedAccuracy;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CpuSpeedAccuracy { get => this._cpuSpeedAccuracy; set => this._cpuSpeedAccuracy = value; }

        /// <summary>Backing field for <see cref="PhysicalMemory" /> property.</summary>
        private int? _physicalMemory;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? PhysicalMemory { get => this._physicalMemory; set => this._physicalMemory = value; }

        /// <summary>Creates an new <see cref="MachineResourcesConfiguration" /> instance.</summary>
        public MachineResourcesConfiguration()
        {

        }
    }
    public partial interface IMachineResourcesConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"cpus",
        PossibleTypes = new [] { typeof(int) })]
        int? Cpu { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"cpuSpeed",
        PossibleTypes = new [] { typeof(int) })]
        int? CpuSpeed { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"cpuSpeedAccuracy",
        PossibleTypes = new [] { typeof(string) })]
        string CpuSpeedAccuracy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"physicalMemory",
        PossibleTypes = new [] { typeof(int) })]
        int? PhysicalMemory { get; set; }

    }
    internal partial interface IMachineResourcesConfigurationInternal

    {
        int? Cpu { get; set; }

        int? CpuSpeed { get; set; }

        string CpuSpeedAccuracy { get; set; }

        int? PhysicalMemory { get; set; }

    }
}