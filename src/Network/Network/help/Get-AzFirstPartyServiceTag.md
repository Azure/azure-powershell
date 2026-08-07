---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azfirstpartyservicetag
schema: 2.0.0
---

# Get-AzFirstPartyServiceTag

## SYNOPSIS
Gets first party service tags.

## SYNTAX

### FirstPartyServiceTagNameParameterSet (Default)
```
Get-AzFirstPartyServiceTag [-ResourceGroupName <String>] [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### FirstPartyServiceTagResourceIdParameterSet
```
Get-AzFirstPartyServiceTag -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzFirstPartyServiceTag** cmdlet gets one first party service tag, lists the tags in a resource group, or lists all first party service tags in the current subscription.
You can identify a single resource by name or resource ID.

## EXAMPLES

### Example 1
```powershell
Get-AzFirstPartyServiceTag -ResourceGroupName "ContosoResourceGroup" -Name "ContosoServiceTag"
```

This command gets the first party service tag named `ContosoServiceTag`.

### Example 2: List first party service tags in a resource group
```powershell
Get-AzFirstPartyServiceTag -ResourceGroupName "ContosoResourceGroup"
```

This command lists all first party service tags in `ContosoResourceGroup`.

### Example 3: List first party service tags in the subscription
```powershell
Get-AzFirstPartyServiceTag
```

This command lists all first party service tags in the current subscription.

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
The first party service tag name.

```yaml
Type: String
Parameter Sets: FirstPartyServiceTagNameParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: FirstPartyServiceTagNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
The first party service tag resource ID.

```yaml
Type: String
Parameter Sets: FirstPartyServiceTagResourceIdParameterSet
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

### Microsoft.Azure.Commands.Network.Models.PSFirstPartyServiceTag

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.Network.Models.PSFirstPartyServiceTag, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=8.0.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[New-AzFirstPartyServiceTag](New-AzFirstPartyServiceTag.md)

[Set-AzFirstPartyServiceTag](Set-AzFirstPartyServiceTag.md)

[Remove-AzFirstPartyServiceTag](Remove-AzFirstPartyServiceTag.md)
