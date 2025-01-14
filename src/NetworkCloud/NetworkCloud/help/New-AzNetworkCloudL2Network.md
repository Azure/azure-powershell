---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudl2network
schema: 2.0.0
---

# New-AzNetworkCloudL2Network

## SYNOPSIS
Create a new layer 2 (L2) network or update the properties of the existing network.

## SYNTAX

```
New-AzNetworkCloudL2Network -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -ExtendedLocationName <String> -ExtendedLocationType <String> -L2IsolationDomainId <String> -Location <String>
 [-HybridAksPluginType <HybridAksPluginType>] [-InterfaceName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new layer 2 (L2) network or update the properties of the existing network.

## EXAMPLES

### Example 1: Create Layer 2 (L2) network
```powershell
New-AzNetworkCloudL2Network -Name l2Network -ResourceGroupName resourceGroupName -ExtendedLocationName "/subscriptions/subscriptionId/resourcegroups/resourceGroupName/providers/microsoft.extendedlocation/customlocations/customLocationsName" -ExtendedLocationType "CustomLocation" -L2IsolationDomainId  "/subscriptions/fabricsubs/resourceGroups/resourceGroupName/providers/Microsoft.NetworkFabric/L2IsolationDomains/L2IsolationDomainsName" -Location  eastus -HybridAksPluginType  "DPDK" -InterfaceName "eth0" -Tag @{tags = "tag1" } -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----       ------------------- -------------------      ----------------------- ------------------------ ------------------------  ---------------------------- ----                              -------------------
eastus   l2Network 05/25/2023 05:36:37  user1                    User                    05/25/2023 05:36:48      app1                      Application                  microsoft.networkcloud/l2networks
```

This command creates a new layer 2 (L2) network.

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
The default interface name for this L2 network in the virtual machine.
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

### -L2IsolationDomainId
The resource ID of the Network Fabric l2IsolationDomain.

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
The name of the L2 network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: L2NetworkName

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL2Network

## NOTES

## RELATED LINKS
