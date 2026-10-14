---
external help file:
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/invoke-azdatadoglinkdatadogmonitorresourcesaas
schema: 2.0.0
---

# Invoke-AzDatadogLinkDatadogMonitorResourceSaaS

## SYNOPSIS
Links a new SaaS to the Datadog organization of the underlying monitor.

## SYNTAX

### LinkExpanded (Default)
```
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-SaaSResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Link
```
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -MonitorName <String> -ResourceGroupName <String>
 -Body <ISaaSData> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentity
```
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -InputObject <IDatadogIdentity> -Body <ISaaSData>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentityExpanded
```
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -InputObject <IDatadogIdentity> [-SaaSResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaJsonFilePath
```
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -MonitorName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaJsonString
```
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -MonitorName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Links a new SaaS to the Datadog organization of the underlying monitor.

## EXAMPLES

### Example 1: Link a SaaS to the monitor's Datadog organization
```powershell
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -SaaSResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.SaaS/resources/mySaaSResource"
```

```output
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command links a new SaaS to the Datadog organization of the underlying monitor.
The SaaS resource id specifies the SaaS resource to link.

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

### -Body
SaaS details

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ISaaSData
Parameter Sets: Link, LinkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: LinkViaIdentity, LinkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
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
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SaaSResourceId
SaaS resource id

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaIdentityExpanded
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
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ISaaSData

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogMonitorResource

## NOTES

## RELATED LINKS

