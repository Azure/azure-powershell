---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/test-azresiliencyrecoveryplanreprotectvalidation
schema: 2.0.0
---

# Test-AzResiliencyRecoveryPlanReprotectValidation

## SYNOPSIS
This action checks if the recovery orchestration plan is eligible for reprotect operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

## SYNTAX

### TestExpanded (Default)
```
Test-AzResiliencyRecoveryPlanReprotectValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Test
```
Test-AzResiliencyRecoveryPlanReprotectValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IReprotectRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### TestViaIdentity
```
Test-AzResiliencyRecoveryPlanReprotectValidation -InputObject <IResiliencyIdentity> -OperationId <String>
 -Body <IReprotectRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TestViaIdentityExpanded
```
Test-AzResiliencyRecoveryPlanReprotectValidation -InputObject <IResiliencyIdentity> -OperationId <String>
 [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityServiceGroup
```
Test-AzResiliencyRecoveryPlanReprotectValidation -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String> -Body <IReprotectRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityServiceGroupExpanded
```
Test-AzResiliencyRecoveryPlanReprotectValidation -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String>
 [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaJsonFilePath
```
Test-AzResiliencyRecoveryPlanReprotectValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### TestViaJsonString
```
Test-AzResiliencyRecoveryPlanReprotectValidation -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This action checks if the recovery orchestration plan is eligible for reprotect operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

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

### -Body
Reprotect post action request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IReprotectRequest
Parameter Sets: Test, TestViaIdentity, TestViaIdentityServiceGroup
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: TestViaIdentity, TestViaIdentityExpanded
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

### -RecoveryPlanName
The name of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded, TestViaIdentityServiceGroup, TestViaIdentityServiceGroupExpanded, TestViaJsonFilePath, TestViaJsonString
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
Parameter Sets: TestExpanded, TestViaIdentityExpanded, TestViaIdentityServiceGroupExpanded
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
Parameter Sets: TestViaIdentityServiceGroup, TestViaIdentityServiceGroupExpanded
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
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IReprotectRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IValidateForRecoveryOperationBaseResponse

## NOTES

## RELATED LINKS

