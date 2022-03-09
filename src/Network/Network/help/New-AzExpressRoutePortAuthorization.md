---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzExpressRoutePortAuthorization

## SYNOPSIS
Creates an ExpressRoutePort authorization.

## SYNTAX

```
New-AzExpressRoutePortAuthorization -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzExpressRoutePortAuthorization** cmdlet creates an authorization object that can
be added to an ExpressRoutePort. The owner of an ExpressRoutePort can create these 
authorizations which generate an authorization key that can be used by a ExpressRoute 
circuit owner to create the circuit on the ExpressRoutePort (with a different owner).
Only one circuit can be created with one ExpressRoutePort authorization. After you
create an ExpressRoutePort you can use **Add-AzExpressRoutePortAuthorization** 
to add an authorization to that ExpressRoutePort. Alternatively, you can use
**New-AzExpressRoutePortAuthorization** to create an authorization that can be added 
to a new ExpressRoutePort at the same time the ExpressRoutePort is created.

## EXAMPLES

### Example 1
```powershell
$Authorization = New-AzExpressRoutePortAuthorization -Name "ContosoPortAuthorization"
New-AzExpressRoutePort -Name $Name -ResourceGroupName $ResourceGroupName -PeeringLocation $PeeringLocationName -BandwidthInGbps 100.0 -Encapsulation QinQ | Dot1Q -Location $AzureRegion -Authorization $Authorization
```

This command creates a new ExpressRoutePort authorization named ContosoPortAuthorization and then stores
that object in a variable named $Authorization. Saving the object to a variable is important:
although **New-AzExpressRoutePortAuthorization** can create a ExpressRoutePort authorization it
cannot add that authorization to a ExpressRoutePort object. Instead, the variable $Authorization is used
New-AzExpressRoutePort when creating a brand-new ExpressRoutePort shown in the final command in the example.

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
Specifies a unique name for the new ExpressRoutePort authorization.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePortAuthorization

## NOTES

## RELATED LINKS
