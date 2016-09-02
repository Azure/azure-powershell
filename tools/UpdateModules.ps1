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
function Create-ModulePsm1
{
  [CmdletBinding()]
  param(
    [string]$ModulePath,
    [string]$TemplatePath
  )

  PROCESS
  {
	 $manifestDir = Get-Item -Path $ModulePath
	 $moduleName = $manifestDir.Name + ".psd1"
	 $manifestPath = Join-Path -Path $ModulePath -ChildPath $moduleName
     $module = Test-ModuleManifest -Path $manifestPath
     $templateOutputPath = $manifestPath -replace ".psd1", ".psm1"
     [string]$strict
     [string]$loose
     foreach ($mod in $module.RequiredModules)
     {
        $strict += "  Import-Module " + $mod.Name + " -RequiredVersion " + [string]$mod.Version + "`r`n"
        $loose += "  Import-Module " + $mod.Name + "`r`n"
     }
     $template = Get-Content -Path $TemplatePath
     $template = $template -replace "%MODULE-NAME%", $module.Name
     $template = $template -replace "%DATE%", [string](Get-Date)
     $template = $template -replace "%STRICT-DEPENDENCIES%", $strict
     $template = $template -replace "%DEPENDENCIES%", $loose
     Write-Host "Writing psm1 manifest to $templateOutputPath"
     $template | Out-File -FilePath $templateOutputPath -Force
     $file = Get-Item -Path $templateOutputPath
  }
}

param(
    [Parameter(Mandatory = $false, Position = 0)]
    [string] $buildConfig,
    [Parameter(Mandatory = $false, Position = 1)]
    [string] $scope
)

if ([string]::IsNullOrEmpty($buildConfig))
{
    Write-Verbose "Setting build configuration to 'Release'"
    $buildConfig = "Release"
}

if ([string]::IsNullOrEmpty($scope))
{
    Write-Verbose "Default scope to all"
    $scope = 'All'  
}

Write-Host "Updating $scope package(and its dependencies)" 

$packageFolder = "$PSScriptRoot\..\src\Package"



$resourceManagerRootFolder = "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager"
$publishToLocal = test-path $repositoryLocation
$templateLocation = "$PSScriptRoot\AzureRM.Example.psm1"
if (($scope -eq 'All') -or $publishToLocal ) {
    # If we publish 'All' or to local folder, publish AzureRM.Profile first, becasue it is the common dependency
    Write-Host "Updating profile module"
    Create-ModulePsm1 -ModulePath "$resourceManagerRootFolder\AzureRM.Profile" -TemplatePath $templateLocation
    Write-Host "Updated profile module"
}

if (($scope -eq 'All') -or ($scope -eq 'AzureStorage')) {
    $modulePath = "$packageFolder\$buildConfig\Storage\Azure.Storage"
    # Publish AzureStorage module
    Write-Host "Updating AzureStorage module from $modulePath"
    Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation
} 

if (($scope -eq 'All') -or ($scope -eq 'ServiceManagement')) {
    $modulePath = "$packageFolder\$buildConfig\ServiceManagement\Azure"
    # Publish Azure module
    Write-Host "Updating ServiceManagement(aka Azure) module from $modulePath"
    Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation
} 

$resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory
if ($scope -eq 'All') {  
    foreach ($module in $resourceManagerModules) {
        # filter out AzureRM.Profile which always gets published first 
        # And "Azure.Storage" which is built out as test dependencies  
        if (($module.Name -ne "AzureRM.Profile") -and ($module.Name -ne "Azure.Storage")) {
            $modulePath = $module.FullName
            Write-Host "Updating $module module from $modulePath"
            Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation
            Write-Host "Updated $module module"
        }
    }
} elseif ($scope -ne 'AzureRM') {
    $modulePath = Join-Path $resourceManagerRootFolder "AzureRM.$scope"
    if (Test-Path $modulePath) {
        Write-Host "Updating $scope module from $modulePath"
        Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation
        Write-Host "Updated $scope module"        
    } else {
        Write-Error "Can not find module with name $scope to publish"
    }
}

if (($scope -eq 'All') -or ($scope -eq 'AzureRM')) {
    # Update AzureRM module    
    $modulePath = "$PSScriptRoot\AzureRM"
    Write-Host "Updating AzureRM module from $modulePath"
    Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation
    Write-Host "Updated Azure module"
} 
