---
external help file: Microsoft.Azure.Commands.MachineLearning.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmMlWebService

## SYNOPSIS
Creates a new web service.

## SYNTAX

### Create a new Azure ML webservice from a JSON definiton file.
```
New-AzureRmMlWebService -ResourceGroupName <String> -Location <String> -Name <String> -DefinitionFile <String>
 [-Force] [-WhatIf] [-Confirm]
```

### Create a new Azure ML webservice from a WebService instance definition.
```
New-AzureRmMlWebService -ResourceGroupName <String> -Location <String> -Name <String>
 -NewWebServiceDefinition <WebService> [-Force] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Creates an Azure Machine Learning web service in an existing resource group.
If a web service with the same name exists in the resource group, the call acts as an update operation and the existing web service is overwritten.

## EXAMPLES

### --------------------------  Example 1: Create a new service from a Json file based definition  --------------------------
@{paragraph=PS C:\\\>}

```
New-AzureRmMlWebService -ResourceGroupName "myresourcegroup" -Name "mywebservicename" -Location "South Central US" -DefinitionFile "C:\mlservice.json"
```

Creates a new Azure Machine Learning web service named "mywebservicename" in the "myresourcegroup" group and South Central US region, based on the definition present in the referenced json file.

### --------------------------  Example 2: Create a new service from an object instance  --------------------------
@{paragraph=PS C:\\\>}

```
New-AzureRmMlWebService -ResourceGroupName "myresourcegroup" -Name "mywebservicename" -Location "South Central US" -NewWebServiceDefinition $serviceDefinitionObject
```

You can obtain a web service object instance to customize before publishing as a resource by using the Import-AzureRmMlWebService cmdlet.

## PARAMETERS

### -DefinitionFile
Specifes the path to the file containing the JSON format definition of the web service.
You can find the latest specification for the web service definition in the swagger spec under https://github.com/Azure/azure-rest-api-specs/tree/master/arm-machinelearning.

```yaml
Type: String
Parameter Sets: Create a new Azure ML webservice from a JSON definiton file.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The region of the web service.
Enter an Azure data center region, such as "West US" or "Southeast Asia".
You can place a web service in any region that supports resources of that type.
The web service does not have to be in the same region your Azure subscription or the same region as its resource group.
Resource groups can contain web services from different regions.
To determine which regions support each resource type, use the Get-AzureRmResourceProvider with the ProviderNamespace parameter cmdlet.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the web service.
The name must be unique in the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewWebServiceDefinition
The definition for the new web service, containing all the properties that make up the service.
This parameter is required and represents an instance of the Microsoft.Azure.Management.MachineLearning.WebServices.Models.WebService class.
You can find the latest specification for the web service definition in the swagger spec under https://github.com/Azure/azure-rest-api-specs/blob/master/arm-machinelearning/2016-05-01-preview/swagger/webservices.json.

```yaml
Type: WebService
Parameter Sets: Create a new Azure ML webservice from a WebService instance definition.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group in which to place the web service.
Enter an Azure data center region, such as "West US" or "Southeast Asia".
You can place a web service in any region that supports resources of that type.
The web service does not have to be in the same region your Azure subscription or the same region as its resource group.
Resource groups can contain web services from different regions.
To determine which regions support each resource type, use the Get-AzureRmResourceProvider with the ProviderNamespace parameter cmdlet.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## INPUTS

## OUTPUTS

### Microsoft.Azure.Management.MachineLearning.WebServices.Models.WebService
A summary description of the Azure Machine Learning web service.
Similar to the description returned by calling the Get-AzureRmMlWebService cmdlet on an existing web service.
This description does not contain sensitive properties such as storage account's credentials and the service's access keys.

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, machine, machine learning, azureml

## RELATED LINKS

