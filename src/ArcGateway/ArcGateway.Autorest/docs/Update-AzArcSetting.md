---
external help file:
Module Name: Az.ArcGateway
online version: https://learn.microsoft.com/powershell/module/az.arcgateway/update-azarcsetting
schema: 2.0.0
---

# Update-AzArcSetting

## SYNOPSIS
Patch the base Settings of the target resource.

## SYNTAX

### PatchExpanded (Default)
```
Update-AzArcSetting -BaseProvider <String> -BaseResourceName <String> -BaseResourceType <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-GatewayResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzArcSetting -BaseProvider <String> -BaseResourceName <String> -BaseResourceType <String>
 -ResourceGroupName <String> -Parameter <ISettings> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzArcSetting -InputObject <IArcGatewayIdentity> -Parameter <ISettings> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzArcSetting -InputObject <IArcGatewayIdentity> [-GatewayResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaJsonFilePath
```
Update-AzArcSetting -BaseProvider <String> -BaseResourceName <String> -BaseResourceType <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaJsonString
```
Update-AzArcSetting -BaseProvider <String> -BaseResourceName <String> -BaseResourceType <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch the base Settings of the target resource.

## EXAMPLES

### Example 1: Patch the base Settings of the target resource
```powershell
Update-AzArcSetting -ResourceGroupName "ytongtest" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BaseProvider "Microsoft.HybridCompute" -BaseResourceName "testmachine" -BaseResourceType "machines" -GatewayResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/gateways/myArcGateway"
```

```output
GatewayPropertyGatewayResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest/p
                                   roviders/Microsoft.HybridCompute/gateways/myArcGateway
Id                               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest/p
                                   roviders/Microsoft.HybridCompute/machines/testmachine/providers/Microsoft.Hybr
                                   idCompute/settings/default
Name                             : default
ResourceGroupName                : ytongtest
SystemDataCreatedAt              :
SystemDataCreatedBy              :
SystemDataCreatedByType          :
SystemDataLastModifiedAt         :
SystemDataLastModifiedBy         :
SystemDataLastModifiedByType     :
TenantId                         : 00000000-0000-0000-0000-000000000000
Type                             : Microsoft.HybridCompute/settings
```

Patch the base Settings of the target resource

## PARAMETERS

### -BaseProvider
The name of the base Resource Provider.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaseResourceName
The name of the base resource.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaseResourceType
The name of the base Resource Type.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
Aliases:

Required: True
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

### -GatewayResourceId
Associated Gateway Resource Id

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IArcGatewayIdentity
Parameter Sets: PatchViaIdentity, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Patch operation

```yaml
Type: System.String
Parameter Sets: PatchViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Patch operation

```yaml
Type: System.String
Parameter Sets: PatchViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ISettings
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IArcGatewayIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ISettings

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ISettings

## NOTES

## RELATED LINKS

