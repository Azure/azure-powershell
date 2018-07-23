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
    Run AzureStack Containers admin tests

.DESCRIPTION
    Run AzureStack Containers admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Containers.Tests.ps1
    Describing Containers
	 [+] TestListContainers 2.36s
	 [+] TestListDestinationShares

.NOTES
    Author: Deepa Thomas
	Copyright: Microsoft
    Date:   February 20, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Storage.Admin {

    Describe "Containers" -Tags @('Containers', 'Azs.Storage.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateContainer {
                param(
                    [Parameter(Mandatory = $true)]
                    $container
                )
                # Resource
                $container											| Should Not Be $null

                # Validate Container properties
                $container.Accountid								| Should Not Be $null
                $container.Accountname								| Should Not Be $null
                $container.Containerid								| Should Not Be $null
                $container.Containername							| Should Not Be $null
                $container.ContainerState							| Should Not Be $null
                $container.Sharename								| Should Not Be $null
                $container.UsedBytesInPrimaryVolume					| Should Not Be $null

            }

            function ValidateDestinationShare {
                param(
                    [Parameter(Mandatory = $true)]
                    $share
                )
                # Resource
                $share								| Should Not Be $null

                # Validate Share properties
                $share.FreeCapacity					| Should Not Be $null
                $share.HealthStatus					| Should Not Be $null
                $share.Id							| Should Not Be $null
                $share.Location						| Should Not Be $null
                $share.Name							| Should Not Be $null
                $share.ShareName					| Should Not Be $null
                $share.TotalCapacity				| Should Not Be $null
                $share.Type							| Should Not Be $null
                $share.UncPath						| Should Not Be $null
                $share.UsedCapacity					| Should Not Be $null
            }
        }

        it "TestListContainers" -Skip:$('TestListContainers' -in $global:SkippedTests) {
            $global:TestName = 'TestListContainers'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                $shares = Get-AzsStorageShare -ResourceGroupName $global:ResourceGroupName -FarmName (Select-Name $farm.Name)
                foreach ($share in $shares) {
                    $containers = Get-AzsStorageContainer -ResourceGroupName $global:ResourceGroupName -ShareName (Select-Name $share.Name) -FarmName (Select-Name $farm.Name) -StartIndex 0 -MaxCount 10
                    $containers  | Should Not Be $null
                    foreach ($container in $containers) {
                        $container  | Should Not Be $null
                        ValidateContainer -container $container
                    }
                }
            }
        }

        it "TestListDestinationShares" -Skip:$('TestListDestinationShares' -in $global:SkippedTests) {
            $global:TestName = 'TestListDestinationShares'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                $shares = Get-AzsStorageShare -ResourceGroupName $global:ResourceGroupName -FarmName (Select-Name $farm.Name)
                foreach ($share in $shares) {
                    $destinationShares = Get-AzsStorageDestinationShare -ResourceGroupName $global:ResourceGroupName -SourceShareName (Select-Name $share.Name) -FarmName (Select-Name $farm.Name)
                    foreach ($destinationShare in $destinationShares) {
                        $destinationShare  | Should Not Be $null
                        ValidateDestinationShare -share $destinationShare
                    }
                }
            }
        }
    }
}
