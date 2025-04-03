---
external help file: Az.DynatraceObservability-help.xml
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/get-azdynatracemonitorssoconfig
schema: 2.0.0
---

# Get-AzDynatraceMonitorSSOConfig

## SYNOPSIS
Get a DynatraceSingleSignOnResource

## SYNTAX

### Get (Default)
```
Get-AzDynatraceMonitorSSOConfig -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDynatraceMonitorSSOConfig -InputObject <IDynatraceObservabilityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DynatraceSingleSignOnResource

## EXAMPLES

### Example 1: Get a dynatrace SingleSignOn resource
```powershell
Get-AzDynatraceMonitorSSOConfig -ResourceGroupName dyobrg -MonitorName dyob-pwsh01
```

```output
Name    ResourceGroupName ProvisioningState SingleSignOnState SingleSignOnUrl
----    ----------------- ----------------- ----------------- ---------------
default dyobrg            Succeeded         Initial
```

This command gets a dynatrace SingleSignOn resource.

### Example 2: Get a dynatrace SingleSignOn resource by pipeline
```powershell
New-AzDynatraceMonitorSSOConfig -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -AadDomain "mpliftrlogz20210811outlook.onmicrosoft.com" | Get-AzDynatraceMonitorSSOConfig
```

```output
Name    ResourceGroupName ProvisioningState SingleSignOnState SingleSignOnUrl
----    ----------------- ----------------- ----------------- ---------------
default dyobrg            Succeeded         Initial
```

This command gets a dynatrace SingleSignOn resource by pipeline.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20230427.IDynatraceSingleSignOnResource

## NOTES

## RELATED LINKS
