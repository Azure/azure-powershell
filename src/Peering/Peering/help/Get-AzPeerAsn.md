---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.dll-Help.xml
Module Name: Az.Peering
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.peering/get-azpeerasn
=======
online version: https://docs.microsoft.com/powershell/module/az.peering/get-azpeerasn
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzPeerAsn

## SYNOPSIS
Gets PeerAsn object from ARM.

## SYNTAX

<<<<<<< HEAD
=======
### ByName (Default)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```
Get-AzPeerAsn [-Name <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

<<<<<<< HEAD
=======
### ByResourceId
```
Get-AzPeerAsn [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
## DESCRIPTION
Gets the PeerAsn for a subscription.

## EXAMPLES

### Example 1
```powershell
<<<<<<< HEAD
PS C:> Get-AzPeerAsn -PeerName Contoso
=======
PS C:> Get-AzPeerAsn -Name Contoso
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

PeerContactInfo : Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSContactInfo
PeerName        : Contoso
ValidationState : None
PeerAsnProperty : 65050
Name            : Contoso
Id              : /subscriptions//providers/Microsoft.Peering/peerAsns/Contoso
Type            : Microsoft.Peering/peerAsns
```

Gets the PeerAsn

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

### -Name
The unique name of the PSPeering.

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: ByName
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
=======
### -ResourceId
The resource id string name.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeerAsn

## NOTES

## RELATED LINKS
