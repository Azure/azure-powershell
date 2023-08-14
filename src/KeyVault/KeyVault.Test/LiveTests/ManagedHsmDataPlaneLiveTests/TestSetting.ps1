Invoke-LiveTestScenario -Name "Get and update key vault setting in a MSHM" -Description "Get and update a key vault setting in a MSHM" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $hsmName = "bezmhsm" + (New-LiveTestRandomName -Option AllNumbers)
    $hsmLocation = 'eastus2euap'
    $adminId = (Get-AzADUser -StartsWith Beisi).Id
    $hsmObject = New-AzKeyVaultManagedHsm -HsmName $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $adminId
    Start-Sleep 1800
    New-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName "Managed HSM Crypto User" -ObjectId $adminId
    Export-AzKeyVaultSecurityDomain -Certificates "$PSScriptRoot\sd1.cer", "$PSScriptRoot\sd2.cer", "$PSScriptRoot\sd3.cer" -Quorum 2 -OutputPath $PSScriptRoot/sd.ps.json -Name $hsmName
    $setting = $hsmObject | Get-AzKeyVaultSetting -Name "AllowKeyManagementOperationsThroughARM"
    $updatedSetting= $setting | Update-AzKeyVaultSetting -Value true -PassThru
    Assert-AreEqual $updatedSetting.Value "true"
}
