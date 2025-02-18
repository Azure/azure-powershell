---
external help file:
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/new-azdynatracemonitorssoconfig
schema: 2.0.0
---

# New-AzDynatraceMonitorSSOConfig

## SYNOPSIS
Create a DynatraceSingleSignOnResource

## SYNTAX

```
New-AzDynatraceMonitorSSOConfig -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AadDomain <String[]>] [-EnterpriseAppId <String>] [-SingleSignOnState <SingleSignOnStates>]
 [-SingleSignOnUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a DynatraceSingleSignOnResource

## EXAMPLES

### Example 1: Create a dynatrace SingleSignOn resource
```powershell
New-AzDynatraceMonitorSSOConfig -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -AadDomain "mpliftrlogz20210811outlook.onmicrosoft.com"
```

```output
Name    ProvisioningState SingleSignOnState SingleSignOnUrl
----    ----------------- ----------------- ---------------
default Succeeded         Initial
```

This command create a dynatrace SingleSignOn resource.

## PARAMETERS

### -AadDomain
array of Aad(azure active directory) domains

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -EnterpriseAppId
Version of the Dynatrace agent installed on the VM.

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

### -SingleSignOnState
State of Single Sign On

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.SingleSignOnStates
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnUrl
The login URL specific to this Dynatrace Environment

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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20210901.IDynatraceSingleSignOnResource

## NOTES

## RELATED LINKS

