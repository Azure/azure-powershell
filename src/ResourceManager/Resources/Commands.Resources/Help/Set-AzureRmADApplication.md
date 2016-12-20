---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: BA97DB6F-F64D-417E-BD72-C2EBB2EC1AA4
online version: 
schema: 2.0.0
---

# Set-AzureRmADApplication

## SYNOPSIS
Updates an existing azure active directory application.

## SYNTAX

### ApplicationObjectIdWithUpdateParamsParameterSet
```
Set-AzureRmADApplication -ObjectId <String> [-DisplayName <String>] [-HomePage <String>]
 [-IdentifierUris <String[]>] [-ReplyUrls <String[]>] [-AvailableToOtherTenants <Boolean>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [-WhatIf] [-Confirm]
```

### ApplicationIdWithUpdateParamsParameterSet
```
Set-AzureRmADApplication -ApplicationId <String> [-DisplayName <String>] [-HomePage <String>]
 [-IdentifierUris <String[]>] [-ReplyUrls <String[]>] [-AvailableToOtherTenants <Boolean>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Updates an existing azure active directory application.
To update the credentials associated with this application, please use New-AzureRmADAppCredential cmdlet.

## EXAMPLES

### --------------------------  Example 1  --------------------------
@{paragraph=PS C:\\\>}

```
PS E:\> Set-AzureRmADApplication -ObjectId fb7b3405-ca44-4b5b-8584-12392f5d96d7 -DisplayName "UpdatedAppName" -HomePage "http://www.microsoft.com" -IdentifierUris "http://UpdatedApp" -AvailableToOtherTenants $false
```

Updates the properties of an existing azure active directory application with objectId "fb7b3405-ca44-4b5b-8584-12392f5d96d7".

### --------------------------  Example 2  --------------------------
@{paragraph=PS C:\\\>}

```
PS E:\> Set-AzureRmADApplication -ObjectId fb7b3405-ca44-4b5b-8584-12392f5d96d7 -DisplayName "UpdatedAppName"
```

Updates the display name of an existing azure active directory application with objectId "fb7b3405-ca44-4b5b-8584-12392f5d96d7".

## PARAMETERS

### -ObjectId
The object id of the application to update.

```yaml
Type: String
Parameter Sets: ApplicationObjectIdWithUpdateParamsParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
New Display name for the application.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -HomePage
New URL of the application homepage.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentifierUris
New URIs that identify the application.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ReplyUrls
New reply urls for the application.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AvailableToOtherTenants
The value specifying whether the application is updated to be a single tenant or a multi-tenant.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: False
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

### -WhatIf


```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationId
The id of the application to update.

```yaml
Type: String
Parameter Sets: ApplicationIdWithUpdateParamsParameterSet
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

[Get-AzureRmADApplication]()

[New-AzureRmADApplication]()

[Remove-AzureRmADApplication]()

[New-AzureRmADAppCredential]()

[Get-AzureRmADAppCredential]()

[Remove-AzureRmADAppCredential]()

