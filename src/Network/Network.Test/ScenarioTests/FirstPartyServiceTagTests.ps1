# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# ----------------------------------------------------------------------------------

function Test-FirstPartyServiceTagBasicOperations
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
            -Value "/RnmRunners" `
            -Tag @{ environment = "test" }

        Assert-AreEqual $serviceTagName $created.Name
        Assert-AreEqual "/RnmRunners" $created.Value
        Assert-NotNull $created.ResourceGuid

        $retrieved = Get-AzFirstPartyServiceTag -ResourceGroupName $resourceGroupName -Name $serviceTagName
        Assert-AreEqual $created.Id $retrieved.Id
        Assert-AreEqual $created.ResourceGuid $retrieved.ResourceGuid

        $ipTag = New-AzPublicIpTag `
            -IpTagType "FirstPartyUsage" `
            -Tag "/Sql" `
            -FirstPartyServiceTagId $created.Id
        Assert-AreEqual $created.Id $ipTag.FirstPartyServiceTagId

    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}
