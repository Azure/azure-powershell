function Get-RotatedLocation
{
    $regions = @("southindia", "westindia", "japaneast", "japanwest", "eastasia", "southeastasia", "brazilsouth", "koreasouth")
    $index = (Get-Date).Day % 8
    return $regions[$index]
}

Invoke-LiveTestScenario -Name "Get and update key vault setting in a MHSM" -Description "Get and update a key vault setting in a MHSM" -Platform Linux -PowerShellVersion Latest -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $hsmName = "bezmhsm" + (New-LiveTestRandomName -Option AllNumbers)
    $hsmLocation = Get-RotatedLocation
    $appId = (Get-AzContext).Account.Id
    $adminId = (Get-AzADServicePrincipal -ApplicationId $appId).Id
    $hsmObject = New-AzKeyVaultManagedHsm -HsmName $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $adminId -SoftDeleteRetentionInDays 7
    Export-AzKeyVaultSecurityDomain -Certificates "$PSScriptRoot\sd1.cer", "$PSScriptRoot\sd2.cer", "$PSScriptRoot\sd3.cer" -Quorum 2 -OutputPath $PSScriptRoot/sd.ps.json -Name $hsmName -Force
    $setting = $hsmObject | Get-AzKeyVaultSetting -Name "AllowKeyManagementOperationsThroughARM"
    $updatedSetting = $setting | Update-AzKeyVaultSetting -Value true -PassThru
    Assert-AreEqual $updatedSetting.Value "true"

    # Clean up
    Get-AzKeyVaultManagedHsm -HsmName $hsmName -ResourceGroupName $rgName | Remove-AzKeyVaultManagedHsm -Force
    Get-AzKeyVaultManagedHsm -HsmName $hsmName -Location $hsmLocation -InRemovedState | Remove-AzKeyVaultManagedHsm -InRemovedState -Force
}
