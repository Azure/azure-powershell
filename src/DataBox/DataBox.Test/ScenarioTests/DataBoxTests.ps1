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
    Assert-ThrowsContains { Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname } "not found"    
}

<#
.SYNOPSIS
Nagative test. Get the credentials of a newly created job. Newly created job doesnot have its credentials generated. 
NOTE : Use a subscription id having West US location to run the test successfully.
#>
function Test-GetCredentialForNewlyCreatedJob
{	
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = 'WestUS'
    
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

	$storageaccountname = Get-StorageAccountName
	$storageaccount = New-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname  -Location $rglocation 

    try
    {
        $a = Create-Job $dfname $rgname $storageaccount.Id
		
		Assert-ThrowsContains {Get-AzDataBoxCredential -ResourceId $a.Id} "Secrets are not yet generated"

    }
    finally
    {
        Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 
		Remove-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname 
    }    
}

<#
The location is hard coded because the cmdlet needs an address. Without hard coding the location and the 
address, the cmdlet cannot be run and hence cannot be tested.
NOTE : Use a subscription id having West US location to run the test successfully.
#>
function Create-Job {
	$dfname = $args[0]
	$rgname = $args[1]
	$storagergid = $args[2]
	$a = New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 'abc@outlook.com' -PhoneNumber 1234567891 -ContactName 'Random' -StorageAccountResourceId $storagergid  -DataBoxType DataBox -ResourceGroupName $rgname -Name $dfname -ErrorAction Ignore
	return $a
}
<#
.SYNOPSIS
Create a databox job and then do a Get to compare the result are identical.
The databox job will be cancelled and removed when the test finishes.
NOTE : Use a subscription id having West US location to run the test successfully.
#>
function Test-CreateDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = 'WestUS'
    
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

	$storageaccountname = Get-StorageAccountName
	$storageaccount = New-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname  -Location $rglocation 

    try
    {
        $actual = Create-Job $dfname $rgname $storageaccount.Id
		$expected = Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.Id $actual.Id
    }
    finally
    {
        Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 
		Remove-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname 
    }
}

<#
.SYNOPSIS
Create an already existing databox job and check for the exception.
Creates a new job. Again tries to create it and gets an exception.
Finally removes the job.
NOTE : Use a subscription id having West US location to run the test successfully.
#>
function Test-CreateAlreadyExistingDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = 'WestUS'
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

	$storageaccountname = Get-StorageAccountName
	$storageaccount = New-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname -Location $rglocation 

    try
    {
        Create-Job $dfname $rgname $storageaccount.Id
        Assert-ThrowsContains {New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 'abc@outlook.com' -PhoneNumber 1234567891 -ContactName 'Random' -StorageAccountResourceId $storageaccount.Id  -DataBoxType DataBox -ResourceGroupName $rgname -Name $dfname 
		} "order already exists with the same name"
    }
    finally
    {
        Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 
		Remove-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname 
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
	
	$storageaccountname = Get-StorageAccountName
	$storageaccount = New-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname -Location $rglocation 

    try
    {
        Create-Job $dfname $rgname $storageaccount.Id
		Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
        $expected = Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.JobResource.Status "Cancelled"
    }
    finally
    {

		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 
		Remove-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname 

    }
}

<#
.SYNOPSIS
Test Removing a Databox Job. Creates a new job, cancels it and then removes it. Then get the job and check for the 
exception to contain "Could not find"
#>
function Test-RemoveDataBoxJob
{
    $dfname = Get-DataBoxJobName
    $rgname = Get-ResourceGroupName
	$rglocation = Get-ProviderLocation ResourceManagement
    
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force
	
	$storageaccountname = Get-StorageAccountName
	$storageaccount = New-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname -Location $rglocation

    try
    {
        Create-Job $dfname $rgname $storageaccount.Id
		Stop-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname -Reason "Random"
		Remove-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname 

        Assert-ThrowsContains { Get-AzDataBoxJob -ResourceGroupName $rgname -Name $dfname } "Could not find" 
    }
	finally
	{
		Remove-AzStorageAccount -ResourceGroupName $rgname -Name $storageaccountname 
	}
}


<#
.SYNOPSIS
Ambiguous Shipping Address when passed to the cmdlet to create a Job Resource Object must give an error.
The Location and Address is hard coded because the cmdlet requires an ambiguous address to run the test.
#>
function Test-JobResourceObjectAmbiguousAddress
{
    
	Assert-ThrowsContains {New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 '16 TOWNSEND ST11' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 'abc@outlook.com' -PhoneNumber 1234567891 -ContactName 'Random' -StorageAccountResourceId "random"  -DataBoxType DataBox -ResourceGroupName "Random" -Name "Random" 
    } "ambiguous"
 
}

<#
.SYNOPSIS
Ambiguous Shipping Address when passed to the cmdlet to create a Job Resource Object must give an error.
The Location and Address is hard coded because the cmdlet requires an invalid address to run the test.
#>
function Test-JobResourceObjectInvalidAddress
{
    
	Assert-ThrowsContains {New-AzDataBoxJob -Location 'WestUS' -StreetAddress1 'blah blah' -PostalCode 94107 -City 'San Francisco' -StateOrProvinceCode 'CA' -CountryCode 'US' -EmailId 'abc@outlook.com' -PhoneNumber 1234567891 -ContactName 'Random' -StorageAccountResourceId "Random"  -DataBoxType DataBox -ResourceGroupName "Random" -Name "Random" 
	} "not Valid"
 
}