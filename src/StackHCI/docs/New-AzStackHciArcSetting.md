---
external help file:
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/new-azstackhciarcsetting
schema: 2.0.0
---

# New-AzStackHciArcSetting

## SYNOPSIS
Create ArcSetting for HCI cluster.

## SYNTAX

```
New-AzStackHciArcSetting -ClusterName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create ArcSetting for HCI cluster.

## EXAMPLES

### Example 1:
```powershell
New-AzStackHciArcSetting -ResourceGroupName "test-rg" -ClusterName "myCluster"
```

```output
Name    ResourceGroupName
----    -----------------
default test-rg
```

This command creates arcSetting for a HCI cluster.
The only arcSetting name allowed is "default" and that is provided by default.

## PARAMETERS

### -ClusterName
The name of the cluster.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Name
The name of the proxy resource holding details of HCI ArcSetting information.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ArcSettingName

Required: False
Position: Named
Default value: "default"
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20210901.IArcSetting

## NOTES

ALIASES

## RELATED LINKS

