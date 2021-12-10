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
.SYNOPSIS Copies *.help.txt files under 'About' folder to current module's culture folder
#>
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$BuildConfig = "Release"
)

function CopyAboutTopicsToCultureFolder {
    param (
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$AboutFolder,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$CultureFolder
    )
    Write-Host "Copying about-documents from $AboutFolder to $CultureFolder"
    Get-ChildItem -Filter *.help.txt -Path $AboutFolder | Copy-Item -Destination $CultureFolder
}

.($PSScriptRoot + "\..\PreloadToolDll.ps1")
$AboutFolders = Get-ChildItem -Include 'About' -Path "$PSScriptRoot\..\..\artifacts\$BuildConfig" -Recurse -Directory | where { -not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName) }

foreach ($AboutFolder in $AboutFolders)
{
    $ModuleFolder = $AboutFolder.Parent.Parent.FullName
    $CultureFolder = Join-Path -Path $ModuleFolder -ChildPath "en-US"
    New-Item -ItemType "directory" -Path $CultureFolder -Force
    CopyAboutTopicsToCultureFolder $AboutFolder $CultureFolder
}