<#
.SYNOPSIS
Tests Managed Service Identity UserAssignedIdentities CRUD.
#>
function Test-CrudUserAssignedIdentity
{
    $MSINamespace = "Microsoft.ManagedIdentity";
    $MSIResourceType = "userAssignedIdentities";
    $MSIPreferredLocation = "westus";
    $rgName1 = getAssetName;
    $rgName2 = getAssetName;
    $identityName1 = getAssetName;
    $identityName2 = getAssetName;
    $identityName3 = getAssetName;
    $location = Get-Location -ProviderNamespace $MSINamespace -ResourceType $MSIResourceType -PreferredLocation $MSIPreferredLocation;
    $identityType = "$MSINamespace/$MSIResourceType";

    try
    {
        #Create Resource Group 1
        New-AzureRmResourceGroup -Name $rgName1 -Location $location;
        #Create Resource Group 2
        New-AzureRmResourceGroup -Name $rgName2 -Location $location;

        #Create Identity1 under Resource Group 1
        $identity1 = New-AzureRmUserAssignedIdentity -ResourceGroupName $rgName1 -Name $identityName1;
        Assert-AreEqual $identity1.ResourceGroupName $rgName1
        Assert-AreEqual $identity1.Name $identityName1;
        Assert-AreEqual $identity1.Type $identityType;

        #Create Identity2 under Resource Group 2
        $identity2 = New-AzureRmUserAssignedIdentity -ResourceGroupName $rgName2 -Name $identityName2 -Location $location;
        Assert-AreEqual $identity2.ResourceGroupName $rgName2;
        Assert-AreEqual $identity2.Name $identityName2;
        Assert-AreEqual $identity2.Type $identityType;

        #Create Identity3 under Resource Group 2 as Job
        $createJob = New-AzureRmUserAssignedIdentity -ResourceGroupName $rgName2 -Name $identityName3 -Location $location -AsJob;
        $createJob | Wait-Job;
        $identity3 = $createJob | Receive-Job;
        Assert-AreEqual $identity3.ResourceGroupName $rgName2;
        Assert-AreEqual $identity3.Name $identityName3;
        Assert-AreEqual $identity3.Type $identityType;

        #Get Identity 1
        $identity1 = Get-AzureRmUserAssignedIdentity -ResourceGroupName $rgName1 -Name $identityName1
        Assert-NotNull $identity1;
        Assert-AreEqual $identity1.ResourceGroupName $rgName1;
        Assert-AreEqual $identity1.Name $identityName1;
        Assert-AreEqual $identity1.Type $identityType;

        #Get identities under ResourceGroup 1
        $identities = Get-AzureRmUserAssignedIdentity -ResourceGroupName $rgName1
        Assert-AreEqual $identities.Count 1
        Assert-AreEqual $identities[0].ResourceGroupName $rgName1;
        Assert-AreEqual $identities[0].Name $identityName1;
        Assert-AreEqual $identities[0].Type $identityType;

        #Get identities under ResourceGroup 2
        $identities = Get-AzureRmUserAssignedIdentity -ResourceGroupName $rgName2
        Assert-AreEqual $identities.Count 2

        #Delete Identity1
        Remove-AzureRmUserAssignedIdentity -ResourceGroupName $rgName1 -Name $identityName1 -Force;
        $resourceGroupIdentities = Get-AzureRmUserAssignedIdentity -ResourceGroupName $rgName1
        Assert-Null $resourceGroupIdentities;

        #Delete Identity2 as Job
        $deleteJob = Remove-AzureRmUserAssignedIdentity -ResourceGroupName $rgName2 -Name $identityName2 -AsJob -Force;
        $deleteJob | Wait-Job;
        $resourceGroupIdentities = Get-AzureRmUserAssignedIdentity -ResourceGroupName $rgName2
        Assert-AreEqual $resourceGroupIdentities.Count 1
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $rgname1 -Force
        Remove-AzureRmResourceGroup -Name $rgname1 -Force
    }
}