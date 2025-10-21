---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/invoke-aznewrelicresubscribemonitor
schema: 2.0.0
---

# Invoke-AzNewRelicResubscribeMonitor

## SYNOPSIS
Resubscribes the New Relic Organization of the underlying Monitor Resource to be billed by Azure Marketplace

## SYNTAX

### ResubscribeExpanded (Default)
```
Invoke-AzNewRelicResubscribeMonitor -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-OfferId <String>] [-OrganizationId <String>] [-PlanId <String>]
 [-PublisherId <String>] [-ResourceGroup <String>] [-SubscriptionId1 <String>] [-TermId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResubscribeViaJsonString
```
Invoke-AzNewRelicResubscribeMonitor -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResubscribeViaJsonFilePath
```
Invoke-AzNewRelicResubscribeMonitor -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Resubscribe
```
Invoke-AzNewRelicResubscribeMonitor -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Body <IResubscribeProperties> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResubscribeViaIdentityExpanded
```
Invoke-AzNewRelicResubscribeMonitor [-SubscriptionId <String>] -InputObject <INewRelicIdentity>
 [-OfferId <String>] [-OrganizationId <String>] [-PlanId <String>] [-PublisherId <String>]
 [-ResourceGroup <String>] [-TermId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResubscribeViaIdentity
```
Invoke-AzNewRelicResubscribeMonitor -InputObject <INewRelicIdentity> -Body <IResubscribeProperties>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Resubscribes the New Relic Organization of the underline Monitor Resource to be billed by Azure Marketplace

## EXAMPLES

### Example 1: Resubscribe NewRelic monitor to Azure Marketplace billing
```powershell
Invoke-AzNewRelicResubscribeMonitor -MonitorName "test-01" -ResourceGroupName "ps-test" -OrganizationId "987654321" -PlanId "newrelicpaygtestplan3@123456789123456@PUBIDnewrelicinc1234567891234" -PublisherId "newrelicinc1234567891234" -OfferId "newrelic-pay-as-you-go"
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 10:45:30 AM    user1@outlook.com        User                         ps-test
```

Resubscribes the NewRelic organization to be billed through Azure Marketplace with a new plan

### Example 2: Resubscribe monitor using resubscribe properties object
```powershell
$resubscribeProps = @{
    OrganizationId = "987654321"
    PlanId = "newrelicpaygtestplan3@123456789123456@PUBIDnewrelicinc1234567891234"
    PublisherId = "newrelicinc1234567891234"
    OfferId = "newrelic-pay-as-you-go"
    TermId = "hjdtn7tfq3ka3"
    ResourceGroup = "ps-test-new"
    SubscriptionId = "22222222-3333-4444-5555-666666666666"
}
Invoke-AzNewRelicResubscribeMonitor -MonitorName "test-01" -ResourceGroupName "ps-test" -Body $resubscribeProps
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 10:45:30 AM    user1@outlook.com        User                         ps-test
```

Resubscribes the NewRelic monitor using a properties object containing all resubscription details including new subscription and resource group

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IResubscribeProperties
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
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

### -OfferId
Offer Id of the NewRelic offer that needs to be resubscribed

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

### -OrganizationId
Organization Id of the NewRelic Organization that needs to be resubscribed

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

### -PublisherId
Publisher Id of the NewRelic offer that needs to be resubscribed

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

```yaml
Type: System.String
Parameter Sets: ResubscribeExpanded, ResubscribeViaJsonString, ResubscribeViaJsonFilePath, Resubscribe, ResubscribeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId1
Newly selected Azure Subscription Id in which the new Marketplace subscription will be created for Resubscribe

```yaml
Type: System.String
Parameter Sets: ResubscribeExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermId
Newly selected term Id to create the new Marketplace subscription for Resubscribe

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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IResubscribeProperties

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicMonitorResource

## NOTES

## RELATED LINKS
