---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/test-azdevcenteruserdevboxcustomizationtaskaction
schema: 2.0.0
---

# Test-AzDevCenterUserDevBoxCustomizationTaskAction

## SYNOPSIS
Validates a list of customization tasks.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint <String> -ProjectName <String>
 [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateExpandedByDevCenter
```
Test-AzDevCenterUserDevBoxCustomizationTaskAction -DevCenterName <String> -ProjectName <String>
 [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpandedByDevCenter
```
Test-AzDevCenterUserDevBoxCustomizationTaskAction -DevCenterName <String>
 -InputObject <IDevCenterdataIdentity> [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validates a list of customization tasks.

## EXAMPLES

### Example 1: Validate customization tasks by endpoint
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "System"
    TimeoutInSecond = 120
}
$tasks = @($task)
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -Task $tasks
```

This command validates the task "choco" by the endpoint.

### Example 2: Validate customization tasks by dev center
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "User"
    TimeoutInSecond = 120
}
$tasks = @($task)
Test-AzDevCenterUserDevBoxCustomizationTaskAction -DevCenterName Contoso -ProjectName DevProject -Task $tasks
```

This command validates the task "choco" by the dev center.

### Example 3: Validate customization tasks by endpoint and InputObject
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "System"
    TimeoutInSecond = 120
}
$tasks = @($task)
$taskInput = @{"ProjectName" = "DevProject" }
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $taskInput -Task $tasks
```

This command validates the task "choco" by the endpoint and InputObject.

### Example 4: Validate customization tasks by dev center and InputObject
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "System"
    TimeoutInSecond = 120
}
$tasks = @($task)
$taskInput = @{"ProjectName" = "DevProject" }
Test-AzDevCenterUserDevBoxCustomizationTaskAction -DevCenterName Contoso -InputObject $taskInput -Task $tasks
```

This command validates the task "choco" by the dev center and InputObject.

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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: ValidateExpandedByDevCenter, ValidateViaIdentityExpandedByDevCenter
Aliases: DevCenter

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: ValidateViaIdentityExpanded, ValidateViaIdentityExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Task
Tasks to apply.
To construct, see NOTES section for TASK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.ICustomizationTask[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

