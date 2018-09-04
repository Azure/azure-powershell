---
external help file: Microsoft.Azure.Commands.DeploymentManager.dll-Help.xml
Module Name: Microsoft.Azure.Commands.DeploymentManager
online version:
schema: 2.0.0
---

# New-AzureRmDeploymentManagerService

## SYNOPSIS
Creates a service in a service topology.

## SYNTAX

```
New-AzureRmDeploymentManagerService -ResourceGroupName <String> -Name <String> -ServiceTopologyName <String>
 -Location <String> -TargetLocation <String> -TargetSubscriptionId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmDeploymentManagerService** cmdlet creates a service under a service topology, and returns an object that represents that service.
Specify the service by its name, service topology it is in and the resource group name. 

The cmdlet returns a Service object. You can modify this object locally, and then apply changes to the service by using the Set-AzureRmDeploymentManagerService cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmDeploymentManagerService -ResourceGroupName ContosoResourceGroup -ServiceTopologyName ContosoServiceTopology -Name ContosoService1 -Location "Central US" -TargetLocation "East US" -TargetSubscriptionId XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX 
```
Creates a new service with name ContosoService1 under service topology ContosoServiceTopology in Resource Group ContosoResourceGroup, in the location Central US. The TargetLocation property indicates that the service ContosoService1 should be deployed to the East US region in the subscription specified.

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

### -Location
The location of the service resource.

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

### -Name
The name of the service.

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

### -ResourceGroupName
The resource group.

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

### -ServiceTopologyName
The name of the service topology this service belongs to.

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

### -TargetLocation
Determines the location where resources under the service would be deployed to.

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

### -TargetSubscriptionId
Determines the subscription to which resources under the service would be deployed to.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceResource

## NOTES

## RELATED LINKS

[Get-AzureRmDeploymentManagerService](./Get-AzureRmDeploymentManagerService.md)

[Remove-AzureRmDeploymentManagerService](./Remove-AzureRmDeploymentManagerService.md)

[Set-AzureRmDeploymentManagerService](./Set-AzureRmDeploymentManagerService.md)