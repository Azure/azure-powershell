---
external help file: Az.DevCenterdata-help.xml
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenterdata/set-azdevcenteruserenvironment
schema: 2.0.0
---

# Set-AzDevCenterUserEnvironment

## SYNOPSIS
Creates or updates an environment.

## SYNTAX

### ReplaceExpanded (Default)
```
Set-AzDevCenterUserEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
 -CatalogName <String> -EnvironmentDefinitionName <String> -EnvironmentType <String>
 [-ExpirationDate <DateTime>] [-Parameter <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Replace
```
Set-AzDevCenterUserEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
 -Body <IEnvironment> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an environment.

## EXAMPLES

### EXAMPLE 1
```
{{ Add code here }}
```

### EXAMPLE 2
```
{{ Add code here }}
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

### -Body
Properties of an environment.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IEnvironment
Parameter Sets: Replace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of the catalog.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: True
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

### -EnvironmentDefinitionName
Name of the environment definition.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentType
Environment type.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationDate
The time the expiration date will be triggered (UTC), after which theenvironment and associated resources will be deleted.

```yaml
Type: System.DateTime
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the environment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EnvironmentName

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters object for the environment.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ReplaceExpanded
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IEnvironment
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IEnvironment
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

BODY \<IEnvironment\>: Properties of an environment.
  CatalogName \<String\>: Name of the catalog.
  DefinitionName \<String\>: Name of the environment definition.
  Type \<String\>: Environment type.
  \[Code \<String\>\]: One of a server-defined set of error codes.
  \[Detail \<IAzureCoreFoundationsError\[\]\>\]: An array of details about specific errors that led to this reported error.
    Code \<String\>: One of a server-defined set of error codes.
    Message \<String\>: A human-readable representation of the error.
    \[Detail \<IAzureCoreFoundationsError\[\]\>\]: An array of details about specific errors that led to this reported error.
    \[Innererror \<IAzureCoreFoundationsInnerError\>\]: An object containing more specific information than the current object about the error.
      \[Code \<String\>\]: One of a server-defined set of error codes.
      \[Innererror \<IAzureCoreFoundationsInnerError\>\]: Inner error.
    \[Target \<String\>\]: The target of the error.
  \[ExpirationDate \<DateTime?\>\]: The time the expiration date will be triggered (UTC), after which the         environment and associated resources will be deleted.
  \[Innererror \<IAzureCoreFoundationsInnerError\>\]: An object containing more specific information than the current object about the error.
  \[Message \<String\>\]: A human-readable representation of the error.
  \[OperationLocation \<String\>\]: 
  \[Parameter \<IEnvironmentParameters\>\]: Parameters object for the environment.
    \[(Any) \<Object\>\]: This indicates any property can be added to this object.
  \[Target \<String\>\]: The target of the error.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenterdata/set-azdevcenteruserenvironment](https://learn.microsoft.com/powershell/module/az.devcenterdata/set-azdevcenteruserenvironment)
