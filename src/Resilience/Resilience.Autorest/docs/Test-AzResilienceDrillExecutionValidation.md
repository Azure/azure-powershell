---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/test-azresiliencedrillexecutionvalidation
schema: 2.0.0
---

# Test-AzResilienceDrillExecutionValidation

## SYNOPSIS
This returns eligible resource to be faulted or failed over.

## SYNTAX

### TestExpanded (Default)
```
Test-AzResilienceDrillExecutionValidation -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 [-ValidateForExecutionPropertyOperationName <String>]
 [-ValidateForExecutionPropertySourceLocation <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Test
```
Test-AzResilienceDrillExecutionValidation -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -Body <IValidateForExecutionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TestViaIdentity
```
Test-AzResilienceDrillExecutionValidation -InputObject <IResilienceIdentity> -OperationId <String>
 -Body <IValidateForExecutionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TestViaIdentityExpanded
```
Test-AzResilienceDrillExecutionValidation -InputObject <IResilienceIdentity> -OperationId <String>
 [-ValidateForExecutionPropertyOperationName <String>]
 [-ValidateForExecutionPropertySourceLocation <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityServiceGroup
```
Test-AzResilienceDrillExecutionValidation -DrillName <String> -ServiceGroupInputObject <IResilienceIdentity>
 -OperationId <String> -Body <IValidateForExecutionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityServiceGroupExpanded
```
Test-AzResilienceDrillExecutionValidation -DrillName <String> -ServiceGroupInputObject <IResilienceIdentity>
 -OperationId <String> [-ValidateForExecutionPropertyOperationName <String>]
 [-ValidateForExecutionPropertySourceLocation <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaJsonFilePath
```
Test-AzResilienceDrillExecutionValidation -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TestViaJsonString
```
Test-AzResilienceDrillExecutionValidation -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
This returns eligible resource to be faulted or failed over.

## EXAMPLES

### Example 1: Validate drill execution validation
```powershell
Test-AzResilienceDrillExecutionValidation `
  -DrillName 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ValidateForExecutionPropertySourceLocation @('eastus')
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
Request body of the Validate For Execute Action of Drill.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IValidateForExecutionRequest
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

### -DrillName
The name of the Drill

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
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

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
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

### -ValidateForExecutionPropertyOperationName
Operation name for which the validation is being done.
This is needed to determine the set of validations to be done for the operation.

```yaml
Type: System.String
Parameter Sets: TestExpanded, TestViaIdentityExpanded, TestViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateForExecutionPropertySourceLocation
Physiscal Source locations from where resources to be failed-over or faulted.

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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IValidateForExecutionRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IValidateForExecutionResponse

## NOTES

## RELATED LINKS

