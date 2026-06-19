---
external help file:
Module Name: Az.PrivateTrafficManager
online version: https://learn.microsoft.com/powershell/module/az.privatetrafficmanager/update-azprivatetrafficmanagerprofile
schema: 2.0.0
---

# Update-AzPrivateTrafficManagerProfile

## SYNOPSIS
Update a Traffic Manager profile.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CustomTopologyMap <String>] [-DnsConfigRecordType <String>]
 [-DnsConfigTtl <Int64>] [-Endpoint <IProfileEndpoint[]>] [-ProfileStatus <String>] [-Tag <Hashtable>]
 [-TopologyMapId <String>] [-TrafficRoutingMethod <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPrivateTrafficManagerProfile -InputObject <IPrivateTrafficManagerIdentity>
 [-CustomTopologyMap <String>] [-DnsConfigRecordType <String>] [-DnsConfigTtl <Int64>]
 [-Endpoint <IProfileEndpoint[]>] [-ProfileStatus <String>] [-Tag <Hashtable>] [-TopologyMapId <String>]
 [-TrafficRoutingMethod <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Traffic Manager profile.

## EXAMPLES

### Example 1: Update the traffic routing method of a profile
```powershell
Update-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -TrafficRoutingMethod "Priority"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Priority             Enabled       Succeeded
```

This command updates the traffic routing method of the specified profile from Weighted to Priority.

### Example 2: Disable a Private Traffic Manager profile
```powershell
Update-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -ProfileStatus "Disabled"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Priority             Disabled      Succeeded
```

This command disables the specified Private Traffic Manager profile.

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerProfile

## NOTES

## RELATED LINKS

