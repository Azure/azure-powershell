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
    [string] $repositoryLocation,
    [Parameter(Mandatory = $false, Position = 4)]
    [string] $nugetExe
)

function Get-TargetModules
{
	[CmdletBinding()]
	param
	(
      [string]$buildConfig,
	  [string]$Scope,
	  [bool]$PublishLocal
	)

	PROCESS 
	{
		$targets = @()
		$packageFolder = "$PSScriptRoot\..\src\Package"
        $resourceManagerRootFolder = "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager"
		if (($Scope -eq 'All') -or $PublishLocal ) {
          $targets += "$resourceManagerRootFolder\AzureRM.Profile" 
        }

        if (($Scope -eq 'All') -or ($Scope -eq 'AzureStorage')) {
          $targets += "$packageFolder\$buildConfig\Storage\Azure.Storage"
        } 

        if (($Scope -eq 'All') -or ($Scope -eq 'ServiceManagement')) {
          $targets += "$packageFolder\$buildConfig\ServiceManagement\Azure"
        } 

        $resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory
        if ($Scope -eq 'All') {  
          foreach ($module in $resourceManagerModules) {
            # filter out AzureRM.Profile which always gets published first 
            # And "Azure.Storage" which is built out as test dependencies  
            if (($module.Name -ne "AzureRM.Profile") -and ($module.Name -ne "Azure.Storage")) {
              $targets += $module.FullName
            }
          }
        } elseif (($Scope -ne 'AzureRM') -and ($Scope -ne "ServiceManagement") -and ($Scope -ne "AzureStorage")) {
          $modulePath = Join-Path $resourceManagerRootFolder "AzureRM.$scope"
          if (Test-Path $modulePath) {
            $targets += $modulePath      
          } else {
            Write-Error "Can not find module with name $scope to publish"
          }
        }

        if (($Scope -eq 'All') -or ($Scope -eq 'AzureRM')) {
            # Publish AzureRM module    
            $targets += "$PSScriptRoot\AzureRM"
        } 

		Write-Output -InputObject $targets
	}
}

function Make-StrictModuleDependencies
{
  [CmdletBinding()]
  param(
  [string] $Path)

  PROCESS 
  {
    $manifest = Test-ModuleManifest -Path $Path
    $newModules = @()
    foreach ($module in $manifest.RequiredModules)
    {
       $newModules += (@{ModuleName = $module.Name; RequiredVersion= $module.Version})
    }

	  if ($newModules.Count -gt 0)
	  {
        Update-ModuleManifest -Path $Path -RequiredModules $newModules
      }
    
  }

}

function Add-PSM1Dependency
{
  [CmdletBinding()]
  param(
  [string] $Path)

  PROCESS 
  {
	$file = Get-Item -Path $Path
    $manifestFile = $file.Name
	$psm1file = $manifestFile -replace ".psd1", ".psm1"
    $manifest = Test-ModuleManifest -Path $Path
    Update-ModuleManifest -Path $Path -RootModule $psm1file
  }

}


function Remove-ModuleDependencies
{
  [CmdletBinding()]
  param(
  [string] $Path)

  PROCESS 
  {
	$regex = New-Object System.Text.RegularExpressions.Regex "RequiredModules\s*=\s*@\([^\)]+\)"
	$content = (Get-Content -Path $Path) -join "`r`n"
	$text = $regex.Replace($content, "RequiredModules = @()")
    $text | Out-File -FilePath $Path
    
  }

}

function Change-RMModule 
{
	[CmdletBinding()]
	param(
		[string]$Path,
		[string]$RepoLocation,
		[string]$TempRepo,
		[string]$TempRepoPath
	)

	PROCESS
	{
		$moduleName = (Get-Item -Path $Path).Name
		$moduleManifest = $moduleName + ".psd1"
		$moduleSourcePath = Join-Path -Path $Path -ChildPath $moduleManifest
		$manifest = Make-StrictModuleDependencies $moduleSourcePath
		$manifest = Test-ModuleManifest -Path $moduleSourcePath
		$toss = Publish-Module -Path $Path -Repository $TempRepo
	    Write-Output "Changing to directory for module modifications $TempRepoPath"
		pushd $TempRepoPath
		try
		{
		  $nupkgPath = Join-Path -Path . -ChildPath ($moduleName + "." + $manifest.Version.ToString() + ".nupkg")
		  $zipPath = Join-Path -Path . -ChildPath ($moduleName + "." + $manifest.Version.ToString() + ".zip")
		  $dirPath = Join-Path -Path . -ChildPath ($moduleName + "." + $manifest.Version.ToString())
		  $unzippedManifest = Join-Path -Path $dirPath -ChildPath ($moduleName + ".psd1")

		  if (!(Test-Path -Path $nupkgPath))
		  {
			  throw "Module at $nupkgPath in $TempRepoPath does not exist"
		  }
		  Write-Output "Renaming package $nupkgPath to nsip archive $zipPath"
		  ren $nupkgPath $zipPath
		  Write-Output "Expanding $zipPath"
		  Expand-Archive $zipPath
		  Write-Output "Adding PSM1 dependency to $unzippedManifest"
		  Add-PSM1Dependency -Path $unzippedManifest
		  Write-Output "Removing module manifest dependencies for $unzippedManifest"
		  Remove-ModuleDependencies -Path $unzippedManifest

		  Remove-Item -Path $zipPath -Force
		  Write-Output "Compressing $zipPath"
		  Compress-Archive (Join-Path -Path $dirPath -ChildPath "*") -DestinationPath $zipPath
		  Write-Output "Renaming package $zipPath to zip archive $nupkgPath"
		  ren $zipPath $nupkgPath
	    }
		finally 
		{
			popd
		}
	}
}

function Publish-RMModule 
{
	[CmdletBinding()]
	param(
		[string]$Path,
		[string]$ApiKey,
		[string]$TempRepoPath,
		[string]$RepoLocation,
		[string]$nugetExe
	)

	PROCESS
	{
		$moduleName = (Get-Item -Path $Path).Name
		$moduleManifest = $moduleName + ".psd1"
		$moduleSourcePath = Join-Path -Path $Path -ChildPath $moduleManifest
		$manifest = Test-ModuleManifest -Path $moduleSourcePath
		$nupkgPath = Join-Path -Path $TempRepoPath -ChildPath ($moduleName + "." + $manifest.Version.ToString() + ".nupkg")
		if (!(Test-Path -Path $nupkgPath))
		{
			throw "Module at $nupkgPath in $TempRepoPath does not exist"
		}

		Write-Output "Pushing package $moduleName to nuget source $RepoLocation"
		&$nugetExe push $nupkgPath $ApiKey -s $RepoLocation
	    Write-Output "Pushed package $moduleName to nuget source $RepoLocation"		  
	}
}



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

if ([string]::IsNullOrEmpty($nugetExe))
{
    Write-Verbose "Use default nuget path"
    $nugetExe =  "$PSScriptRoot\nuget.exe"
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

$publishToLocal = test-path $repositoryLocation
[string]$tempRepoPath = "$PSScriptRoot\..\src\package"
if ($publishToLocal)
{
	$tempRepoPath = (Join-Path $repositoryLocation -ChildPath "package")
}
$tempRepoName = ([System.Guid]::NewGuid()).ToString()
Register-PSRepository -Name $tempRepoName -SourceLocation $tempRepoPath -PublishLocation $tempRepoPath -InstallationPolicy Trusted -PackageManagementProvider NuGet

try {
	$modulesInScope = Get-TargetModules -buildConfig $buildConfig -Scope $scope -PublishLocal $publishToLocal
    foreach ($modulePath in $modulesInScope) {
        # filter out AzureRM.Profile which always gets published first 
        # And "Azure.Storage" which is built out as test dependencies  
		$module = Get-Item -Path $modulePath
        Write-Host "Changing $module module from $modulePath"
        Change-RMModule -Path $modulePath -RepoLocation $repositoryLocation -TempRepo $tempRepoName -TempRepoPath $tempRepoPath
        Write-Host "Changed $module module"
	}

	if (!$publishToLocal)
	{
      foreach ($modulePath in $modulesInScope) {
        # filter out AzureRM.Profile which always gets published first 
        # And "Azure.Storage" which is built out as test dependencies  
		$module = Get-Item -Path $modulePath
        Write-Host "Pushing $module module from $modulePath"
        Publish-RMModule -Path $modulePath -ApiKey $apiKey -TempRepoPath $tempRepoPath -RepoLocation $repositoryLocation -nugetExe $nugetExe
        Write-Host "Pushed $module module"
	  }
	}

}
finally 
{
	Unregister-PSRepository -Name $tempRepoName
}
