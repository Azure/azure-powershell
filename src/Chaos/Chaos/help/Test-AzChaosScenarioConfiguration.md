---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/test-azchaosscenarioconfiguration
schema: 2.0.0
---

# Test-AzChaosScenarioConfiguration

## SYNOPSIS
Validate the given scenario configuration.

## SYNTAX

### Validate (Default)
```
Test-AzChaosScenarioConfiguration -Name <String> -ResourceGroupName <String> -ScenarioName <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzChaosScenarioConfiguration -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityScenario
```
Test-AzChaosScenarioConfiguration -Name <String> -ScenarioInputObject <IChaosIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityWorkspace
```
Test-AzChaosScenarioConfiguration -Name <String> -ScenarioName <String> -WorkspaceInputObject <IChaosIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate the given scenario configuration.

## EXAMPLES

### Example 1: Validate a scenario configuration
```powershell
Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

Runs a pre-flight validation of the `default` scenario configuration.
Validation reports errors without starting a run and stores a terminal validation record that you can read later with `Get-AzChaosScenarioConfigurationValidation`.

### Example 2: Validate a scenario configuration and branch on the result
```powershell
$validation = Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
if ($validation.Status -eq 'Succeeded') {
    Write-Host 'The scenario configuration is valid.'
} else {
    Write-Host "Validation returned '$($validation.Status)'."
    $validation.ValidationErrorPermission | Format-List ResourceId, MissingPermission, RecommendedRole
}
```

```output
Validation returned 'RequiresAttention'.

ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm
MissingPermission : {Microsoft.Compute/virtualMachines/powerOff/action, Microsoft.Compute/virtualMachines/start/action}
RecommendedRole   : {9980e02c-c2be-4d73-94e8-173b1dc7cf3c}
```

Branches on the returned validation record.
The command returns a validation object, not a boolean, so test `Status` explicitly &mdash; testing the object itself is always true and would treat a failed validation as a success.
A terminal status of `Succeeded` means the configuration is ready to run; `RequiresAttention` means the errors on `ValidationErrorPermission` and `ValidationErrorResource` must be resolved first.
To re-read this record later, call `Get-AzChaosScenarioConfigurationValidation`.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the scenario definition.

```yaml
Type: System.String
Parameter Sets: Validate, ValidateViaIdentityScenario, ValidateViaIdentityWorkspace
Aliases: ScenarioConfigurationName

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
Parameter Sets: Validate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScenarioInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: ValidateViaIdentityScenario
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ScenarioName
Name of the scenario.

```yaml
Type: System.String
Parameter Sets: Validate, ValidateViaIdentityWorkspace
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
Type: System.String
Parameter Sets: Validate
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: ValidateViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
String that represents a Workspace resource name.

```yaml
Type: System.String
Parameter Sets: Validate
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IValidation

## NOTES

## RELATED LINKS

