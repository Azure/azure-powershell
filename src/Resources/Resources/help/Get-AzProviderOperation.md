---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 6424B740-DBFB-490C-AEAA-EDD60952B435
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azprovideroperation
schema: 2.0.0
---

# Get-AzProviderOperation

## SYNOPSIS
Gets the operations for an Azure resource provider that are securable using Azure RBAC.

## SYNTAX

```
Get-AzProviderOperation [[-OperationSearchString] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzProviderOperation gets the operations exposed by Azure resource providers.
Operations can be composed to create custom roles in Azure RBAC.
The command takes as input an operation search string (with possible wildcard(*) character(s)) which determines the operations details to display.
Use Get-AzProviderOperation * to get all operations for all Azure resource providers.
Use Get-AzProviderOperation Microsoft.Compute/* to get all operations of Microsoft.Compute resource provider.

## EXAMPLES

### Example 1: Get all actions for all providers
```powershell
PS C:\> Get-AzProviderOperation *
```

### Example 2: Get actions for a particular resource provider
```powershell
PS C:\> Get-AzProviderOperation Microsoft.Insights/*
```

### Example 3: Get all actions that can be performed on virtual machines
```powershell
PS C:\> Get-AzProviderOperation */virtualMachines/*
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationSearchString
The operation search string (with possible wildcard (*) characters)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: 0
Default value: "*"
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.PSResourceProviderOperation

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS
