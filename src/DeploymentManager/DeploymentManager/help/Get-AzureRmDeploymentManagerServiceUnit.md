---
external help file: Microsoft.Azure.Commands.DeploymentManager.dll-Help.xml
Module Name: AzureRM.DeploymentManager
online version:
schema: 2.0.0
---

# Get-AzureRmDeploymentManagerServiceUnit

## SYNOPSIS
Gets a service unit.

## SYNTAX

### Interactive (Default)
```
Get-AzureRmDeploymentManagerServiceUnit [-ResourceGroupName] <String> [-ServiceTopologyName] <String>
 [-ServiceName] <String> [-Name] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByServiceObject
```
Get-AzureRmDeploymentManagerServiceUnit [-ResourceGroupName] <String> [-Name] <String>
 [-Service] <PSServiceResource> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByServiceResourceId
```
Get-AzureRmDeploymentManagerServiceUnit [-ResourceGroupName] <String> [-Name] <String>
 [-ServiceResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByTopologyObjectAndServiceName
```
Get-AzureRmDeploymentManagerServiceUnit [-ResourceGroupName] <String> [-ServiceName] <String> [-Name] <String>
 [-ServiceTopology] <PSServiceTopologyResource> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByTopologyResourceAndServiceName
```
Get-AzureRmDeploymentManagerServiceUnit [-ResourceGroupName] <String> [-ServiceName] <String> [-Name] <String>
 [-ServiceTopologyResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Get-AzureRmDeploymentManagerServiceUnit [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### InputObject
```
Get-AzureRmDeploymentManagerServiceUnit [-ServiceUnit] <PSServiceUnitResource>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDeploymentManagerServiceUnit** cmdlet gets a service unit in a service.

Specify the service unit by its name, the service under which it was defined, the service topology name and the resource group name. Alternately, you can provide the ServiceUnit object or the ResourceId.

You can modify this object locally, and then apply changes to the service unit by using the Set-AzureRmDeploymentManagerServiceUnit cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmDeploymentManagerServiceUnit -ResourceGroupName ContosoResourceGroup -ServiceTopologyName ContosoServiceTopology -ServiceName ContosoService1  -Name ContosoService1Storage
```

This command gets a service unit named ContosoService1Storage under a service ContosoService1 in a service topology named ContosoServiceTopology in the ContosoResourceGroup.

### Example 2: Get a service unit using the resource identifier.
```powershell
PS C:\> Get-AzureRmDeploymentManagerServiceUnit -ResourceId "/subscriptions/subscriptionId/resourcegroups/ContosoResourceGroup/providers/Microsoft.DeploymentManager/serviceTopologies/ContosoServiceTopology/services/ContosoService1/serviceUnits/ContosoService1Storage"
```

This command gets a service unit named ContosoService1Storage under a service ContosoService1 in a service topology named ContosoServiceTopology in the ContosoResourceGroup.

### Example 3: Get a service unit using the service unit object.
```powershell
PS C:\> Get-AzureRmDeploymentManagerServiceUnit -ServiceUnit $serviceUnitObject
```

This command gets a service unit whose name, service name, service topology name and ResourceGroup match the Name, ServiceName, ServiceTopologyName and ResourceGroupName properties of the $serviceUnitObject, respectively.

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

### -Name
The name of the service unit.

```yaml
Type: System.String
Parameter Sets: Interactive, ByServiceObject, ByServiceResourceId, ByTopologyObjectAndServiceName, ByTopologyResourceAndServiceName
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group.

```yaml
Type: System.String
Parameter Sets: Interactive, ByServiceObject, ByServiceResourceId, ByTopologyObjectAndServiceName, ByTopologyResourceAndServiceName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource identifier.

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Service
The service object in which the service unit should be created.

```yaml
Type: Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceResource
Parameter Sets: ByServiceObject
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the service the service unit is part of.

```yaml
Type: System.String
Parameter Sets: Interactive, ByTopologyObjectAndServiceName, ByTopologyResourceAndServiceName
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceResourceId
The service resource identifier in which the service unit should be created.

```yaml
Type: System.String
Parameter Sets: ByServiceResourceId
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTopology
The service topology object in which the service unit should be created.

```yaml
Type: Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceTopologyResource
Parameter Sets: ByTopologyObjectAndServiceName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTopologyName
The name of the service topology the service unit is part of.

```yaml
Type: System.String
Parameter Sets: Interactive
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceTopologyResourceId
The service topology resource identifier in which the service unit should be created.

```yaml
Type: System.String
Parameter Sets: ByTopologyResourceAndServiceName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceUnit
Service unit resource object.

```yaml
Type: Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceUnitResource
Parameter Sets: InputObject
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.DeploymentManager.Models.PSServiceUnitResource

## NOTES

## RELATED LINKS

[New-AzureRmDeploymentManagerServiceUnit](./New-AzureRmDeploymentManagerServiceUnit.md)

[Remove-AzureRmDeploymentManagerServiceUnit](./Remove-AzureRmDeploymentManagerServiceUnit.md)

[Set-AzureRmDeploymentManagerServiceUnit](./Set-AzureRmDeploymentManagerServiceUnit.md)