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
Nagative test. Get resources from an non-existing empty group.
#>
function Test-GetNonExistingDataBoxJob
{	
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force
    
    # Test
    Assert-ThrowsContains { Get-AzDataBoxJobs -ResourceGroupName $rgname -Name $dfname } "not found"    
}

<#
.SYNOPSIS
Creates a job resource object to use in tests
#>
function Create-JobResourceObject
{
    $resource = New-AzDataBoxJobResourceObject -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailIds 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountProviderType Microsoft.Storage -StorageAccountResourceGroupName smoketest -StorageAccountName wuspodsmoketest -DataBoxType DataBox
    
    return $resource
}

<#
.SYNOPSIS
Create a databox job and then do a Get to compare the result are identical.
The databox job will be cancelled and removed when the test finishes.
#>
function Test-CreateDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = Get-ProviderLocation ResourceManagement
    $jobResource = Create-JobResourceObject
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = New-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -JobResource $jobResource
        $expected = Get-AzDataBoxJobs -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.Id $actual.Id
    }
    finally
    {
        Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
    }
}

<#
.SYNOPSIS
Create an already existing databox job and check for the exception.
Creates a new job. Again tries to create it and gets an exception.
Finally removes the job.
#>
function Test-CreateAlreadyExistingDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = Get-ProviderLocation ResourceManagement
    $jobResource = Create-JobResourceObject
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -JobResource $jobResource
        Assert-ThrowsContains {New-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -JobResource $jobResource} "order already exists with the same name"
    }
    finally
    {
        Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
    }
}

<#
.SYNOPSIS
Test Cancelling a Databox Job. Creates a new job and then cancels it. Then get the job and check the 
status of the fetched job.
#>
function Test-StopDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = Get-ProviderLocation ResourceManagement
    $jobResource = Create-JobResourceObject
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -JobResource $jobResource
		Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
        $expected = Get-AzDataBoxJobs -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.Status "Cancelled"
    }
    finally
    {

		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
    }
}

<#
.SYNOPSIS
Test Removing a Databox Job. Creates a new job, cancels it and then removes it. Then get the job and check for the 
exception to contain "not found"
#>
function Test-RemoveDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = Get-ProviderLocation ResourceManagement
    $jobResource = Create-JobResourceObject
    
    #New-AzResourceGroup -Name $rgname -Location $rglocation -Force
	$rgname = "IrfansRG"

    try
    {
        New-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -JobResource $jobResource
		Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"

        Assert-Throws { Get-AzDataBoxJobs -ResourceGroupName $rgname -Name $dfname } "not found" 
    }
	finally
	{
	}
}

<#
.SYNOPSIS
Ambiguous Shipping Address when passed to the cmdlet to create a Job Resource Object must give an error
#>
function Test-JobResourceObjectAmbiguousAddress
{
    
	Assert-ThrowsContains {New-AzDataBoxJobResourceObject -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST11' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailIds 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountProviderType Microsoft.Storage -StorageAccountResourceGroupName smoketest -StorageAccountName wuspodsmoketest -DataBoxType DataBox
    } "ambiguous"
 
}

<#
.SYNOPSIS
Ambiguous Shipping Address when passed to the cmdlet to create a Job Resource Object must give an error
#>
function Test-JobResourceObjectInvalidAddress
{
    
	Assert-ThrowsContains {New-AzDataBoxJobResourceObject -Location 'WestUS' -StreetAddress1 'Blah Blah' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailIds 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountProviderType Microsoft.Storage -StorageAccountResourceGroupName smoketest -StorageAccountName wuspodsmoketest -DataBoxType DataBox
    } "not Valid"
 
}