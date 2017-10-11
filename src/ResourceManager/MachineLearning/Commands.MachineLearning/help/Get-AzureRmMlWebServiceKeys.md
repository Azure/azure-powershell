---
external help file: Microsoft.Azure.Commands.MachineLearning.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmMlWebServiceKeys

## SYNOPSIS
Retrieves the web service's keys.

## SYNTAX

### Get an Azure ML web service's access keys given its name and resource group.
```
Get-AzureRmMlWebServiceKeys -ResourceGroupName <String> -Name <String> [<CommonParameters>]
```

### Get the access kesy for the given web service instance.
```
Get-AzureRmMlWebServiceKeys -MlWebService <WebService> [<CommonParameters>]
```

## DESCRIPTION
Gets the access keys for the Azure Machine Learning web service's runtime APIs.

## EXAMPLES

### --------------------------  Example 1 - Get the keys for a web service specified by resource group and name  --------------------------
@{paragraph=PS C:\\\>}



```
Get-AzureRmMlWebServiceKeys -ResourceGroupName "myresourcegroup" -Name "mywebservicename"
```

### --------------------------  Example 2 - Get keys for web service instance  --------------------------
@{paragraph=PS C:\\\>}



```
Get-AzureRmMlWebServiceKeys -MlWebService $mlService
```

$mlService is an object of type Microsoft.Azure.Management.MachineLearning.WebServices.Models.WebService.

## PARAMETERS

### -MlWebService
The name of the web service for which the access keys are retrieved.

```yaml
Type: WebService
Parameter Sets: Get the access kesy for the given web service instance.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the web service for which the access keys are retrieved.

```yaml
Type: String
Parameter Sets: Get an Azure ML web service's access keys given its name and resource group.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group for the web service.

```yaml
Type: String
Parameter Sets: Get an Azure ML web service's access keys given its name and resource group.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### WebService

Parameter 'MlWebService' accepts value of type 'WebService' from the pipeline

## OUTPUTS

### None

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, machine, machine learning, azureml

## RELATED LINKS

