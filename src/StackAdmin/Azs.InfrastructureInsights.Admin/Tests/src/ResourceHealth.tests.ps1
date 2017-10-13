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
    C:\PS> .\src\ResourceHealth.Tests.ps1
	Describing ResourceHealths
	[+] TestListResourceHealths 1.2s
	[+] TestGetResourceHealth 94ms
	[+] TestGetAllResourceHealths 116ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
	[bool]$RunRaw = $false
)

$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.InfrastructureInsights.Admin {

	Describe "ResourceHealths" -Tags @('ResourceHealth', 'InfrastructureInsightsAdmin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateResourceHealth {
				param(
					[Parameter(Mandatory=$true)]
					$ResourceHealth
				)
			
				$ResourceHealth          | Should Not Be $null

				# Resource
				$ResourceHealth.Id       | Should Not Be $null
				$ResourceHealth.Location | Should Not Be $null
				$ResourceHealth.Name     | Should Not Be $null
				$ResourceHealth.Type     | Should Not Be $null

				# Scale Unit Node
				$ResourceHealth.AlertSummary    	| Should Not Be $null
				$ResourceHealth.HealthState     	| Should Not Be $null
				# Sometimes this can be null??
				#$ResourceHealth.Namespace  			| Should Not Be $null
				$ResourceHealth.RegistrationId  	| Should Not Be $null
				$ResourceHealth.ResourceDisplayName	| Should Not Be $null
				$ResourceHealth.ResourceLocation	| Should Not Be $null
				$ResourceHealth.ResourceName		| Should Not Be $null
				$ResourceHealth.ResourceType		| Should Not Be $null
				$ResourceHealth.ResourceURI			| Should Not Be $null
				$ResourceHealth.RoutePrefix			| Should Not Be $null
				$ResourceHealth.RpRegistrationId	| Should Not Be $null
			}

			function AssertResourceHealthsAreSame {
				param(
					[Parameter(Mandatory=$true)]
					$Expected,
        
					[Parameter(Mandatory=$true)]
					$Found
				)
				if($Expected -eq $null) {
					$Found | Should Be $null
				} else {
					$Found                  | Should Not Be $null

					# Resource
					$Found.Id               | Should Be $Expected.Id
					$Found.Location         | Should Be $Expected.Location
					$Found.Name             | Should Be $Expected.Name
					$Found.Type             | Should Be $Expected.Type

					# Resource Health
					if($Expected.AlertSummary -eq $null) {
						$Found.AlertSummary | Should be $null
					} else {
						$Found.AlertSummary                     | Should Not Be $null
						$Found.AlertSummary.CriticalAlertCount  | Should Not Be $Expected.AlertSummary.CriticalAlertCount
						$Found.AlertSummary.WarningAlertCount  	| Should Not Be $Expected.AlertSummary.WarningAlertCount
					}
					
					$Found.HealthState      	| Should Be $Expected.HealthState
					$Found.Namespace      		| Should Be $Expected.Namespace
					$Found.RegistrationId       | Should Be $Expected.RegistrationId
					$Found.ResourceDisplayName  | Should Be $Expected.ResourceDisplayName
					$Found.ResourceLocation   	| Should Be $Expected.ResourceLocation
					$Found.ResourceName      	| Should Be $Expected.ResourceName
					$Found.ResourceType  		| Should Be $Expected.ResourceType
					$Found.ResourceURI  		| Should Be $Expected.ResourceURI
					$Found.RoutePrefix  		| Should Be $Expected.RoutePrefix
					$Found.RpRegistrationId  	| Should Be $Expected.RpRegistrationId
				}
			}
		}
	
		
		It "TestListResourceHealths" {
			$global:TestName = 'TestListResourceHealths'
			$ServiceHealths = Get-AzsServiceHealth -Location $Location
			foreach($serviceHealth in $ServiceHealths) {
				$ResourceHealths = Get-AzsResourceHealth -Location $Location -ServiceRegistrationId $serviceHealth.RegistrationId
				foreach($ResourceHealth in $ResourceHealths) {
					ValidateResourceHealth -ResourceHealth $ResourceHealth
				}
			}
	    }
	
	
		It "TestGetResourceHealth" {
            $global:TestName = 'TestGetResourceHealth'

			$ServiceHealths = Get-AzsServiceHealth -Location $Location
			foreach($serviceHealth in $ServiceHealths) {
				$ResourceHealths = Get-AzsResourceHealth -Location $Location -ServiceRegistrationId $serviceHealth.RegistrationId
				foreach($ResourceHealth in $ResourceHealths) {
					$retrieved = Get-AzsResourceHealth -Location $Location -ServiceRegistrationId $serviceHealth.RegistrationId -ResourceRegistrationId $ResourceHealth.RegistrationId
					AssertResourceHealthsAreSame -Expected $ResourceHealth -Found $retrieved
					break
				}
				break
			}
		}

		It "TestGetAllResourceHealths" {
			$global:TestName = 'TestGetAllResourceHealths'

			$ServiceHealths = Get-AzsServiceHealth -Location $Location
			foreach($serviceHealth in $ServiceHealths) {
				$ResourceHealths = Get-AzsResourceHealth -Location $Location -ServiceRegistrationId $serviceHealth.RegistrationId
				foreach($ResourceHealth in $ResourceHealths) {
					$retrieved = Get-AzsResourceHealth -Location $Location -ServiceRegistrationId $serviceHealth.RegistrationId -ResourceRegistrationId $ResourceHealth.RegistrationId
					AssertResourceHealthsAreSame -Expected $ResourceHealth -Found $retrieved
					break
				}
				break
			}
		}
    }
}