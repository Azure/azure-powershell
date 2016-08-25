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
    [string] $scope,
    [Parameter(Mandatory = $false, Position = 2)]
    [string] $apiKey,
    [Parameter(Mandatory = $false, Position = 3)]
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

if ([string]::IsNullOrEmpty($scope))
{
    Write-Verbose "Default scope to all"
    $scope = 'All'  
}

Write-Host "Publishing $scope package(and its dependencies)" 

$packageFolder = "$PSScriptRoot\..\src\Package"

$repo = Get-PSRepository | where { $_.SourceLocation -eq $repositoryLocation }
if ($repo -ne $null) {
    $repoName = $repo.Name
} else {
    $repoName = $(New-Guid).ToString()
    Register-PSRepository -Name $repoName -SourceLocation $repositoryLocation -PublishLocation $repositoryLocation/package -InstallationPolicy Trusted
}

$resourceManagerRootFolder = "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager"
$publishToLocal = test-path $repositoryLocation
if (($scope -eq 'All') -or $publishToLocal ) {
    # If we publish 'All' or to local folder, publish AzureRM.Profile first, becasue it is the common dependency
    Write-Host "Publishing profile module"
    Publish-Module -Path "$resourceManagerRootFolder\AzureRM.Profile" -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure")
    Write-Host "Published profile module"
}

if (($scope -eq 'All') -or ($scope -eq 'AzureStorage')) {
    $modulePath = "$packageFolder\$buildConfig\Storage\Azure.Storage"
    # Publish AzureStorage module
    Write-Host "Publishing AzureStorage module from $modulePath"
    Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure")
} 

if (($scope -eq 'All') -or ($scope -eq 'ServiceManagement')) {
    $modulePath = "$packageFolder\$buildConfig\ServiceManagement\Azure"
    # Publish Azure module
    Write-Host "Publishing ServiceManagement(aka Azure) module from $modulePath"
    Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure")
} 

$resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory
if ($scope -eq 'All') {  
    foreach ($module in $resourceManagerModules) {
        # filter out AzureRM.Profile which always gets published first 
        # And "Azure.Storage" which is built out as test dependencies  
        if (($module.Name -ne "AzureRM.Profile") -and ($module.Name -ne "Azure.Storage")) {
            $modulePath = $module.FullName
            Write-Host "Publishing $module module from $modulePath"
            Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure")
            Write-Host "Published $module module"
        }
    }
} elseif ($scope -ne 'AzureRM') {
    $modulePath = Join-Path $resourceManagerRootFolder "AzureRM.$scope"
    if (Test-Path $modulePath) {
        Write-Host "Publishing $scope module from $modulePath"
        Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure")
        Write-Host "Published $scope module"        
    } else {
        Write-Error "Can not find module with name $scope to publish"
    }
}

if (($scope -eq 'All') -or ($scope -eq 'AzureRM')) {
    # Publish AzureRM module    
    $modulePath = "$PSScriptRoot\AzureRM"
    Write-Host "Publishing AzureRM module from $modulePath"
    Publish-Module -Path $modulePath -NuGetApiKey $apiKey -Repository $repoName -Tags ("Azure")
    Write-Host "Published Azure module"
} 
