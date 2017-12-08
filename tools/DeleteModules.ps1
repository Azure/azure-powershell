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

# Run script in an elevated session after uninstalling Azure Powershell
[CmdletBinding(SupportsShouldProcess=$true, DefaultParameterSetName="ByName")]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateSet("ModuleList", "AzureRMAndDependencies", "AzureAndDependencies", "NetCoreModules", "AzureStackAndDependencies")]
    [string] $scope,
    [Parameter(Mandatory = $true)]
    [ValidateSet("TestGallery", "PSGallery")]
    [string] $repoName,
    [Parameter(Mandatory = $false)]
    [string[]] $ListOfModules,
    [Parameter(Mandatory = $false)]
    [string] $nugetExe
)

function Get-TargetModules
{
    [CmdletBinding()]
    param
    (
      [string]$scope,
      [string[]]$moduleList
    )

    if ($scope -eq "AzureRMAndDependencies") {
        return Find-Module -Name AzureRM -Repository $repoName -IncludeDependencies
    } elseif ($scope -eq "AzureAndDependencies") {
        return Find-Module -Name Azure -Repository $repoName -IncludeDependencies
    } elseif ($scope -eq "NetCoreModules") {
        return Find-Module -Name AzureRM.Netcore -Repository $repoName -IncludeDependencies
    } elseif ($scope -eq "AzureStackAndDependencies") {
        return Find-Module -Name AzureStack -Repository $repoName -IncludeDependencies
    } elseif ($scope -eq "ModuleList") {
        $targets = @()
        $moduleList | ForEach-Object {
            $targets += Find-Module -Name $_ -Repository $repoName
        }
        return $targets
    }

    return @()
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
    Write-Verbose "Use default nuget path"
    $nugetExe =  "$PSScriptRoot\nuget.exe"
}

if (($scope -eq "ModuleList") -and ($ListOfModules -eq $null))
{
    Write-Error "Must supply -ListOfModule when using ModuleList scope"
    return
}

$repositoryLocation = "https://dtlgalleryint.cloudapp.net/api/v2/package/"
if ($repoName -eq "PSGallery")
{
    $repositoryLocation = "https://www.powershellgallery.com/api/v2/package/"
}

$ApiKey = Get-ApiKey -repoName $repoName

$ModulesToDelete = Get-TargetModules -scope $scope -moduleList $ListOfModules
$ModulesToDelete
$ModulesToDelete | ForEach-Object {
    &$nugetExe delete $_.Name $_.Version -ApiKey $ApiKey -Source $repositoryLocation
}