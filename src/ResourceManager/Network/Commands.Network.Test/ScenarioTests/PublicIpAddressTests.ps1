﻿# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Tests creating new simple publicIpAddress.
#>
function Test-PublicIpAddressCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres
      $job = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel -AsJob
      $job | Wait-Job
	  $actual = $job | Receive-Job
	  $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqual "Dynamic" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.ResourceGuid
      Assert-AreEqual "Succeeded" $expected.ProvisioningState
      Assert-AreEqual $domainNameLabel $expected.DnsSettings.DomainNameLabel
      
      # list
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName  
      Assert-AreEqual $list[0].Name $actual.Name    
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqual "Dynamic" $list[0].PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $list[0].ProvisioningState
      Assert-AreEqual $domainNameLabel $list[0].DnsSettings.DomainNameLabel
      
      # delete
      $job = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
	  $job | Wait-Job
	  $delete = $job | Receive-Job
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple publicIpAddress without DomainNameLabel.
#>
function Test-PublicIpAddressCRUD-NoDomainNameLabel
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $expected.Name $actual.Name   
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqual "Dynamic" $expected.PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $expected.ProvisioningState

      # list
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName  
      Assert-AreEqual $list[0].Name $actual.Name    
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqual "Dynamic" $list[0].PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $list[0].ProvisioningState

      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple publicIpAddress with Static allocation.
#>
function Test-PublicIpAddressCRUD-StaticAllocation
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Static
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $expected.Name $actual.Name   
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqual "Static" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.IpAddress
      Assert-AreEqual "Succeeded" $expected.ProvisioningState

      # list
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName  
      Assert-AreEqual $list[0].Name $actual.Name    
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqual "Static" $list[0].PublicIpAllocationMethod
      Assert-NotNull $list[0].IpAddress
      Assert-AreEqual "Succeeded" $list[0].ProvisioningState

      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests edit the domain name label of a publicIpAddress.
#>
function Test-PublicIpAddressCRUD-EditDomainNameLavel
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $newDomainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
      $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $publicip.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $publicip.Name $actual.Name   
      Assert-AreEqual $publicip.Location $actual.Location
      Assert-AreEqual "Dynamic" $publicip.PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $publicip.ProvisioningState
      Assert-AreEqual $domainNameLabel $publicip.DnsSettings.DomainNameLabel
      
      $publicip.DnsSettings.DomainNameLabel = $newDomainNameLabel

      # Set publicIpAddress
      $job = $publicip | Set-AzureRmPublicIpAddress -AsJob
      $job | Wait-Job

      $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $newDomainNameLabel $publicip.DnsSettings.DomainNameLabel
      
      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests edit the domain name label of a publicIpAddress.
#>
function Test-PublicIpAddressCRUD-ReverseFqdn
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
      $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $publicip.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $publicip.Name $actual.Name   
      Assert-AreEqual $publicip.Location $actual.Location
      Assert-AreEqual "Dynamic" $publicip.PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $publicip.ProvisioningState
      Assert-AreEqual $domainNameLabel $publicip.DnsSettings.DomainNameLabel
      
      $publicip.DnsSettings.ReverseFqdn = $publicip.DnsSettings.Fqdn

      # Set publicIpAddress
      $publicip | Set-AzureRmPublicIpAddress

      $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $publicip.DnsSettings.Fqdn $publicip.DnsSettings.ReverseFqdn
      
      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests edit the domain name label of a publicIpAddress with Iptags
#>
function Test-PublicIpAddressCRUD-IpTag
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent

    try
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      $IpTag = New-AzureRmPublicIpTag -IpTagType "FirstPartyUsage" -Tag "/Sql"

      Assert-AreEqual $IpTag.IpTagType "FirstPartyUsage"
      Assert-AreEqual $IpTag.Tag "/Sql"

      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel -IpTag $IpTag
      $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $publicip.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $publicip.Name $actual.Name
      Assert-AreEqual $publicip.Location $actual.Location
      Assert-AreEqual "Dynamic" $publicip.PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $publicip.ProvisioningState
      Assert-AreEqual $domainNameLabel $publicip.DnsSettings.DomainNameLabel

      # Set publicIpAddress
      $publicip | Set-AzureRmPublicIpAddress

      $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual "FirstPartyUsage" $publicip.IpTags.IpTagType
      Assert-AreEqual "/Sql" $publicip.IpTags.Tag

      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete

      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new publicIpAddress with IpVersion.
#>
function Test-PublicIpAddressIpVersion
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rname1 = Get-ResourceName
    $rname2 = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres with default ipversion
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $expected.Name $actual.Name   
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqual "Dynamic" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.ResourceGuid
      Assert-AreEqual "Succeeded" $expected.ProvisioningState
      Assert-AreEqual $domainNameLabel $expected.DnsSettings.DomainNameLabel
      Assert-AreEqual $expected.PublicIpAddressVersion IPv4
      
      # list
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName  
      Assert-AreEqual $list[0].Name $actual.Name    
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqual "Dynamic" $list[0].PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $list[0].ProvisioningState
      Assert-AreEqual $domainNameLabel $list[0].DnsSettings.DomainNameLabel
      Assert-AreEqual $list[0].PublicIpAddressVersion IPv4

      # Create publicIpAddres with IPv4 ipversion
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname1 -location $location -AllocationMethod Dynamic -IpAddressVersion IPv4
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname1
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $expected.Name $actual.Name   
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqual "Dynamic" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.ResourceGuid
      Assert-AreEqual "Succeeded" $expected.ProvisioningState      
      Assert-AreEqual $expected.PublicIpAddressVersion IPv4
      
      # Create publicIpAddres with IPv6 ipversion
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname2 -location $location -AllocationMethod Dynamic -IpAddressVersion IPv6
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname2
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $expected.Name $actual.Name   
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqual "Dynamic" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.ResourceGuid
      Assert-AreEqual "Succeeded" $expected.ProvisioningState      
      Assert-AreEqual $expected.PublicIpAddressVersion IPv6

      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete

      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname1 -PassThru -Force
      Assert-AreEqual true $delete

      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname2 -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Get-NameById($Id, $ResourceType)
{
    $name = $Id.Substring($Id.IndexOf($ResourceType + '/') + $ResourceType.Length + 1);
    if ($name.IndexOf('/') -ne -1)
    {
        $name = $name.Substring(0, $name.IndexOf('/'));
    }
    return $name;
}

<#
.SYNOPSIS
Tests checking VMSSPublicIP features.
#>
function Test-PublicIpAddressVmss
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Compute/virtualMachineScaleSets"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        . ".\AzureRM.Resources.ps1"

        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        $vmssName = "vmssip"
        $templateFile = (Resolve-Path ".\ScenarioTests\Data\VmssDeploymentTemplate.json").Path
        New-AzureRmResourceGroupDeployment -Name $rgname -ResourceGroupName $rgname -TemplateFile $templateFile;

        $listAllResults = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -VirtualMachineScaleSetName $vmssName;
        Assert-NotNull $listAllResults;

        $listFirstResultId = $listAllResults[0].Id;
        $vmIndex = Get-NameById $listFirstResultId "virtualMachines";
        $nicName = Get-NameById $listFirstResultId "networkInterfaces";
        $ipConfigName = Get-NameById $listFirstResultId "ipConfigurations";
        $ipName = Get-NameById $listFirstResultId "publicIPAddresses";

        $listResults = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -VirtualMachineScaleSetName $vmssName -VirtualmachineIndex $vmIndex -NetworkInterfaceName $nicName -IpConfigurationName $ipConfigName;
        Assert-NotNull $listResults;
        Assert-AreEqualObjectProperties $listAllResults[0] $listResults[0] "List and list all results should contain equal items";

        $vmssIp = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -VirtualMachineScaleSetName $vmssName -VirtualmachineIndex $vmIndex -NetworkInterfaceName $nicName -IpConfigurationName $ipConfigName -Name $ipName;
        Assert-NotNull $vmssIp;
        Assert-AreEqualObjectProperties $vmssIp $listResults[0] "List and get results should contain equal items";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple publicIpAddress.
#>
function Test-PublicIpAddressCRUD-BasicSku
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel -Sku Basic
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName 
      Assert-AreEqual $expected.Name $actual.Name   
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqualObjectProperties $expected.Sku $actual.Sku
      Assert-AreEqual "Dynamic" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.ResourceGuid
      Assert-AreEqual "Succeeded" $expected.ProvisioningState
      Assert-AreEqual $domainNameLabel $expected.DnsSettings.DomainNameLabel
      
      # list
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName  
      Assert-AreEqual $list[0].Name $actual.Name    
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqualObjectProperties $list[0].Sku $actual.Sku
      Assert-AreEqual "Dynamic" $list[0].PublicIpAllocationMethod
      Assert-AreEqual "Succeeded" $list[0].ProvisioningState
      Assert-AreEqual $domainNameLabel $list[0].DnsSettings.DomainNameLabel
      
      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple publicIpAddress with Static allocation.
#>
function Test-PublicIpAddressCRUD-StandardSku
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Static -Sku Standard -DomainNameLabel $domainNameLabel
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $expected.Name $actual.Name
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqualObjectProperties $expected.Sku $actual.Sku
      Assert-AreEqual "Static" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.IpAddress
      Assert-AreEqual "Succeeded" $expected.ProvisioningState

      # list
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $list[0].Name $actual.Name
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqualObjectProperties $list[0].Sku $actual.Sku
      Assert-AreEqual "Static" $list[0].PublicIpAllocationMethod
      Assert-NotNull $list[0].IpAddress
      Assert-AreEqual "Succeeded" $list[0].ProvisioningState

      # delete
      $delete = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple publicIpAddress.
#>
function Test-PublicIpAddressZones
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $zones = "1";
    $rglocation = Get-ProviderLocation ResourceManagement
    # TODO: replace hardcoded location
    # $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = "centralus"; # = Get-ProviderLocation $resourceTypeParent

    try
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

      # Create publicIpAddres
      $actual = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname -location $location -AllocationMethod Dynamic -Zone $zones;
      $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $expected.Name $actual.Name
      Assert-AreEqual $expected.Location $actual.Location
      Assert-AreEqual "Dynamic" $expected.PublicIpAllocationMethod
      Assert-NotNull $expected.ResourceGuid
      Assert-AreEqual "Succeeded" $expected.ProvisioningState
      Assert-AreEqual $zones $expected.Zones[0]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
