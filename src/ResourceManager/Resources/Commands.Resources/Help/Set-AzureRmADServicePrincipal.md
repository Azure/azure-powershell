---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: 7B8C8239-16A3-4C47-9D6F-DE31885532F4
online version: 
schema: 2.0.0
---

# Set-AzureRmADServicePrincipal

## SYNOPSIS
Updates an existing azure active directory service principal.

## SYNTAX

### SpObjectIdWithDisplayNameParameterSet (Default)
```
Set-AzureRmADServicePrincipal -ObjectId <String> -DisplayName <String> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [-WhatIf] [-Confirm]
```

### SPNWithDisplayNameParameterSet
```
Set-AzureRmADServicePrincipal -ServicePrincipalName <String> -DisplayName <String>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Updates an existing azure active directory service principal. 
To update the credentials associated with this service principal, please use New-AzureRmADSpCredential cmdlet. 
To update the properties associated with the underlying application, please use Set-AzureRmADApplication cmdlet.

## EXAMPLES

### --------------------------  Example 1  --------------------------
@{paragraph=PS C:\\\>}

```
Set-AzureRmADServicePrincipal -ObjectId 784136ca-3ae2-4fdd-a388-89d793e7c780 -DisplayName "UpdatedNameForSp"
```

Updates the display name for the service principal with specified object id.

### --------------------------  Example 2  --------------------------
@{paragraph=PS C:\\\>}

```
Set-AzureRmADServicePrincipal -ServicePrincipalName "http://MyApp1" -DisplayName "UpdatedNameforSp"
```

Updates the display name for the service principal with specified service principal name.

## PARAMETERS

### -ObjectId
The object id of the service principal to update.

```yaml
Type: String
Parameter Sets: SpObjectIdWithDisplayNameParameterSet
Aliases: ServicePrincipalObjectId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
New display name for the service principal.

```yaml
Type: String
Parameter Sets: (All)
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

### -ServicePrincipalName
The SPN of service principal to update.

```yaml
Type: String
Parameter Sets: SPNWithDisplayNameParameterSet
Aliases: SPN

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

[New-AzureRmADServicePrincipal]()

[Get-AzureRmADServicePrincipal]()

[Remove-AzureRmADServicePrincipal]()

[Set-AzureRmADApplication]()

[New-AzureRmADSpCredential]()

[Remove-AzureRmADSpCredential]()

