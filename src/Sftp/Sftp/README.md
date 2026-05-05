# Az.Sftp
This module provides PowerShell cmdlets for securely connecting to Azure Storage accounts using SFTP (SSH File Transfer Protocol).

## Overview
Az.Sftp enables you to establish secure SFTP connections to Azure Storage accounts with hierarchical namespace enabled. The module supports multiple authentication modes including automatic Microsoft Entra certificate generation.

## Requirements
- Azure Storage account with SFTP enabled
- Hierarchical namespace (HNS) enabled on the storage account
- Appropriate RBAC permissions (Storage Blob Data Contributor or similar)
- OpenSSH client (typically pre-installed on modern systems)

## Installation
```powershell
Install-Module -Name Az.Sftp
```

## Getting Started
```powershell
# Connect to Azure
Connect-AzAccount

# Connect to storage account using Microsoft Entra authentication
Connect-AzSftp -StorageAccount "mystorageaccount"
```

## Available Cmdlets
- `New-AzSftpCertificate` - Generate SSH certificates for SFTP authentication
- `Connect-AzSftp` - Establish SFTP connections to Azure Storage accounts

## Links
- [Azure Storage SFTP Support](https://docs.microsoft.com/en-us/azure/storage/blobs/secure-file-transfer-protocol-support)
- [Azure PowerShell Documentation](https://docs.microsoft.com/en-us/powershell/azure/)
