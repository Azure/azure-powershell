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
    Run AzureStack AzureBridge admin edge gateway tests.

.DESCRIPTION
    Run AzureStack AzureBridge admin edge gateway tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.PARAMETER UseInstalled
    Use the locally installed modules.

.EXAMPLE
    PS C:\> .\src\Activation.Tests.ps1
    Describing Activations
	 [+] TestListActivations 81ms
	 [+] TestGetActivation 73ms
	 [+] TestGetAllActivations 66ms

.NOTES
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.AzureBridge.Admin {

    Describe "AzsAzureBridgeActivation" -Tags @('AzureBridgeActivation', 'Azs.AzureBridge.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateActivationInfo {
                param(
                    [Parameter(Mandatory = $true)]
                    $Activation
                )

                $Activation          | Should Not Be $null

                # Resource
                $Activation.Id       | Should Not Be $null
                $Activation.Name     | Should Not Be $null
                $Activation.Type     | Should Not Be $null

                $Activation.ProvisioningState    | Should Not Be $null
                $Activation.Expiration         | Should Not Be $null
                $Activation.MarketplaceSyndicationEnabled        | Should Not Be $null
                $Activation.AzureRegistrationResourceIdentifier  | Should Not Be $null
                $Activation.Location    | Should Not Be $null
                $Activation.DisplayName  | Should Not Be $null

            }
        }

        AfterEach {
            $global:Client = $null
        }

        It "TestListAzsAzureBridgeActivation" -Skip:$('TestListAzsAzureBridgeActivation' -in $global:SkippedTests) {
            $global:TestName = "TestListAzsAzureBridgeActivation"
            $Activations = Get-AzsAzureBridgeActivation -ResourceGroupName $global:ResourceGroupName

            Foreach ($Activation in $Activations) {
                ValidateActivationInfo -Activation $Activation
            }
        }

        It "TestGetAzsAzureBridgeActivationByName" -Skip:$('TestGetAzsAzureBridgeActivationByName' -in $global:SkippedTests) {
            $global:TestName = "TestGetAzsAzureBridgeActivationByName"
            $Activation = Get-AzsAzureBridgeActivation -Name $global:ActivationName -ResourceGroupName $global:ResourceGroupName
            ValidateActivationInfo -Activation $Activation
        }
    }

}
