# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# ----------------------------------------------------------------------------------

function Test-FirstPartyServiceTagsCRUD
{
    $resourceGroupName = Get-ResourceGroupName
    $location = Get-ProviderLocation ResourceManagement "eastus2euap"
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

        $retrievedByResourceId = Get-AzFirstPartyServiceTag -ResourceId $created.Id
        Assert-AreEqual $created.Id $retrievedByResourceId.Id

        $wildcardList = Get-AzFirstPartyServiceTag `
            -ResourceGroupName $resourceGroupName `
            -Name "$serviceTagName*"
        Assert-AreEqual 1 @($wildcardList).Count
        Assert-AreEqual $created.Id $wildcardList[0].Id

        $resourceGroupList = Get-AzFirstPartyServiceTag -ResourceGroupName $resourceGroupName
        Assert-True { $resourceGroupList.Count -ge 1 }

        $subscriptionList = Get-AzFirstPartyServiceTag
        Assert-True { $subscriptionList.Count -ge 1 }

        $retrieved.Value = "updatedServiceTagValue"
        $updated = $retrieved | Set-AzFirstPartyServiceTag
        Assert-AreEqual "updatedServiceTagValue" $updated.Value

        $ipTag = New-AzPublicIpTag `
            -IpTagType "FirstPartyUsage" `
            -Tag "/Sql" `
            -FirstPartyServiceTagId $updated.Id
        Assert-AreEqual $updated.Id $ipTag.FirstPartyServiceTagId

        $removed = Remove-AzFirstPartyServiceTag `
            -ResourceId $updated.Id `
            -PassThru `
            -Force
        Assert-AreEqual $true $removed
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}
