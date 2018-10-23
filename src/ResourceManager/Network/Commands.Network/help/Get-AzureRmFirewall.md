---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 91D58F60-F22A-454A-B04C-E5AEF33E9D06
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermfirewall
schema: 2.0.0
---

# Get-AzureRmFirewall

## SYNOPSIS
Gets a Azure Firewall.

## SYNTAX

```
Get-AzureRmFirewall [-Name <String>] [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmFirewall** cmdlet gets one or more Firewalls in a resource group.

## EXAMPLES

### 1:  Retrieve all Firewalls in a resource group
```
Get-AzureRmFirewall -ResourceGroupName rgName
```

This example retrieves all Firewalls in resource group "rgName".

### 2:  Retrieve a Firewall by name
```
Get-AzureRmFirewall -ResourceGroupName rgName -Name azFw
```

This example retrieves Firewall named "azFw" in resource group "rgName".

### 3:  Retrieve a firewall and then add a application rule collection to the Firewall
```
$azFw=Get-AzureRmFirewall -Name "azFw" -ResourceGroupName "rgName"
$appRule = New-AzureRmFirewallApplicationRule -Name R1 -Protocol "http:80","https:443" -TargetFqdn "*google.com", "*microsoft.com" -SourceAddress "10.0.0.0"
$appRuleCollection = New-AzureRmFirewallApplicationRuleCollection -Name "MyAppRuleCollection" -Priority 100 -Rule $appRule -ActionType "Allow"
$azFw.AddApplicationRuleCollection($appRuleCollection)
```

This example retrieves a firewall, then adds a application rule collection to the firewall by calling method AddApplicationRuleCollection.

### 4:  Retrieve a firewall and then add a network rule collection to the Firewall
```
$azFw=Get-AzureRmFirewall -Name "azFw" -ResourceGroupName "rgName"
$netRule = New-AzureRmFirewallNetworkRule -Name "all-udp-traffic" -Description "Rule for all UDP traffic" -Protocol "Udp" -SourceAddress "*" -DestinationAddress "*" -DestinationPort "*"
$netRuleCollection = New-AzureRmFirewallNetworkRuleCollection -Name "MyNetworkRuleCollection" -Priority 100 -Rule $netRule -ActionType "Allow"
$azFw.AddNetworkRuleCollection($netRuleCollection)
```

This example retrieves a firewall, then adds a network rule collection to the firewall by calling method AddNetworkRuleCollection.

### 5:  Retrieve a firewall and then retrieve a application rule collection by name from the Firewall
```
$azFw=Get-AzureRmFirewall -Name "azFw" -ResourceGroupName "rgName"
$getAppRc=$azFw.GetApplicationRuleCollectionByName("MyAppRuleCollection")
```

This example retrieves a firewall and then gets a rule collection by name, calling method GetApplicationRuleCollectionByName on the 
firewall object. The rule collection name for method GetApplicationRuleCollectionByName is case-insensitive.

### 6:  Retrieve a firewall and then retrieve a network rule collection by name from the Firewall
```
$azFw=Get-AzureRmFirewall -Name "azFw" -ResourceGroupName "rgName"
$getNetRc=$azFw.GetNetworkRuleCollectionByName("MyNetworkRuleCollection")
```

This example retrieves a firewall and then gets a rule collection by name, calling method GetNetworkRuleCollectionByName on the 
firewall object. The rule collection name for method GetNetworkRuleCollectionByName is case-insensitive.

### 7:  Retrieve a firewall and then remove a application rule collection by name from the Firewall
```
$azFw=Get-AzureRmFirewall -Name "azFw" -ResourceGroupName "rgName"
$azFw.RemoveApplicationRuleCollectionByName("MyAppRuleCollection")
```

This example retrieves a firewall and then removes a rule collection by name, calling method RemoveApplicationRuleCollectionByName on the 
firewall object. The rule collection name for method RemoveApplicationRuleCollectionByName is case-insensitive.

### 8:  Retrieve a firewall and then remove a network rule collection by name from the Firewall
```
$azFw=Get-AzureRmFirewall -Name "azFw" -ResourceGroupName "rgName"
$azFw.RemoveNetworkRuleCollectionByName("MyNetworkRuleCollection")
```

This example retrieves a firewall and then removes a rule collection by name, calling method RemoveNetworkRuleCollectionByName on the 
firewall object. The rule collection name for method RemoveNetworkRuleCollectionByName is case-insensitive.

### 9:  Retrieve a firewall and then allocate the firewall
```
$vnet=Get-AzureRmVirtualNetwork -Name "vnet" -ResourceGroupName "rgName"
$publicIp=Get-AzureRmPublicIpAddress -Name "firewallpip" -ResourceGroupName "rgName"
$azFw=Get-AzureRmFirewall -Name "azFw" -ResourceGroupName "rgName"
$azFw.Allocate($vnet, $publicIp)
```

This example retrieves a firewall and calls Allocate on the firewall to start the firewall service using the configuration
(application and network rule collections) associated with the firewall.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the Firewall that this cmdlet gets.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that Firewall belongs to.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewall

## NOTES

## RELATED LINKS

[New-AzureRmFirewall](./New-AzureRmFirewall.md)

[Remove-AzureRmFirewall](./Remove-AzureRmFirewall.md)

[Set-AzureRmFirewall](./Set-AzureRmFirewall.md)
