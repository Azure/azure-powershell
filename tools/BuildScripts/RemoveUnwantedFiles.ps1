# ----------------------------------------------------------------------------------
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

<##
# .SYNOPSIS 
# Remove unnecessary files before packaging.
# .DESCRIPTION
# This script removes the runtime assemblies because PowerShell already has them, as well as the .deps.json files because they are not needed.
# .EXAMPLE
# .\RemoveRuntimeAssemblies.ps1 -RootPath "C:\repo\azure-powershell\artifacts\Debug\"
# This example removes the runtime assemblies in the Debug folder
# .EXAMPLE
# .\RemoveRuntimeAssemblies.ps1 -RootPath "C:\repo\azure-powershell\artifacts\Debug\" -CodeSign
# This example removes the runtime assemblies and the runtimes folder
# .NOTES
# It's unclear whether removing the runtimes folder is still necessary because the folder doesn't seem to exist in the build process.
#>

param(
    [CmdletBinding()]
    [Parameter(Mandatory = $True, HelpMessage = "Root path of the assemblies, e.g. artifacts/Debug/")]
    [string] $RootPath,

    [Parameter(HelpMessage = "true or false. If true, remove the runtimes folder")]
    [string] $CodeSign
)

$RuntimeDllsIncludeList = @(
    'Microsoft.Powershell.*.dll',
    'System*.dll',
    'Microsoft.VisualBasic.dll',
    'Microsoft.CSharp.dll',
    'Microsoft.CodeAnalysis.dll',
    'Microsoft.CodeAnalysis.CSharp.dll'
)
$RuntimeDllsExcludeList = @(
    'System.Security.Cryptography.ProtectedData.dll',
    'System.Configuration.ConfigurationManager.dll',
    'System.Runtime.CompilerServices.Unsafe.dll',
    'System.IO.FileSystem.AccessControl.dll',
    'System.Buffers.dll',
    'System.Text.Encodings.Web.dll',
    'System.CodeDom.dll',
    'System.Management.dll',
    'System.Text.Json.dll',
    'System.Threading.Tasks.Extensions.dll',
    'System.IO.Hashing.dll'
)

$toRemove = Get-ChildItem -Path $RootPath -Recurse -Include $RuntimeDllsIncludeList -Exclude $RuntimeDllsExcludeList
    | Where-Object { $_.FullName -notlike '*Accounts*lib*' -and $_.FullName -notlike '*ModuleAlcAssemblies*' }
Write-Host "Removing $($toRemove.Count) runtime assemblies."    
$toRemove | Remove-Item -Force
Write-Host "runtime assemblies removed."

if ($CodeSign -eq 'true') {
    $toRemove = Get-ChildItem -Path $RootPath -Recurse -Include 'runtimes'
    Write-Host "Removing $($toRemove.Count) 'runtimes' folders."
    $toRemove | Remove-Item -Recurse -Force
    Write-Host "'runtimes' folders removed."
}

$toRemove = Get-ChildItem -Path $RootPath -Recurse
    | Where-Object { $_.Name -Like '*Az.*.deps.json' -or $_.Name -Like 'Microsoft.Azure.*.deps.json' }
Write-Host "Removing $($toRemove.Count) .deps.json files."
$toRemove | Remove-Item -Force
Write-Host ".deps.json files removed."
