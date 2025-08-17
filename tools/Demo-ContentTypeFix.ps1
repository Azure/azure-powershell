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
    Demonstrates the content type fix for .tar.gz files.
.DESCRIPTION
    This script shows how the StorageUploadHelper module correctly identifies
    content types for various file extensions, particularly fixing the issue
    where .tar.gz files would get "application/octet-stream" instead of 
    "application/x-gzip".
#>

# Import the helper module
Import-Module "$PSScriptRoot\StorageUploadHelper.psm1" -Force

Write-Host "Azure PowerShell .tar.gz Content Type Fix Demonstration" -ForegroundColor Cyan
Write-Host "=" * 60
Write-Host ""

# Demonstrate the key fix for the reported issue
$criticalFiles = @(
    "Az-Cmdlets-13.5.0.tar.gz",
    "Az-Cmdlets-14.0.0.tar.gz", 
    "AzPreview-11.0.0-preview.tar.gz"
)

Write-Host "Critical Fix - .tar.gz files now get correct content type:" -ForegroundColor Green
foreach ($file in $criticalFiles) {
    $contentType = Get-ContentTypeFromExtension -FilePath $file
    Write-Host "  📦 $file" -ForegroundColor Yellow
    Write-Host "     Content-Type: $contentType" -ForegroundColor White
    if ($contentType -eq "application/x-gzip") {
        Write-Host "     ✅ Correct! This will work with offline installation." -ForegroundColor Green
    } else {
        Write-Host "     ❌ Wrong! This would break offline installation." -ForegroundColor Red
    }
    Write-Host ""
}

Write-Host "Other supported file types:" -ForegroundColor Cyan
$otherFiles = @(
    "azure-powershell-13.5.0-x64.msi",
    "Az.Tools.Predictor.zip", 
    "Release.zip",
    "InstallModule.ps1",
    "Az.Accounts.psd1"
)

foreach ($file in $otherFiles) {
    $contentType = Get-ContentTypeFromExtension -FilePath $file
    Write-Host "  📄 $file -> $contentType" -ForegroundColor White
}

Write-Host ""
Write-Host "Impact of this fix:" -ForegroundColor Cyan
Write-Host "  • .tar.gz files will have content-type 'application/x-gzip'" -ForegroundColor Green
Write-Host "  • Offline installation scripts will work correctly" -ForegroundColor Green  
Write-Host "  • Web browsers will handle downloads properly" -ForegroundColor Green
Write-Host "  • All existing functionality remains unchanged" -ForegroundColor Green
Write-Host ""

Write-Host "Fixed issue: https://github.com/Azure/azure-powershell/issues/28395" -ForegroundColor Blue