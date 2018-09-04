---
external help file: Microsoft.Azure.Commands.DeploymentManager.dll-Help.xml
Module Name: Microsoft.Azure.Commands.DeploymentManager
online version:
schema: 2.0.0
---

# Set-AzureRmDeploymentManagerServiceUnit

## SYNOPSIS
Updates a service unit.

## SYNTAX

```
Set-AzureRmDeploymentManagerServiceUnit [-ServiceUnit] <PSServiceUnitResource>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmDeploymentManagerServiceUnit** cmdlet updates a service unit with the specified service unit object.
The cmdlet returns the updated service unit object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzureRmDeploymentManagerServiceUnit -ServiceUnit $serviceUnitObject 
```

This command updates a service unit whose name, service name, service topology name and ResourceGroup match the Name, ServiceName, ServiceTopologyName and ResourceGroupName properties of the $serviceUnitObject, respectively.
The command returns the updated service unit object.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceUnit
The service unit object.

```yaml
Type: Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceUnitResource
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceUnitResource

## OUTPUTS

### Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceUnitResource

## NOTES

## RELATED LINKS

[New-AzureRmDeploymentManagerServiceUnit](./New-AzureRmDeploymentManagerServiceUnit.md)

[Get-AzureRmDeploymentManagerServiceUnit](./Set-AzureRmDeploymentManagerServiceUnit.md)

[Remove-AzureRmDeploymentManagerServiceUnit](./Remove-AzureRmDeploymentManagerServiceUnit.md)