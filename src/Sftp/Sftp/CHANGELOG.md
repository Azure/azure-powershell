<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->

## Upcoming Release
* Added `BufferSizeInBytes` parameter to `Connect-AzSftp` cmdlet
    - Allows users to specify buffer size in bytes for SFTP file transfers using the sftp -B flag
    - Default value is 262144 (256 KB)
* Added `StorageAccountEndpoint` parameter to `Connect-AzSftp` cmdlet
    - Allows users to specify a custom storage account endpoint suffix
    - Useful for connecting to storage accounts with custom endpoints

## Version 0.1.0
* Initial release of Az.Sftp module
* Added `New-AzSftpCertificate` cmdlet for generating SSH certificates using Microsoft Entra credentials
    - Automatic SSH key pair generation
    - Certificate generation for existing public keys
    - Support for custom certificate paths
    - Cross-platform SSH client detection
* Added `Connect-AzSftp` cmdlet for establishing SFTP connections to Azure Storage accounts
    - Fully managed authentication with automatic certificate generation
    - Certificate-based authentication using existing SSH certificates
    - Key-based authentication with automatic certificate generation
    - Support for custom SFTP arguments and SSH client locations
* Support for multiple authentication modes:
    - LocalUser parameter for local user authentication
    - Interactive authentication (username/password) when using LocalUser
    - Enhanced parameter sets for better user experience
* Cross-platform support (Windows, Linux, macOS)
* Comprehensive help documentation following Azure PowerShell standards
* Extensive test suite covering all scenarios
* Security features including secure key handling and short-lived certificates
