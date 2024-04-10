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
    Create nuget packages for each module.

.PARAMETER IsNetCore
    If built using .NET core.

.PARAMETER BuildConfig
    Either Debug or Release.

.PARAMETER Scope
    Either All, Latest, Stack, NetCore, ServiceManagement, AzureStorage

.PARAMETER ApiKey
    ApiKey used to publish nuget to PS repository.

.PARAMETER RepositoryLocation
    Location we want to publish too.

.PARAMETER NugetExe
    Path to the nuget executable.

#>

param(
    [CmdletBinding()]
    [Parameter(Mandatory = $false, Position = 0)]
    [switch]$IsNetCore,

    [Parameter(Mandatory = $false, Position = 1)]
    [ValidateSet("Debug", "Release")]
    [string]$BuildConfig,

    [Parameter(Mandatory = $false, Position = 2)]
    [ValidateSet("All", "Latest", "Stack", "NetCore", "ServiceManagement", "AzureStorage")]
    [string]$Scope,

    [Parameter(Mandatory = $false, Position = 3)]
    [string]$ApiKey,

    [Parameter(Mandatory = $false, Position = 4)]
    [string]$RepositoryLocation,

    [Parameter(Mandatory = $false, Position = 5)]
    [string]$NugetExe, 

    [Parameter(Mandatory = $false, Position = 6)]
    [string]$TargetBuild
)

Import-Module "$PSScriptRoot\PublishModules.psm1"

<###################################
#
#           Setup/Execute
#
###################################>

if ([string]::IsNullOrEmpty($buildConfig)) {
    Write-Verbose "Setting build configuration to 'Release'"
    $buildConfig = "Release"
}

if ([string]::IsNullOrEmpty($repositoryLocation)) {
    Write-Verbose "Setting repository location to 'https://dtlgalleryint.cloudapp.net/api/v2'"
    $repositoryLocation = "https://dtlgalleryint.cloudapp.net/api/v2"
}

if ([string]::IsNullOrEmpty($nugetExe)) {
    Write-Verbose "Use default nuget path"
    $nugetExe = "$PSScriptRoot\nuget.exe"
}

Write-Host "Publishing $Scope package (and its dependencies)"

Get-PackageProvider -Name NuGet -Force
Write-Host " "

# NOTE: Can only be Azure or Azure Stack, not both.
$packageFolder = "$PSScriptRoot\..\artifacts"
if ($Scope -eq 'Stack') {
    $packageFolder = "$PSScriptRoot\..\src\Stack"
}
# Set temporary repo location
$PublishLocal = test-path $repositoryLocation
[string]$tempRepoPath = "$packageFolder"
if ($PublishLocal) {
    if ($Scope -eq 'Stack') {
        $tempRepoPath = (Join-Path $repositoryLocation -ChildPath "Stack")
    } else {
        $tempRepoPath = (Join-Path $repositoryLocation -ChildPath "..\artifacts")
    }
}

$null = New-Item -ItemType Directory -Force -Path $tempRepoPath
$tempRepoName = ([System.Guid]::NewGuid()).ToString()
$repo = Get-PSRepository | Where-Object { $_.SourceLocation -eq $tempRepoPath }
if ($null -ne $repo) {
    $tempRepoName = $repo.Name
} else {
    Register-PSRepository -Name $tempRepoName -SourceLocation $tempRepoPath -PublishLocation $tempRepoPath -InstallationPolicy Trusted -PackageManagementProvider NuGet
}

$env:PSModulePath = "$env:PSModulePath;$tempRepoPath"

$Errors = $null

try {
    $modules = Get-AllModules -BuildConfig $BuildConfig -Scope $Scope -TargetBuild $TargetBuild -PublishLocal:$PublishLocal -IsNetCore:$IsNetCore
    Add-AllModules -ModulePaths $modules -TempRepo $tempRepoName -TempRepoPath $tempRepoPath -NugetExe $NugetExe
    Publish-AllModules -ModulePaths $modules -ApiKey $apiKey -TempRepoPath $tempRepoPath -RepoLocation $repositoryLocation -NugetExe $NugetExe -PublishLocal:$PublishLocal
} catch {
    $Errors = $_
    Write-Error ($_ | Out-String)
} finally {
    Unregister-PSRepository -Name $tempRepoName
}

if ($Errors -ne $null) {
    exit 1
}
exit 0
