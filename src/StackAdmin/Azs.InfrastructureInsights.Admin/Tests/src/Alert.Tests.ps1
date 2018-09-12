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
    Run AzureStack fabric admin edge gateway pool tests.

.DESCRIPTION
    Run AzureStack fabric admin edge gateway pool tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Alert.Tests.ps1
	Describing Alerts
	[+] TestListAlerts 349ms
	[+] TestGetAlert 175ms
	[+] TestGetAllAlerts 866ms
	[+] TestCloseAlert 171ms

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

InModuleScope Azs.InfrastructureInsights.Admin {

    Describe "Alerts" -Tags @('Alert', 'InfrastructureInsightsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateAlert {
                param(
                    [Parameter(Mandatory = $true)]
                    $Alert
                )

                $Alert          | Should Not Be $null

                # Resource
                $Alert.Id       | Should Not Be $null
                $Alert.Location | Should Not Be $null
                $Alert.Name     | Should Not Be $null
                $Alert.Type     | Should Not Be $null

                # Alert
                $Alert.AlertId                         | Should Not Be $null
                $Alert.AlertProperties                 | Should Not Be $null
                $Alert.CreatedTimestamp                | Should Not Be $null
                $Alert.Description                     | Should Not Be $null
                $Alert.FaultTypeId                     | Should Not Be $null
                $Alert.ImpactedResourceDisplayName     | Should Not Be $null
                $Alert.ImpactedResourceId              | Should Not Be $null
                $Alert.LastUpdatedTimestamp            | Should Not Be $null
                $Alert.Remediation                     | Should Not Be $null
                $Alert.ResourceProviderRegistrationId  | Should Not Be $null
                $Alert.Severity                        | Should Not Be $null
                $Alert.State                           | Should Not Be $null
                $Alert.Title                           | Should Not Be $null

            }

            function AssertAlertsAreSame {
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

                    # Alert
                    $Found.AlertId                         | Should Be $Expected.AlertId

                    if ($Expected.AlertProperties -eq $null) {
                        $Found.AlertProperties             | Should Be $null
                    }
                    else {
                        $Found.AlertProperties             | Should Not Be $null
                        $Found.AlertProperties.Count       | Should Be $Expected.AlertProperties.Count
                    }

                    $Found.ClosedByUserAlias               | Should Be $Expected.ClosedByUserAlias
                    $Found.ClosedTimestamp                 | Should Be $Expected.ClosedTimestamp
                    $Found.CreatedTimestamp                | Should Be $Expected.CreatedTimestamp

                    if ($Expected.Description -eq $null) {
                        $Found.Description                 | Should Be $null
                    }
                    else {
                        $Found.Description                 | Should Not Be $null
                        $Found.Description.Count           | Should Be $Expected.Description.Count
                    }

                    $Found.FaultId                         | Should Be $Expected.FaultId
                    $Found.FaultTypeId                     | Should Be $Expected.FaultTypeId
                    $Found.ImpactedResourceDisplayName     | Should Be $Expected.ImpactedResourceDisplayName
                    $Found.ImpactedResourceId              | Should Be $Expected.ImpactedResourceId
                    $Found.LastUpdatedTimestamp            | Should Be $Expected.LastUpdatedTimestamp

                    if ($Expected.Remediation -eq $null) {
                        $Found.Remediation                 | Should Be $null
                    }
                    else {
                        $Found.Remediation                 | Should Not Be $null
                        $Found.Remediation.Count           | Should Be $Expected.Remediation.Count
                    }

                    $Found.ResourceProviderRegistrationId  | Should Be $Expected.ResourceProviderRegistrationId
                    $Found.ResourceRegistrationId          | Should Be $Expected.ResourceRegistrationId
                    $Found.Severity                        | Should Be $Expected.Severity
                    $Found.State                           | Should Be $Expected.State
                    $Found.Title                           | Should Be $Expected.Title

                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListAlerts" -Skip:$('TestListAlerts' -in $global:SkippedTests) {
            $global:TestName = 'TestListAlerts'

            $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($Alert in $Alerts) {
                ValidateAlert -Alert $Alert
            }
        }

        it "TestGetAlert" -Skip:$('TestGetAlert' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAlert'
            $Regions = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($Region in $Regions) {
                $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $Region.Name
                foreach ($Alert in $Alerts) {
                    $retrieved = Get-AzsAlert -Location $Location -Name $Alert.Name
                    AssertAlertsAreSame -Expected $Alert -Found $retrieved
                    return
                }
            }
        }

        it "TestGetAllAlerts" -Skip:$('TestGetAllAlerts' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllAlerts'


            $Regions = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($Region in $Regions) {
                $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $Region.Name
                foreach ($Alert in $Alerts) {
                    $retrieved = Get-AzsAlert -Location $Location -Name $Alert.Name
                    AssertAlertsAreSame -Expected $Alert -Found $retrieved
                }
            }
        }

        it "TestGetAllAlerts" -Skip:$('TestGetAllAlerts' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllAlerts'


            $Regions = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($Region in $Regions) {
                $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $Region.Name
                foreach ($Alert in $Alerts) {
                    $retrieved = $Alert | Get-AzsAlert
                    AssertAlertsAreSame -Expected $Alert -Found $retrieved
                }
            }
        }

        it "TestCloseAlert" -Skip:$('TestCloseAlert' -in $global:SkippedTests) {
            $global:TestName = 'TestCloseAlert'

            $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $global:location
            $Alerts | Should Not Be $null
            foreach ($Alert in $Alerts) {

                $Alert | Should not be $null
                $Alert.State | Should not be $null

                if ($Alert.State -eq "Active") {
                    $Alert | Close-AzsAlert -Force
                    return
                }
            }
        }
    }
}
