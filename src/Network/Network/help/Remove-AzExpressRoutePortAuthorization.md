---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# Remove-AzExpressRoutePortAuthorization

## SYNOPSIS
Removes an existing ExpressRoutePort authorization.

## SYNTAX

```
Remove-AzExpressRoutePortAuthorization -Name <String> -ExpressRoutePort <PSExpressRoutePort> [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzExpressRoutePortAuthorization** cmdlet removes an authorization assigned to an ExpressRoutePort.

## EXAMPLES

### Example 1
```powershell
$ERPort = Get-AzExpressRoutePort -Name "ContosoPort" -ResourceGroupName "ContosoResourceGroup"
Remove-AzExpressRoutePortAuthorization -Name "ContosoPortAuthorization" -ExpressRoutePort $ERPort
```

This example removes an authorization from an ExpressRoutePort. The first command uses
the **Get-AzExpressRoutePort** cmdlet to create an object reference to an ExpressRoutePort
named ContosoPort and stores the result in the variable named $ERPort.
The second command removes the ExpressRoutePort authorization ContosoPortAuthorization from
the ContosoPort.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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
Specifies the ExpressRoutePort object that this cmdlet removes the authorization from.

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
Specifies the name of the ExpressRoutePort authorization that this cmdlet removes.

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

### -PassThru
Returns an object representing the item with which you are working. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
