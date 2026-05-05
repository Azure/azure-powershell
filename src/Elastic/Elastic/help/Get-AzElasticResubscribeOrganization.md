---
external help file: Az.Elastic-help.xml
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelasticresubscribeorganization
schema: 2.0.0
---

# Get-AzElasticResubscribeOrganization

## SYNOPSIS
Resubscribe the Elasticsearch Organization.

## SYNTAX

### ResubscribeExpanded (Default)
```
Get-AzElasticResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-OrganizationId <String>] [-PlanId <String>] [-ResourceGroup <String>]
 [-TargetSubscriptionId <String>] [-Term <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### ResubscribeViaJsonString
```
Get-AzElasticResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### ResubscribeViaJsonFilePath
```
Get-AzElasticResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### Resubscribe
```
Get-AzElasticResubscribeOrganization -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -Body <IResubscribeProperties> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### ResubscribeViaIdentityExpanded
```
Get-AzElasticResubscribeOrganization -InputObject <IElasticIdentity> [-OrganizationId <String>]
 [-PlanId <String>] [-ResourceGroup <String>] [-TargetSubscriptionId <String>] [-Term <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### ResubscribeViaIdentity
```
Get-AzElasticResubscribeOrganization -InputObject <IElasticIdentity> -Body <IResubscribeProperties>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

## DESCRIPTION
Resubscribe the Elasticsearch Organization.

## EXAMPLES

### Example 1: Resubscribe an Elastic organization to a new Azure subscription
```powershell
Get-AzElasticResubscribeOrganization -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -TargetSubscriptionId "87654321-4321-4321-4321-210987654321"
```

```output
Id                   : /subscriptions/87654321-4321-4321-4321-210987654321/resourceGroups/myResourceGroup/providers/Microsoft.Elastic/monitors/myElasticMonitor/resubscribe
Name                 : myElasticMonitor
Type                 : Microsoft.Elastic/monitors/resubscribe
Status               : InProgress
TargetSubscriptionId : 87654321-4321-4321-4321-210987654321
Message              : Resubscription initiated successfully
```

This command resubscribes the specified Elastic monitor to a new Azure subscription, moving the marketplace subscription to the target subscription.

### Example 2: Resubscribe using pipeline from Get-AzElasticMonitor
```powershell
Get-AzElasticMonitor -ResourceGroupName "myResourceGroup" -Name "myElasticMonitor" | Get-AzElasticResubscribeOrganization -TargetSubscriptionId "87654321-4321-4321-4321-210987654321"
```

```output
Id                   : /subscriptions/87654321-4321-4321-4321-210987654321/resourceGroups/myResourceGroup/providers/Microsoft.Elastic/monitors/myElasticMonitor/resubscribe
Name                 : myElasticMonitor
Type                 : Microsoft.Elastic/monitors/resubscribe
Status               : InProgress
TargetSubscriptionId : 87654321-4321-4321-4321-210987654321
Message              : Resubscription initiated successfully
```

This command resubscribes an Elastic monitor to a new subscription by piping the monitor object from Get-AzElasticMonitor.

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
Resubscribe Properties

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IResubscribeProperties
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
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

### -OrganizationId
Organization Id of the Elastic Organization that needs to be resubscribed

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

### -PlanId
Newly selected plan Id to create the new Marketplace subscription for Resubscribe

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: ResubscribeExpanded, ResubscribeViaJsonString, ResubscribeViaJsonFilePath, Resubscribe
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSubscriptionId
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

### -Term
Newly selected term to create the new Marketplace subscription for Resubscribe

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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IResubscribeProperties

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticMonitorResource

## NOTES

## RELATED LINKS
