---
external help file: Microsoft.Azure.Commands.MachineLearning.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmMlWebService

## SYNOPSIS
Retrieves the summary information for one or more web services.

## SYNTAX

```
Get-AzureRmMlWebService [-ResourceGroupName <String>] [-Name <String>]
```

## DESCRIPTION
Retrieves web service defintion information.
Depending on the paramenters passed, the cmdlet returns the defintion for a specific web service, a collection of defintions for the web services for a specified resource group within the current subscription, or a collection of defintions for the web services within the current subscription.

## EXAMPLES

### --------------------------  Example 1: Get details of specific web service  --------------------------
@{paragraph=PS C:\\\>}

```
Get-AzureRmMlWebService -ResourceGroupName "myresourcegroup" -Name "mywebservicename"
```

### --------------------------  Example 2: Get all web service resources in current subscription  --------------------------
@{paragraph=PS C:\\\>}

```
Get-AzureRmMlWebService
```

### --------------------------  Example 3: Get all web services in the current subscription and given resource group  --------------------------
@{paragraph=PS C:\\\>}

```
Get-AzureRmMlWebService -ResourceGroupName "myresourcegroup"
```

## PARAMETERS

### -Name
The name of the web service for which the details are retrieved.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group from which the details for the web service are retrieved.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

### None

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, machine, machine learning, azureml

## RELATED LINKS

