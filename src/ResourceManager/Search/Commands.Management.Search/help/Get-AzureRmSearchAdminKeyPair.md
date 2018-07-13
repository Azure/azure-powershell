---
external help file: Microsoft.Azure.Commands.Management.Search.dll-Help.xml
Module Name: AzureRM.Search
online version:
schema: 2.0.0
---

# Get-AzureRmSearchAdminKeyPair

## SYNOPSIS
Get Admin Key pair of the Azure Search Service.

## SYNTAX

### ParentObjectParameterSet
```
Get-AzureRmSearchAdminKeyPair [-ParentObject] <PSSearchService> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ParentResourceIdParameterSet
```
Get-AzureRmSearchAdminKeyPair [-ParentResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceNameParameterSet
```
Get-AzureRmSearchAdminKeyPair [-ResourceGroupName] <String> [-ServiceName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSearchAdminKeyPair** cmdlet gets the Admin Key pair of the Azure Search Service.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmSearchAdminKeyPair -ResourceGroupName "TestAzureSearchPsGroup" -ServiceName "pstestazuresearch01"

Primary                          Secondary
-------                          ---------
44EE0AA1CD9FCE46E05D899222D96417 CEF791D5BAC2E6C0B232C56702F21E87


PS C:\>
```

The example gets Admin Key pair of the Azure Search Service.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Search Service Input Object.

```yaml
Type: PSSearchService
Parameter Sets: ParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourceId
Search Service Resource Id.

```yaml
Type: String
Parameter Sets: ParentResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceName
Search Service name.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

You can pipe input to this cmdlet.

## OUTPUTS

### Microsoft.Azure.Commands.Management.Search.Models.PSSearchAdminKey


## NOTES

## RELATED LINKS

[New-AzureRmSearchAdminKey](./New-AzureRmSearchAdminKey.md)
