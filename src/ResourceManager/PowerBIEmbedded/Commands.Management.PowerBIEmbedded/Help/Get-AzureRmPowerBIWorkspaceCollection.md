---
external help file: Microsoft.Azure.Commands.Management.PowerBIEmbedded.dll-Help.xml
ms.assetid: EEF32F48-00F6-4C57-B4F1-B58B566EAFEF
online version: 
schema: 2.0.0
---

# Get-AzureRmPowerBIWorkspaceCollection

## SYNOPSIS
Gets Power BI workspace collections.

## SYNTAX

### WorkspaceCollectionNameParameterSet
```
Get-AzureRmPowerBIWorkspaceCollection [-ResourceGroupName] <String> [-WorkspaceCollectionName] <String>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

### ResourceGroupParameterSet
```
Get-AzureRmPowerBIWorkspaceCollection [[-ResourceGroupName] <String>] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmPowerBIWorkspaceCollection** cmdlet gets Power BI workspace collections in your Azure subscription and resource group, or by collection name.

## EXAMPLES

### Example 1: Get all workspace collections in a resource group
```
PS C:\>Get-AzureRmPowerBIWorkspaceCollection -ResourceGroupName "ResourceGroup17"
```

This command gets the workspace collections that belong to the resource group named ResourceGroup17.

### Example 2: Get a workspace collection by using its name
```
PS C:\>Get-AzureRmPowerBIWorkspaceCollection -ResourceGroupName "ResourceGroup17" -WorkspaceCollectionName "WCN11"
```

This command gets the workspace collection named WCN11 in the specified resource group.

## PARAMETERS

### -ResourceGroupName
Specifies the name of the resource group from which this cmdlet gets workspace collections.

```yaml
Type: String
Parameter Sets: WorkspaceCollectionNameParameterSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ResourceGroupParameterSet
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceCollectionName
Specifies the name of the Power BI workspace collection that this cmdlet gets.

```yaml
Type: String
Parameter Sets: WorkspaceCollectionNameParameterSet
Aliases: Name, ResourceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[New-AzureRmPowerBIWorkspaceCollection](./New-AzureRmPowerBIWorkspaceCollection.md)

[Remove-AzureRmPowerBIWorkspaceCollection](./Remove-AzureRmPowerBIWorkspaceCollection.md)


