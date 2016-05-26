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
    [string] $buildConfig
)

$VerbosePreference = 'Continue'

if ([string]::IsNullOrEmpty($buildConfig))
{
	Write-Verbose "Setting build configuration to 'Release'"
	$buildConfig = 'Release'
}

Write-Verbose "Build configuration is set to $buildConfig"

$output = Join-Path $env:AzurePSRoot "src\Package\$buildConfig"
Write-Verbose "The output folder is set to $output"
$serviceManagementPath = Join-Path $output "ServiceManagement\Azure"
$resourceManagerPath = Join-Path $output "ResourceManager\AzureResourceManager"

Write-Verbose "Removing unneeded psd1 and other files"
Remove-Item -Force $resourceManagerPath\AzureResourceManager.psd1 -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.DataLakeAnalytics\AzureRM.Tags.psd1 -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.DataLakeAnalytics\Microsoft.Azure.Commands.Tags.dll-Help.xml -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.DataLakeAnalytics\Microsoft.Azure.Commands.Tags.format.ps1xml -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.DataLakeStore\AzureRM.Tags.psd1 -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.DataLakeStore\Microsoft.Azure.Commands.Tags.dll-Help.xml -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.DataLakeStore\Microsoft.Azure.Commands.Tags.format.ps1xml -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.Intune\AzureRM.Intune.psd1 -ErrorAction SilentlyContinue
Remove-Item -Force $resourceManagerPath\AzureRM.RecoveryServices.Backup\AzureRM.RecoveryServices.psd1 -ErrorAction SilentlyContinue
Write-Verbose "Removing duplicated Resources folder"
Remove-Item -Recurse -Force $serviceManagementPath\Compute\Resources\ -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force $serviceManagementPath\Sql\Resources\ -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force $serviceManagementPath\Storage\Resources\ -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force $serviceManagementPath\ManagedCache\Resources\ -ErrorAction SilentlyContinue

Write-Verbose "Removing generated NuGet folders from $output"
$resourcesFolders = @("de", "es", "fr", "it", "ja", "ko", "ru", "zh-Hans", "zh-Hant")
Get-ChildItem -Include $resourcesFolders -Recurse -Force -Path $output | Remove-Item -Force -Recurse -ErrorAction SilentlyContinue

Write-Verbose "Removing XML help files for helper dlls from $output"
$exclude = @("*.dll-Help.xml", "Scaffold.xml", "RoleSettings.xml", "WebRole.xml", "WorkerRole.xml")
$include = @("*.xml", "*.lastcodeanalysissucceeded", "*.dll.config", "*.pdb")
Get-ChildItem -Include $include -Exclude $exclude -Recurse -Path $output | Remove-Item -Force -Recurse
Get-ChildItem -Recurse -Path $output -Include *.dll-Help.psd1 | Remove-Item -Force

Write-Verbose "Removing unneeded web deployment dependencies"
$webdependencies = @("Microsoft.Web.Hosting.dll", "Microsoft.Web.Delegation.dll", "Microsoft.Web.Administration.dll", "Microsoft.Web.Deployment.Tracing.dll")
Get-ChildItem -Include $webdependencies -Recurse -Path $output | Remove-Item -Force

if (Get-Command "heat.exe" -ErrorAction SilentlyContinue)
{
	$azureFiles = Join-Path $env:AzurePSRoot 'setup\azurecmdfiles.wxi'
    heat dir $output -srd -sfrag -sreg -ag -g1 -cg azurecmdfiles -dr PowerShellFolder -var var.sourceDir -o $azureFiles
    
	# Replace <Wix> with <Include>
	(gc $azureFiles).replace('<Wix', '<Include') | Set-Content $azureFiles
	(gc $azureFiles).replace('</Wix' ,'</Include') | Set-Content $azureFiles
}
else
{
    Write-Error "Failed to execute heat.exe, the Wix bin folder is not in PATH"
}