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
    Helper module for Azure Storage uploads with proper content types.
.DESCRIPTION
    This module provides functions to upload files to Azure Storage with the correct
    content types, particularly for compressed archives like .tar.gz files.
#>

<#
.SYNOPSIS
    Gets the appropriate content type for a file based on its extension.
.PARAMETER FilePath
    The path to the file or just the filename.
.RETURNS
    The MIME content type string for the file.
#>
function Get-ContentTypeFromExtension {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$FilePath
    )
    
    $extension = [System.IO.Path]::GetExtension($FilePath).ToLowerInvariant()
    $fileName = [System.IO.Path]::GetFileName($FilePath).ToLowerInvariant()
    
    # Check for compound extensions first
    if ($fileName.EndsWith('.tar.gz')) {
        return 'application/x-gzip'
    }
    elseif ($fileName.EndsWith('.tar.bz2')) {
        return 'application/x-bzip2'
    }
    elseif ($fileName.EndsWith('.tar.xz')) {
        return 'application/x-xz'
    }
    
    # Check single extensions
    switch ($extension) {
        '.gz' { return 'application/x-gzip' }
        '.gzip' { return 'application/x-gzip' }
        '.tar' { return 'application/x-tar' }
        '.zip' { return 'application/zip' }
        '.7z' { return 'application/x-7z-compressed' }
        '.rar' { return 'application/x-rar-compressed' }
        '.bz2' { return 'application/x-bzip2' }
        '.xz' { return 'application/x-xz' }
        '.msi' { return 'application/x-msi' }
        '.exe' { return 'application/x-msdownload' }
        '.dll' { return 'application/x-msdownload' }
        '.pdf' { return 'application/pdf' }
        '.json' { return 'application/json' }
        '.xml' { return 'application/xml' }
        '.txt' { return 'text/plain' }
        '.ps1' { return 'text/plain' }
        '.psm1' { return 'text/plain' }
        '.psd1' { return 'text/plain' }
        '.ps1xml' { return 'application/xml' }
        '.md' { return 'text/markdown' }
        '.html' { return 'text/html' }
        '.htm' { return 'text/html' }
        '.css' { return 'text/css' }
        '.js' { return 'application/javascript' }
        '.nupkg' { return 'application/zip' }
        default { return 'application/octet-stream' }
    }
}

<#
.SYNOPSIS
    Uploads a file to Azure Storage with the correct content type.
.PARAMETER Container
    The name of the storage container.
.PARAMETER File
    The local file path to upload.
.PARAMETER Blob
    The blob name in the container.
.PARAMETER Context
    The Azure Storage context.
.PARAMETER Force
    Whether to overwrite existing blobs.
.PARAMETER ContentType
    Optional explicit content type. If not provided, it will be determined from the file extension.
.RETURNS
    The result of Set-AzStorageBlobContent.
#>
function Set-AzStorageBlobContentWithCorrectType {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$Container,
        
        [Parameter(Mandatory = $true)]
        [string]$File,
        
        [Parameter(Mandatory = $true)]
        [string]$Blob,
        
        [Parameter(Mandatory = $true)]
        $Context,
        
        [Parameter(Mandatory = $false)]
        [switch]$Force,
        
        [Parameter(Mandatory = $false)]
        [string]$ContentType,
        
        [Parameter(Mandatory = $false)]
        [switch]$Verbose
    )
    
    # Determine content type if not explicitly provided
    if ([string]::IsNullOrWhiteSpace($ContentType)) {
        $ContentType = Get-ContentTypeFromExtension -FilePath $File
    }
    
    Write-Verbose "Uploading '$File' to blob '$Blob' with content type '$ContentType'"
    
    # Create properties hashtable with the content type
    $properties = @{
        ContentType = $ContentType
    }
    
    # Upload the file with the correct content type
    $result = Set-AzStorageBlobContent -Container $Container -File $File -Blob $Blob -Context $Context -Properties $properties -Force:$Force -Verbose:$Verbose -ErrorAction Stop
    
    return $result
}

Export-ModuleMember -Function Get-ContentTypeFromExtension, Set-AzStorageBlobContentWithCorrectType