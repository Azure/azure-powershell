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
	New-AzureCredential -NewServicePrincipalDisplayName "credentialtestserviceprincipal" -NewServicePrincipalPassword "testpassword" -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Playback" -Force
	$servicePrincipal = Get-AzureRmADServicePrincipal -SearchString credentialtestserviceprincipal | where { $_.DisplayName -eq "credentialtestserviceprincipal" }
	if ($servicePrincipal -eq $null)
	{
		throw "ServicePrincipal not properly created."
	}

	# Test that file is correctly set
	
	# Test that connection string is properly set
	[System.Reflection.Assembly]::LoadFrom("$PSScriptRoot\..\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll")
	$envHelper = New-Object Microsoft.Azure.Commands.ScenarioTest.EnviromentSetupHelper -ArgumentList @()

	# Test that TestEnviroment is set-up properly

	# Clean-up
	Get-AzureRmADApplication -ApplicationId $servicePrincipal.ApplicationId | Remove-AzureRmADApplication -Force
}

Function Test-NewCredentialExistingServicePrincipal
{
	# Set-up
	$NewServicePrincipal = New-AzureRmADServicePrincipal -DisplayName "credentialtestserviceprincipal" -Password "testpassword"
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

	# Test that file is correctly set
	New-AzureCredential -ServicePrincipalId $NewServicePrincipal.ApplicationId -ServicePrincipalSecret "testpassword" -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Playback" -Force

	# Test that connection string is properly set

	# Test that TestEnviroment is set-up properly

	# Clean-up
	Get-AzureRmADApplication -ApplicationId $servicePrincipal.ApplicationId | Remove-AzureRmADApplication -Force
}

Function Test-NewCredentialUserId 
{
	# Test that file is correctly set
	New-AzureCredential -UserId "testuser" -SubscriptionId $context.Subscription.Id -RecordMode "Playback" -Force

	# Test that connection string is properly set

	# Test that TestEnviroment is set-up properly

	# Clean-up
}

Function Test-SetEnvironmentServicePrincipal
{
	# Set-up
	$NewServicePrincipal = New-AzureRmADServicePrincipal -DisplayName "credentialtestserviceprincipal" -Password "testpassword"
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
	Set-TestEnvironment -ServicePrincipalId $NewServicePrincipal.ApplicationId -ServicePrincipalSecret "testpassword" -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Playback"

	# Test that TestEnviroment is set-up properly

	# Clean-up
	Get-AzureRmADApplication -ApplicationId $servicePrincipal.ApplicationId | Remove-AzureRmADApplication -Force
}

Function Test-SetEnvironmentUserId
{
	# Test that connection string is properly set
	Set-TestEnvironment -UserId "testuser" -SubscriptionId $context.Subscription.Id RecordMode "Playback"

	# Test that TestEnviroment is set-up properly

	# Clean-up
}

Test-NewCredentialNewServicePrincipal