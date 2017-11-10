Function CreateAdApp_Test
{
    $adDisplayName = "TestAdAppForNodeCliTestCase"
    $subId = '2c224e7e-3ef5-431d-a57b-e71f4662e3a6'

    Create-ServicePrincipal -ADAppDisplayName "MyModTestApp1" -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6 -TenantId 72f988bf-86f1-41af-91ab-2d7cd011db47 -createADAppIfNotFound $true -createADSpnIfNotFound $true

    Set-SPNRole -ADAppDisplayName "MyModTestApp1" -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6
    Remove-ServicePrincipal -ADAppDisplayName "MyModTestApp1" -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6 -TenantId 72f988bf-86f1-41af-91ab-2d7cd011db47
}


Function Test-NewCredentialNewServicePrincipal
{
	Import-Module $PSScriptRoot\..\TestFx-Tasks.psd1
	# Test that Service Principal is correctly created
	$context = Get-AzureRmContext
	$secureSecret = ConvertTo-SecureString -String "testpassword" -AsPlainText -Force
	New-TestCredential -ServicePrincipalDisplayName "credentialtestserviceprincipal" -ServicePrincipalSecret $secureSecret -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Record" -Force
	$servicePrincipal = Get-AzureRmADServicePrincipal -SearchString credentialtestserviceprincipal | where { $_.DisplayName -eq "credentialtestserviceprincipal" }
	if ($servicePrincipal -eq $null)
	{
		throw "ServicePrincipal not properly created."
	}
	
	# Test that connection string is properly set
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
	$envHelper.SetEnvironmentVariableFromCredentialFile()
	if (($Env:AZURE_TEST_MODE -ne "Record") -or ($Env:TEST_CSM_ORGID_AUTHENTICATION -ne 
		"SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Record;Environment=Prod;ServicePrincipal=" + $servicePrincipal.ApplicationId + ";ServicePrincipalSecret=testpassword;" + 
		"AADTenant=" + $context.Tenant.Id))
	{
		throw "ConnectionString not set correctly: " + $Env:TEST_CSM_ORGID_AUTHENTICATION + ", expected: " + "SubscriptionId=" + $context.Subscription.Id + 
		";HttpRecorderMode=Record;Environment=Prod;ServicePrincipal=" + $servicePrincipal.ApplicationId + ";ServicePrincipalSecret=testpassword;" + "AADTenant=" + $context.Tenant.Id
	}

	# Test that TestEnviroment is set-up properly
	$synch = New-Object System.Threading.SynchronizationContext -ArgumentList @()
	[System.Threading.SynchronizationContext]::SetSynchronizationContext($synch)
	$envHelper.SetupAzureEnvironmentFromEnvironmentVariables("AzureResourceManager")
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\Common\Commands.Common.Authentication.Abstractions\bin\Debug\Microsoft.Azure.Commands.Common.Authentication.Abstractions.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$defaultContext = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
	if ($defaultContext.Subscription.Id -ne $context.Subscription.Id)
	{
		throw "Subscription not set correctly" + $context.Subscription.Id
	}
	
	if ($defaultContext.Tenant.Id -ne $context.Tenant.Id)
	{
		throw "Tenant not set correctly" + $context.Tenant.Id
	}

	# Clean-up
	Get-AzureRmADApplication -ApplicationId $servicePrincipal.ApplicationId | Remove-AzureRmADApplication -Force
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
	$filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
	Remove-Item -LiteralPath $filePath -Force
	$directoryPath = $Env:USERPROFILE + "\.azure\"
	$directoryEmpty = Get-ChildItem $directoryPath | Measure-Object
	if ($directoryEmpty.Count -eq 0)
	{
		Remove-Item $directoryPath -Recurse -Force
	}
}

Function Test-NewCredentialExistingServicePrincipal
{
	# Set-up
	$SecureStringSecret = ConvertTo-SecureString "testpassword" -AsPlainText -Force
	$NewServicePrincipal = New-AzureRmADServicePrincipal -DisplayName "credentialtestserviceprincipal" -Password $SecureStringSecret
	$context = Get-AzureRmContext
	$Scope = "/subscriptions/" + $context.Subscription.Id
	$NewRole = $null
	$Retries = 0;
	While ($NewRole -eq $null -and $Retries -le 6)
	{
		# Sleep here for a few seconds to allow the service principal application to become active (should only take a couple of seconds normally)
		Start-Sleep 5
		New-AzureRMRoleAssignment -RoleDefinitionName Contributor -ServicePrincipalName $NewServicePrincipal.ApplicationId -Scope $Scope | Write-Verbose -ErrorAction SilentlyContinue
		$NewRole = Get-AzureRMRoleAssignment -ObjectId $NewServicePrincipal.Id -ErrorAction SilentlyContinue
		$Retries++;
	}

	$secureSecret = ConvertTo-SecureString -String "testpassword" -AsPlainText -Force
	New-TestCredential -ServicePrincipalDisplayName "credentialtestserviceprincipal" -ServicePrincipalSecret $secureSecret -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Playback" -Force

	# Test that connection string is properly set
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
	$envHelper.SetEnvironmentVariableFromCredentialFile()
	if (($Env:AZURE_TEST_MODE -ne "Playback") -or ($Env:TEST_CSM_ORGID_AUTHENTICATION -ne 
		"SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Playback;Environment=Prod;ServicePrincipal=" + $NewServicePrincipal.ApplicationId + ";ServicePrincipalSecret=testpassword;" + 
		"AADTenant=" + $context.Tenant.Id))
	{
		throw "ConnectionString not set correctly" + $Env:TEST_CSM_ORGID_AUTHENTICATION
	}

	# Test that TestEnviroment is set-up properly
	$synch = New-Object System.Threading.SynchronizationContext -ArgumentList @()
	[System.Threading.SynchronizationContext]::SetSynchronizationContext($synch)
	$envHelper.SetupAzureEnvironmentFromEnvironmentVariables("AzureResourceManager")
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\Common\Commands.Common.Authentication.Abstractions\bin\Debug\Microsoft.Azure.Commands.Common.Authentication.Abstractions.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$defaultContext = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
	if ($defaultContext.Subscription.Id -ne $context.Subscription.Id)
	{
		throw "Subscription not set correctly" + $context.Subscription.Id
	}
	
	if ($defaultContext.Tenant.Id -ne $context.Tenant.Id)
	{
		throw "Tenant not set correctly" + $context.Tenant.Id
	}

	# Clean-up
	Get-AzureRmADApplication -ApplicationId $NewServicePrincipal.ApplicationId | Remove-AzureRmADApplication -Force
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
	$filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
	Remove-Item -LiteralPath $filePath -Force
	$directoryPath = $Env:USERPROFILE + "\.azure\"
	$directoryEmpty = Get-ChildItem $directoryPath | Measure-Object
	if ($directoryEmpty.Count -eq 0)
	{
		Remove-Item $directoryPath -Recurse -Force
	}
}

Function Test-NewCredentialUserId 
{
	$context = Get-AzureRmContext
	New-TestCredential -UserId "testuser" -SubscriptionId $context.Subscription.Id -RecordMode "Playback" -Force

	# Test that connection string is properly set
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
	$envHelper.SetEnvironmentVariableFromCredentialFile()
	if (($Env:AZURE_TEST_MODE -ne "Playback") -or ($Env:TEST_CSM_ORGID_AUTHENTICATION -ne "SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Playback;Environment=Prod;UserId=testuser"))
	{
		throw "ConnectionString not set correctly" + $Env:TEST_CSM_ORGID_AUTHENTICATION
	}

	# Test that TestEnviroment is set-up properly
	$synch = New-Object System.Threading.SynchronizationContext -ArgumentList @()
	[System.Threading.SynchronizationContext]::SetSynchronizationContext($synch)
	$envHelper.SetupAzureEnvironmentFromEnvironmentVariables("AzureResourceManager")
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\Common\Commands.Common.Authentication.Abstractions\bin\Debug\Microsoft.Azure.Commands.Common.Authentication.Abstractions.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$defaultContext = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
	if ($defaultContext.Subscription.Id -ne $context.Subscription.Id)
	{
		throw "Subscription not set correctly" + $context.Subscription.Id
	}

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
	$filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
	Remove-Item -LiteralPath $filePath -Force
	$directoryPath = $Env:USERPROFILE + "\.azure\"
	$directoryEmpty = Get-ChildItem $directoryPath | Measure-Object
	if ($directoryEmpty.Count -eq 0)
	{
		Remove-Item $directoryPath -Recurse -Force
	}
}

Function Test-SetEnvironmentServicePrincipal
{
	# Set-up
	$SecureStringSecret = ConvertTo-SecureString "testpassword" -AsPlainText -Force
	$NewServicePrincipal = New-AzureRmADServicePrincipal -DisplayName "credentialtestserviceprincipal" -Password $SecureStringSecret
	$context = Get-AzureRmContext
	$Scope = "/subscriptions/" + $context.Subscription.Id
	$NewRole = $null
	$Retries = 0;
	While ($NewRole -eq $null -and $Retries -le 6)
	{
		# Sleep here for a few seconds to allow the service principal application to become active (should only take a couple of seconds normally)
		Start-Sleep 5
		New-AzureRMRoleAssignment -RoleDefinitionName Contributor -ServicePrincipalName $NewServicePrincipal.ApplicationId -Scope $Scope | Write-Verbose -ErrorAction SilentlyContinue
		$NewRole = Get-AzureRMRoleAssignment -ObjectId $NewServicePrincipal.Id -ErrorAction SilentlyContinue
		$Retries++;
	}

	# Test that connection string is properly set
	Set-TestEnvironment -ServicePrincipalId $NewServicePrincipal.ApplicationId -ServicePrincipalSecret "testpassword" -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Record"
	if (($Env:AZURE_TEST_MODE -ne "Record") -or ($Env:TEST_CSM_ORGID_AUTHENTICATION -ne 
		"SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Record;Environment=Prod;AADTenant=" + $context.Tenant.Id + ";ServicePrincipal=" + $NewServicePrincipal.ApplicationId + ";ServicePrincipalSecret=testpassword"))
	{
		throw "ConnectionString not set correctly" + $Env:TEST_CSM_ORGID_AUTHENTICATION
	}

	# Test that TestEnviroment is set-up properly
	$synch = New-Object System.Threading.SynchronizationContext -ArgumentList @()
	[System.Threading.SynchronizationContext]::SetSynchronizationContext($synch)
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
	$envHelper.SetupAzureEnvironmentFromEnvironmentVariables("AzureResourceManager")
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\Common\Commands.Common.Authentication.Abstractions\bin\Debug\Microsoft.Azure.Commands.Common.Authentication.Abstractions.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$defaultContext = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
	if ($defaultContext.Subscription.Id -ne $context.Subscription.Id)
	{
		throw "Subscription not set correctly" + $context.Subscription.Id
	}
	
	if ($defaultContext.Tenant.Id -ne $context.Tenant.Id)
	{
		throw "Tenant not set correctly" + $context.Tenant.Id
	}

	# Clean-up
	Get-AzureRmADApplication -ApplicationId $NewServicePrincipal.ApplicationId | Remove-AzureRmADApplication -Force
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
}

Function Test-SetEnvironmentUserId
{
	$context = Get-AzureRmContext
	Set-TestEnvironment -UserId "testuser" -SubscriptionId $context.Subscription.Id -RecordMode "Playback"

	# Test that connection string is properly set
	if (($Env:AZURE_TEST_MODE -ne "Playback") -or ($Env:TEST_CSM_ORGID_AUTHENTICATION -ne "SubscriptionId=" + $context.Subscription.Id + ";HttpRecorderMode=Playback;Environment=Prod;UserId=testuser"))
	{
		throw "ConnectionString not set correctly" + $Env:TEST_CSM_ORGID_AUTHENTICATION
	}

	# Test that TestEnviroment is set-up properly
	$synch = New-Object System.Threading.SynchronizationContext -ArgumentList @()
	[System.Threading.SynchronizationContext]::SetSynchronizationContext($synch)
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$envHelper = New-Object Microsoft.WindowsAzure.Commands.ScenarioTest.EnvironmentSetupHelper -ArgumentList @()
	$envHelper.SetupAzureEnvironmentFromEnvironmentVariables("AzureResourceManager")
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\..\..\..\src\Common\Commands.Common.Authentication.Abstractions\bin\Debug\Microsoft.Azure.Commands.Common.Authentication.Abstractions.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$defaultContext = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
	if ($defaultContext.Subscription.Id -ne $context.Subscription.Id)
	{
		throw "Subscription not set correctly" + $context.Subscription.Id
	}

	# Clean-up
	Remove-Item Env:AZURE_TEST_MODE
	Remove-Item Env:TEST_CSM_ORGID_AUTHENTICATION
}

Test-NewCredentialNewServicePrincipal
Test-NewCredentialExistingServicePrincipal
Test-NewCredentialUserId
Test-SetEnvironmentServicePrincipal
Test-SetEnvironmentUserId