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

$script:AzPSCommonParameters = @("-Break", "-Confirm", "-Debug", "-DefaultProfile", "-ErrorAction", "-ErrorVariable", "-HttpPipelineAppend", "-HttpPipelinePrepend", "-InformationAction", "-InformationVariable",
    "-OutBuffer", "-OutVariable", "-PassThru", "-PipelineVariable", "-Proxy", "-ProxyCredential", "-ProxyUseDefaultCredentials", "-Verbose", "-WarningAction", "-WarningVariable", "-WhatIf")
function Get-TestCoverageModuleDetails {
    [CmdletBinding()]
    [OutputType([hashtable])]
    param (
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        $Module
    )

    [hashtable] $ModuleDetails = @{}

    $moduleCommands = $Module.ExportedCmdlets.Keys + $Module.ExportedFunctions.Keys
    $totalCommands = $moduleCommands.Count

    $totalParameterSets = 0
    $totalParameters = 0
    $moduleCommands | ForEach-Object {
        $command = Get-Command -Name $_
        $totalParameterSets += $command.ParameterSets.Count

        $commandParams = $command.Parameters
        $commandParams.Keys | ForEach-Object {
            if ($_ -notin $script:AzPSCommonParameters) {
                $totalParameters += $commandParams[$_].ParameterSets.Count
            }
        }
    }

    $ModuleDetails = @{ TotalCommands = $totalCommands; TotalParameterSets = $totalParameterSets; TotalParameters = $totalParameters }
    $ModuleDetails
}
