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
    [ValidateSet("ModuleList", "AzureRMAndDependencies", "AzureAndDependencies", "NetCoreModules", "StackModules")]
    [string] $scope,
    [Parameter(Mandatory = $false, Position = 1)]
    [string[]] $ListOfModules,
    [Parameter(Mandatory = $false, Position = 3)]
    [string] $apiKey,
    [Parameter(Mandatory = $false, Position = 4)]
    [string] $repositoryLocation,
    [Parameter(Mandatory = $false, Position = 5)]
    [string] $nugetExe
)

function Get-TargetModules
{
    [CmdletBinding()]
    param
    (
      [string]$buildConfig,
      [string]$Scope
    )
}