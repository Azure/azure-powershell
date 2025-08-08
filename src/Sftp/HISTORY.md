# Release History

## 1.0.0

### Features Added
* Initial release of Az.Sftp module
* Added `New-AzSftpCertificate` cmdlet for generating SSH certificates using Azure AD credentials
* Added `Connect-AzSftp` cmdlet for establishing SFTP connections to Azure Storage accounts
* Support for multiple authentication modes:
  - Fully managed authentication with automatic certificate generation
  - Certificate-based authentication using existing SSH certificates
  - Key-based authentication with automatic certificate generation
  - LocalUser parameter for local user authentication
* Cross-platform support for Windows, Linux, and macOS
* Comprehensive help documentation and examples
* Integration with Azure PowerShell authentication context

### Breaking Changes
* N/A - Initial release

### Bugs Fixed
* N/A - Initial release
