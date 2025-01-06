---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azresourcemanagementprivatelink
schema: 2.0.0
---

# New-AzResourceManagementPrivateLink

## SYNOPSIS
Create Azure Resource Management Private Link

## SYNTAX

```
New-AzResourceManagementPrivateLink [[-ResourceGroupName] <String>] [-Name] <String> [-Location] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The New-AzResourceManagementPrivateLink cmdlet create a specific resource management private link.

## EXAMPLES

### Example 1
```powershell
New-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -Name NewPL
```

```output
Id                         : /subscriptions/aeb49941-36c3-4e7c-9ffd-16ba89d33ec4/resourceGroups/PrivateLinkTestRG/provi
                             ders/Microsoft.Authorization/resourceManagementPrivateLinks/NewPL
Type                       : Microsoft.Authorization/resourceManagementPrivateLinks
Name                       : NewPL
Location                   : centralus
PrivateEndpointConnections : {}
```

Create the resource management private link.

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

### -Location
The private link location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the private link.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PrivateLinkName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.PrivateLinks.PSResourceManagementPrivateLink

## NOTES

## RELATED LINKS

[Remove-AzResourceManagementPrivateLink](./Remove-AzResourceManagementPrivateLink.md)
[Get-AzResourceManagementPrivateLink](./Get-AzResourceManagementPrivateLink.md)
