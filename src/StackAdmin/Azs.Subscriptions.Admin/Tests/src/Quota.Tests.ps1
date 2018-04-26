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
    Run AzureStack subscription admin tests.

.DESCRIPTION
    Run AzureStack subscriptions admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Quota.Tests.ps1
	Describing Quota
	  [+] TestListQuotas 2.03s

.NOTES
    Author: Mike Giesler
	Copyright: Microsoft
    Date:   March 16, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)
$Global:UseInstalled = $UseInstalled
$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions.Admin {

    Describe "Quota" -Tags @('Quotas', 'SubscriptionsAdmin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

            function ValidateQuota {
                param(
                    [Parameter(Mandatory = $true)]
                    $Quota
                )
                # Overall
                $Quota               | Should Not Be $null

                # Resource
                $Quota.Id            | Should Not Be $null
                $Quota.Name          | Should Not Be $null
                $Quota.Type          | Should Not Be $null
                $Quota.Location      | Should Not Be $null
            }
        }

        It "TestListQuotas" {
            $global:TestName = 'TestListQuotas'

            $allQuotas = Get-AzsSubscriptionsQuota -Location redmond
            $resourceGroups = New-Object  -TypeName System.Collections.Generic.HashSet[System.String]

            foreach($Quota in $allQuotas) {
				ValidateQuota $Quota
            }
        }
    }
}
