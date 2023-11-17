---
RFC: Parameter Flattening and Inline Creation
Author: Scott Phibbs
Status: Draft
SupersedeBy: None
Version: 1.0
Area: Across all commands that use configurations or complex types
---

# Flattening to simple parameter types for easy in-line creation
To improve consistency and simplify creation scenarios, users will no longer need to build configurations or complex types to create Azure Resources. Complex types will be flattened into multiple parameters of simple types. Return types will remain the same.

## Motivation

More consistency across Azure PowerShell commands is well known user feedback. While both flattening and Inline Creation improvements address the consistency concerns, let's focus more on the specific changes. Creating complex types prior to calling creation commands, whether that is by creating your own hashtable or calling a cmdlet to create an in memory complex object is a setup step that will no longer be necessary. We have made this possible by flattening complex types into simple type parameters. Using the Az 4.0 preview, you will be able to create or modify a resource using a single cmdlet execution. To demonstrate these changes, we will look at the generic resource creation command `New-AzResource` for flattened parameters and a Networking scenario that no longer needs pre created in-memory configurations.

## User Experience

`New-AzResource` is an example of where we have flattened `Hashtable` parameters into simple types. The `-Plan` and `-Sku` parameters are both examples of parameters that previously accepted a hashtable and have now been flattened. First, let's look at the `Plan` and `Sku` parameters for `New-AzResource` in `Az` 2.6.

```
New-AzResource
...
   [-Plan <Hashtable>]
   [-Sku <Hashtable>]
  ...
```

Before calling `New-AzResource`, you would need to create your own hashtable for either of these parameters. Here we have the code to create a Standard LRS storage account using the generic resource creation command:

```powershell
$sku = @{Name= "Standard_LRS"; Tier= "Standard" }
New-AzResource `
    -Name storageskuhash `
    -ResourceGroupName myResourceGroup `
    -ResourceType "Microsoft.Storage/storageAccounts" `
    -Sku $sku `
    -Kind "Storage" `
    -ApiVersion "2019-04-01" `
    -Location centralus
```

In `Az` 4.0 (Preview), we have flattened both `-Sku` and `-Plan` to the individual simple types expected in the hashtable. Here I have stripped down the help content to only show the new, flattened 'Sku' and 'Plan' parameters:

```
New-AzResource
    ...
    [-PlanName <String>]
    [-PlanProduct <String>]
    [-PlanPromotionCode <String>]
    [-PlanPublisher <String>]
    [-PlanVersion <String>]
    [-SkuCapacity <Int32>]
    [-SkuFamily <String>]
    [-SkuModel <String>]
    [-SkuName <String>]
    [-SkuSize <String>]
    [-SkuTier <String>]

```

With the flattened parameters, the new script would look like the following:

```powershell
New-AzResource `
    -Name storagesku `
    -ResourceGroupName myResourceGroup `
    -ProviderNamespace Microsoft.Storage `
    -ResourceType "storageAccounts" `
    -SkuName "Standard_LRS" `
    -SkuTier "Standard" `
    -Kind "Storage" `
    -ApiVersion "2019-04-01" `
    -Location centralus
```

Some Network cmdlets use in-memory models or configurations for sub-resources that are then passed to creation cmdlets. To align all creation scenarios, we have removed all in-memory model and configuration creation commands. In `Az` 4.0 (Preview) and beyond you will create all resources directly in Azure. A Subnet is a good example of this model as described in the [_Virtual Network Creation Quickstart_](https://learn.microsoft.com/en-us/azure/virtual-network/quick-create-powershell) document.

#### `Az` 2.x

**Create the virtual network**

Create a virtual network with the `New-AzVirtualNetwork` cmdlet. This example creates a default virtual network named "myVirtualNetwork" in the East US location:

```powershell
$virtualNetwork = New-AzVirtualNetwork `
    -ResourceGroupName myResourceGroup `
    -Location EastUS `
    -Name myVirtualNetwork `
    -AddressPrefix 10.0.0.0/16
```

**Add a subnet**

Azure deploys resources to a subnet within a virtual network, so you need to create a subnet. Create a subnet configuration named "default" with the `Add-AzVirtualNetworkSubnetConfig` cmdlet:

```powershell
$subnetConfig = Add-AzVirtualNetworkSubnetConfig `
    -Name default `
    -AddressPrefix 10.0.0.0/24 `
    -VirtualNetwork $virtualNetwork
```

**Associate the subnet to the virtual network**

You can write the subnet configuration to the virtual network with the `Set-AzVirtualNetwork` cmdlet. This command creates the subnet:

```powershell
$virtualNetwork | Set-AzVirtualNetwork
```

#### `Az` 4.0 (Preview)

Create the virtual network the same as `Az` 2.6

```powershell
$virtualNetwork = New-AzVirtualNetwork `
    -ResourceGroupName myResourceGroup `
    -Location EastUS `
    -Name myVirtualNetwork `
    -AddressPrefix 10.0.0.0/16

```

Now create the subnet directly and you're done:

```powershell
New-AzVnetSubnet -Name MySubnet `
    -ResourceGroupName myResourceGroup `
    -VnetName myVirtualNetwork `
    -AddressPrefix 10.0.2.0/24
```

You could use an array of hashtables and pass it to `-Subnet`, similar to using a the array of subnet configurations used in the Create Application Gateway - Powershell quickstart. [Required network resources](https://learn.microsoft.com/en-us/azure/application-gateway/quick-create-powershell). Here is the `Az` 2.6 script to setup a VirtualNetwork with 2 subnets:

#### `Az` 2.6

```powershell
$agSubnetConfig = New-AzVirtualNetworkSubnetConfig `
    -Name myAGSubnet `
    -AddressPrefix 10.0.1.0/24
$backendSubnetConfig = New-AzVirtualNetworkSubnetConfig `
    -Name myBackendSubnet `
    -AddressPrefix 10.0.2.0/24
New-AzVirtualNetwork `
    -ResourceGroupName myResourceGroup `
    -Location eastus `
    -Name myVNet `
    -AddressPrefix 10.0.0.0/16 `
    -Subnet $agSubnetConfig, $backendSubnetConfig
```

With the new model of creating resources inline, you can replace the configuration step with an array of hashtable (_note_: see model flattening for more details). Here we have the property `AddressPrefix` to differentiate the VNet address prefix with subnet address prefix. Future releases can rename the flattened property here as subnet address prefix.

#### `Az` 4.0 (Preview)
```powershell
$agSubnetConfig = @{ Name= "myAGSubnet"; PropertiesAddressPrefix = "10.0.1.0/24" }
$backendSubnetConfig = @{ Name= "myBackendSubnet"; PropertiesAddressPrefix = "10.0.2.0/24" }
$vn1 = New-AzVirtualNetwork `
    -Name myvnet `
    -ResourceGroupName myResourceGroup `
    -location centralus `
    -AddressPrefix 10.0.0.0/16 `
    -Subnet $agSubnetConfig, $backendSubnetConfig
```
## Comments and Questions
Add your comments and questions about the proposed change
