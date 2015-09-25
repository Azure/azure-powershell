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

param(
    [Parameter(Mandatory = $false, Position = 0)]
    [string] $buildConfig,
    [Parameter(Mandatory = $false, Position = 1)]
    [string] $apiKey,
    [Parameter(Mandatory = $false, Position = 2)]
    [string] $repositoryLocation
)

if ([string]::IsNullOrEmpty($buildConfig))
{
    Write-Verbose "Setting build configuration to 'Release'"
    $buildConfig = "Release"
}

if ([string]::IsNullOrEmpty($repositoryLocation))
{
    Write-Verbose "Setting repository location to 'https://dtlgalleryint.cloudapp.net/api/v2'"
    
    $repositoryLocation = "https://dtlgalleryint.cloudapp.net/api/v2"
}


$packageFolder = "$PSScriptRoot\..\src\Package"

$repo = Get-PSRepository | where { $_.SourceLocation -eq $repositoryLocation }
if ($repo -ne $null) {
    $repoName = $repo.Name
} else {
    $repoName = $(New-Guid).ToString()
    Register-PSRepository -Name $repoName -SourceLocation $repositoryLocation -PublishLocation $repositoryLocation/package -InstallationPolicy Trusted
}
$modulePath = "$packageFolder\$buildConfig\ServiceManagement\Azure"
# Publish Azure module
Write-Host "Publishing Azure module from $modulePath"
Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure", "AzureRM")
# Publish AzureRM module
$modulePath = "$PSScriptRoot\AzureRM"
Write-Host "Publishing AzureRM module from $modulePath"
Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure", "AzureRM")
Write-Host "Published Azure module"
# Publish AzureRM.Profile module
Write-Host "Publishing AzureRM.Profile module from $modulePath"
Publish-Module -Path "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager\AzureRM.Profile" -NuGetApiKey $apiKey -Repository $repoName
Write-Host "Published AzureRM.Profile module"

# Publish AzureRM modules
$resourceManagerModules = Get-ChildItem -Path "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager" -Directory
foreach ($module in $resourceManagerModules) {
    if ($module -ne "AzureRM.Profile") {
        $modulePath = $module.FullName
        Write-Host "Publishing $module module from $modulePath"
        Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure", "AzureRM")
        Write-Host "Published $module module"
    }
}
