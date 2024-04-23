---
external help file: Az.DynatraceObservability-help.xml
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/get-azdynatracemonitorvmhostpayload
schema: 2.0.0
---

# Get-AzDynatraceMonitorVMHostPayload

## SYNOPSIS
Returns the payload that needs to be passed in the request body for installing Dynatrace agent on a VM.

## SYNTAX

```
Get-AzDynatraceMonitorVMHostPayload -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the payload that needs to be passed in the request body for installing Dynatrace agent on a VM.

## EXAMPLES

### Example 1: Get the payload that needs to be passed in the request body for installing Dynatrace agent on a VM
```powershell
Get-AzDynatraceMonitorVMHostPayload -ResourceGroupName dyobrg -MonitorName dyob-pwsh01
```

```output
EnvironmentId IngestionKey
------------- ------------
ihx78752      dt0c01.C3A5JBXDZ4C3SCZDRBJ3D23I.xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This coammnd gets the payload that needs to be passed in the request body for installing Dynatrace agent on a VM.

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

### -MonitorName
Monitor resource name

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

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20210901.IVMExtensionPayload

## NOTES

## RELATED LINKS
