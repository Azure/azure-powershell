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
[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, HelpMessage="Use Install parameter to install Azure modules from PowerShell Gallery.")]
[switch]$Install
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
Installing Azure Modules from PowerShell Gallery. 
This may take some time...
"@
		$env:PSModulePath = "$env:USERPROFILE\Documents\WindowsPowerShell\Modules;$env:ProgramFiles\WindowsPowerShell\Modules;$env:SystemRoot\system32\WindowsPowerShell\v1.0\Modules\"

		Import-Module PackageManagement
		
		$result = Get-PackageProvider -Name NuGet -ForceBootstrap

		Import-Module PowerShellGet

		Install-Module AzureRM
		Write-Output "AzureRM $((Get-InstalledModule -Name AzureRM)[0].Version) installed..."
		Update-AzureRM
	} else {
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

		$VerbosePreference = "Continue"
	}
}
catch 
{ 
Write-Output "An error occured during installation."
Write-Output $error 
Write-Output "Press any key..."
$host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}

