<#
.SYNOPSIS
Tests PowerBI Embedded Capacity lifecycle (Create, Update, Get, List, Delete).
#>
function Test-PowerBIEmbeddedCapacity
{
	try
	{  
		# Creating capacity
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$capacityCreated = New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $capacityName $capacityCreated.Name
		Assert-AreEqual $location $capacityCreated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityCreated.Type
		Assert-AreEqual 2 $capacityCreated.AsAdministrators.Count
		Assert-True {$capacityCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$capacityCreated.CapacityFullName -ne $null -and $capacityCreated.CapacityFullName.Contains("$capacityName")}
	
		[array]$capacityGet = Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		$capacityGetItem = $capacityGet[0]

		Assert-True {$capacityGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$capacityGetItem.State -like "Succeeded"}
		
		Assert-AreEqual $capacityName $capacityGetItem.Name
		Assert-AreEqual $location $capacityGetItem.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityGetItem.Type
		Assert-True {$capacityGetItem.Id -like "*$resourceGroupName*"}

		# Test to make sure the capacity does exist
		Assert-True {Test-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName}
		# Test it without specifying a resource group
		Assert-True {Test-AzureRmPowerBIEmbeddedCapacity -Name $capacityName}
		
		# Updating capacity
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$capacityUpdated = Set-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Tag $tagsToUpdate -PassThru
		Assert-NotNull $capacityUpdated.Tag "Tag do not exists"
		Assert-NotNull $capacityUpdated.Tag["TestTag"] "The updated tag 'TestTag' does not exist"
		Assert-AreEqual $capacityUpdated.AsAdministrators.Count 2

		$capacityUpdated = Set-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Administrator 'aztest1@stabletest.ccsctp.net' -PassThru
		Assert-NotNull $capacityUpdated.AsAdministrators "Capacity Administrator list is empty"
		Assert-AreEqual $capacityUpdated.AsAdministrators.Count 1

		Assert-AreEqual $capacityName $capacityUpdated.Name
		Assert-AreEqual $location $capacityUpdated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityUpdated.Type
		Assert-True {$capacityUpdated.Id -like "*$resourceGroupName*"}

		# List all capacitys in resource group
		[array]$capacitysInResourceGroup = Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName
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
		[array]$capacitysInSubscription = Get-AzureRmPowerBIEmbeddedCapacity
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
		Suspend-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		[array]$capacityGet = Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		$capacityGetItem = $capacityGet[0]
		# this is to ensure backward compatibility compatibility. The servie side would make change to differenciate state and provisioningState in future
		Assert-True {$capacityGetItem.State -like "Paused"}
		Assert-True {$capacityGetItem.ProvisioningState -like "Paused"}

		# Resume PowerBI Embedded capacity
		Resume-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		[array]$capacityGet = Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		$capacityGetItem = $capacityGet[0]
		Assert-True {$capacityGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$capacityGetItem.State -like "Succeeded"}
		
		# Delete PowerBI Embedded capacity
		Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests scale up and down of PowerBI Embedded Capacity (A1 -> A6 -> A1).
#>
function Test-PowerBIEmbeddedCapacityScaleUpDown
{
	try
	{  
		# Creating capacity
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$capacityCreated = New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'B1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
		Assert-AreEqual $capacityName $capacityCreated.Name
		Assert-AreEqual $location $capacityCreated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityCreated.Type
		Assert-AreEqual B1 $capacityCreated.Sku.Name
		Assert-True {$capacityCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$capacityCreated.CapacityFullName -ne $null -and $capacityCreated.CapacityFullName.Contains("$capacityName")}
	
		# Check capacity was created successfully
		[array]$capacityGet = Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName
		$capacityGetItem = $capacityGet[0]

		Assert-True {$capacityGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$capacityGetItem.State -like "Succeeded"}
		
		Assert-AreEqual $capacityName $capacityGetItem.Name
		Assert-AreEqual $location $capacityGetItem.Location
		Assert-AreEqual B1 $capacityGetItem.Sku.Name
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityGetItem.Type
		Assert-True {$capacityGetItem.Id -like "*$resourceGroupName*"}
		
		# Scale up B1 -> S2
		$capacityUpdated = Set-AzureRmPowerBIEmbeddedCapacity -Name $capacityName -Sku S2 -PassThru
		Assert-AreEqual S2 $capacityUpdated.Sku.Name

		# Scale down S2 -> A1
		$capacityUpdated = Set-AzureRmPowerBIEmbeddedCapacity -Name $capacityName -Sku A1 -PassThru
		Assert-AreEqual A1 $capacityUpdated.Sku.Name
		
		# Delete PowerBI Embedded capacity
		Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
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
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		$capacityCreated = New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'

		Assert-AreEqual $capacityName $capacityCreated.Name
		Assert-AreEqual $location $capacityCreated.Location
		Assert-AreEqual "Microsoft.PowerBIDedicated/capacities" $capacityCreated.Type
		Assert-True {$capacityCreated.Id -like "*$resourceGroupName*"}

		# attempt to recreate the already created capacity
		Assert-Throws {New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location}

		# attempt to update a non-existent capacity
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Set-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $fakecapacityName -Tag $tagsToUpdate}

		# attempt to get a non-existent capacity
		Assert-Throws {Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $fakecapacityName}

		# attempt to create a capacity with invalid Sku
		Assert-Throws {New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $fakecapacityName -Location $location -Sku $invalidSku -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'}

		# attempt to scale a capacity to invalid Sku
		Assert-Throws {Set-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Sku $invalidSku}

		# Delete PowerBI Embedded capacity
		Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru

		# Delete PowerBI Embedded capacity again should throw.
		Assert-Throws {Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Test log exporting from Azure PowerBI Embedded capacity.
In order to run this test successfully, Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaaswestusloop1.asazure-int.windows.net'
ASAZURE_TESTUSER_PWD e.x. value 'samplepwd'
#>
function Test-PowerBIEmbeddedCapacityLogExport
{
    param
	(
		$rolloutEnvironment = $env:ASAZURE_TEST_ROLLOUT
	)
    try
    {
        $location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$capacityCreated = New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrators $env:ASAZURE_TEST_ADMUSERS
		Assert-True {$capacityCreated.ProvisioningState -like "Succeeded"}
		Assert-True {$capacityCreated.State -like "Succeeded"}

		$secpasswd = ConvertTo-SecureString $env:ASAZURE_TESTUSER_PWD -AsPlainText -Force
		$admuser0 = $env:ASAZURE_TEST_ADMUSERS.Split(',')[0]
		$cred = New-Object System.Management.Automation.PSCredential ($admuser0, $secpasswd)
		$asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount -RolloutEnvironment $rolloutEnvironment -Credential $cred
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment must not return null"

        $tempFile = [System.IO.Path]::GetTempFileName()
        Export-AzurePowerBIEmbeddedCapacityInstanceLog -Instance $capacityName -OutputPath $tempFile
        Assert-Exists $tempFile
        $logContent = [System.IO.File]::ReadAllText($tempFile)
        Assert-False { [string]::IsNullOrEmpty($logContent); }
    }
    finally
    {
        if (Test-Path $tempFile) {
            Remove-Item $tempFile
        }
        Invoke-HandledCmdlet -Command {Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
    }
}

<#
.SYNOPSIS
Tests PowerBI Embedded Capacity Login and restart.
In order to run this test successfully, Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaasnightly1.pbidedicated-int.windows.net'
ASAZURE_TESTUSER_PWD e.x. value 'aztest0password'
ASAZURE_TEST_ADMUSERS e.x. value 'aztest0@asazure.ccsctp.net,aztest1@asazure.ccsctp.net'
#>
function Test-PowerBIEmbeddedCapacityRestart
{
    param
	(
		$rolloutEnvironment = $env:ASAZURE_TEST_ROLLOUT
	)
	try
	{
		# Creating capacity
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$capacityName = Get-PowerBIEmbeddedCapacityName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$capacityCreated = New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrator $env:ASAZURE_TEST_ADMUSERS
		Assert-True {$capacityCreated.ProvisioningState -like "Succeeded"}
		Assert-True {$capacityCreated.State -like "Succeeded"}

		$asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount -RolloutEnvironment $rolloutEnvironment
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment must not return null"

		$secpasswd = ConvertTo-SecureString $env:ASAZURE_TESTUSER_PWD -AsPlainText -Force
		$admuser0 = $env:ASAZURE_TEST_ADMUSERS.Split(',')[0]
		$cred = New-Object System.Management.Automation.PSCredential ($admuser0, $secpasswd)

		$asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount -RolloutEnvironment $rolloutEnvironment -Credential $cred
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment must not return null"
		Assert-True { Restart-AzureCapacityInstance -Instance $capacityName -PassThru }

		$rolloutEnvironment = 'pbidedicated-int.windows.net'
		$asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment must not return null"

		$rolloutEnvironment = 'pbidedicated.windows.net'
		$asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment must not return null"

	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}


<#
.SYNOPSIS
Tests PowerBI Embedded Capacity Login and synchronize single database.
In order to run this test successfully, Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaaswestusloop1.pbidedicated-int.windows.net'
ASAZURE_TESTUSER e.x. value 'aztest0@asazure.ccsctp.net'
ASAZURE_TESTUSER_PWD e.x. value 'samplepwd'
ASAZURE_TESTDATABASE e.x. value 'adventureworks'
#>
function Test-PowerBIEmbeddedCapacitySynchronizeSingle
{
    param
	(
		$rolloutEnvironment = $env.ASAZURE_TEST_ROLLOUT
	)
	try
	{
		# Creating capacity
        $location = Get-Location
        $resourceGroupName = Get-ResourceGroupName
        $capacityName = Get-PowerBIEmbeddedCapacityName
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

        $capacityCreated = New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Location $location -Sku 'A1' -Administrators $env.ASAZURE_TESTUSER
        Assert-True {$capacityCreated.ProvisioningState -like "Succeeded"}
        Assert-True {$capacityCreated.State -like "Succeeded"}

        $asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount -RolloutEnvironment $rolloutEnvironment
        Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment must not return null"

        $secpasswd = ConvertTo-SecureString $env.ASAZURE_TESTUSER_PWD -AsPlainText -Force
        $cred = New-Object System.Management.Automation.PSCredential ($env.ASAZURE_TESTUSER, $secpasswd)

		Synchronize-AzureAsInstance -Instance $capacityName -Database $env.ASAZURE_TESTDATABASE -PassThru
		
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount $rolloutEnvironment must not return null"
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName $resourceGroupName -Name $capacityName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests PowerBI Embedded Capacity Login with SPN. In order to run this test successfully:
1. Create one application with password, and create another application with certificate authentication.
2. Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaaswestusloop1.pbidedicated-int.windows.net'
ASAZURE_TESTAPP1_ID e.x. value 'xxxx-xxxx-xxxx-xxxx' ( must be created before test with password )
ASAZURE_TESTAPP1_PWD e.x. value 'yyyyyyyyyyyyyyyy' (password for application ASAZURE_TESTAPP_ID1)
ASAZURE_TESTAPP2_ID e.x. value 'aaaa-aaaa-aaaa-aaaa' ( must be created before test with certificate to authenticate )
ASAZURE_TESTAPP2_CERT_THUMBPRINT e.x. value 'bbbbbbbbbbbbbbbb' (certificate thumbprint for application ASAZURE_TESTAPP_ID2)
#>
function Test-PowerBIEmbeddedCapacityLoginWithSPN
{
    param
	(
		$rolloutEnvironment = $env.ASAZURE_TEST_ROLLOUT
	)
	try
	{
		# login capacity with ASAZURE_TESTAPP1_ID and ASAZURE_TESTAPP1_PWD
		$SecurePassword = ConvertTo-SecureString -String $env.ASAZURE_TESTAPP1_PWD -AsPlainText -Force
		$Credential_SPN = New-Object -TypeName "System.Management.Automation.PSCredential" -ArgumentList $env.ASAZURE_TESTAPP1_ID, $SecurePassword
		$asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount -RolloutEnvironment $rolloutEnvironment -ServicePrincipal -Credential $Credential_SPN -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47"
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount with Service Principal and password must not return null"
		$token = [Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Dataplane.PBIClientSession]::TokenCache.ReadItems()[0]
		Assert-NotNull $token "Login-AzurePowerBIEmbeddedCapacityAccount with Service Principal and password must not return null"

		# login capacity with ASAZURE_TESTAPP2_ID and ASAZURE_TESTAPP2_CERT_THUMBPRINT
		$asAzureProfile = Login-AzurePowerBIEmbeddedCapacityAccount -RolloutEnvironment $rolloutEnvironment -ServicePrincipal -ApplicationId $env.ASAZURE_TESTAPP1_ID -CertificateThumbprint $env.ASAZURE_TESTAPP2_CERT_THUMBPRINT -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47"
		Assert-NotNull $asAzureProfile "Login-AzurePowerBIEmbeddedCapacityAccount with Service Principal and certificate thumbprint must not return null"
		$token = [Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Dataplane.PBIClientSession]::TokenCache.ReadItems()[0]
		Assert-NotNull $token "Login-AzurePowerBIEmbeddedCapacityAccount with Service Principal and certificate thumbprint must not return null"
	}
	finally
	{

	}
}