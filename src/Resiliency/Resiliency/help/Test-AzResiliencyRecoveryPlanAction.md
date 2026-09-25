---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/test-azresiliencyrecoveryplanaction
schema: 2.0.0
---

# Test-AzResiliencyRecoveryPlanAction

## SYNOPSIS
This action checks if the recovery orchestration plan is eligible for failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> [-ExecutionConfigurationUserConsent <String>]
 [-FailoverRequestPropertySelectedResourceId <String[]>] [-FailoverRequestPropertySourceLocation <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded1
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -OperationName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded2
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded3
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> [-ExecutionConfigurationUserConsent <String>]
 [-FailoverRequestPropertySelectedResourceId <String[]>] [-FailoverRequestPropertySourceLocation <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzResiliencyRecoveryPlanAction -InputObject <IResiliencyIdentity> -OperationId <String>
 [-ExecutionConfigurationUserConsent <String>] [-FailoverRequestPropertySelectedResourceId <String[]>]
 [-FailoverRequestPropertySourceLocation <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded1
```
Test-AzResiliencyRecoveryPlanAction -InputObject <IResiliencyIdentity> -OperationId <String>
 -OperationName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpanded2
```
Test-AzResiliencyRecoveryPlanAction -InputObject <IResiliencyIdentity> -OperationId <String>
 [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded3
```
Test-AzResiliencyRecoveryPlanAction -InputObject <IResiliencyIdentity> -OperationId <String>
 [-ExecutionConfigurationUserConsent <String>] [-FailoverRequestPropertySelectedResourceId <String[]>]
 [-FailoverRequestPropertySourceLocation <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityServiceGroupExpanded
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupInputObject <IResiliencyIdentity>
 -OperationId <String> [-ExecutionConfigurationUserConsent <String>]
 [-FailoverRequestPropertySelectedResourceId <String[]>] [-FailoverRequestPropertySourceLocation <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityServiceGroupExpanded1
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupInputObject <IResiliencyIdentity>
 -OperationId <String> -OperationName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityServiceGroupExpanded2
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupInputObject <IResiliencyIdentity>
 -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityServiceGroupExpanded3
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupInputObject <IResiliencyIdentity>
 -OperationId <String> [-ExecutionConfigurationUserConsent <String>]
 [-FailoverRequestPropertySelectedResourceId <String[]>] [-FailoverRequestPropertySourceLocation <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonFilePath
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonFilePath1
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonFilePath2
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonFilePath3
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonString
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonString1
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonString2
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonString3
```
Test-AzResiliencyRecoveryPlanAction -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This action checks if the recovery orchestration plan is eligible for failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -ExecutionConfigurationUserConsent
User consent for performing recovery action.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded3, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded3, ValidateViaIdentityServiceGroupExpanded, ValidateViaIdentityServiceGroupExpanded3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverRequestPropertySelectedResourceId
Selected recovery resource Ids to be processed.
If not provided, all qualified resources based on the source location(s) will be processed.

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateExpanded3, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded3, ValidateViaIdentityServiceGroupExpanded, ValidateViaIdentityServiceGroupExpanded3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverRequestPropertySourceLocation
Source locations from where resources to be failed-over.

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateExpanded3, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded3, ValidateViaIdentityServiceGroupExpanded, ValidateViaIdentityServiceGroupExpanded3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1, ValidateViaIdentityExpanded2, ValidateViaIdentityExpanded3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonFilePath, ValidateViaJsonFilePath1, ValidateViaJsonFilePath2, ValidateViaJsonFilePath3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonString, ValidateViaJsonString1, ValidateViaJsonString2, ValidateViaJsonString3
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

### -OperationId
A GUID that represents the Long Running OperationId.

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

### -OperationName
Operation Name to validate.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1, ValidateViaIdentityServiceGroupExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlanName
The name of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateExpanded2, ValidateExpanded3, ValidateViaIdentityServiceGroupExpanded, ValidateViaIdentityServiceGroupExpanded1, ValidateViaIdentityServiceGroupExpanded2, ValidateViaIdentityServiceGroupExpanded3, ValidateViaJsonFilePath, ValidateViaJsonFilePath1, ValidateViaJsonFilePath2, ValidateViaJsonFilePath3, ValidateViaJsonString, ValidateViaJsonString1, ValidateViaJsonString2, ValidateViaJsonString3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReprotectRequestPropertySelectedResourceId
Selected recovery resource Ids to be processed.
If not provided, all qualified resources will be processed.

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded2, ValidateViaIdentityExpanded2, ValidateViaIdentityServiceGroupExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: ValidateViaIdentityServiceGroupExpanded, ValidateViaIdentityServiceGroupExpanded1, ValidateViaIdentityServiceGroupExpanded2, ValidateViaIdentityServiceGroupExpanded3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateExpanded2, ValidateExpanded3, ValidateViaJsonFilePath, ValidateViaJsonFilePath1, ValidateViaJsonFilePath2, ValidateViaJsonFilePath3, ValidateViaJsonString, ValidateViaJsonString1, ValidateViaJsonString2, ValidateViaJsonString3
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IErrorResponse

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IValidateForRecoveryOperationBaseResponse

## NOTES

## RELATED LINKS

