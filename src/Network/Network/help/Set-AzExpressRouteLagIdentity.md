---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azexpressroutelagidentity
schema: 2.0.0
---

# Set-AzExpressRouteLagIdentity

## SYNOPSIS
Updates a identity assigned to an ExpressRouteLag.

## SYNTAX

```
Set-AzExpressRouteLagIdentity -ExpressRouteLag <PSExpressRouteLag> -UserAssignedIdentityId <String>
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzExpressRouteLagIdentity** cmdlet updates a local Azure ExpressRouteLag object. Use **Set-AzExpressRouteLag** to assign it to ExpressRouteLag.

## EXAMPLES

### Example 1
```powershell
$rgName = "MyResourceGroup"
$lagName = "MyExpressRouteLag"
$identityName = "MyUserAssignedIdentity"
$location = "eastus2euap"
$exrLag = Get-AzExpressRouteLag -Name $lagName -ResourceGroupName $rgName
$identity = New-AzUserAssignedIdentity -Name $identityName -ResourceGroupName $rgName -Location $location
$exrLagIdentity = Set-AzExpressRouteLagIdentity -UserAssignedIdentity $identity.Id -ExpressRouteLag $exrLag
$updatedExrLag = Set-AzExpressRouteLag -ExpressRouteLag $exrLag
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

### -ExpressRouteLag
The ExpressRouteLag

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag

## NOTES

## RELATED LINKS

[Get-AzExpressRouteLagIdentity](./Get-AzExpressRouteLagIdentity.md)

[New-AzExpressRouteLagIdentity](./New-AzExpressRouteLagIdentity.md)

[Remove-AzExpressRouteLagIdentity](./Remove-AzExpressRouteLagIdentity.md)
