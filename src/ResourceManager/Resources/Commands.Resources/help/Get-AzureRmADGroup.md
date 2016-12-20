---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: 85DDA491-7A7D-4217-B0E3-72CDC3787889
online version: 
schema: 2.0.0
---

# Get-AzureRmADGroup

## SYNOPSIS
Filters active directory groups.

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzureRmADGroup [-ObjectId <Guid>] [-InformationAction <ActionPreference>] [-InformationVariable <String>]
```

### SearchStringParameterSet
```
Get-AzureRmADGroup -SearchString <String> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

### ObjectIdParameterSet
```
Get-AzureRmADGroup -ObjectId <Guid> [-InformationAction <ActionPreference>] [-InformationVariable <String>]
```

## DESCRIPTION
Filters active directory groups.

## EXAMPLES

### --------------------------  Filters groups using object id  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmADGroup -ObjectId 85F89C90-780E-4AA6-9F4F-6F268D322EEE
```

Gets group with 85F89C90-780E-4AA6-9F4F-6F268D322EEE id

### --------------------------  Filters groups using Search String  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmADGroup -SearchString Joe
```

Filters all ad groups that has Joe in the display name.

### --------------------------  List AD groups  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmADGroup
```

Gets all AD groups

## PARAMETERS

### -ObjectId
Object id of the group.

```yaml
Type: Guid
Parameter Sets: EmptyParameterSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: Guid
Parameter Sets: ObjectIdParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchString
The group display name

```yaml
Type: String
Parameter Sets: SearchStringParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmADUser]()

[Get-AzureRmADServicePrincipal]()

[Get-AzureRmADGroupMember]()

