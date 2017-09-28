---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Invoke-AzsInfraRoleInstanceShutdown

## SYNOPSIS
Shut down an infrastructure role instance.  On failure an exception is thrown.

## SYNTAX

```
Invoke-AzsInfraRoleInstanceShutdown -InfraRoleInstance <String> -Location <String> [-AsJob]
```

## DESCRIPTION
Shut down an infrastructure role instance.  On failure an exception is thrown.

## EXAMPLES

### Example 1
```
PS C:\> Invoke-AzsInfraRoleInstanceShutdown -Location "local" -InfraRoleInstance "AzS-ACS01"

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

### -InfraRoleInstance
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

