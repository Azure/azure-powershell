---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Disable-AzsInfrastructureRoleInstance

## SYNOPSIS
Shut down an infrastructure role instance.  On failure an exception is thrown.

## SYNTAX

```
Disable-AzsInfrastructureRoleInstance -InfrastructureRoleInstance <String> -Location <String> [-AsJob]
```

## DESCRIPTION
Shut down an infrastructure role instance.  On failure an exception is thrown.

## EXAMPLES

### Example 1
```
PS C:\> Disable-AzsInfrastructureRoleInstance -Location "local" -InfrastructureRoleInstance "AzS-ACS01"

ProvisioningState
-----------------
Succeeded
```

Shut down an infrastructure role instance.  On failure an exception is thrown.

## PARAMETERS

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

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus

## NOTES

## RELATED LINKS

