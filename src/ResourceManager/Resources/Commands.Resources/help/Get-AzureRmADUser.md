---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: BF254F2F-F658-45CC-8AC8-53FF96CFCAAD
online version: 
schema: 2.0.0
---

# Get-AzureRmADUser

## SYNOPSIS
Filters active directory users.

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzureRmADUser [-UserPrincipalName <String>] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

### SearchStringParameterSet
```
Get-AzureRmADUser -SearchString <String> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

### ObjectIdParameterSet
```
Get-AzureRmADUser -ObjectId <Guid> [-InformationAction <ActionPreference>] [-InformationVariable <String>]
```

### UPNParameterSet
```
Get-AzureRmADUser -UserPrincipalName <String> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

### MailParameterSet
```
Get-AzureRmADUser -Mail <String> [-InformationAction <ActionPreference>] [-InformationVariable <String>]
```

## DESCRIPTION
Filters active directory users.

## EXAMPLES

### --------------------------  Filters users using UPN  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmADUser -UPN foo@domain.com
```

Gets user with foo@domain.com

### --------------------------  Filters users using Search String  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmADUser -SearchString Joe
```

Filters all ad users that has Joe in the display name.

### --------------------------  List AD users  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmADUser
```

Gets all AD users

## PARAMETERS

### -UserPrincipalName
UPN of the user.

```yaml
Type: String
Parameter Sets: EmptyParameterSet
Aliases: UPN

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: UPNParameterSet
Aliases: UPN

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
The user display name

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

### -ObjectId
Object id of the user.

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

### -Mail


```yaml
Type: String
Parameter Sets: MailParameterSet
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

[New-AzureRmADUser]()

[Set-AzureRmADUser]()

[Remove-AzureRmADUser]()

