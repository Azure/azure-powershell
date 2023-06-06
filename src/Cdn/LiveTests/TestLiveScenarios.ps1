Invoke-LiveTestScenario -Name "Create function app" -Description "Test creating function app" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $frontDoorCdnProfileName = "pstest"
    $profileSku = "Standard_AzureFrontDoor"
    $subID = "27cafca8-b9a4-4264-b399-45d0c9cca1ab"
    $userId =  @{"/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/afdx-cert-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/AFDX-Cert-Test" = @{} }

    Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

    $profileSku = "Standard_AzureFrontDoor"
    New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $rgName -Location Global -SubscriptionId $subID

    Write-Host -ForegroundColor Green "Update AzFrontDoorCdnProfile"
    $profileObject = Update-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $rgName -IdentityType UserAssigned -IdentityUserAssignedIdentity $userId -SubscriptionId $subID

    Write-Host -ForegroundColor Green "Get AzFrontDoorCdnProfile"
    $updatedProfile = Get-AzFrontDoorCdnProfile -InputObject $profileObject
    
    Assert-AreEqual "UserAssigned"
    $updatedProfile.IdentityType | Should -Be "UserAssigned"

    Assert-NotNull $updatedProfile
    Assert-AreEqual $rgName $updatedProfile.ResourceGroupName
    Assert-AreEqual "UserAssigned" $updatedProfile.IdentityType
}

# At the end of live test, clear the resource group
Clear-LiveTestResources -Name $rgName