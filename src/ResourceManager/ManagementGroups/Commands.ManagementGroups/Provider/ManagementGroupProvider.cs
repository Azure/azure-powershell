namespace Microsoft.Samples.PowerShell.Providers
{
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Management.Automation.Provider;

    #region ManagementGroupProvider

    [CmdletProvider("ManagementGroup", ProviderCapabilities.None)]
    public class ManagmentGroupProvider : DriveCmdletProvider
    {
        #region Drive Manipulation

        /// The Windows PowerShell engine calls this method when the 
        /// New-PSDrive cmdlet is run and the path to this provider is 
        /// specified. This method creates a connection to the database 
        /// file and sets the Connection property of the PSDriveInfo object.
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            // Check if the drive object is null.
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentNullException("drive"),
                           "NullDrive",
                           ErrorCategory.InvalidArgument,
                           null));

                return null;
            }

            // Check if the drive root is not null or empty
            // and if it is an existing file.
            if (String.IsNullOrEmpty(drive.Root) || File.Exists(drive.Root))
            {
                WriteError(new ErrorRecord(
                           new ArgumentException("drive.Root"),
                           "NoRoot",
                           ErrorCategory.InvalidArgument,
                           drive));

                return null;
            }

            MGDriveInfo mgDriveInfo = new MGDriveInfo(drive);

            return mgDriveInfo;
        }

        /// The Windows PowerShell engine calls this method when the 
        /// Remove-PSDrive cmdlet is run and the path to this provider is 
        /// specified. This method closes the ODBC connection of the drive.
        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentNullException("drive"),
                           "NullDrive",
                           ErrorCategory.InvalidArgument,
                           drive));

                return null;
            }

            MGDriveInfo mgDriveInfo = drive as MGDriveInfo;

            if (mgDriveInfo == null)
            {
                return null;
            }

            return mgDriveInfo;
        }

        #endregion Drive Manipulation
    }

    #endregion ManagementGroupProvider

    #region ManagementGroupPSDriveInfo

    /// Any state associated with the drive is held here. In this 
    /// case, the state information is the connection to the database.
    internal class MGDriveInfo : PSDriveInfo
    {
        public MGDriveInfo(PSDriveInfo driveInfo)
               : base(driveInfo)
        {
        }
    }

    #endregion ManagementGroupPSDriveInfo
}