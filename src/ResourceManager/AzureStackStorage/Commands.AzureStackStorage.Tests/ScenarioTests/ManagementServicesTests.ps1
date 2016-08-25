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
Tests getting a single farm for a resource group with admin subscription id.
#>
function Test-GetManagementService
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $actual = Get-ACSManagementService -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName

        # Assert TODO add more asserts for detail payload check
	}
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests listing farms in a resource group with admin subscription id.
#>
function Test-SetManagementService
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'	
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $actual = Set-ACSManagementService -FarmName $farmName `
		-SubscriptionId $subscriptionId -ResourceGroupName $rgname -SkipCertificateValidation `
		-WacContainerGcFullScanIntervalInSeconds 3600 `
		-WacAccountGcFullScanIntervalInSeconds 3600 `		
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}