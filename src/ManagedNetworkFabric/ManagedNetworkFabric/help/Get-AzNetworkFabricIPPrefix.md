---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricipprefix
schema: 2.0.0
---

# Get-AzNetworkFabricIPPrefix

## SYNOPSIS
Implements IP Prefix GET method.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricIPPrefix [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricIPPrefix -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricIPPrefix -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricIPPrefix -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Implements IP Prefix GET method.

## EXAMPLES

### Example 1: List IpPrefixes by Subscription
```powershell
Get-AzNetworkFabricIPPrefix -SubscriptionId $subscriptionId
```

```output
Location    Name                          SystemDataCreatedAt SystemDataCreatedBy         SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType
--------    ----                          ------------------- -------------------         ----------------------- ------------------------ ------------------------    ----
eastus2euap ipprefixName1                 09/21/2023 07:48:48 <identity>                  User                    09/21/2023 10:41:48      <identity>                  App…
eastus2euap ipprefixName2                 09/21/2023 07:49:54 <identity>                  User                    09/21/2023 10:41:49      <identity>                  App…
eastus2euap ipprefix-v4-egress            09/21/2023 10:41:49 <identity>                  Application             09/21/2023 10:42:14      <identity>                  App…
eastus2euap ipprefix-v6-egress            09/21/2023 10:42:31 <identity>                  Application             09/22/2023 07:00:56      <identity>                  User
eastus2euap ipprefix-v4-ingress           09/21/2023 10:43:12 <identity>                  Application             09/22/2023 06:28:13      <identity>                  User
eastus2euap ipprefix-v6-ingress           09/21/2023 10:43:54 <identity>                  Application             09/21/2023 10:44:24      <identity>                  App…
eastus      ipprefixName                  09/21/2023 13:37:56 <identity>                  User                    09/22/2023 07:32:58      <identity>                  App…
eastus      ipPrefix092523                09/25/2023 07:36:13 <identity>                  User                    09/25/2023 07:36:13      <identity>                  User
```

This command lists all the IpPrefixes under the given Subscription.

### Example 2: List IpPrefixes by Resource Group
```powershell
Get-AzNetworkFabricIPPrefix -ResourceGroupName $resourceGroupName
```

```output
Location Name           SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType ResourceGroupName
-------- ----           ------------------- -------------------        ----------------------- ------------------------ ------------------------    ---------------------------- ---
eastus   ipprefixName   09/21/2023 13:37:56 <identity>                 User                    09/22/2023 07:32:58      <identity>                  Application                  nf…
eastus   ipPrefix092523 09/25/2023 07:36:13 <identity>                 User                    09/25/2023 07:36:13      <identity>                  User                         nf…
```

This command lists all the IpPrefixes under the given Resource Group.

### Example 3: Get IpPrefix
```powershell
Get-AzNetworkFabricIPPrefix -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command gets details of the given IpPrefix.

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
Name of the IP Prefix.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: IPPrefixName

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
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IIPPrefix

## NOTES

## RELATED LINKS
