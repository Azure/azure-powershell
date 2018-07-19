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
    Run AzureStack fabric admin software load balancer mux instance tests.

.DESCRIPTION
    Run AzureStack fabric admin software load balancer mux instance tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\SlbMuxInstance.Tests.ps1
	Describing SlbMuxInstances
	 [+] TestListSlbMuxInstances 155ms
	 [+] TestGetSlbMuxInstance 100ms
	 [+] TestGetAllSlbMuxInstances 73ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Fabric.Admin {

    Describe "SlbMuxInstances" -Tags @('SlbMuxInstance', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateSlbMuxInstance {
                param(
                    [Parameter(Mandatory = $true)]
                    $SlbMuxInstance
                )

                $SlbMuxInstance          | Should Not Be $null

                # Resource
                $SlbMuxInstance.Id       | Should Not Be $null
                $SlbMuxInstance.Location | Should Not Be $null
                $SlbMuxInstance.Name     | Should Not Be $null
                $SlbMuxInstance.Type     | Should Not Be $null

                # Software Load Balancing Mux Instance
                $SlbMuxInstance.BgpPeers            | Should Not Be $null
                $SlbMuxInstance.ConfigurationState  | Should Not Be $null
                $SlbMuxInstance.VirtualServer       | Should Not Be $null
            }

            function AssertSlbMuxInstancesAreSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                }
                else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Software Load Balancing Mux Instance
                    if ($Expected.BgpPeers -eq $null) {
                        $Found.BgpPeers        | Should Be $null
                    }
                    else {
                        $Found.BgpPeers        | Should not Be $null
                        $Found.BgpPeers.Count  | Should Be $Expected.BgpPeers.Count
                    }

                    $Found.ConfigurationState  | Should Be $Expected.ConfigurationState
                    $Found.VirtualServer       | Should Be $Expected.VirtualServer
                }
            }
        }


        it "TestListSlbMuxInstances" -Skip:$('TestListSlbMuxInstances' -in $global:SkippedTests) {
            $global:TestName = 'TestListSlbMuxInstances'
            $SlbMuxInstances = Get-AzsSlbMuxInstance -ResourceGroupName $global:ResourceGroupName -Location $Location
            $SlbMuxInstances | Should Not Be $null
            foreach ($SlbMuxInstance in $SlbMuxInstances) {
                ValidateSlbMuxInstance -SlbMuxInstance $SlbMuxInstance
            }
        }


        it "TestGetSlbMuxInstance" -Skip:$('TestGetSlbMuxInstance' -in $global:SkippedTests) {
            $global:TestName = 'TestGetSlbMuxInstance'

            $SlbMuxInstances = Get-AzsSlbMuxInstance -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($SlbMuxInstance in $SlbMuxInstances) {
                $retrieved = Get-AzsSlbMuxInstance -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $SlbMuxInstance.Name
                AssertSlbMuxInstancesAreSame -Expected $SlbMuxInstance -Found $retrieved
                break
            }
        }

        it "TestGetAllSlbMuxInstances" -Skip:$('TestGetAllSlbMuxInstances' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllSlbMuxInstances'

            $SlbMuxInstances = Get-AzsSlbMuxInstance -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($SlbMuxInstance in $SlbMuxInstances) {
                $retrieved = Get-AzsSlbMuxInstance -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $SlbMuxInstance.Name
                AssertSlbMuxInstancesAreSame -Expected $SlbMuxInstance -Found $retrieved
            }
        }
    }
}
