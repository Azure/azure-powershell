---
external help file: Az.DevCenterdata-help.xml
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenterdata/skip-azdevcenteruserenvironmentaction
schema: 2.0.0
---

# Skip-AzDevCenterUserEnvironmentAction

## SYNOPSIS
Skips an occurrence of an action.

## SYNTAX

### Skip (Default)
```
Skip-AzDevCenterUserEnvironmentAction -Endpoint <String> -EnvironmentName <String> -Name <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SkipViaIdentity
```
Skip-AzDevCenterUserEnvironmentAction -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Skips an occurrence of an action.

## EXAMPLES

### EXAMPLE 1
```
Skip-AzDevCenterUserEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -Name "myEnvironment-Delete"
```

### EXAMPLE 2
```
Skip-AzDevCenterUserEnvironmentAction -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject -Name "myEnvironment-Delete"
```

### EXAMPLE 3
```
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "myEnvironment-Delete"}
Skip-AzDevCenterUserEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $environmentInput
```

### EXAMPLE 4
```
$environmentInput = @{"EnvironmentName" = "myEnvironment"; "UserId" = "me"; "ProjectName" = "DevProject"; "ActionName" = "myEnvironment-Delete"}
Skip-AzDevCenterUserEnvironmentAction -DevCenterName Contoso -InputObject $environmentInput
```

## PARAMETERS

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

### -EnvironmentName
Environment name.

```yaml
Type: System.String
Parameter Sets: Skip
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
Parameter Sets: SkipViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Uniquely identifies the action.

```yaml
Type: System.String
Parameter Sets: Skip
Aliases: ActionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
Name of the project.

```yaml
Type: System.String
Parameter Sets: Skip
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

```yaml
Type: System.String
Parameter Sets: Skip
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

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenterdata/skip-azdevcenteruserenvironmentaction](https://learn.microsoft.com/powershell/module/az.devcenterdata/skip-azdevcenteruserenvironmentaction)
