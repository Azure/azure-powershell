---
external help file: Microsoft.Azure.Commands.Management.Search.dll-Help.xml
Module Name: AzureRM.Search
online version:
schema: 2.0.0
---

# Get-AzureRmSearchService

## SYNOPSIS
Get an Azure Search service.

## SYNTAX

### ResourceGroupParameterSet
```
Get-AzureRmSearchService [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceNameParameterSet
```
Get-AzureRmSearchService [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzureRmSearchService [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSearchService** cmdlet gets the specified Azure Search service.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmSearchService -ResourceGroupName "TestAzureSearchPsGroup" -Name "pstestazuresearch"


ResourceGroupName : TestAzureSearchPsGroup
Name              : pstestazuresearch
Id                : /subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/TestAzureSearchPsGroup/providers
                    /Microsoft.Search/searchServices/pstestazuresearch
Location          : West US
Sku               : Standard
ReplicaCount      : 1
PartitionCount    : 1
HostingMode       : Default
Tags              :
```

Get an Azure Search service with specified parameters.

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

### -Name
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

### -ResourceGroupName
Resource Group name.

```yaml
Type: String
Parameter Sets: ResourceGroupParameterSet, ResourceNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Search Service Resource Id.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
You can pipe input to this cmdlet.


## OUTPUTS

### Microsoft.Azure.Commands.Management.Search.Models.PSSearchService


## NOTES

## RELATED LINKS

[New-AzureRmSearchService](./New-AzureRmSearchService.md)

[Set-AzureRmSearchService](./Set-AzureRmSearchService.md)

[Remove-AzureRmSearchService](./Remove-AzureRmSearchService.md)