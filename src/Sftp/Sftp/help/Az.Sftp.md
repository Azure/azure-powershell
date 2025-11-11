---
Module Name: Az.Sftp
Module Guid: a1832bbb-ec22-4694-9450-cdf6ee642705
Download Help Link: https://learn.microsoft.com/powershell/module/az.sftp
Help Version: 0.0.1.0
Locale: en-US
---

# Az.Sftp Module
## Description
SFTP module for Azure Storage. Provides cmdlets to generate SSH certificates and establish secure SFTP connections to Azure Storage accounts with hierarchical namespace enabled. For more information on Azure Storage SFTP support, please visit: https://learn.microsoft.com/en-us/azure/storage/blobs/secure-file-transfer-protocol-support

## Az.Sftp Cmdlets
### [Connect-AzSftp](Connect-AzSftp.md)
Starts an interactive SFTP session to an Azure Storage Account.
Users can login using Microsoft Entra accounts, or local user accounts via standard SSH authentication. Use Microsoft Entra account login for the best security and convenience.

### [New-AzSftpCertificate](New-AzSftpCertificate.md)
Generate SSH certificates for SFTP authentication using Microsoft Entra credentials.