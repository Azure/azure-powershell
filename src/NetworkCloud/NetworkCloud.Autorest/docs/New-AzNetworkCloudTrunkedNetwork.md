---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudtrunkednetwork
schema: 2.0.0
---

# New-AzNetworkCloudTrunkedNetwork

## SYNOPSIS
Create a new trunked network or update the properties of the existing trunked network.

## SYNTAX

```
New-AzNetworkCloudTrunkedNetwork -Name <String> -ResourceGroupName <String> -ExtendedLocationName <String>
 -ExtendedLocationType <String> -IsolationDomainId <String[]> -Location <String> -Vlan <Int64[]>
 [-SubscriptionId <String>] [-HybridAksPluginType <HybridAksPluginType>] [-InterfaceName <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new trunked network or update the properties of the existing trunked network.

## EXAMPLES

### Example 1: Create trunked network
```powershell
New-AzNetworkCloudTrunkedNetwork -Name trunkedNetworkName -ResourceGroupName trunkedNetworkRg -SubscriptionId subscriptionId -ExtendedLocationName extendedLocationName -ExtendedLocationType "CustomLocation" -Location location -Vlan vlans -IsolationDomainId isolationDomainId -InterfaceName interfaceName -Tag @{ tag = "tag" }
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity>
```

This command creates a trunked network.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The extended location type, for example, CustomLocation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HybridAksPluginType
Field Deprecated.
The field was previously optional, now it will have no defined behavior and will be ignored.
The network plugin type for Hybrid AKS.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.HybridAksPluginType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InterfaceName
The default interface name for this trunked network in the virtual machine.
This name can be overridden by the name supplied in the network attachment configuration of that virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsolationDomainId
The list of resource IDs representing the Network Fabric isolation domains.
It can be any combination of l2IsolationDomain and l3IsolationDomain resources.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the trunked network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TrunkedNetworkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vlan
The list of vlans that are selected from the isolation domains for trunking.

```yaml
Type: System.Int64[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ITrunkedNetwork

## NOTES

## RELATED LINKS

