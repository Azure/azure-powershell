﻿# ----------------------------------------------------------------------------------
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
    Run AzureStack fabric admin logical subnet tests.

.DESCRIPTION
    Run AzureStack fabric admin logical subnet tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    C:\PS> .\src\LogicalSubnet.Tests.ps1
	Describing LogicalSubnets
	  [+] TestListLogicalSubnets 1.55s
	  [+] TestGetLogicalSubnet 286ms
	  [+] TestGetAllLogicalSubnets 429ms

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

$global:TestName = ""

InModuleScope Azs.Fabric.Admin {

	Describe "LogicalSubnets" -Tags @('LogicalSubnet', 'Azs.Fabric.Admin') {

		BeforeEach  {
			
			. $PSScriptRoot\Common.ps1

			function ValidateLogicalSubnet {
				param(
					[Parameter(Mandatory=$true)]
					$LogicalSubnet
				)
			
				$LogicalSubnet          | Should Not Be $null

				# Resource
				$LogicalSubnet.Id       | Should Not Be $null
				$LogicalSubnet.Location | Should Not Be $null
				$LogicalSubnet.Name     | Should Not Be $null
				$LogicalSubnet.Type     | Should Not Be $null

				# Logical Network
				<#
				$LogicalSubnet.Metadata  | Should Not Be $null
				#>
				$LogicalSubnet.IpPools   | Should Not Be $null
				$LogicalSubnet.IsPublic  | Should Not Be $null
			}

			function AssertLogicalSubnetsAreSame {
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
					
					# Logical Network
					if($Expected -eq $null) {
						$Found.IpPools | Should be $null
					} else {
						$Found.IpPools.Count   | Should Be $Expected.IpPools.Count
					}
					$Found.IsPublic  | Should Be $Expected.IsPublic

					if($Expected.Metadata -eq $null) {
						$Found.Metadata        | Should Be $null
					} else {
						$Found.Metadata        | Should Not Be $null
						$Found.Metadata.Count  | Should Be $Expected.Metadata.Count
					}
				}
			}
		}
	
		
		It "TestListLogicalSubnets" {
			$global:TestName = 'TestListLogicalSubnets'
			
			$logicalNetworks = Get-AzsLogicalNetwork -Location $Location
			foreach($logicalNetwork in $logicalNetworks) {
				$logicalSubnets = Get-AzsLogicalSubnet -Location $Location -LogicalNetwork $logicalNetwork.Name
				foreach($logicalSubnet in $logicalSubnets) {
					ValidateLogicalSubnet $logicalSubnet
				}
				break
			}
	    }
	
	
		It "TestGetLogicalSubnet" {
            $global:TestName = 'TestGetLogicalSubnet'

			$logicalNetworks = Get-AzsLogicalNetwork -Location $Location
			foreach($logicalNetwork in $logicalNetworks) {
				$logicalSubnets = Get-AzsLogicalSubnet -Location $Location -LogicalNetwork $logicalNetwork.Name
				foreach($logicalSubnet in $logicalSubnets) {
					$retrieved = Get-AzsLogicalSubnet -Location $Location -LogicalNetwork $logicalNetwork.Name -LogicalSubnet $logicalSubnet.Name
					AssertLogicalSubnetsAreSame -Expected $logicalSubnet -Found $retrieved
					break
				}
				break
			}
		}

		It "TestGetAllLogicalSubnets" {
			$global:TestName = 'TestGetAllLogicalSubnets'
			
			$logicalNetworks = Get-AzsLogicalNetwork -Location $Location
			foreach($logicalNetwork in $logicalNetworks) {
				$logicalSubnets = Get-AzsLogicalSubnet -Location $Location -LogicalNetwork $logicalNetwork.Name
				foreach($logicalSubnet in $logicalSubnets) {
					$retrieved = Get-AzsLogicalSubnet -Location $Location -LogicalNetwork $logicalNetwork.Name -LogicalSubnet $logicalSubnet.Name
					AssertLogicalSubnetsAreSame -Expected $logicalSubnet -Found $retrieved
				}
			}
		}
    }
}