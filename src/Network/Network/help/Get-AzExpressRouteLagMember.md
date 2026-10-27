---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressroutelagmember
schema: 2.0.0
---

# Get-AzExpressRouteLagMember

## SYNOPSIS
Gets the members of an Azure ExpressRouteLag link.

## SYNTAX

```
Get-AzExpressRouteLagMember -ResourceGroupName <String> -ExpressRouteLagName <String> -LinkName <String>
 [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRouteLagMember** cmdlet gets one or more members of a link on an Azure ExpressRouteLag. Specify **Name** to retrieve a single member, or omit it to list all members of the link.

## EXAMPLES

### Example 1: List the members of an ExpressRouteLag link
```powershell
Get-AzExpressRouteLagMember -ResourceGroupName "MyResourceGroup" -ExpressRouteLagName "MyLag" -LinkName "link1"
```

Lists all members of the link `link1` on the ExpressRouteLag named `MyLag`.

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

### -ExpressRouteLagName
The name of the express route LAG.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LinkName
The name of the express route LAG link.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the express route LAG member.

```yaml
Type: String
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteLagMember

## NOTES

## RELATED LINKS
