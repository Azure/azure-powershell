---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://docs.microsoft.com/powershell/module/az.cognitiveservices/get-azcognitiveservicesaccountmodel
schema: 2.0.0
---

# Get-AzCognitiveServicesAccountModel

## SYNOPSIS
Get Models available for a Cognitive Services account

## SYNTAX

### DefaultParameterSet (Default)
```
Get-AzCognitiveServicesAccountModel [[-ResourceGroupName] <String>] [-AccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzCognitiveServicesAccountModel [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Models available for a Cognitive Services account

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzCognitiveServicesAccountModel -ResourceGroupName cognitive-services-resource-group -AccountName resource-name

BaseModel    :
MaxCapacity  : 3
Capabilities : {[fineTune, true]}
Deprecation  : Microsoft.Azure.Management.CognitiveServices.Models.ModelDeprecationInfo
SystemData   : Microsoft.Azure.Management.CognitiveServices.Models.SystemData
Format       : OpenAI
Name         : ada
Version      : 1

BaseModel    :
MaxCapacity  : 3
Capabilities : {[fineTune, true]}
Deprecation  : Microsoft.Azure.Management.CognitiveServices.Models.ModelDeprecationInfo
SystemData   : Microsoft.Azure.Management.CognitiveServices.Models.SystemData
Format       : OpenAI
Name         : davinci
Version      : 1
```

Get Models available for a Cognitive Services account

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

### Microsoft.Azure.Management.CognitiveServices.Models.AccountModel

## NOTES

## RELATED LINKS

[New-AzCognitiveServicesAccountDeployment](./New-AzCognitiveServicesAccountDeployment.md)
