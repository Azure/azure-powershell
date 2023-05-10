---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgridpartnernamespacekey
schema: 2.0.0
---

# Get-AzEventGridPartnerNamespaceKey

## SYNOPSIS
Gets the details of an Event Grid partner namespace key.

## SYNTAX

### PartnerNamespaceNameParameterSet (Default)
```
Get-AzEventGridPartnerNamespaceKey -ResourceGroupName <String> -PartnerNamespaceName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PartnerNamespaceInputObjectParameterSet
```
Get-AzEventGridPartnerNamespaceKey -InputObject <PSPartnerNamespace> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzEventGridPartnerNamespaceKey cmdlet gets the details of an Event Grid partner namespace key.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridPartnerNamespaceKey -ResourceGroupName MyResourceGroupName -PartnerNamespaceName PartnerNamespace1
```

Gets the details of the keys for Event Grid partner namespace \`PartnerNamespace1\` in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputObject
PartnerNamespace object

```yaml
Type: Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespace
Parameter Sets: PartnerNamespaceInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerNamespaceName
Event Grid partner namespace name.

```yaml
Type: System.String
Parameter Sets: PartnerNamespaceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: PartnerNamespaceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespace

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespaceListInstance

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespace

## NOTES

## RELATED LINKS
