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

$error.clear()
try {
	if ($Install.IsPresent) {
		Write-Output @"

Finalizing installation of Azure PowerShell. 
Installing Azure Modules from PowerShell Gallery. 
This may take some time...
"@
		Import-Module PackageManagement
		Get-PackageProvider -Name NuGet -ForceBootstrap

		$NuGetPublishingSource = $env:NuGetPublishingSource
		if ([string]::IsNullOrWhiteSpace($NuGetPublishingSource)) {
			Install-Module AzureRM -Repository $NuGetPublishingSource
		} else {
			Install-Module AzureRM
		}
	} else {
		cd c:\
		$welcomeMessage = @"
For a list of all Azure cmdlets type 'help azure'.
For a list of Azure Pack cmdlets type 'Get-Command *wapack*'.
"@
		Write-Output $welcomeMessage

		$VerbosePreference = "Continue"
	}
}
catch { Write-Output $error }
if ($error) {
	Read-Host -Prompt "An error occured during installation. Press any key..."
}