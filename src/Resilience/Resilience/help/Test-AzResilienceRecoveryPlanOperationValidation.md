---
external help file: Az.Resilience-help.xml
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/test-azresiliencerecoveryplanoperationvalidation
schema: 2.0.0
---

# Test-AzResilienceRecoveryPlanOperationValidation

## SYNOPSIS
This action checks if the recovery orchestration plan is eligible for operations like failover and reprotect, ensuring it meets the necessary criteria.

## SYNTAX

### TestExpanded (Default)
```
Test-AzResilienceRecoveryPlanOperationValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -OperationName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TestViaJsonString
```
Test-AzResilienceRecoveryPlanOperationValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TestViaJsonFilePath
```
Test-AzResilienceRecoveryPlanOperationValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TestViaIdentityServiceGroupExpanded
```
Test-AzResilienceRecoveryPlanOperationValidation -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String> -OperationName <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### TestViaIdentityServiceGroup
```
Test-AzResilienceRecoveryPlanOperationValidation -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String> -Body <IValidateForOperationRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Test
```
Test-AzResilienceRecoveryPlanOperationValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IValidateForOperationRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TestViaIdentityExpanded
```
Test-AzResilienceRecoveryPlanOperationValidation -InputObject <IResilienceIdentity> -OperationId <String>
 -OperationName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TestViaIdentity
```
Test-AzResilienceRecoveryPlanOperationValidation -InputObject <IResilienceIdentity> -OperationId <String>
 -Body <IValidateForOperationRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This action checks if the recovery orchestration plan is eligible for operations like failover and reprotect, ensuring it meets the necessary criteria.

## EXAMPLES

### Example 1: Validate recovery plan operation validation
```powershell
Test-AzResilienceRecoveryPlanOperationValidation `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -OperationName 'Failover'
```

Checks whether the operation can proceed and reports qualified and unqualified resources.

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
ValidateForOperation post action request to check if operation can be performed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IValidateForOperationRequest
Parameter Sets: TestViaIdentityServiceGroup, Test, TestViaIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: TestViaIdentityExpanded, TestViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Test operation

```yaml
Type: System.String
Parameter Sets: TestViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Test operation

```yaml
Type: System.String
Parameter Sets: TestViaJsonString
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
Parameter Sets: TestExpanded, TestViaIdentityServiceGroupExpanded, TestViaIdentityExpanded
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
Parameter Sets: TestExpanded, TestViaJsonString, TestViaJsonFilePath, TestViaIdentityServiceGroupExpanded, TestViaIdentityServiceGroup, Test
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: TestViaIdentityServiceGroupExpanded, TestViaIdentityServiceGroup
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
Parameter Sets: TestExpanded, TestViaJsonString, TestViaJsonFilePath, Test
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IValidateForOperationRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IErrorResponse

## NOTES

## RELATED LINKS
