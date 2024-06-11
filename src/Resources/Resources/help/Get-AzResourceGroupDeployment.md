---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 20CB842B-F7A9-4052-85D9-0DF9586D5FEA
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azresourcegroupdeployment
schema: 2.0.0
---

# Get-AzResourceGroupDeployment

## SYNOPSIS
Gets the deployments in a resource group.

## SYNTAX

### GetByResourceGroupDeploymentName (Default)
```
Get-AzResourceGroupDeployment [-ResourceGroupName] <String> [[-Name] <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByResourceGroupDeploymentId
```
Get-AzResourceGroupDeployment -Id <String> [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzResourceGroupDeployment** cmdlet gets the deployments in an Azure resource group.
Specify the *Name* or *Id* parameter to filter the results.
By default, **Get-AzResourceGroupDeployment** gets all deployments for a specified resource group.
An Azure resource is a user-managed Azure entity, such as a database server, database, or web site.
An Azure resource group is a collection of Azure resources that are deployed as a unit.
A deployment is the operation that makes the resources in the resource group available for use.
For more information about Azure resources and Azure resource groups, see the New-AzResourceGroup cmdlet.
You can use this cmdlet for tracking.
For debugging, use this cmdlet with the Get-AzLog cmdlet.

## EXAMPLES

### Example 1: Get all deployments for a resource group
```powershell
Get-AzResourceGroupDeployment -ResourceGroupName "ContosoLabsRG"
```

This command gets all deployments for the ContosoLabsRG resource group.
The output shows a deployment for a WordPress blog that used a gallery template.

### Example 2: Get a deployment by name
```powershell
Get-AzResourceGroupDeployment -ResourceGroupName "ContosoLabsRG" -Name "DeployWebsite01"
```

This command gets the DeployWebsite01 deployment of the ContosoLabsRG resource group.
You can assign a name to a deployment when you create it by using the **New-AzResourceGroup** or **New-AzResourceGroupDeployment** cmdlets.
If you do not assign a name, the cmdlets provide a default name based on the template that is used to create the deployment.

### Example 3: Get the deployments of all resource groups
```powershell
Get-AzResourceGroup | Get-AzResourceGroupDeployment | Format-Table ResourceGroupName, DeploymentName, ProvisioningState
```

This command gets all resource groups in your subscription by using the Get-AzResourceGroup cmdlet.
The command passes the resource groups to the current cmdlet by using the pipeline operator.
The current cmdlet gets all deployments of all resource groups in the subscription, and passes the results to the Format-Table cmdlet to display their **ResourceGroupName**, **DeploymentName**, and **ProvisioningState** property values.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -Id
Specifies the ID of the resource group deployment to get.

```yaml
Type: System.String
Parameter Sets: GetByResourceGroupDeploymentId
Aliases: DeploymentId, ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the deployment to get.
Wildcard characters are not permitted.

```yaml
Type: System.String
Parameter Sets: GetByResourceGroupDeploymentName
Aliases: DeploymentName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
Indicates that this cmdlet considers pre-release API versions when it automatically determines which version to use.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group.
The cmdlet gets the deployments for the resource group that this parameter specifies.
Wildcard characters are not permitted.
This parameter is required and you can specify only one resource group in each command.

```yaml
Type: System.String
Parameter Sets: GetByResourceGroupDeploymentName
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

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceGroupDeployment

## NOTES

## RELATED LINKS

[Get-AzResourceGroup](./Get-AzResourceGroup.md)

[New-AzResourceGroup](./New-AzResourceGroup.md)

[New-AzResourceGroupDeployment](./New-AzResourceGroupDeployment.md)

[Remove-AzResourceGroupDeployment](./Remove-AzResourceGroupDeployment.md)

[Stop-AzResourceGroupDeployment](./Stop-AzResourceGroupDeployment.md)

[Test-AzResourceGroupDeployment](./Test-AzResourceGroupDeployment.md)
