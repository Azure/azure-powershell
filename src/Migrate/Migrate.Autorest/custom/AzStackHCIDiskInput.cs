// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview
{
    public class AzStackHCIDiskInput
    {
        public AzStackHCIDiskInput(
            string diskId, 
            bool isDynamic, 
            long diskSizeGB, 
            string diskFileFormat, 
            bool isOsDisk)
        {
            DiskId = diskId;
            IsDynamic = isDynamic;
            DiskSizeGb = diskSizeGB;
            DiskFileFormat = diskFileFormat;
            IsOSDisk = isOsDisk;
        }

        /// <summary>Gets or sets the type of the virtual hard disk, vhd or vhdx.</summary>
        public string DiskFileFormat { get; set; }

        /// <summary>Gets or sets the disk Id.</summary>
        public string DiskId { get; set; }

        /// <summary>Gets or sets the disk size in GB.</summary>
        public long DiskSizeGb { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether dynamic sizing is enabled on the virtual hard
        /// disk.
        /// </summary>
        public bool? IsDynamic { get; set; }
        
        /// <summary>Gets or sets a value indicating whether disk is os disk.</summary>
        public bool IsOSDisk { get; set; }
    }
}