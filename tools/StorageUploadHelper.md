# Azure Storage Upload Helper

## Overview

This module provides utilities to upload files to Azure Storage with the correct MIME content types, addressing the issue where .tar.gz files were being uploaded with incorrect content types that break offline installation processes.

## Problem

Starting with Az 13.5.0, the content type for Az .tar.gz files changed from "application/x-gzip" to "application/octet-stream", which breaks step 3 in the offline installation script documented at [install-azps-offline](https://learn.microsoft.com/powershell/azure/install-azps-offline).

## Solution

The `StorageUploadHelper.psm1` module provides:

1. **Content Type Detection**: Automatically determines the correct MIME type based on file extensions
2. **Correct Upload Function**: Uploads files with the proper content type set
3. **Comprehensive Support**: Handles various file types commonly used in PowerShell releases

## Usage

### Import the Module

```powershell
Import-Module ".\StorageUploadHelper.psm1"
```

### Upload Files with Correct Content Types

```powershell
# Upload a single file
Set-AzStorageBlobContentWithCorrectType -Container "release" -File "Az-Cmdlets-13.5.0.tar.gz" -Blob "Az-Cmdlets-13.5.0.tar.gz" -Context $storageContext -Force

# Get content type for a file
$contentType = Get-ContentTypeFromExtension -FilePath "package.tar.gz"
# Returns: "application/x-gzip"
```

### Upload Release Artifacts

Use the dedicated script for uploading release artifacts:

```powershell
.\UploadReleaseArtifacts.ps1 -StorageAccountName "azpspackage" -ContainerName "release" -ResourceGroupName "rg-azps" -LocalPath "artifacts" -FilePattern "*.tar.gz"
```

## Supported File Types

The helper correctly identifies content types for:

| Extension | Content Type |
|-----------|--------------|
| .tar.gz | application/x-gzip |
| .tar.bz2 | application/x-bzip2 |
| .tar.xz | application/x-xz |
| .gz, .gzip | application/x-gzip |
| .tar | application/x-tar |
| .zip | application/zip |
| .msi | application/x-msi |
| .exe, .dll | application/x-msdownload |
| .ps1, .psm1, .psd1 | text/plain |
| .ps1xml | application/xml |
| .nupkg | application/zip |
| .json | application/json |
| .xml | application/xml |

## Integration

The module has been integrated into:

1. **ModuleUploader.ps1** - For automation test framework uploads
2. **SaveLiveTestResult.ps1** - For test result uploads
3. **UploadReleaseArtifacts.ps1** - New dedicated script for release artifacts

## Testing

Run the test suite to verify functionality:

```powershell
.\Test-StorageUploadHelper.ps1
```

## Migration

To migrate existing upload scripts:

1. Import the StorageUploadHelper module
2. Replace `Set-AzStorageBlobContent` calls with `Set-AzStorageBlobContentWithCorrectType`
3. The function accepts the same parameters plus automatic content type detection

### Before
```powershell
Set-AzStorageBlobContent -Container $container -File $file -Blob $blob -Context $context -Force
```

### After
```powershell
Set-AzStorageBlobContentWithCorrectType -Container $container -File $file -Blob $blob -Context $context -Force
```

## Backward Compatibility

The updated functions maintain full backward compatibility with existing scripts while adding the content type fix automatically.