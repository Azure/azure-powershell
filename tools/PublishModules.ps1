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
    [string] $isNetCore,
    [Parameter(Mandatory = $false, Position = 1)]
    [string] $buildConfig,
    [Parameter(Mandatory = $false, Position = 2)]
    [string] $scope,
    [Parameter(Mandatory = $false, Position = 3)]
    [string] $apiKey,
    [Parameter(Mandatory = $false, Position = 4)]
    [string] $repositoryLocation,
    [Parameter(Mandatory = $false, Position = 5)]
    [string] $nugetExe,
    [Parameter(Mandatory=$false)]
    [ValidateSet("Latest", "Stack")]
    [string] $Profile = "Latest"
)

function Get-TargetModules
{
    [CmdletBinding()]
    param
    (
      [string]$buildConfig,
      [string]$Scope,
      [bool]$PublishLocal,
      [string] $Profile = "Latest"
    )

    PROCESS 
    {
        $targets = @()
        $packageFolder = "$PSScriptRoot\..\src\Package"
        if ($Profile -eq "Stack")
        {
            $packageFolder = "$PSScriptRoot\..\src\Stack"
        }
    
        if($isNetCore -eq "true") {
            $resourceManagerRootFolder = "$packageFolder\$buildConfig\ResourceManager"
        } else {
            $resourceManagerRootFolder = "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager"
        }
    
        if ((($Scope -eq 'All') -or $PublishLocal)) {
          if($isNetCore -eq "false") {
            $targets += "$resourceManagerRootFolder\AzureRM.Profile" 
          } else {
            $targets += "$resourceManagerRootFolder\AzureRM.Profile.Netcore" 
          }
        }

        if ((($Scope -eq 'All') -or ($Scope -eq 'AzureStorage')) -and ($isNetCore -eq "false") ) {
          $targets += "$packageFolder\$buildConfig\Storage\Azure.Storage"
        } 

        if ((($Scope -eq 'All') -or ($Scope -eq 'ServiceManagement')) -and ($isNetCore -eq "false") -and ($Profile -ne "Stack")) {
          $targets += "$packageFolder\$buildConfig\ServiceManagement\Azure"
        } 

        $resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory
        if ($Scope -eq 'All') {  
          foreach ($module in $resourceManagerModules) {
            # filter out AzureRM.Profile which always gets published first 
            # And "Azure.Storage" which is built out as test dependencies  
            if (($module.Name -ne "AzureRM.Profile") -and ($module.Name -ne "Azure.Storage") -and ($module.Name -ne "AzureRM.Profile.Netcore")) {
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
            if ($Profile -eq "Stack")
            {
                $targets += "$PSScriptRoot\..\src\StackAdmin\AzureRM"
                $targets += "$PSScriptRoot\..\src\StackAdmin\AzureStack"
            }
            if($isNetCore -eq "false") {
                # Publish AzureRM module    
                $targets += "$PSScriptRoot\AzureRM"
            } else {
                # For .NetCore publish AzureRM.Netcore
                $targets += "$PSScriptRoot\AzureRM.Netcore"
            }
        } 

        Write-Output -InputObject $targets
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
    
    $regex = New-Object System.Text.RegularExpressions.Regex "NestedModules\s*=\s*@\([^\)]+\)"
    $content = (Get-Content -Path $Path) -join "`r`n"
    $text = $regex.Replace($content, "NestedModules = @()")
    $text | Out-File -FilePath $Path
  }

}

function Update-NugetPackage
{
    [CmdletBinding()]
    param(
        [string]$BasePath,
        [string]$ModuleName,
        [string]$DirPath,
        [string]$NugetExe
    )

    PROCESS
    {
        $regex = New-Object -Type System.Text.RegularExpressions.Regex -ArgumentList  "([0-9\.]+)nupkg$"
        $regex2 = "<requireLicenseAcceptance>false</requireLicenseAcceptance>"
        
        $relDir = Join-Path $DirPath -ChildPath "_rels"
        $contentPath = Join-Path $DirPath -ChildPath '`[Content_Types`].xml'
        $packPath = Join-Path $DirPath -ChildPath "package"
        $modulePath = Join-Path $DirPath -ChildPath ($ModuleName + ".nuspec")
        Remove-Item -Recurse -Path $relDir -Force
        Remove-Item -Recurse -Path $packPath -Force
        Remove-Item -Path $contentPath -Force
        $content = (Get-Content -Path $modulePath) -join "`r`n"
        $content = $content -replace $regex2, ("<requireLicenseAcceptance>true</requireLicenseAcceptance>")
        $content | Out-File -FilePath $modulePath -Force
        &$NugetExe pack $modulePath -OutputDirectory $BasePath
    }
}

<#
.DESCRIPTION
Creates a module Nuget Package with correct Nuget metadata and module manifest metadata in two parts.
Part 1: Uses Publish-Module to create a .nupkg file with the correct metadata for module installation, 
Part 2: Updates the package contents to make module suitable for Import inside PowerShell.
In part 1, psd1 dependencies are used to determine the dependencies in the Nuget package
In part 2, Alters psd1 settings to allow fine-grained control of assembly loading when module is imported 
through a generated psm1 file. If a module manifest already has a psm1 module definition in its RootModule property
then the Part 2 processing is skipped.
#>
function Change-RMModule 
{
    [CmdletBinding()]
    param(
        [string]$Path,
        [string]$RepoLocation,
        [string]$TempRepo,
        [string]$TempRepoPath,
        [string]$NugetExe
    )

    PROCESS
    {
        $moduleName = (Get-Item -Path $Path).Name
        $moduleManifest = $moduleName + ".psd1"
        $moduleSourcePath = Join-Path -Path $Path -ChildPath $moduleManifest
        $file = Get-Item $moduleSourcePath
        Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
        $toss = Publish-Module -Path $Path -Repository $TempRepo -Force
        # Create a psm1 and alter psd1 dependencies to allow fine-grained control over assembly loading.  Opt out by definitng a RootModule.
        if ($ModuleMetadata.RootModule)
        {
            return
        }
        Write-Output "Changing to directory for module modifications $TempRepoPath"
        $moduleVersion = $ModuleMetadata.ModuleVersion.ToString()
        if ($ModuleMetadata.PrivateData.PSData.Prerelease -ne $null)
        {
            $moduleVersion += ("-" + $ModuleMetadata.PrivateData.PSData.Prerelease -replace "--", "-")
        }
        
        pushd $TempRepoPath
        try
        {
            $nupkgPath = Join-Path -Path . -ChildPath ($moduleName + "." + $moduleVersion + ".nupkg")
            $zipPath = Join-Path -Path . -ChildPath ($moduleName + "." + $moduleVersion + ".zip")
            $dirPath = Join-Path -Path . -ChildPath $moduleName
            $unzippedManifest = Join-Path -Path $dirPath -ChildPath ($moduleName + ".psd1")

            if (!(Test-Path -Path $nupkgPath))
            {
                throw "Module at $nupkgPath in $TempRepoPath does not exist"
            }
            Write-Output "Renaming package $nupkgPath to zip archive $zipPath"
            ren $nupkgPath $zipPath
            Write-Output "Expanding $zipPath"
            Expand-Archive $zipPath -DestinationPath $dirPath
            Write-Output "Adding PSM1 dependency to $unzippedManifest"
            Write-Output "Removing module manifest dependencies for $unzippedManifest"
            Remove-ModuleDependencies -Path $unzippedManifest
            Remove-Item -Path $zipPath -Force
            Write-Output "Repackaging $dirPath"
            Update-NugetPackage -BasePath $TempRepoPath -ModuleName $moduleName -DirPath $dirPath -NugetExe $NugetExe
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
        $file = Get-Item $moduleSourcePath
        Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
        $nupkgPath = Join-Path -Path $TempRepoPath -ChildPath ($moduleName + "." + $ModuleMetadata.ModuleVersion.ToString() + ".nupkg")
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
Get-PackageProvider -Name NuGet -Force

$packageFolder = "$PSScriptRoot\..\src\Package"
if ($Profile -eq "Stack")
{
    $packageFolder = "$PSScriptRoot\..\src\Stack"
}

$publishToLocal = test-path $repositoryLocation
[string]$tempRepoPath = "$PSScriptRoot\..\src\package"
if ($publishToLocal)
{
    if ($Profile -eq "Stack"){
        $tempRepoPath = (Join-Path $repositoryLocation -ChildPath "stack")
    }
    else {
       $tempRepoPath = (Join-Path $repositoryLocation -ChildPath "package")
       
    }
}

$tempRepoName = ([System.Guid]::NewGuid()).ToString()
$repo = Get-PSRepository | Where-Object { $_.SourceLocation -eq $tempRepoPath }
if ($repo -ne $null) {
    $tempRepoName = $repo.Name
} else {
    Register-PSRepository -Name $tempRepoName -SourceLocation $tempRepoPath -PublishLocation $tempRepoPath -InstallationPolicy Trusted -PackageManagementProvider NuGet
}

$env:PSModulePath="$env:PSModulePath;$tempRepoPath"

try {
    $modulesInScope = Get-TargetModules -buildConfig $buildConfig -Scope $scope -PublishLocal $publishToLocal -Profile $Profile
    foreach ($modulePath in $modulesInScope) {
        # filter out AzureRM.Profile which always gets published first 
        # And "Azure.Storage" which is built out as test dependencies  
        $module = Get-Item -Path $modulePath
        Write-Host "Changing $module module from $modulePath"
        Change-RMModule -Path $modulePath -RepoLocation $repositoryLocation -TempRepo $tempRepoName -TempRepoPath $tempRepoPath -nugetExe $nugetExe
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
