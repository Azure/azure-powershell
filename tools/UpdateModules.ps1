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

<#
.SYNOPSIS
    Update the modules.

.PARAMETER BuildConfig
    The build configuration, either Debug or Release

.PARAMETER Scope
    Either All, Latest, Stack, NetCore, ServiceManagement, AzureStorage

#>
param(
    [Parameter(Mandatory = $false, Position = 0)]
    [ValidateSet("Release", "Debug")]
    [string] $BuildConfig,

    [Parameter(Mandatory = $false, Position = 1)]
    [ValidateSet("All", "Latest", "Stack", "NetCore", "ServiceManagement", "AzureStorage")]
    [string] $Scope
)

Import-Module "$PSScriptRoot\UpdateModules.psm1"

<################################################
#  Main
#################################################>


# Constants (Scopes)
$NetCoreScopes = @('NetCore')
$AzureScopes = @('All', 'Latest', 'ServiceManagement', 'AzureStorage')
$StackScopes = @('All', 'Stack')

# Begin
Write-Host "Updating $Scope package (and its dependencies)"

if ($Scope -in $NetCoreScopes) {
    Update-Netcore -BuildConfig $BuildConfig
}

if ($Scope -in $AzureScopes) {
    Update-Azure -Scope $Scope -BuildConfig $BuildConfig
}

if ($Scope -in $StackScopes) {
    Update-Stack -BuildConfig $BuildConfig
}

