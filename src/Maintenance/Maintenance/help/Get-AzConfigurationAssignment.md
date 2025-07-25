---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version: https://learn.microsoft.com/powershell/module/az.maintenance/get-azconfigurationassignment
schema: 2.0.0
---

# Get-AzConfigurationAssignment

## SYNOPSIS
List configurationAssignments for resource.

## SYNTAX

```
Get-AzConfigurationAssignment [[-ResourceGroupName] <String>] [[-ProviderName] <String>]
 [-ResourceParentType <String>] [-ResourceParentName <String>] [[-ResourceType] <String>]
 [[-ResourceName] <String>] [-ConfigurationAssignmentName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
List configurationAssignments for resource.

## EXAMPLES

### Example 1
```powershell
Get-AzConfigurationAssignment -ResourceGroupName smdtestwestus2 -ResourceParentType hostGroups -ResourceParentName smddhgwestus2 -ResourceType hosts -ResourceName smddhwestus2 -ProviderName Microsoft.Compute
```

```output
MaintenanceConfigurationId : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/ps1/providers/Microsoft.Maintenance/maintenanceConfigurations/ps2
Id                         :
/subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/smdtestwestus2/providers/Microsoft.Compute/hostGroups/smddhgwestus2/hosts/smddhwestus2/providers/Microsoft.Maintenance/configurationAssignments/ps2
Name                       : ps2
Type                       : Microsoft.Maintenance/configurationAssignments
```

List configurationAssignments for dedicated host.

### Example 2
```powershell
Get-AzConfigurationAssignment -ResourceGroupName 'rgtestwestus2' -ProviderName Microsoft.Compute -ResourceType virtualmachines -ResourceName 'LAPTOP-ABCDEFG'
```

```output
MaintenanceConfigurationId : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/maintenanceconfigurations/providers/microsoft.maintenance/maintenanceconfigurations/dynamicfiltertag
ResourceId                 : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/rgtestwestus2/providers/microsoft.hybridcompute/machines/laptop-abcdefg
Id                         : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa747/resourcegroups/rgtestwestus2/providers/Microsoft.HybridCompute/machines/LAPTOP-ABCDEFG/providers/Microsoft.Maintenance/configurationAssignments/pphsfbx2qur7k-azpolicy
Name                       : pphsfbx2qur7k-azpolicy
Type                       : Microsoft.Maintenance/configurationAssignments
```

List configurationAssignments for Azure VMs in Guest scope.

### Example 3
```powershell
Get-AzConfigurationAssignment -ResourceGroupName 'ArcMachines' -ProviderName Microsoft.HybridCompute -ResourceType machines -ResourceName 'LAPTOP-IVMI31G2'
```

```output
MaintenanceConfigurationId : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/maintenanceconfigurations/providers/microsoft.maintenance/maintenanceconfigurations/dynamicfiltertag
ResourceId                 : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/arcmachines/providers/microsoft.hybridcompute/machines/laptop-ivmi31g2
Id                         : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa747/resourcegroups/arcmachines/providers/Microsoft.HybridCompute/machines/LAPTOP-IVMI31G2/providers/Microsoft.Maintenance/configurationAssignments/pphsfbx2qur7k-azpolicy
Name                       : pphsfbx2qur7k-azpolicy
Type                       : Microsoft.Maintenance/configurationAssignments
```

List configurationAssignments for Arc VMs in Guest scope.

## PARAMETERS

### -ConfigurationAssignmentName
The configuration assignment name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ProviderName
The resource provider Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource Group Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceName
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceParentName
The parent resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceParentType
The parent resource type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceType
The resource type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Maintenance.Models.PSConfigurationAssignment

## NOTES

## RELATED LINKS
