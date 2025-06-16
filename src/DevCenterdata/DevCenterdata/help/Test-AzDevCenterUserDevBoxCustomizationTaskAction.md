---
external help file: Az.DevCenterdata-help.xml
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenterdata/test-azdevcenteruserdevboxcustomizationtaskaction
schema: 2.0.0
---

# Test-AzDevCenterUserDevBoxCustomizationTaskAction

## SYNOPSIS
Validates a list of customization tasks.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint <String> -ProjectName <String>
 [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Validates a list of customization tasks.

## EXAMPLES

### EXAMPLE 1
```
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

### EXAMPLE 2
```
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

### EXAMPLE 3
```
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

### EXAMPLE 4
```
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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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

### -Endpoint
The DevCenter-specific URI to operate on.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: ValidateViaIdentityExpanded
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.ICustomizationTask[]
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
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IDevCenterdataIdentity\>: Identity Parameter
  \[ActionName \<String\>\]: The name of the action.
  \[AddOnName \<String\>\]: Name of the dev box addon.
  \[CatalogName \<String\>\]: Name of the catalog.
  \[CustomizationGroupName \<String\>\]: Name of the customization group.
  \[CustomizationTaskId \<String\>\]: A customization task ID.
  \[DefinitionName \<String\>\]: Name of the environment definition.
  \[DevBoxName \<String\>\]: Display name for the Dev Box.
  \[EnvironmentName \<String\>\]: Environment name.
  \[EnvironmentTypeName \<String\>\]: Name of the environment type.
  \[Id \<String\>\]: Resource identity path
  \[ImageBuildLogId \<String\>\]: An imaging build log id.
  \[OperationId \<String\>\]: Unique identifier for the Dev Box operation.
  \[PoolName \<String\>\]: Pool name.
  \[ProjectName \<String\>\]: Name of the project.
  \[ScheduleName \<String\>\]: Display name for the Schedule.
  \[SnapshotId \<String\>\]: The id of the snapshot.
Should be treated as opaque string.
  \[TaskName \<String\>\]: Full name of the task: {catalogName}/{taskName}.
  \[UserId \<String\>\]: The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

TASK \<ICustomizationTask\[\]\>: Tasks to apply.
  Name \<String\>: Name of the task.
  \[DisplayName \<String\>\]: Display name to help differentiate multiple instances of the same task.
  \[Parameter \<ICustomizationTaskParameters\>\]: Parameters for the task.
    \[(Any) \<String\>\]: This indicates any property can be added to this object.
  \[RunAs \<CustomizationTaskExecutionAccount?\>\]: What account to run the task as.
  \[TimeoutInSecond \<Int32?\>\]: Timeout, in seconds.
Overrides any timeout provided on the task definition.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenterdata/test-azdevcenteruserdevboxcustomizationtaskaction](https://learn.microsoft.com/powershell/module/az.devcenterdata/test-azdevcenteruserdevboxcustomizationtaskaction)
