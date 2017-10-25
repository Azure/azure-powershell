---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Stop-AzsInfrastructureRoleInstance

## SYNOPSIS
Power off an infrastructure role instance. On failure an exception is thrown.

## SYNTAX

```
Stop-AzsInfrastructureRoleInstance -InfrastructureRoleInstance <String> -Location <String> [-AsJob]
 [<CommonParameters>]
```

## DESCRIPTION
Power off an infrastructure role instance. On failure an exception is thrown.

## EXAMPLES

### Example 1
```
PS C:\> Stop-AzsInfrastructureRoleInstancef -Location "local" -InfrastructureRoleInstance "AzS-ACS01"

ProvisioningState
-----------------
Succeeded
```

Power off a infrastructure role instance.

## PARAMETERS

### -AsJob
Runs as job.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureRoleInstance
Name of an infra role instance.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus

## NOTES

## RELATED LINKS

