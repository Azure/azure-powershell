// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes a disk on the machine</summary>
    public partial class Disk :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IDisk,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IDiskInternal
    {

        /// <summary>Backing field for <see cref="GeneratedId" /> property.</summary>
        private string _generatedId;

        /// <summary>The generated ID of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string GeneratedId { get => this._generatedId; set => this._generatedId = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ID of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="MaxSizeInByte" /> property.</summary>
        private long? _maxSizeInByte;

        /// <summary>The size of the disk, in bytes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public long? MaxSizeInByte { get => this._maxSizeInByte; set => this._maxSizeInByte = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>The path of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="UsedSpaceInByte" /> property.</summary>
        private long? _usedSpaceInByte;

        /// <summary>The amount of space used on the disk, in bytes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public long? UsedSpaceInByte { get => this._usedSpaceInByte; set => this._usedSpaceInByte = value; }

        /// <summary>Creates an new <see cref="Disk" /> instance.</summary>
        public Disk()
        {

        }
    }
    /// Describes a disk on the machine
    public partial interface IDisk :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>The generated ID of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The generated ID of the disk.",
        SerializedName = @"generatedId",
        PossibleTypes = new [] { typeof(string) })]
        string GeneratedId { get; set; }
        /// <summary>The ID of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ID of the disk.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The size of the disk, in bytes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The size of the disk, in bytes",
        SerializedName = @"maxSizeInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxSizeInByte { get; set; }
        /// <summary>The name of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the disk.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The path of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The path of the disk.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>The type of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of the disk.",
        SerializedName = @"diskType",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>The amount of space used on the disk, in bytes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The amount of space used on the disk, in bytes",
        SerializedName = @"usedSpaceInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? UsedSpaceInByte { get; set; }

    }
    /// Describes a disk on the machine
    internal partial interface IDiskInternal

    {
        /// <summary>The generated ID of the disk.</summary>
        string GeneratedId { get; set; }
        /// <summary>The ID of the disk.</summary>
        string Id { get; set; }
        /// <summary>The size of the disk, in bytes</summary>
        long? MaxSizeInByte { get; set; }
        /// <summary>The name of the disk.</summary>
        string Name { get; set; }
        /// <summary>The path of the disk.</summary>
        string Path { get; set; }
        /// <summary>The type of the disk.</summary>
        string Type { get; set; }
        /// <summary>The amount of space used on the disk, in bytes</summary>
        long? UsedSpaceInByte { get; set; }

    }
}