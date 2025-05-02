---
external help file:
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/get-azdatadogtagrule
schema: 2.0.0
---

# Get-AzDatadogTagRule

## SYNOPSIS
Get a tag rule set for a given monitor resource.

## SYNTAX

### List (Default)
```
Get-AzDatadogTagRule -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDatadogTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDatadogTagRule -InputObject <IDatadogIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityMonitor
```
Get-AzDatadogTagRule -MonitorInputObject <IDatadogIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: List all tag rules set for a given monitor resource
```powershell
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command lists all tag rules set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource
```powershell
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource.

### Example 3: Get a tag rule set for a given monitor resource by pipeline
```powershell
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | Get-AzDatadogTagRule
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command gets a tag rule set for a given monitor resource by pipeline.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: GetViaIdentityMonitor
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Rule set name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityMonitor
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoringTagRules

## NOTES

## RELATED LINKS

