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
param([switch]$Isolated, [switch]$IncludeGeneralParameters, [switch]$UseExpandedFormat)
$ErrorActionPreference = 'Stop'

$pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
if(-not $Isolated) {
  Write-Host -ForegroundColor Green 'Creating isolated process...'
  & "$pwsh" -NonInteractive -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated
  return
}

$dll = Join-Path $PSScriptRoot 'bin\Az.VMware.private.dll'
if(-not (Test-Path $dll)) {
  Write-Error "Unable to find output assembly in '$binFolder'."
}
$null = Import-Module -Name $dll

$moduleName = 'Az.VMware'
$exportsFolder = Join-Path $PSScriptRoot 'exports'
$resourcesFolder = Join-Path $PSScriptRoot 'resources'

Export-CmdletSurface -ModuleName $moduleName -CmdletFolder $exportsFolder -OutputFolder $resourcesFolder -IncludeGeneralParameters $IncludeGeneralParameters.IsPresent -UseExpandedFormat $UseExpandedFormat.IsPresent
Write-Host -ForegroundColor Green "CmdletSurface file(s) created in '$resourcesFolder'"

Export-ModelSurface -OutputFolder $resourcesFolder -UseExpandedFormat $UseExpandedFormat.IsPresent
Write-Host -ForegroundColor Green "ModelSurface file created in '$resourcesFolder'"

Write-Host -ForegroundColor Green '-------------Done-------------'