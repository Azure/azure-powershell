---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
Module Name: AzureRM.Resources
ms.assetid: 6424B740-DBFB-490C-AEAA-EDD60952B435
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/get-azurermprovideroperation
schema: 2.0.0
---

# Get-AzureRmProviderOperation

## SYNOPSIS
Gets the operations for an Azure resource provider that are securable using Azure RBAC.

## SYNTAX

```
Get-AzureRmProviderOperation [[-OperationSearchString] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmProviderOperation gets the operations exposed by Azure resource providers.
Operations can be composed to create custom roles in Azure RBAC.
The command takes as input an operation search string (with possible wildcard(*) character(s)) which determines the operations details to display.

Use Get-AzureRmProviderOperation * to get all operations for all Azure resource providers.

Use Get-AzureRmProviderOperation Microsoft.Compute/* to get all operations of Microsoft.Compute resource provider.

## EXAMPLES

### Get all actions for all providers
```
PS C:\> Get-AzureRmProviderOperation *
```

### Get actions for a particular resource provider
```
PS C:\> Get-AzureRmProviderOperation Microsoft.Insights/*
```

### Get all actions that can be performed on virtual machines
```
PS C:\> Get-AzureRmProviderOperation */virtualMachines/*
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -OperationSearchString
The operation search string (with possible wildcard (*) characters)

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: 0
Default value: "*"
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### String
Parameter 'OperationSearchString' accepts value of type 'String' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.PSResourceProviderOperation

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS
