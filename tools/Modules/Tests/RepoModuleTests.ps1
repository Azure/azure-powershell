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
	New-AzureCredential -NewServicePrincipalDisplayName "credentialtestserviceprincipal" -NewServicePrincipalPassword "testpassword" -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Playback"
	$servicePrincipal = Get-AzureRmADServicePrincipal -SearchString credentialtestserviceprincipal | where { $_.DisplayName -eq "credentialtestserviceprincipal" }
	if ($servicePrincipal -eq $null)
	{
		throw "ServicePrincipal not properly created."
	}

	#Test that connection string is properly set
	[System.Reflection.Assembly]::LoadFrom("$PSScriptRoot\..\..\..\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\bin\Debug\Microsoft.Azure.Commands.ScenarioTest.Common.dll")
	$envHelper = New-Object Microsoft.Azure.Commands.ScenarioTest.EnviromentSetupHelper -ArgumentList @()


	Get-AzureRmADApplication -ApplicationId $servicePrincipal.ApplicationId | Remove-AzureRmADApplication -Force
}

Function Test-NewCredentialExistingServicePrincipal
{

}

Function Test-NewCredentialUserId 
{

}

Function Test-SetEnvironmentServicePrincipal
{

}

Function Test-SetEnvironmentUserId
{

}

Test-NewCredentialNewServicePrincipal