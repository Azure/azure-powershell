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
    Write-Host $AboutFolder, $CultureFolder
    Get-ChildItem -Filter *.help.txt -Path $AboutFolder | Copy-Item -Destination $CultureFolder
}

.($PSScriptRoot + "\PreloadToolDll.ps1")
$AboutFolders = Get-ChildItem -Include 'About' -Path "$PSScriptRoot\..\artifacts\$BuildConfig" -Recurse -Directory | where { -not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName) }

foreach ($AboutFolder in $AboutFolders)
{
    $ModuleFolder = (Get-Item $AboutFolders.Parent).Parent.FullName
    $CultureFolder = Join-Path -Path $ModuleFolder -ChildPath "en-US"
    New-Item -ItemType "directory" -Path $CultureFolder -Force
    CopyAboutTopicsToCultureFolder $AboutFolder $CultureFolder
}