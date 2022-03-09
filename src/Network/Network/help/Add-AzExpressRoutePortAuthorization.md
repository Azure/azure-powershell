---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# Add-AzExpressRoutePortAuthorization

## SYNOPSIS
Adds an ExpressRoutePort authorization.

## SYNTAX

```
Add-AzExpressRoutePortAuthorization -Name <String> -ExpressRoutePort <PSExpressRoutePort>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzExpressRoutePortAuthorization** cmdlet adds an authorization to an ExpressRoutePort.
The owner of an ExpressRoutePort can create these authorizations which generate an
authorization key that can be used by a ExpressRoute circuit owner to create the circuit on 
the ExpressRoutePort (with a different owner). Only one circuit can be created with one
ExpressRoutePort authorization.**Add-AzExpressRoutePortAuthorization**
adds a new authorization to a ExpressRoutePort and, at the same time, generates the corresponding
authorization key. These keys can be viewed at any time by running the
**Get-AzExpressRoutePortAuthorization** cmdlet and, as needed, can then be copied and forwarded
to the appropriate circuit owner.
Note that, after running **Add-AzExpressRoutePortAuthorization**, you must call the
**Set-AzExpressRoutePort** cmdlet to activate the key. If you do not call
**Set-AzExpressRoutePort** the authorization will be added to the ExpressRoutePort but will not be
enabled for use.

## EXAMPLES

### Example 1
```powershell
$ERPort = Get-AzExpressRoutePort -Name "ContosoPort" -ResourceGroupName "ContosoResourceGroup"
Add-AzExpressRoutePortAuthorization -Name "ContosoPortAuthorization" -ExpressRoutePort $ERPort
Set-AzExpressRoutePort -ExpressRoutePort $ERPort
```

The commands in this example add a new authorization to an existing ExpressRoutePort. The first
command uses **Get-AzExpressRoutePort** to create an object reference to a ExpressRoutePort named
ContosoPort. That object reference is stored in a variable named $ERPort.
In the second command, the **Add-AzExpressRoutePortAuthorization** cmdlet is used to add a
new authorization (ContosoPortAuthorization) to the ExpressRoutePort. This command adds the
authorization but does not activate that authorization. Activating an authorization requires the
**Set-AzExpressRoutePort** shown in the final command in the example.

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

### -ExpressRoutePort
Specifies the ExpressRoutePort that this cmdlet adds the authorization to.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort

## NOTES

## RELATED LINKS
