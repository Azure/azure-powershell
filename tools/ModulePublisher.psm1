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

function Get-ModuleOrder
{
	param([string]$directory)
	$regex = New-Object -Type System.Text.RegularExpressions.Regex -ArgumentList "Az(ureRM)?\.[0-9].*"
	$orderedPackages = @()
	$packages = (Get-ChildItem -Path $directory -Filter "*.nupkg")
	$profile = $packages | Where {$_.Name.Contains(".Accounts.") -or $_.Name.Contains(".Profile.")}
	$storage = $packages | Where {$_.Name.Contains("Azure.Storage.") -or $_.Name.Contains("Az.Storage.")}
	$azurerm = $packages | Where {$regex.IsMatch($_.Name)}
	if ($profile -ne $null -and $profile.Length -gt 0)
	{
		$orderedPackages += $profile[0]
	}
	if ($storage -ne $null -and $storage.Length -gt 0)
	{
		$orderedPackages += $storage
	}
	foreach ($package in $packages)
	{
		if (!$package.Name.Contains(".Accounts.") -and `
		    !$package.Name.Contains(".Profile.") -and `
			!$package.Name.Contains("Azure.Storage.") -and `
			!$package.Name.Contains("Az.Storage.") -and `
			!$regex.IsMatch($package.Name))
		{
			$orderedPackages += $package
		}
	}
	if ($azurerm -ne $null -and $azurerm.Length -gt 0)
	{
		$orderedPackages += $azurerm[0]
	}

	$orderedPackages
}

function Get-RepoLocation
{
	param([string]$repoName)
		$location = "https://www.poshtestgallery.com/api/v2/package/"
		if ($repoName -eq "PSGallery")
		{
			$location = "https://www.powershellgallery.com/api/v2/package/"
		}

		$location
}

function Get-ApiKey
{
	param([string]$repoName)
		$vaultKey="PSTestGalleryApiKey"
		if ($repoName -eq "PSGallery")
		{
			$vaultKey = "PowerShellGalleryApiKey"
		}

		$context = (Get-AzContext -ErrorAction Ignore)

		if ($context -eq $null -or $context.Account -eq $null -or $context.Account.Id -eq $null)
		{
			Connect-AzAccount -ErrorAction Stop
		}

		$secret = Get-AzKeyVaultSecret -VaultName kv-azuresdk -Name $vaultKey -ErrorAction Stop

		if($secret.SecretValueText -eq $null)
		{
			$secret = Get-AzKeyVaultSecret -VaultName kv-azuresdk -Name $vaultKey -ErrorAction Stop
			$secretPlainText = ConvertFrom-SecureString -SecureString $secret.SecretValue -AsPlainText
			$secretPlainText
		}
		else 
		{
			$secret.SecretValueText
		}
}

function Update-NugetPackage
{
	[CmdletBinding()]
	param(
		[System.IO.FileInfo]$Path,
		[string]$NugetExe
	)

	PROCESS
	{
        $regex = New-Object -Type System.Text.RegularExpressions.Regex -ArgumentList  "([0-9\.]+)nupkg$"
		$regex2 = "<requireLicenseAcceptance>false</requireLicenseAcceptance>"
		$zipPath = $Path.FullName.Replace(".nupkg", ".zip")
		$dirName = $regex.Replace($Path.Name, [string]::Empty)
		$dirPath = Join-Path -Path $Path.Directory.FullName -ChildPath $dirName
		ren $Path.FullName $zipPath
		Expand-Archive $zipPath -DestinationPath $dirPath
		$relDir = Join-Path $dirPath -ChildPath "_rels"
		$contentPath = Join-Path $dirPath -ChildPath '`[Content_Types`].xml'
		$packPath = Join-Path $dirPath -ChildPath "package"
		$modulePath = Join-Path $dirPath -ChildPath ($dirName + ".nuspec")
		Remove-Item -Recurse -Path $relDir -Force
		Remove-Item -Recurse -Path $packPath -Force
		Remove-Item -Path $contentPath -Force
		$content = (Get-Content -Path $modulePath) -join "`r`n"
		$content = $content -replace $regex2, ("<licenseUrl>https://raw.githubusercontent.com/Azure/azure-powershell/dev/LICENSE.txt</licenseUrl>`r`n    <projectUrl>https://github.com/Azure/azure-powershell</projectUrl>`r`n    <requireLicenseAcceptance>true</requireLicenseAcceptance>")
		$content | Out-File -FilePath $modulePath -Force
		&$NugetExe pack $modulePath -OutputDirectory $Path.Directory.FullName
	}
}

function Remove-RMPackage
{
	[CmdletBinding(SupportsShouldProcess=$true)]
	param(
		[Parameter(Mandatory=$true, ValueFromPipeline=$true)]
		[PSObject]$ModuleInfo, 
		[string]$RepoLocation,
		[string]$ApiKey,
		[string]$NugetExe = (Join-Path $PSScriptRoot "NuGet.exe"))

    process {
		$Name = $ModuleINfo.Name
		$Version = $ModuleInfo.Version
		if ($PSCmdlet.ShouldProcess("$Name version $Version", "Removing Nuget Package using command $NugetExe delete $Name $Version $ApiKey -Source $RepoLocation -Verbosity detailed")) {
			&$NugetExe delete $Name $Version $ApiKey -Source $RepoLocation -Verbosity detailed -NoPrompt
		}
	}
}

function Remove-RMPackages {
	[CmdletBinding(SupportsShouldProcess=$true)]
	param(
		[Parameter(Mandatory=$true)]
		[string]
		$ModuleNameString,

		[Parameter(Mandatory=$false)]
		[string]
		$NugetExe = (Join-Path $PSScriptRoot "NuGet.exe"),

		[Parameter(ParameterSetName="ByName", Mandatory=$true)]
		[ValidateSet("TestGallery", "PSGallery")]
		[string]
		$RepoName 
	)

	process {
		$RepoLocation = (Get-RepoLocation -repoName $RepoName)
		$ApiKey = (Get-ApiKey -repoName $RepoName)
		$modules = (Find-Module -Name $ModuleNameString -Repository $RepoName)
		$modules | %{Find-Module -Name $_.Name -Repository $RepoName -AllVersions} | Remove-RMPackage -RepoLocation $RepoLocation -ApiKey $ApiKey -NugetExe $NugetExe -WhatIf:([bool]$WhatIfPreference) -ErrorAction Stop

	}
}

function Update-Packages
{
	[CmdletBinding()]
	param(
		[Parameter(Mandatory=$true)]
		[string]
		$Path,

		[Parameter(Mandatory=$true)]
		[string]
		$NugetExe
		)

	PROCESS
	{
		$modules = (Get-ModuleOrder -directory $Path)
		foreach ($package in $modules)
		{
			Update-NugetPackage -Path $package -NugetExe $NugetExe
		}
	}
}

function Publish-RMModules
{
	[CmdletBinding(SupportsShouldProcess=$true, DefaultParameterSetName="ByName")]
	param(
		[Parameter(Mandatory=$true)]
		[string]
		$Path,

		[Parameter(Mandatory=$false)]
		[string]
		$NugetExe = (Join-Path $PSScriptRoot "NuGet.exe"),

		[Parameter(ParameterSetName="ByLocation", Mandatory=$true)]
		[string]
		$RepoLocation,

		[Parameter(ParameterSetName="ByLocation", Mandatory=$true)]
		[string]
		$ApiKey,

		[Parameter(ParameterSetName="ByName", Mandatory=$true)]
		[ValidateSet("TestGallery", "PSGallery")]
		[string]
		$RepoName
	)

	PROCESS
	{

		if ($PSCmdlet.ParameterSetName -eq "ByName")
		{
			$RepoLocation = (Get-RepoLocation -repoName $RepoName)
			$ApiKey = (Get-ApiKey -repoName $RepoName)
		}
		$modules = (Get-ModuleOrder -directory $Path)
		foreach ($package in $modules)
		{
		  $packagePath = $package.FullName
		  if (!(Test-Path -Path $packagePath -ErrorAction Ignore))
		  {
			throw "Module at $packagePath does not exist"
		  }

		  if ($PSCmdlet.ShouldProcess($packagePath, "Pushing package $packagePath to nuget source $RepoLocation using command '$NugetExe push $packagePath $ApiKey -Source $RepoLocation'"))
		  {
		    Write-Host "Pushing package $packagePath to nuget source $RepoLocation"
		    &$NugetExe push $packagePath $ApiKey -Source $RepoLocation -Verbosity detailed
	        Write-Host "Pushed package $packagePath to nuget source $RepoLocation"
	      }
		}
	}
}
