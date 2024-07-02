---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricinternetgateway
schema: 2.0.0
---

# Get-AzNetworkFabricInternetGateway

## SYNOPSIS
Implements Gateway GET method.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricInternetGateway [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricInternetGateway -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricInternetGateway -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricInternetGateway -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements Gateway GET method.

## EXAMPLES

### Example 1: List Internet Gateways by Subscription
```powershell
Get-AzNetworkFabricInternetGateway -SubscriptionId $subscriptionId
```

```output
Location    Name                              SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                              ------------------- -------------------     ----------------------- ------------------------ ------------------------
eastus2euap nfcfab3-4-1-GF1-infra             09/21/2023 08:44:39 <identity>              Application             09/21/2023 08:44:39      <identity>
eastus2euap nfcfab3-4-1-GF1-workload          09/21/2023 08:47:24 <identity>              Application             09/21/2023 08:47:24      <identity>
eastus2euap nfa-tool-ts-GA-nfc071323-infra    07/13/2023 09:51:13 <identity>              Application             07/13/2023 09:51:13      <identity>
eastus2euap nfa-tool-ts-GA-nfc071323-workload 07/13/2023 09:54:56 <identity>              Application             07/13/2023 09:54:56      <identity>
eastus2euap nfa-tool-ts-GA-nfc081023-infra    08/10/2023 06:59:49 <identity>              Application             09/04/2023 15:35:58      <identity>
eastus2euap nfa-tool-ts-GA-nfc081023-workload 08/10/2023 07:03:49 <identity>              Application             08/10/2023 07:03:49      <identity>
eastus2euap nfcfab1-4-1-BF-infra              09/22/2023 02:30:51 <identity>              Application             09/22/2023 02:30:51      <identity>
eastus2euap nfcfab1-4-1-BF-workload           09/22/2023 02:33:32 <identity>              Application             09/22/2023 02:33:32      <identity>
eastus      controller092123-infra            09/21/2023 12:11:48 <identity>              Application             09/22/2023 11:42:50      <identity>
eastus      controller092123-workload         09/21/2023 12:15:05 <identity>              Application             09/21/2023 12:15:05      <identity>
```

This command lists all the Internet Gateways under the given Subscription.

### Example 2: List Internet Gateways by Resource Group
```powershell
Get-AzNetworkFabricInternetGateway -ResourceGroupName $resourceGroupName
```

```output
Location Name                      SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy      SystemDataLastModifiedByType
-------- ----                      ------------------- -------------------     ----------------------- ------------------------ ------------------------      -----------
eastus   controller092123-infra    09/21/2023 12:11:48 <identity>              Application             09/22/2023 11:42:50      <identity>                    User
eastus   controller092123-workload 09/21/2023 12:15:05 <identity>              Application             09/21/2023 12:15:05      <identity>                    Application
```

This command lists all the Internet Gateways under the given Resource Group.

### Example 3: Get Internet Gateway
```powershell
Get-AzNetworkFabricInternetGateway -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/internetGateways/controller092123-inf…
```

This command gets details of the given Internet Gateway.

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
Name of the Internet Gateway.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: InternetGatewayName

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternetGateway

## NOTES

## RELATED LINKS

