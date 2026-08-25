---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressroutelag
schema: 2.0.0
---

# Get-AzExpressRouteLag

## SYNOPSIS
Gets an Azure ExpressRouteLag resource.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Get-AzExpressRouteLag [-ResourceGroupName <String>] [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzExpressRouteLag -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRouteLag** cmdlet gets one or more Azure ExpressRouteLag resources. An ExpressRouteLag represents a link aggregation group (LAG) that bundles ExpressRoute ports together. Specify **Name** to retrieve a single resource, or omit it to list all ExpressRouteLag resources in a resource group.

## EXAMPLES

### Example 1: Get a specific ExpressRouteLag
```powershell
Get-AzExpressRouteLag -ResourceGroupName "MyResourceGroup" -Name "MyLag"
```

Gets the ExpressRouteLag named `MyLag` in the resource group `MyResourceGroup`.

### Example 2: List all ExpressRouteLag resources in a resource group
```powershell
Get-AzExpressRouteLag -ResourceGroupName "MyResourceGroup"
```

Lists all ExpressRouteLag resources in the resource group `MyResourceGroup`.

## PARAMETERS

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
The name of the express route LAG.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
The resource group name of the express route LAG.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
ResourceId of the express route LAG.

```yaml
Type: String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag

## NOTES

## RELATED LINKS
