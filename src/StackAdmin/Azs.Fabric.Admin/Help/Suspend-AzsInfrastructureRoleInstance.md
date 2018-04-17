---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Suspend-AzsInfrastructureRoleInstance

## SYNOPSIS
Shut down an infrastructure role instance.

## SYNTAX

### Shutdown (Default)
```
Suspend-AzsInfrastructureRoleInstance -Name <String> [-Location <String>] [-ResourceGroupName <String>] [-Wait]
 [<CommonParameters>]
```

### ResourceId
```
Suspend-AzsInfrastructureRoleInstance -ResourceId <String> [-Wait] [<CommonParameters>]
```

## DESCRIPTION
Shut down an infrastructure role instance.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Disable-AzsInfrastructureRoleInstance -ResourceGroup "System.local" -Location "local" -InfrastructureRoleInstance "AzS-ACS01"
```

Shut down an infrastructure role instance.
On failure an exception is thrown.

## PARAMETERS

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: Shutdown
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of an infrastructure role instance.

```yaml
Type: String
Parameter Sets: Shutdown
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group in which the resource provider has been registered.

```yaml
Type: String
Parameter Sets: Shutdown
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Infrastructure role instance resource ID.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Wait
{{Fill Wait Description}}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

