---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/invoke-azdatadogresubscribeorganization
schema: 2.0.0
---

# Invoke-AzDatadogResubscribeOrganization

## SYNOPSIS
Reinstate integration with your Datadog organization by choosing one of the available subscription plans.

## SYNTAX

### ResubscribeExpanded (Default)
```
Invoke-AzDatadogResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AzureSubscriptionId <String>] [-ResourceGroup <String>] [-SkuName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResubscribeViaJsonString
```
Invoke-AzDatadogResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResubscribeViaJsonFilePath
```
Invoke-AzDatadogResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Resubscribe
```
Invoke-AzDatadogResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Body <IResubscribeProperties> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResubscribeViaIdentityExpanded
```
Invoke-AzDatadogResubscribeOrganization -InputObject <IDatadogIdentity> [-AzureSubscriptionId <String>]
 [-ResourceGroup <String>] [-SkuName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResubscribeViaIdentity
```
Invoke-AzDatadogResubscribeOrganization -InputObject <IDatadogIdentity> -Body <IResubscribeProperties>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Reinstate integration with your Datadog organization by choosing one of the available subscription plans.

## EXAMPLES

### Example 1: Resubscribe using the default plan
```powershell
Invoke-AzDatadogResubscribeOrganization -MonitorName datadodmonitor01 -ResourceGroupName datadog-rg
```

```output
Object of Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20250611.DatadogMonitorResource
```

Resubscribed to datadog using the default plan.

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

### -AzureSubscriptionId
Newly selected Azure Subscription Id in which the new Marketplace subscription will be created for Resubscribe

```yaml
Type: System.String
Parameter Sets: ResubscribeExpanded, ResubscribeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Resubscribe Properties

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IResubscribeProperties
Parameter Sets: Resubscribe, ResubscribeViaIdentity
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
Parameter Sets: ResubscribeViaIdentityExpanded, ResubscribeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Resubscribe operation

```yaml
Type: System.String
Parameter Sets: ResubscribeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Resubscribe operation

```yaml
Type: System.String
Parameter Sets: ResubscribeViaJsonString
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
Parameter Sets: ResubscribeExpanded, ResubscribeViaJsonString, ResubscribeViaJsonFilePath, Resubscribe
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

### -ResourceGroup
Newly selected Azure resource group in which the new Marketplace subscription will be created for Resubscribe

```yaml
Type: System.String
Parameter Sets: ResubscribeExpanded, ResubscribeViaIdentityExpanded
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
Parameter Sets: ResubscribeExpanded, ResubscribeViaJsonString, ResubscribeViaJsonFilePath, Resubscribe
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the SKU in {PlanId} format.
For Terraform, the only allowed value is 'Linked'.

```yaml
Type: System.String
Parameter Sets: ResubscribeExpanded, ResubscribeViaIdentityExpanded
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
Parameter Sets: ResubscribeExpanded, ResubscribeViaJsonString, ResubscribeViaJsonFilePath, Resubscribe
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IResubscribeProperties

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogMonitorResource

## NOTES

## RELATED LINKS
