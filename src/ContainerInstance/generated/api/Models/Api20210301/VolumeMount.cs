namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The properties of the volume mount.</summary>
    public partial class VolumeMount :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMountInternal
    {

        /// <summary>Backing field for <see cref="MountPath" /> property.</summary>
        private string _mountPath;

        /// <summary>
        /// The path within the container where the volume should be mounted. Must not contain colon (:).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string MountPath { get => this._mountPath; set => this._mountPath = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the volume mount.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ReadOnly" /> property.</summary>
        private bool? _readOnly;

        /// <summary>The flag indicating whether the volume mount is read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public bool? ReadOnly { get => this._readOnly; set => this._readOnly = value; }

        /// <summary>Creates an new <see cref="VolumeMount" /> instance.</summary>
        public VolumeMount()
        {

        }
    }
    /// The properties of the volume mount.
    public partial interface IVolumeMount :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The path within the container where the volume should be mounted. Must not contain colon (:).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The path within the container where the volume should be mounted. Must not contain colon (:).",
        SerializedName = @"mountPath",
        PossibleTypes = new [] { typeof(string) })]
        string MountPath { get; set; }
        /// <summary>The name of the volume mount.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the volume mount.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The flag indicating whether the volume mount is read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The flag indicating whether the volume mount is read-only.",
        SerializedName = @"readOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ReadOnly { get; set; }

    }
    /// The properties of the volume mount.
    internal partial interface IVolumeMountInternal

    {
        /// <summary>
        /// The path within the container where the volume should be mounted. Must not contain colon (:).
        /// </summary>
        string MountPath { get; set; }
        /// <summary>The name of the volume mount.</summary>
        string Name { get; set; }
        /// <summary>The flag indicating whether the volume mount is read-only.</summary>
        bool? ReadOnly { get; set; }

    }
}