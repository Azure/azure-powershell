Invoke-LiveTestScenario -Name "Create CdnProfile with Change Safety" -Description "Test New-AzCdnProfile -AcquirePolicyToken" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $profileName = New-LiveTestResourceName

    $actual = New-AzCdnProfile -ResourceGroupName $rgName -Name $profileName -SkuName Standard_Microsoft -Location Global -AcquirePolicyToken -Confirm:$false
    Assert-AreEqual $profileName $actual.Name
}

Invoke-LiveTestScenario -Name "Create FrontDoorCdnProfile with Change Safety" -Description "Test New-AzFrontDoorCdnProfile -AcquirePolicyToken" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $profileName = New-LiveTestResourceName

    $actual = New-AzFrontDoorCdnProfile -ResourceGroupName $rgName -Name $profileName -SkuName Standard_AzureFrontDoor -Location Global -AcquirePolicyToken -Confirm:$false
    Assert-AreEqual $profileName $actual.Name
}

Invoke-LiveTestScenario -Name "Create FrontDoorCdnEndpoint with Change Safety" -Description "Test New-AzFrontDoorCdnEndpoint -AcquirePolicyToken" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $profileName = New-LiveTestResourceName
    $endpointName = New-LiveTestResourceName

    New-AzFrontDoorCdnProfile -ResourceGroupName $rgName -Name $profileName -SkuName Standard_AzureFrontDoor -Location Global -Confirm:$false | Out-Null
    $actual = New-AzFrontDoorCdnEndpoint -ResourceGroupName $rgName -ProfileName $profileName -EndpointName $endpointName -Location Global -EnabledState Enabled -AcquirePolicyToken -Confirm:$false
    Assert-AreEqual $endpointName $actual.Name
}

Invoke-LiveTestScenario -Name "Create FrontDoorCdnRuleSet with Change Safety" -Description "Test New-AzFrontDoorCdnRuleSet -AcquirePolicyToken (fully generated, non-custom-fronted cmdlet)" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $profileName = New-LiveTestResourceName
    $ruleSetName = New-LiveTestResourceName

    New-AzFrontDoorCdnProfile -ResourceGroupName $rgName -Name $profileName -SkuName Standard_AzureFrontDoor -Location Global -Confirm:$false | Out-Null
    $actual = New-AzFrontDoorCdnRuleSet -ResourceGroupName $rgName -ProfileName $profileName -Name $ruleSetName -AcquirePolicyToken -Confirm:$false
    Assert-AreEqual $ruleSetName $actual.Name
}
