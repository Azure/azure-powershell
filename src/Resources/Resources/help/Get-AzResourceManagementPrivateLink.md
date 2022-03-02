---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/update-azaduser
schema: 2.0.0
---

# Get-AzResourceManagementPrivateLink

## SYNOPSIS
Gets Azure Resource Management Private Link

## SYNTAX

```
Get-AzResourceManagementPrivateLink [-ResourceGroupName] <String> [-PrivateLinkName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzResourceManagementPrivateLink cmdlet gets a specific resource management private link.


## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -PrivateLinkName NewPL


Id                         : /subscriptions/aeb49941-36c3-4e7c-9ffd-16ba89d33ec4/resourceGroups/PrivateLinkTestRG/provi
                             ders/Microsoft.Authorization/resourceManagementPrivateLinks/NewPL
Type                       : Microsoft.Authorization/resourceManagementPrivateLinks
Name                       : NewPL
Location                   : centralus
PrivateEndpointConnections : {}
```

Get the resource management private link with the private endpoint connections associated with it.

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

### -PrivateLinkName
The name of the private link.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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

Required: True
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
