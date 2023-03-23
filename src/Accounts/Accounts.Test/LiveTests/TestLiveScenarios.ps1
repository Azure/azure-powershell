Invoke-LiveTestScenario -Name "Validate access token" -Description "Test validating access token" -NoResourceGroup -ScenarioScript `
{
    $account = (Get-AzContext).Account
    $applicationId = $account.Id
    $tenantId = $account.Tenants[0]
    $token = Get-AzAccessToken
    Assert-AreEqual $applicationId $token.UserId
    Assert-AreEqual $tenantId $token.TenantId
}

Invoke-LiveTestScenario -Name "Disconnect service principal account" -Description "Test disconnecting service principal account" -NoResourceGroup -ScenarioScript `
{
    $account = (Get-AzContext).Account
    $applicationId = $account.Id
    $tenantId = $account.Tenants[0]
    Disconnect-AzAccount -ApplicationId $applicationId -TenantId $tenantId

    $token = Get-AzAccessToken -ErrorAction SilentlyContinue
    Assert-True { ($null -eq $token) -or ($null -ne $token -and $token.UserId -ne $applicationId) }
}
