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
[CmdletBinding(DefaultParametersetName="none")]
Param(
[Parameter(Mandatory=$True, HelpMessage="Use Install parameter to install Azure modules from PowerShell Gallery.", ParameterSetName="install")]
[switch]$Install,
[Parameter(Mandatory=$True, HelpMessage="Use Uninstall parameter to uninstall Azure modules from PowerShell Gallery.", ParameterSetName="uninstall")]
[switch]$Uninstall
)

function EnsureRegistryPath
{
	$originalpaths = (Get-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PSModulePath).PSModulePath
	if($originalpaths.Contains("$env:ProgramFiles\WindowsPowerShell\Modules") -eq $false)
	{
		Write-Output "Fixing PSModulePath"
		$newPath = "$originalpaths;$env:ProgramFiles\WindowsPowerShell\Modules"
		Set-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PSModulePath –Value $newPath
	}
	else
	{
		Write-Output "PSModulePath successfuly validated"
	}
}

$error.clear()
try {
	if ($Install.IsPresent) {
		Write-Output @"

Finalizing installation of Azure PowerShell. 
Installing AzureRM Modules from PowerShell Gallery. 
This may take some time...
"@
		$env:PSModulePath = "$env:USERPROFILE\Documents\WindowsPowerShell\Modules;$env:ProgramFiles\WindowsPowerShell\Modules;$env:SystemRoot\system32\WindowsPowerShell\v1.0\Modules\"

		Import-Module PackageManagement
		
		$result = Get-PackageProvider -Name NuGet -ForceBootstrap

		Import-Module PowerShellGet

		$DefaultPSRepository = $env:DefaultPSRepository
		if ([string]::IsNullOrWhiteSpace($DefaultPSRepository)) 
		{
			$DefaultPSRepository = "PSGallery"
		}

		$_InstallationPolicy = (Get-PSRepository -Name $DefaultPSRepository).InstallationPolicy
		try 
		{
			Set-PSRepository -Name $DefaultPSRepository -InstallationPolicy Trusted
		
			Install-Module AzureRM -Repository $DefaultPSRepository
			Write-Output "AzureRM $((Get-InstalledModule -Name AzureRM)[0].Version) installed..."

			Update-AzureRM -Repository $DefaultPSRepository
		} finally {
			# Clean up
			Set-PSRepository -Name $DefaultPSRepository -InstallationPolicy $_InstallationPolicy
		}
	}
	elseif ($Uninstall.IsPresent) 
	{
		Write-Output @"

Finalizing uninstallation of Azure PowerShell. 
This may take some time...
"@
		$env:PSModulePath = "$env:USERPROFILE\Documents\WindowsPowerShell\Modules;$env:ProgramFiles\WindowsPowerShell\Modules;$env:SystemRoot\system32\WindowsPowerShell\v1.0\Modules\"

		Uninstall-AzureRM
		Uninstall-Module -Name AzureRM -Confirm:$false -Force
	} 
	else 
	{
		cd c:\
		$welcomeMessage = @"
For a list of all Azure RM cmdlets type 'help azurerm'.

To start using Azure RM login via Login-AzureRmAccount cmdlet.
To switch between subscriptions use Set-AzureRmContext.
For more details, see http://aka.ms/azps-getting-started.

To use Azure Service Management cmdlets please execute the following cmdlet:
  Install-Module Azure
"@
		Write-Output $welcomeMessage
	}
}
catch 
{ 
Write-Output "An error occured during installation."
Write-Output $error 
Write-Output "Press any key..."
$key = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}

