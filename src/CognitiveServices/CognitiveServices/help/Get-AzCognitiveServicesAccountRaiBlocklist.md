---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/get-azcognitiveservicesaccountraiblocklist
schema: 2.0.0
---

# Get-AzCognitiveServicesAccountRaiBlocklist

## SYNOPSIS
Get or list Cognitive Services Account RaiBlocklist(s).

## SYNTAX

### DefaultParameterSet (Default)
```
Get-AzCognitiveServicesAccountRaiBlocklist [[-ResourceGroupName] <String>] [-AccountName] <String>
 [[-Name] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzCognitiveServicesAccountRaiBlocklist [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get or list Cognitive Services Account RaiBlocklist(s).

## EXAMPLES

### Example 1
```powershell
Get-AzCognitiveServicesAccountRaiBlocklist -ResourceGroupName ResourceGroupName -AccountName AccountName
```

List Cognitive Services Account RaiBlocklist(s) under an Account.

### Example 2
```powershell
Get-AzCognitiveServicesAccountRaiBlocklist -ResourceGroupName ResourceGroupName -AccountName AccountName -Name Name
```

Get a Cognitive Services Account RaiBlocklist.

## PARAMETERS

### -AccountName
Cognitive Services Account Name.

```yaml
Type: String
Parameter Sets: DefaultParameterSet
Aliases: CognitiveServicesAccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Cognitive Services RaiBlocklist Name.

```yaml
Type: String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource Id.

```yaml
Type: String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.CognitiveServices.Models.RaiBlocklist

## NOTES

## RELATED LINKS
