# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# ----------------------------------------------------------------------------------

function Test-FirstPartyServiceTagsCRUD
{
    $resourceGroupName = Get-ResourceGroupName
    $location = Get-ProviderLocation ResourceManagement "eastus"
    $serviceTagName = Get-ResourceName

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        $created = New-AzFirstPartyServiceTag `
            -ResourceGroupName $resourceGroupName `
            -Name $serviceTagName `
            -Location $location `
            -Value "myServiceTagValue" `
            -Tag @{ environment = "test" }

        Assert-AreEqual $serviceTagName $created.Name
        Assert-AreEqual "myServiceTagValue" $created.Value

        $retrieved = Get-AzFirstPartyServiceTag -ResourceGroupName $resourceGroupName -Name $serviceTagName
        Assert-AreEqual $created.Id $retrieved.Id

        $resourceGroupList = Get-AzFirstPartyServiceTag -ResourceGroupName $resourceGroupName
        Assert-True { $resourceGroupList.Count -ge 1 }

        $subscriptionList = Get-AzFirstPartyServiceTag
        Assert-True { $subscriptionList.Count -ge 1 }

        $retrieved.Value = "updatedServiceTagValue"
        $updated = $retrieved | Set-AzFirstPartyServiceTag
        Assert-AreEqual "updatedServiceTagValue" $updated.Value

        $removed = Remove-AzFirstPartyServiceTag `
            -ResourceGroupName $resourceGroupName `
            -Name $serviceTagName `
            -PassThru `
            -Force
        Assert-AreEqual $true $removed
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}
