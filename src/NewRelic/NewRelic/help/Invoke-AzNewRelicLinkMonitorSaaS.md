---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/invoke-aznewreliclinkmonitorsaas
schema: 2.0.0
---

# Invoke-AzNewRelicLinkMonitorSaaS

## SYNOPSIS
Links a new SaaS to the newrelic organization of the underlying monitor.

## SYNTAX

### LinkExpanded (Default)
```
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-SaaSResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaJsonString
```
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaJsonFilePath
```
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Link
```
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Body <ISaaSData> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaIdentityExpanded
```
Invoke-AzNewRelicLinkMonitorSaaS -InputObject <INewRelicIdentity> [-SaaSResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### LinkViaIdentity
```
Invoke-AzNewRelicLinkMonitorSaaS -InputObject <INewRelicIdentity> -Body <ISaaSData>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Links a new SaaS to the newrelic organization of the underlying monitor.

## EXAMPLES

### Example 1: Link a SaaS resource to a NewRelic monitor
```powershell
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName "test-01" -ResourceGroupName "ps-test" -SaaSResourceId "/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-saas/providers/Microsoft.SaaS/resources/newrelic-saas-01"
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 9:15:20 AM     user1@outlook.com        User                         ps-test
```

Links a new SaaS resource to the NewRelic monitor organization

### Example 2: Link SaaS resource using a SaaS data object
```powershell
$saasData = @{
    SaaSResourceId = "/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-saas/providers/Microsoft.SaaS/resources/newrelic-saas-01"
}
Invoke-AzNewRelicLinkMonitorSaaS -MonitorName "test-01" -ResourceGroupName "ps-test" -Body $saasData
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 9:15:20 AM     user1@outlook.com        User                         ps-test
```

Links a SaaS resource to the NewRelic monitor using a data object containing the SaaS resource ID

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ISaaSData
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
Parameter Sets: LinkViaIdentityExpanded, LinkViaIdentity
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
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
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
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
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
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ISaaSData

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicMonitorResource

## NOTES

## RELATED LINKS
