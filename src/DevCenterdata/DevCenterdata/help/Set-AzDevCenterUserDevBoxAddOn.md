---
external help file: Az.DevCenterdata-help.xml
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenterdata/set-azdevcenteruserdevboxaddon
schema: 2.0.0
---

# Set-AzDevCenterUserDevBoxAddOn

## SYNOPSIS
Creates a Dev Box addon.

## SYNTAX

### ReplaceExpanded (Default)
```
Set-AzDevCenterUserDevBoxAddOn -Endpoint <String> -AddOnName <String> -DevBoxName <String>
 -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Replace
```
Set-AzDevCenterUserDevBoxAddOn -Endpoint <String> -AddOnName <String> -DevBoxName <String>
 -ProjectName <String> [-UserId <String>] -Body <IDevBoxAddOn> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a Dev Box addon.

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

### -AddOnName
The name of the Dev Box addon.

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
A Dev Box addon.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IDevBoxAddOn
Parameter Sets: Replace
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

### -DevBoxName
The name of a Dev Box.

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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IDevBoxAddOn
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IDevBoxAddOn
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

BODY \<IDevBoxAddOn\>: A Dev Box addon.
  \[Code \<String\>\]: One of a server-defined set of error codes.
  \[Detail \<IAzureCoreFoundationsError\[\]\>\]: An array of details about specific errors that led to this reported error.
    Code \<String\>: One of a server-defined set of error codes.
    Message \<String\>: A human-readable representation of the error.
    \[Detail \<IAzureCoreFoundationsError\[\]\>\]: An array of details about specific errors that led to this reported error.
    \[Innererror \<IAzureCoreFoundationsInnerError\>\]: An object containing more specific information than the current object about the error.
      \[Code \<String\>\]: One of a server-defined set of error codes.
      \[Innererror \<IAzureCoreFoundationsInnerError\>\]: Inner error.
    \[Target \<String\>\]: The target of the error.
  \[Innererror \<IAzureCoreFoundationsInnerError\>\]: An object containing more specific information than the current object about the error.
  \[Message \<String\>\]: A human-readable representation of the error.
  \[OperationLocation \<String\>\]: 
  \[Target \<String\>\]: The target of the error.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenterdata/set-azdevcenteruserdevboxaddon](https://learn.microsoft.com/powershell/module/az.devcenterdata/set-azdevcenteruserdevboxaddon)
