---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-Help.xml
Module Name: Az.ServiceFabric
online version: https://docs.microsoft.com/powershell/module/az.servicefabric/update-azservicefabricvmimage
schema: 2.0.0
---

# Update-AzServiceFabricVmImage

## SYNOPSIS

Update the cluster resource vmImage setting which maps the appropriate runtime package to be delivered based on the target operating system.

## SYNTAX

```
Update-AzServiceFabricVmImage [-ResourceGroupName] <String> [-Name] <String> -VmImage <VmImageKind>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

Use **Update-AzServiceFabricVmImage** to update the vmImage setting of the cluster, responsible for runtime package delivery.

Important Note: VmImage 'Linux' as well as 'Ubuntu' map to the delivery of the Ubuntu 16.04 package,
so if the intent is to run Ubuntu18+, use Ubuntu18_04.

## EXAMPLES

### Example 1

```powershell
Update-AzServiceFabricVmImage -ResourceGroupName 'Group1' -ClusterName 'Contoso01SFCluster' -VmImage Ubuntu18_04
```

This command changes vmImage of the of the cluster 'Contoso01SFCluster' to 'Ubuntu18_04',
for the purpose of migrating future upgrades to use the Ubuntu 18 SF runtime deb package.

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

Specify the name of the cluster, if not given it will be same as resource group name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName

Specify the name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VmImage
Specify common target vmImage to be used for the cluster.

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.VmImageKind
Parameter Sets: (All)
Aliases:
Accepted values: Windows, Linux, Ubuntu, Ubuntu18_04, Ubuntu20_04

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf

Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.ServiceFabric.Models.VmImageKind

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PSDeploymentResult

## NOTES

## RELATED LINKS
