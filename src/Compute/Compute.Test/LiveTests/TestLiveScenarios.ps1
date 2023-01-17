Invoke-LiveTestScenario -Name "VM.NewVM Test" -Description "Test create new VM" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName

    $vm = Get-AzVM -ResourceGroupName $rgName -Name $name 
    if ($null -eq $vm) {
        $actual = New-AzVM -Name $name -Credential (Get-Credential)
    }
    Assert-AreEqual $name $actual.Name

    Assert-AreEqual $false $actual.EnabledForDeployment
    Assert-Null $actual.Zone "By default Zone should be null"
}

Invoke-LiveTestScenario -Name "VM.RemoveVM Test" -Description "Test remove VM" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName

    New-AzVM -Name $name -Credential (Get-Credential)
    Remove-AzVM -ResourceGroupName $rgName -Name $name -Force

    $removedVM = Get-AzVM -ResourceGroupName $rgName -Name $name
    Assert-Null $removedVM

    # purge deleted vault
    Remove-AzVM -ResourceGroupName $rgName -Name $name -Force
}
