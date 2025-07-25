Invoke-LiveTestScenario -Name "Create automation account" -Description "Test creating automation account with different sku" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $autoAccParams = @(
        @{
            Name = New-LiveTestResourceName;
            Location = "westus";
            Plan = "Free"
        },
        @{
            Name = New-LiveTestResourceName;
            Location = "eastus";
            Plan = "Basic"
        }
    )

    $autoAccParams | ForEach-Object {
        New-AzAutomationAccount -ResourceGroupName $rgName -Name $_.Name -Location $_.Location -Plan $_.Plan

        $actual = Get-AzAutomationAccount -ResourceGroupName $rgName -Name $_.Name
        Assert-NotNull $actual
        Assert-AreEqual $rgName $actual.ResourceGroupName
        Assert-AreEqual $_.Name $actual.AutomationAccountName
        Assert-AreEqual $_.Location $actual.Location
        #Assert-AreEqual $_.Plan $actual.Plan
        Assert-AreEqual "Ok" $actual.State
    }
}

Invoke-LiveTestScenario -Name "Update automation account" -Description "Test updating an existing automation account" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $accName = New-LiveTestResourceName
    $accLocation = "centralus"

    New-AzAutomationAccount -ResourceGroupName $rgName -Name $accName -Location $accLocation
    Set-AzAutomationAccount -ResourceGroupName $rgName -Name $accName -AssignSystemIdentity -DisablePublicNetworkAccess -Tags @{ "key" = "val" }

    $actual = Get-AzAutomationAccount -ResourceGroupName $rgName -Name $accName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $accName $actual.AutomationAccountName
    Assert-AreEqual $accLocation $actual.Location
    Assert-AreEqual "Ok" $actual.State
}

Invoke-LiveTestScenario -Name "Remove automation account" -Description "Test removing an automation account" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $accName = New-LiveTestResourceName
    $accLocation = "eastus"

    New-AzAutomationAccount -ResourceGroupName $rgName -Name $accName -Location $accLocation
    Remove-AzAutomationAccount -ResourceGroupName $rgName -Name $accName -Force

    $actual = Get-AzAutomationAccount -ResourceGroupName $rgName -Name $accName -ErrorAction SilentlyContinue
    Assert-Null $actual
}
