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
Positive test. Get an existing databox job.
#>
function Test-GetExistingDataBoxJob
{	
    $dfname = "OrderTest7"
    $rgname = "IrfansRG"
    $result = Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname
    # Test
    Assert-AreEqual $dfname $result.JobResource.Name
}

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
    Assert-ThrowsContains { Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname } "not found"    
}

function Create-Job {
	$dfname = $args[0]
	$rgname = $args[1]
	$a = New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountResourceId "/subscriptions/05b5dd1c-793d-41de-be9f-6f9ed142f695/resourceGroups/smoketest/providers/Microsoft.Storage/storageAccounts/wuspodsmoketest"  -DataBoxType DataBox -ResourceGroupName $rgname -Name $dfname -ErrorAction Ignore
	return $a
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
    
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
       # $actual = New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountResourceId "/subscriptions/05b5dd1c-793d-41de-be9f-6f9ed142f695/resourceGroups/smoketest/providers/Microsoft.Storage/storageAccounts/wuspodsmoketest"  -DataBoxType DataBox -ResourceGroupName $rgname -Name $dfname -ErrorAction Ignore
        $actual = Create-Job $dfname $rgname
		$expected = Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.Id $actual.Id
    }
    finally
    {
        Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 
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
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Create-Job $dfname $rgname
        Assert-ThrowsContains {New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountResourceId "/subscriptions/05b5dd1c-793d-41de-be9f-6f9ed142f695/resourceGroups/smoketest/providers/Microsoft.Storage/storageAccounts/wuspodsmoketest"  -DataBoxType DataBox -ResourceGroupName $rgname -Name $dfname 
		} "order already exists with the same name"
    }
    finally
    {
        Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 
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
    
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Create-Job $dfname $rgname
		Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
        $expected = Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.JobResource.Status "Cancelled"
    }
    finally
    {

		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 
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
    
    
    #New-AzResourceGroup -Name $rgname -Location $rglocation -Force
	$rgname = "IrfansRG"

    try
    {
        Create-Job $dfname $rgname
		Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 

        Assert-ThrowsContains { Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname } "Could not find" 
    }
	finally
	{
	}
}

<#
.SYNOPSIS
Test Removing an already removed Databox Job. Creates a new job, cancels it and then removes it. Then again tries to remove the job and check for the 
exception 
#>
function Test-RemoveAlreadyRemovedDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = Get-ProviderLocation ResourceManagement
    
    
    #New-AzResourceGroup -Name $rgname -Location $rglocation -Force
	$rgname = "IrfansRG"

    try
    {
        Create-Job $dfname $rgname
		Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 

        Assert-ThrowsContains { Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname  } "Could not find" 
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
    
	Assert-ThrowsContains {New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST11' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountResourceId "/subscriptions/05b5dd1c-793d-41de-be9f-6f9ed142f695/resourceGroups/smoketest/providers/Microsoft.Storage/storageAccounts/wuspodsmoketest"  -DataBoxType DataBox -ResourceGroupName "IrfansRG" -Name "Test" 
    } "ambiguous"
 
}

<#
.SYNOPSIS
Ambiguous Shipping Address when passed to the cmdlet to create a Job Resource Object must give an error
#>
function Test-JobResourceObjectInvalidAddress
{
    
	Assert-ThrowsContains {New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 'blah blah' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 't-irali@microsoft.com' -PhoneNumber 1234567891 -ContactName 'Irfan' -StorageAccountResourceId "/subscriptions/05b5dd1c-793d-41de-be9f-6f9ed142f695/resourceGroups/smoketest/providers/Microsoft.Storage/storageAccounts/wuspodsmoketest"  -DataBoxType DataBox -ResourceGroupName "IrfansRG" -Name "Test" 
	} "not Valid"
 
}