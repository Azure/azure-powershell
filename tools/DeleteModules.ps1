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

#Requires -Modules AzureRM.KeyVault
[CmdletBinding(
    DefaultParameterSetName='Scope', 
    SupportsShouldProcess=$true
)]
param(
    [Parameter(ParameterSetName='Scope', Mandatory = $true, Position = 0)]
    [ValidateSet("AzureRMAndDependencies", "AzureAndDependencies", "NetCoreModules", "AzureStackAndDependencies")]
    [string] $scope,
    [Parameter(ParameterSetName='ModuleList', Mandatory = $false)]
    [string[]] $listOfModules,
    [Parameter(Mandatory = $false)]
    [ValidateSet("TestGallery", "PSGallery")]
    [string] $repoName,
    [Parameter(Mandatory = $false)]
    [string] $nugetExe,
    [Parameter(Mandatory = $false)]
    [string] $apiKey
)

function Get-TargetModules
{
    [CmdletBinding()]
    param
    (
      [string]$scope,
      [string[]]$moduleList
    )

    if ($listOfModules.Count -ge 1) 
    {
        $targets = @()
        $moduleList | ForEach-Object {
            $targets += Find-Module -Name $_ -Repository $repoName
        }

        return $targets
    }

    else
    {
        $targets = @()
        $query = ""
        if ($scope -eq "AzureRMAndDependencies") {
            $query = "AzureRM"
        } elseif ($scope -eq "AzureAndDependencies") {
            $query = "Azure"
        } elseif ($scope -eq "NetCoreModules") {
            $query = "AzureRM.Netcore"
        } elseif ($scope -eq "AzureStackAndDependencies") {
            $query = "AzureStack"
        }

        $azureRmAllVersions = Find-Module -Name $query -Repository PSGallery -AllVersions
        $targets += $azureRmAllVersions[0]
        $currentDependencies = $azureRmAllVersions[0].Dependencies
        $previousDependencies = $azureRmAllVersions[1].Dependencies
        $currentDependencies | ForEach-Object {
            $CDModule = $_
            $versionChanged = $true
            $previousDependencies | ForEach-Object {
                if (($_.Name -eq $CDModule.Name) -and (($_.RequiredVersion -eq $CDModule.RequiredVersion) -and ($_.MinimumVersion -eq $CDModule.MinimumVersion)))
                {
                    $versionChanged = $false
                }
            }

            if ($versionChanged)
            {
                $targets += $CDModule
            }
        }

        return $targets
    }
}

function Get-DependentModules
{
    param(
        [string]$repoName,
        [string]$moduleName,
        [string]$moduleVersion,
        $allModules,
        $azureModules
    )

    $dependencies = @()
    $azureModules | ForEach-Object {
        $targetName = $_.Name
        $moduleNotBeingDeleted = $true
        $allModules | ForEach-Object {
            if ($_.Name -eq $targetName)
            {
                $moduleNotBeingDeleted = $false
            }
        }

        $_.Dependencies | ForEach-Object {
            $dependencyName = $_.Name

            if ($moduleNotBeingDeleted -and ($moduleName -eq $dependencyName))
            {
                $allTargetVersions = Find-Module -Name $targetName -Repository $repoName -AllVersions
                $allTargetVersions | ForEach-Object {
                    $targetVersion = $_.Version
                    $_.Dependencies | ForEach-Object {
                        if (($moduleName -eq $_.Name) -and (($_.MinimumVersion -eq $moduleVersion) -or ($_.RequiredVersion -eq $moduleVersion)))
                        {
                            $dependencies += "`"$targetName $targetVersion`","
                        }
                    }
                }
            }
        }
    }
    if ($dependencies.Count -ne 0)
    {
        Write-Warning "$moduleName $moduleVersion is a dependency for $dependencies the module(s) will have an orphaned dependency."
    }
}

function Get-ApiKey
{
	param([string]$repoName)
    
    $vaultKey="PSTestGalleryApiKey"
    if ($repoName -eq "PSGallery")
    {
        $vaultKey = "PowerShellGalleryApiKey"
    }
    
    $context = $null
    try {
        $context = Get-AzureRMContext
    } catch {}

    if ($context -eq $null)
    {
        Add-AzureRMAccount
    }

    $secret = Get-AzureKeyVaultSecret -VaultName kv-azuresdk -Name $vaultKey

    $secret.SecretValueText
}

if ([string]::IsNullOrEmpty($nugetExe))
{
    $nugetExe =  "$PSScriptRoot\nuget.exe"
}
Write-Host "Using the following NuGet path: $nugetExe"

if ([string]::IsNullOrEmpty($repoName))
{
    $repoName = "PSGallery"
}
Write-Host "Deleting modules from the following repository: $repoName"

$repositoryLocation = "https://dtlgalleryint.cloudapp.net/api/v2/package/"
if ($repoName -eq "PSGallery")
{
    $repositoryLocation = "https://www.powershellgallery.com/api/v2/package/"
}

if ([string]::IsNullOrEmpty($apiKey))
{
    $apiKey = Get-ApiKey -repoName $repoName
}

$ModulesToDelete = Get-TargetModules -scope $scope -moduleList $listOfModules
$ModulesToDeleteName = $ModulesToDelete | ForEach-Object {$_.Name}
$ModulesToDeleteName
$azureModules = Find-Module Azure* -Repository $repoName
if ($PSCmdlet.ShouldProcess("Module(s) being deleted: $ModulesToDeleteName"))
{
    $ModulesToDelete | ForEach-Object {
        if (![string]::IsNullOrEmpty($_.Version))
        {
            Get-DependentModules -repoName $repoName -moduleName $_.Name -moduleVersion $_.Version -allModules $ModulesToDelete -azureModules $azureModules
            &$nugetExe delete $_.Name $_.Version -ApiKey $apiKey -Source $repositoryLocation
        }
        elseif (![string]::IsNullOrEmpty($_.RequiredVersion))
        {
            Get-DependentModules -repoName $repoName -moduleName $_.Name -moduleVersion $_.RequiredVersion -allModules $ModulesToDelete -azureModules $azureModules
            &$nugetExe delete $_.Name $_.RequiredVersion -ApiKey $apiKey -Source $repositoryLocation
        }
        elseif (![string]::IsNullOrEmpty($_.MinimumVersion))
        {
            Get-DependentModules -repoName $repoName -moduleName $_.Name -moduleVersion $_.MinimumVersion -allModules $ModulesToDelete -azureModules $azureModules
            &$nugetExe delete $_.Name $_.MinimumVersion -ApiKey $apiKey -Source $repositoryLocation
        }
    }
}