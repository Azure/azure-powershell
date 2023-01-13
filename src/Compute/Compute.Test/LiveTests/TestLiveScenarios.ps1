Write-Host "VM test live scenarios"

Invoke-LiveTestScenario -Name "VM.NewVM Test" -Description "Test create new VM" -ScenarioScript `
{
    param ($rgName, $rgLocation)

    Write-Host "Resource group name: $rgName"

    $vaultLocation = "westus"
    $Name = New-LiveTestResourceName

    $kv = Get-AzVM -ResourceGroupName $rgName -Name $Name 
    if ($null -eq $kv) {
        New-AzVM  -ResourceGroupName $rgName -Name $Name -Location $vaultLocation -Credential (Get-Credential)
    }
    $got = Get-AzVM  -ResourceGroupName $rgName -Name $Name

    Assert-NotNull $got
    Assert-AreEqual $got.Location $vaultLocation
    Assert-AreEqual $got.ResourceGroupName $rgName
    Assert-AreEqual $got.Name $Name

    $got = Get-AzVM -Name $Name

    Assert-NotNull $got
    Assert-AreEqual $got.Location $vaultLocation
    Assert-AreEqual $got.ResourceGroupName $rgName
    Assert-AreEqual $got.Name $Name
}

Invoke-LiveTestScenario -Name "VM.RemoveVM Test" -Description "Test remove VM" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ([string] $rgName, [string] $rgLocation)

    Write-Host "Resource group name: $rgName"

    $vaultLocation = "westus"
    $vaultName = New-LiveTestResourceName

    New-AzVM -ResourceGroupName $rgname -Name $Name -Location $vaultLocation
    Remove-AzVM -Name $Name -Force

    $removedVM = Get-AzVM -ResourceGroupName $rgName -Name $Name
    Assert-Null $removedVM

    # purge deleted vault
    Remove-AzVM -ResourceGroupName $rgName -Name $Name -Location $vaultLocation -InRemovedState -Force

    # Test piping
    New-AzVM -ResourceGroupName $rgname -Name $Name -Location $vaultLocation

    Get-AzVM -ResourceGroupName $rgname -Name $Name | Remove-AzVM -Force

    $removedVM = Get-AzVM -ResourceGroupName $rgName -Name $Name
    Assert-Null $removedVM
}
