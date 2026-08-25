---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azexpressroutelagidentity
schema: 2.0.0
---

# New-AzExpressRouteLagIdentity

## SYNOPSIS
Creates an Azure ExpressRouteLagIdentity.

## SYNTAX

```
New-AzExpressRouteLagIdentity -UserAssignedIdentityId <String> [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzExpressRouteLagIdentity** cmdlet creates a local Azure ExpressRouteLag Identity object. Use **Set-AzExpressRouteLag** to assign it to an Azure ExpressRouteLag.

## EXAMPLES

### Example 1
```powershell
$parameters = @{
    UserAssignedIdentityId='/subscriptions/<SubId>/resourceGroups/<ResourceGroupName>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/<IdentityName>'
	}
New-AzExpressRouteLagIdentity @parameters
```

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -UserAssignedIdentityId
ResourceId of the user assigned identity to be assigned to ExpressRouteLag.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: UserAssignedIdentity

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

### Microsoft.Azure.Commands.Network.Models.PSManagedServiceIdentity

## NOTES

## RELATED LINKS

[Get-AzExpressRouteLagIdentity](./Get-AzExpressRouteLagIdentity.md)

[Remove-AzExpressRouteLagIdentity](./Remove-AzExpressRouteLagIdentity.md)

[Set-AzExpressRouteLagIdentity](./Set-AzExpressRouteLagIdentity.md)
