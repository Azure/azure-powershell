---
external help file:
Module Name: Az.Migrate
online version: https://docs.microsoft.com/en-us/powershell/module/az.migrate/new-azmigrateassessment
schema: 2.0.0
---

# New-AzMigrateAssessment

## SYNOPSIS
Create a new assessment with the given name and the specified settings.
Since name of an assessment in a project is a unique identifier, if an assessment with the name provided already exists, then the existing assessment is updated.\n\nAny PUT operation, resulting in either create or update on an assessment, will cause the assessment to go in a \"InProgress\" state.
This will be indicated by the field 'computationState' on the Assessment object.
During this time no other PUT operation will be allowed on that assessment object, nor will a Delete operation.
Once the computation for the assessment is complete, the field 'computationState' will be updated to 'Ready', and then other PUT or DELETE operations can happen on the assessment.\n\nWhen assessment is under computation, any PUT will lead to a 400 - Bad Request error.\n

## SYNTAX

```
New-AzMigrateAssessment -GroupName <String> -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -AzureDiskType <AzureDiskType> -AzureHybridUseBenefit <AzureHybridUseBenefit> -AzureLocation <AzureLocation>
 -AzureOfferCode <AzureOfferCode> -AzurePricingTier <AzurePricingTier>
 -AzureStorageRedundancy <AzureStorageRedundancy> -AzureVMFamily <AzureVMFamily[]> -Currency <Currency>
 -DiscountPercentage <Double> -Percentile <Percentile> -ReservedInstance <ReservedInstance>
 -ScalingFactor <Double> -SizingCriterion <AssessmentSizingCriterion> -Stage <AssessmentStage>
 -TimeRange <TimeRange> [-SubscriptionId <String>] [-AcceptLanguage <String>] [-ETag <String>]
 [-VMUptimeDaysPerMonth <Single>] [-VMUptimeHoursPerDay <Single>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new assessment with the given name and the specified settings.
Since name of an assessment in a project is a unique identifier, if an assessment with the name provided already exists, then the existing assessment is updated.\n\nAny PUT operation, resulting in either create or update on an assessment, will cause the assessment to go in a \"InProgress\" state.
This will be indicated by the field 'computationState' on the Assessment object.
During this time no other PUT operation will be allowed on that assessment object, nor will a Delete operation.
Once the computation for the assessment is complete, the field 'computationState' will be updated to 'Ready', and then other PUT or DELETE operations can happen on the assessment.\n\nWhen assessment is under computation, any PUT will lead to a 400 - Bad Request error.\n

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AcceptLanguage
Standard request header.
Used by service to respond to client in appropriate language.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureDiskType
Storage type selected for this disk.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AzureDiskType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureHybridUseBenefit
AHUB discount on windows virtual machines.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AzureHybridUseBenefit
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureLocation
Target Azure location for which the machines should be assessed.
These enums are the same as used by Compute API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AzureLocation
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureOfferCode
Offer code according to which cost estimation is done.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AzureOfferCode
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzurePricingTier
Pricing tier for Size evaluation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AzurePricingTier
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureStorageRedundancy
Storage Redundancy type offered by Azure.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AzureStorageRedundancy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureVMFamily
List of azure VM families.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AzureVMFamily[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Currency
Currency to report prices in.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.Currency
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DiscountPercentage
Custom discount percentage to be applied on final costs.
Can be in the range [0, 100].

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ETag
For optimistic concurrency control.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GroupName
Unique name of a group within a project.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Unique name of an assessment within a project.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AssessmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Percentile
Percentile of performance data used to recommend Azure size.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.Percentile
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProjectName
Name of the Azure Migrate project.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ReservedInstance
Azure reserved instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ReservedInstance
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the Azure Resource Group that project is part of.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScalingFactor
Scaling factor used over utilization data to add a performance buffer for new machines to be created in Azure.
Min Value = 1.0, Max value = 1.9, Default = 1.3.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SizingCriterion
Assessment sizing criterion.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AssessmentSizingCriterion
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Stage
User configurable setting that describes the status of the assessment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AssessmentStage
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Azure Subscription Id in which project was created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TimeRange
Time range of performance data used to recommend a size.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TimeRange
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMUptimeDaysPerMonth
Number of days in a month for VM uptime.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMUptimeHoursPerDay
Number of hours per day for VM uptime.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20191001.IAssessment

## ALIASES

## NOTES

## RELATED LINKS

