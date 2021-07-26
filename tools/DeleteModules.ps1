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

#Requires -Modules AzureRM.KeyVault, @{ModuleName='PowerShellGet';ModuleVersion='1.6.0'}
[CmdletBinding(
    DefaultParameterSetName='Scope', 
    SupportsShouldProcess=$true
)]
param(
    [Parameter(ParameterSetName='Scope', Mandatory = $true, Position = 0)]
    [ValidateSet("AzureRMAndDependencies", "AzureAndDependencies", "NetCoreModules", "AzureStackAndDependencies")]
    [string] $scope,
    [Parameter(ParameterSetName='ModuleList', Mandatory = $true)]
    [string[]] $listOfModules,
    [Parameter(ParameterSetName='ModulesAndVersionsList', Mandatory = $true)]
    [hashtable[]] $moduleVersionTable,
    [Parameter(Mandatory = $false)]
    [string] $repoName,
    [Parameter(Mandatory = $false)]
    [string] $nugetExe,
    [Parameter(Mandatory = $false)]
    [string] $apiKey,
    [Parameter(Mandatory = $false)]
    [switch] $Force
)

function Get-TargetModules
{
    [CmdletBinding()]
    param
    (
      [string]$scope,
      [string[]]$moduleList,
      [hashtable[]]$moduleVersionTable
    )

    $targets = @()

    if ($listOfModules.Count -ge 1) 
    {
        $moduleList | ForEach-Object {
            $targets += Find-Module -Name $_ -Repository $repoName -AllowPrerelease
        }
    }

    elseif ($moduleVersionTable.Count -ge 1)
    {
        $moduleVersionTable | ForEach-Object {
            $targets += Find-Module -Name $_.Module -RequiredVersion $_.Version -Repository $repoName -AllowPrerelease
        }
    }

    else
    {
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
    }

    return $targets
}

function Get-DependentModules
{
    param(
        [string]$repoName,
        [string]$moduleName,
        [string]$moduleVersion,
        [object[]]$allModules,
        [object[]]$azureModules
    )

    $dependencies = @()
    $azureModules | ForEach-Object {
        $targetName = $_.Name
        $moduleBeingDeleted = $allModules | Where-Object {$_.Name -eq $targetName}

        $_.Dependencies | ForEach-Object {
            $dependencyName = $_.Name

            if (($moduleBeingDeleted -eq $null) -and ($moduleName -eq $dependencyName))
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
        return "$moduleName $moduleVersion is a dependency for $dependencies the module(s) will have an orphaned dependency.  Are you sure you want to unlist this package?"
    }
}

function Get-ApiKey
{
	param([string]$repoName)
    
    if ($repoName -eq "PSGallery")
    {
        $vaultKey = "PowerShellGalleryApiKey"
    }

    elseif ($repoName -eq "TestGallery")
    {
        $vaultKey="PSTestGalleryApiKey"
    }

    else
    {
        throw "Must supply ApiKey if not using PSGallery or TestGallery"
    }
    
    $context = $null
    try {
        $context = Get-AzureRMContext -ErrorAction Stop
    } catch {}

    if ($context -eq $null)
    {
        Add-AzureRMAccount
    }

    $secret = Get-AzureKeyVaultSecret -VaultName kv-azuresdk -Name $vaultKey

    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($secret.SecretValue))
    $secretValueText
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

if (($repoName -eq "PSGallery") -or ([string]::IsNullOrEmpty($repoName)))
{
    $repositoryLocation = "https://www.powershellgallery.com/api/v2/package/"
}

elseif ($repoName -eq "TestGallery")
{
    $repositoryLocation = "https://dtlgalleryint.cloudapp.net/api/v2/package/"
}

else
{
    $repositoryLocation = $repoName    
}

if ([string]::IsNullOrEmpty($apiKey))
{
    $apiKey = Get-ApiKey -repoName $repoName
}

$ModulesToDelete = Get-TargetModules -scope $scope -moduleList $listOfModules -moduleVersionTable $moduleVersionTable
$ModulesToDeleteName = $ModulesToDelete | ForEach-Object {$_.Name}
$azureModules = Find-Module Azure* -Repository $repoName
if ($PSCmdlet.ShouldProcess("Module(s) being deleted: $ModulesToDeleteName"))
{
    $ModulesToDelete | ForEach-Object {
        $version = $null
        if (![string]::IsNullOrEmpty($_.Version))
        {
            $version = $_.Version
        }
        elseif (![string]::IsNullOrEmpty($_.RequiredVersion))
        {
            $version = $_.RequiredVersion
        }
        elseif (![string]::IsNullOrEmpty($_.MinimumVersion))
        {
            $version = $_.MinimumVersion
        }

        $warning = Get-DependentModules -repoName $repoName -moduleName $_.Name -moduleVersion $version -allModules $ModulesToDelete -azureModules $azureModules
        if (($warning -eq $null) -or ($Force) -or ($PSCmdlet.ShouldContinue($warning, "Deleting package with orphaned dependencies")))
        {
            &$nugetExe delete $_.Name $version -ApiKey $apiKey -Source $repositoryLocation -NonInteractive
        }
    }
}
