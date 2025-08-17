# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
    Uploads release artifacts to Azure Storage with correct content types.
.DESCRIPTION
    This script uploads various release artifacts (tar.gz, msi, zip files) to Azure Storage
    ensuring that the correct MIME content types are set, particularly for .tar.gz files
    which should have content type "application/x-gzip" for proper offline installation support.
.PARAMETER StorageAccountName
    The name of the Azure Storage account.
.PARAMETER ContainerName
    The name of the storage container.
.PARAMETER ResourceGroupName
    The resource group containing the storage account.
.PARAMETER LocalPath
    The local path containing the files to upload.
.PARAMETER FilePattern
    The file pattern to match for upload (e.g., "*.tar.gz", "*.msi").
.PARAMETER BlobPrefix
    Optional prefix for blob names in storage.
.EXAMPLE
    .\UploadReleaseArtifacts.ps1 -StorageAccountName "azpspackage" -ContainerName "release" -ResourceGroupName "rg-azps" -LocalPath "artifacts" -FilePattern "*.tar.gz"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$StorageAccountName,
    
    [Parameter(Mandatory = $true)]
    [string]$ContainerName,
    
    [Parameter(Mandatory = $true)]
    [string]$ResourceGroupName,
    
    [Parameter(Mandatory = $true)]
    [string]$LocalPath,
    
    [Parameter(Mandatory = $false)]
    [string]$FilePattern = "*",
    
    [Parameter(Mandatory = $false)]
    [string]$BlobPrefix = ""
)

# Import the storage upload helper module
Import-Module "$PSScriptRoot\StorageUploadHelper.psm1" -Force

# Ensure Azure PowerShell modules are available
if (-not (Get-Module -Name Az.Storage -ListAvailable)) {
    Write-Error "Az.Storage module is not available. Please install it first."
    exit 1
}

if (-not (Get-Module -Name Az.Accounts -ListAvailable)) {
    Write-Error "Az.Accounts module is not available. Please install it first."
    exit 1
}

Write-Host "Starting upload of release artifacts..."

try {
    # Get the storage account context
    Write-Host "Getting storage account context for '$StorageAccountName' in resource group '$ResourceGroupName'..."
    $storageAccount = Get-AzStorageAccount -ResourceGroupName $ResourceGroupName -AccountName $StorageAccountName -ErrorAction Stop
    $context = $storageAccount.Context
    
    # Get files to upload
    Write-Host "Searching for files matching pattern '$FilePattern' in '$LocalPath'..."
    $files = Get-ChildItem -Path $LocalPath -Filter $FilePattern -File -Recurse
    
    if ($files.Count -eq 0) {
        Write-Warning "No files found matching pattern '$FilePattern' in '$LocalPath'"
        exit 0
    }
    
    Write-Host "Found $($files.Count) files to upload:"
    $files | ForEach-Object { Write-Host "  - $($_.FullName)" }
    
    # Upload each file with correct content type
    $successCount = 0
    $errorCount = 0
    
    foreach ($file in $files) {
        try {
            $relativePath = $file.FullName.Substring($LocalPath.Length).TrimStart('\', '/')
            $blobName = if ($BlobPrefix) { "$BlobPrefix/$relativePath" } else { $relativePath }
            $blobName = $blobName.Replace('\', '/')  # Ensure forward slashes for blob names
            
            Write-Host "Uploading '$($file.Name)' to blob '$blobName'..."
            
            $result = Set-AzStorageBlobContentWithCorrectType -Container $ContainerName -File $file.FullName -Blob $blobName -Context $context -Force -Verbose
            
            # Get the content type that was set
            $blob = Get-AzStorageBlob -Container $ContainerName -Blob $blobName -Context $context
            $contentType = $blob.ICloudBlob.Properties.ContentType
            
            Write-Host "Successfully uploaded '$($file.Name)' with content type '$contentType'"
            $successCount++
        }
        catch {
            Write-Error "Failed to upload '$($file.Name)': $($_.Exception.Message)"
            $errorCount++
        }
    }
    
    Write-Host "Upload completed. Success: $successCount, Errors: $errorCount"
    
    if ($errorCount -gt 0) {
        exit 1
    }
}
catch {
    Write-Error "Failed to upload artifacts: $($_.Exception.Message)"
    exit 1
}