Function CreateAdApp_Test
{
    $adDisplayName = "TestAdAppForNodeCliTestCase"
    $subId = '2c224e7e-3ef5-431d-a57b-e71f4662e3a6'

    Create-ServicePrincipal -ADAppDisplayName "MyModTestApp1" -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6 -TenantId 72f988bf-86f1-41af-91ab-2d7cd011db47 -createADAppIfNotFound $true -createADSpnIfNotFound $true

    Set-SPNRole -ADAppDisplayName "MyModTestApp1" -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6
    Remove-ServicePrincipal -ADAppDisplayName "MyModTestApp1" -SubscriptionId 2c224e7e-3ef5-431d-a57b-e71f4662e3a6 -TenantId 72f988bf-86f1-41af-91ab-2d7cd011db47
}


Function Test-NewServicePrincipalCredential
{
	# Test that Service Principal is correctly created
	$context = Get-AzureRmContext
	New-AzureCredential -NewServicePrincipalDisplayName "credentialtestserviceprincipal" -NewServicePrincipalPassword "testpassword" -SubscriptionId $context.Subscription.Id -TenantId $context.Tenant.Id -RecordMode "Playback"
	$servicePrincipal = Get-AzureRmADServicePrincipal -SearchString credentialstestserviceprincipal
	Remove-AzureRmADServicePrincipal -ObjectId $servicePrincipal.Id -Force

	#Test that connection string is properly set
	
}