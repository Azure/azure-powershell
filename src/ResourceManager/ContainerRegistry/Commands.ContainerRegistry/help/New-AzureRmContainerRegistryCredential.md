---
external help file: Microsoft.Azure.Commands.ContainerRegistry.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmContainerRegistryCredential

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
New-AzureRmContainerRegistryCredential [-ResourceGroupName] <String> [-Name] <String> [-PasswordName] <String>
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Name
Container Registry Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ContainerRegistryName, RegistryName, ResourceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PasswordName
The name of password to regenerate.
Allowed values: password, password2.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: password, password2

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryCredential


## NOTES

## RELATED LINKS

