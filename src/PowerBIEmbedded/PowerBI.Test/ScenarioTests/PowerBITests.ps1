<#
.SYNOPSIS
Tests PowerBI Embedded Capacity lifecycle (Create, Update, Get, List, Delete).
#>
function Test-PowerBIEmbeddedCapacity
{
	try
	{  
		# Creating capacity
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName

		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		$capacityCreated = New-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrator 'aztest0@stabletest.ccsctp.net','aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $capacityName $capacityCreated.Name
		Assert-AreEqual $location $capacityCreated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityCreated.Type
		Assert-AreEqual 2 $capacityCreated.Administrator.Count
		Assert-True {$capacityCreated.Id -like "*$resourceGroupName*"}
	
		[array]$capacityGet = Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		$capacityGetItem = $capacityGet[0]

		Assert-True {$capacityGetItem.State -like "Succeeded"}
		Assert-AreEqual $capacityName $capacityGetItem.Name
		Assert-AreEqual $location $capacityGetItem.Location
		Assert-AreEqual $resourceGroupName $capacityGetItem.ResourceGroup
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityGetItem.Type
		Assert-True {$capacityGetItem.Id -like "*$resourceGroupName*"}

		# Test to make sure the capacity does exist
		Assert-True {Test-AzPowerBIEmbeddedCapacity -Name $capacityName}
		# Test it without specifying a resource group
		Assert-True {Test-AzPowerBIEmbeddedCapacity -Name $capacityName}
		
		# Updating capacity
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$capacityUpdated = Update-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Tag $tagsToUpdate -PassThru
		Assert-NotNull $capacityUpdated.Tag "Tag do not exists"
		Assert-NotNull $capacityUpdated.Tag["TestTag"] "The updated tag 'TestTag' does not exist"
		Assert-AreEqual $capacityUpdated.Administrator.Count 2

		$capacityUpdated = Update-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Administrator 'aztest1@stabletest.ccsctp.net' -PassThru
		Assert-NotNull $capacityUpdated.Administrator "Capacity Administrator list is empty"
		Assert-AreEqual $capacityUpdated.Administrator.Count 1

		Assert-AreEqual $capacityName $capacityUpdated.Name
		Assert-AreEqual $location $capacityUpdated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityUpdated.Type
		Assert-True {$capacityUpdated.Id -like "*$resourceGroupName*"}

		# List all capacitys in resource group
		[array]$capacitysInResourceGroup = Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName
		Assert-True {$capacitysInResourceGroup.Count -ge 1}

		$found = 0
		for ($i = 0; $i -lt $capacitysInResourceGroup.Count; $i++)
		{
			if ($capacitysInResourceGroup[$i].Name -eq $capacityName)
			{
				$found = 1
				Assert-AreEqual $location $capacitysInResourceGroup[$i].Location
				Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacitysInResourceGroup[$i].Type
				Assert-True {$capacitysInResourceGroup[$i].Id -like "*$resourceGroupName*"}

				break
			}
		}
		Assert-True {$found -eq 1} "capacity created earlier is not found when listing all in resource group: $resourceGroupName."

		# List all PowerBI Embedded Capacities in subscription
		[array]$capacitysInSubscription = Get-AzPowerBIEmbeddedCapacity
		Assert-True {$capacitysInSubscription.Count -ge 1}
		Assert-True {$capacitysInSubscription.Count -ge $capacitysInResourceGroup.Count}
    
		$found = 0
		for ($i = 0; $i -lt $capacitysInSubscription.Count; $i++)
		{
			if ($capacitysInSubscription[$i].Name -eq $capacityName)
			{
				$found = 1
				Assert-AreEqual $location $capacitysInSubscription[$i].Location
				Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacitysInSubscription[$i].Type
				Assert-True {$capacitysInSubscription[$i].Id -like "*$resourceGroupName*"}
    
				break
			}
		}
		Assert-True {$found -eq 1} "Account created earlier is not found when listing all in subscription."

		# Suspend PowerBI Embedded capacity
		$capacityGetItem = Suspend-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru
		# this is to ensure backward compatibility compatibility. The servie side would make change to differenciate state and provisioningState in future
		Assert-True {$capacityGetItem.State -like "Paused"}
		Assert-AreEqual $resourceGroupName $capacityGetItem.ResourceGroup

		# Resume PowerBI Embedded capacity
		$capacityGetItem = Resume-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru
		[array]$capacityGet = Get-AzPowerBIEmbeddedCapacity -ResourceId $capacityGetItem.Id
		$capacityGetItem = $capacityGet[0]
		Assert-AreEqual $capacityGetItem.Name $capacityGetItem.Name
		Assert-True {$capacityGetItem.State -like "Succeeded"}
		
		# Delete PowerBI Embedded capacity
		Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName | Remove-AzPowerBIEmbeddedCapacity -PassThru

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests scale up and down of PowerBI Embedded Capacity (A1 -> A2 -> A1).
#>
function Test-PowerBIEmbeddedCapacityScale
{
	try
	{  
		# Creating capacity
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName

		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		$capacityCreated = New-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrator 'aztest0@stabletest.ccsctp.net','aztest1@stabletest.ccsctp.net'
		Assert-AreEqual $capacityName $capacityCreated.Name
		Assert-AreEqual $location $capacityCreated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityCreated.Type
		Assert-AreEqual A1 $capacityCreated.Sku
		Assert-True {$capacityCreated.Id -like "*$resourceGroupName*"}
	
		# Check capacity was created successfully
		[array]$capacityGet = Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		$capacityGetItem = $capacityGet[0]

		Assert-True {$capacityGetItem.State -like "Succeeded"}
		Assert-AreEqual $capacityName $capacityGetItem.Name
		Assert-AreEqual $location $capacityGetItem.Location
		Assert-AreEqual A1 $capacityGetItem.Sku
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityGetItem.Type
		Assert-True {$capacityGetItem.Id -like "*$resourceGroupName*"}
		
		# Scale up A1 -> A2
		$capacityUpdated = Update-AzPowerBIEmbeddedCapacity -Name $capacityName -Sku A2 -PassThru
		Assert-AreEqual A2 $capacityUpdated.Sku

		$capacityGetItem = Suspend-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru
		# this is to ensure backward compatibility compatibility. The servie side would make change to differenciate state and provisioningState in future
		Assert-True {$capacityGetItem.State -like "Paused"}

		# Scale down A2 -> A1
		$capacityUpdated = Update-AzPowerBIEmbeddedCapacity -Name $capacityName -Sku A1 -PassThru
		Assert-AreEqual A1 $capacityUpdated.Sku
		
		# Delete PowerBI Embedded capacity
		Remove-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests PowerBI Embedded Capacity lifecycle  Failure scenarios (Create, Update, Get, Delete).
#>
function Test-NegativePowerBIEmbeddedCapacity
{
    param
	(
		$fakecapacityName = "psfakecapacitytest",
		$invalidSku = "INVALID"
	)
	
	try
	{
		# Creating Account
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName
		
		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		$capacityCreated = New-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrator 'aztest0@stabletest.ccsctp.net','aztest1@stabletest.ccsctp.net'

		Assert-AreEqual $capacityName $capacityCreated.Name
		Assert-AreEqual $location $capacityCreated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityCreated.Type
		Assert-True {$capacityCreated.Id -like "*$resourceGroupName*"}

		# attempt to recreate the already created capacity
		Assert-Throws {New-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location}

		# attempt to update a non-existent capacity
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Update-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $fakecapacityName -Tag $tagsToUpdate}

		# attempt to get a non-existent capacity
		Assert-Throws {Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $fakecapacityName}

		# attempt to create a capacity with invalid Sku
		Assert-Throws {New-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $fakecapacityName -Location $location -Sku $invalidSku -Administrator 'aztest0@stabletest.ccsctp.net','aztest1@stabletest.ccsctp.net'}

		# attempt to scale a capacity to invalid Sku
		Assert-Throws {Update-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Sku $invalidSku}

		# Delete PowerBI Embedded capacity
		Remove-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru

		# Delete PowerBI Embedded capacity again should throw.
		Assert-Throws {Remove-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests PowerBI Embedded Capacity lifecycle for large skus (A7,A8) (Create, Update, Scale, Get, Delete).
#>
function Test-PowerBIEmbeddedCapacityLargeSku
{
	try
	{  
		# Creating capacity
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName

		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		$capacityCreated = New-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A7' -Administrator 'aztest0@stabletest.ccsctp.net','aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $capacityName $capacityCreated.Name
		Assert-AreEqual $location $capacityCreated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityCreated.Type
		Assert-AreEqual 2 $capacityCreated.Administrator.Count
		Assert-True {$capacityCreated.Id -like "*$resourceGroupName*"}
	
		[array]$capacityGet = Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		$capacityGetItem = $capacityGet[0]
		Assert-True {$capacityGetItem.State -like "Succeeded"}

		# Test to make sure the capacity does exist
		Assert-True {Test-AzPowerBIEmbeddedCapacity -Name $capacityName}
		# Test it without specifying a resource group
		Assert-True {Test-AzPowerBIEmbeddedCapacity -Name $capacityName}
		
		# Updating capacity and Scale up A7 -> A8
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$capacityUpdated = Update-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Tag $tagsToUpdate -Sku 'A8' -Administrator 'aztest1@stabletest.ccsctp.net' -PassThru
		Assert-NotNull $capacityUpdated.Tag "Tag do not exists"
		Assert-NotNull $capacityUpdated.Tag["TestTag"] "The updated tag 'TestTag' does not exist"
		Assert-AreEqual $capacityUpdated.Administrator.Count 1
		Assert-AreEqual A8 $capacityUpdated.Sku
		Assert-NotNull $capacityUpdated.Administrator "Capacity Administrator list is empty"

		# Suspend PowerBI Embedded capacity
		$capacityGetItem = Suspend-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru
		[array]$capacityGet = Get-AzPowerBIEmbeddedCapacity -ResourceId $capacityGetItem.Id
		$capacityGetItem = $capacityGet[0]
		Assert-AreEqual $capacityGetItem.Name $capacityGetItem.Name
		Assert-True {$capacityGetItem.State -like "Paused"}

		# Resume PowerBI Embedded capacity
		$capacityGetItem = Resume-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru
		[array]$capacityGet = Get-AzPowerBIEmbeddedCapacity -ResourceId $capacityGetItem.Id
		$capacityGetItem = $capacityGet[0]
		Assert-AreEqual $capacityGetItem.Name $capacityGetItem.Name
		Assert-True {$capacityGetItem.State -like "Succeeded"}
		
		# Delete PowerBI Embedded capacity
		Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName | Remove-AzPowerBIEmbeddedCapacity -PassThru

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}
