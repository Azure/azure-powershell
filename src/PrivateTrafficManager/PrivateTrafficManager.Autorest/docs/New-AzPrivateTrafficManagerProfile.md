---
external help file:
Module Name: Az.PrivateTrafficManager
online version: https://learn.microsoft.com/powershell/module/az.privatetrafficmanager/new-azprivatetrafficmanagerprofile
schema: 2.0.0
---

# New-AzPrivateTrafficManagerProfile

## SYNOPSIS
Create a Private Traffic Manager profile.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-CustomTopologyMap <String>] [-DnsConfigRecordType <String>]
 [-DnsConfigTtl <Int64>] [-Endpoint <IProfileEndpoint[]>] [-ProfileStatus <String>] [-Tag <Hashtable>]
 [-TopologyMapId <String>] [-TrafficRoutingMethod <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a Private Traffic Manager profile.

## EXAMPLES

### Example 1: Create a Private Traffic Manager profile with weighted routing
```powershell
New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Location "global" -TrafficRoutingMethod "Weighted" -ProfileStatus "Enabled" -DnsConfigRecordType "CNAME" -DnsConfigTtl 60 -Tag @{environment="test"; team="networking"}
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Weighted             Enabled       Succeeded
```

This command creates a new Private Traffic Manager profile with weighted traffic routing, CNAME DNS record type, and a TTL of 60 seconds.

### Example 2: Create a Private Traffic Manager profile with a topology map
```powershell
New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "priority-profile" -ResourceGroupName "demo-rg" -Location "global" -TrafficRoutingMethod "Priority" -ProfileStatus "Enabled" -CustomTopologyMap "Enable" -TopologyMapId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-ptm-demo/providers/Microsoft.Network/topologyMaps/ptm-topology-demo"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
priority-profile  global   Priority             Enabled       Succeeded
```

This command creates a Private Traffic Manager profile with priority-based routing and associates it with an existing topology map.

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

### -CustomTopologyMap
The experience level of the Private Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -DnsConfigRecordType
The record type of the Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsConfigTtl
The TTL of the DNS records in seconds.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The list of endpoints in the Private Traffic Manager profile.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IProfileEndpoint[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded
Aliases:

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

### -PrivateTrafficManagerProfileName
The name of the Private Traffic Manager profile.

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

### -ProfileStatus
The status of the Private Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopologyMapId
The ARM resource ID of the topology map which has site(s) associated with this probing gateway.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficRoutingMethod
The traffic routing method of the Private Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerProfile

## NOTES

## RELATED LINKS

