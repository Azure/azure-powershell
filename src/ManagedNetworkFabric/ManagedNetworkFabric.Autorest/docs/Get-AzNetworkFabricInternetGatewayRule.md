---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricinternetgatewayrule
schema: 2.0.0
---

# Get-AzNetworkFabricInternetGatewayRule

## SYNOPSIS
Gets an Internet Gateway Rule resource.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricInternetGatewayRule [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricInternetGatewayRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricInternetGatewayRule -InputObject <IManagedNetworkFabricIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricInternetGatewayRule -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an Internet Gateway Rule resource.

## EXAMPLES

### Example 1: List Internet Gateway Rules by Subscription
```powershell
Get-AzNetworkFabricInternetGatewayRule -SubscriptionId $subscriptionId
```

```output
Location    Name                          SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy      SystemDataLastModifiedByType
--------    ----                          ------------------- -------------------        ----------------------- ------------------------ ------------------------      ----
eastus2euap nfcfab3-4-1-GF1-infra-system  09/21/2023 08:47:10 <identity>                 Application             09/21/2023 08:47:22      <identity>                    App…
eastus2euap nfa-tool-ts-GA-IGwRule081023  08/10/2023 11:05:30 <identity>                 User                    09/04/2023 15:35:53      <identity>                    App…
eastus2euap nfcfab1-4-1-BF-infra-system   09/22/2023 02:33:21 <identity>                 Application             09/22/2023 02:33:29      <identity>                    App…
eastus      controller092123-infra-system 09/21/2023 12:14:52 <identity>                 Application             09/21/2023 12:15:03      <identity>                    App…
```

This command lists all the Internet Gateway Rules under the given Subscription.

### Example 2: List Internet Gateway Rules by Resource Group
```powershell
Get-AzNetworkFabricInternetGatewayRule -ResourceGroupName $resourceGroupName
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/InternetGatewayRules/controller092123…
```

This command lists all the Internet Gateway Rules under the given Resource Group.

### Example 3: Get Internet Gateway Rule
```powershell
Get-AzNetworkFabricInternetGatewayRule -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/InternetGatewayRules/controller092123…
```

This command gets details of the given Internet Gateway Rule.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Internet Gateway rule.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: InternetGatewayRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternetGatewayRule

## NOTES

## RELATED LINKS

