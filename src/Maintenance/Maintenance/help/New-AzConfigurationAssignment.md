---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version: https://learn.microsoft.com/powershell/module/az.maintenance/new-azconfigurationassignment
schema: 2.0.0
---

# New-AzConfigurationAssignment

## SYNOPSIS
Register configuration for resource.

## SYNTAX

```
New-AzConfigurationAssignment [[-ResourceGroupName] <String>] [[-ProviderName] <String>]
 [-ResourceParentType <String>] [-ResourceParentName <String>] [[-ResourceType] <String>]
 [[-ResourceName] <String>] -ConfigurationAssignmentName <String> [-ResourceId <String>] [-Location <String>]
 -MaintenanceConfigurationId <String> [-FilterResourceType <String[]>] [-FilterLocation <String[]>]
 [-FilterTag <String>] [-FilterOperator <String>] [-FilterOsType <String[]>] [-FilterResourceGroup <String[]>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Register maintenance configuration for resource.

## EXAMPLES

### Example 1
```powershell
New-AzConfigurationAssignment -ResourceGroupName smdtest$location -ResourceParentType hostGroups -ResourceParentName smddhg$location -ResourceType hosts -ResourceName smddh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationCreated.Id -Location $location
```

```output
Location                   : westus2
MaintenanceConfigurationId : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/ps1/providers/Microsoft.Maintenance/maintenanceConfigurations/ps2
ResourceId                 : 7b32ed22-dc7b-4a17-9c42-36c024f4c9f9
Id                         :
/subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/smdtestwestus2/providers/Microsoft.Compute/hostGroups/smddhgwestus2/hosts/smddhwestus2/providers/Microsoft.Maintenance/configurationAssignments/ps2
Name                       : ps2
Type                       : Microsoft.Maintenance/configurationAssignments
```

Register maintenance configuration for dedicated host.

### Example 2
```powershell
New-AzConfigurationAssignment -ConfigurationAssignmentName configAssignmentName -MaintenanceConfigurationId /subscriptions/eee2cef4-bc47-4278-b4f8-cfc65f25dfd8/resourceGroups/AUMDemov01/providers/Microsoft.Maintenance/maintenanceConfigurations/kachavan-prepost01  -FilterLocation eastus2euap,centraluseuap  -FilterOsType Windows,Linux -FilterTag '{"tagKey1" : ["tagKey1Value1", "tagKey1Value2"], "tagKey2" : ["tagKey2Value1", "tagKey2Value2", "tagKey2Value3"] }' -FilterOperator "Any" -Location global
```

```output
Location                   : global
MaintenanceConfigurationId : /subscriptions/eee2cef4-bc47-4278-b4f8-cfc65f25dfd8/resourceGroups/AUMDemov01/providers/Microsoft.Maintenance/maintenanceConfigurations/kachavan-prepost01
ResourceId                 : /subscriptions/eee2cef4-bc47-4278-b4f8-cfc65f25dfd8
Id                         : /subscriptions/eee2cef4-bc47-4278-b4f8-cfc65f25dfd8/providers/microsoft.maintenance/configurationassignments/configassignmentname
Name                       : configassignmentname
Type                       : microsoft.maintenance/configurationassignments
FilterTag                  : {"tagKey1":["tagKey1Value1","tagKey1Value2"],"tagKey2":["tagKey2Value1","tagKey2Value2","tagKey2Value3"]}
FilterOperator             : Any
FilterLocation[0]          : eastus2euap
FilterLocation[1]          : centraluseuap
FilterOsType[0]            : Windows
FilterOsType[1]            : Linux
```
Register maintenance configuration for InGuest scope

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

### -ConfigurationAssignmentName
The configuration assignment name, should match the MaintenanceConfigurationName.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -FilterLocation
Allowed locations for dynamic scope.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterOperator
Tag filter operator for dynamic scope.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterOsType
Operating system type for dynamic scope.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterResourceGroup
Operating system type for dynamic scope.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterResourceType
Allowed resource types for dynamic scope.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterTag
Allowed resource types for dynamic scope.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location without spaces for the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceConfigurationId
The fully qualified MaintenanceConfiguration.

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

### -ResourceId
The configuration assignment name, should match the MaintenanceConfigurationName.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

## OUTPUTS

### Microsoft.Azure.Commands.Maintenance.Models.PSConfigurationAssignment

## NOTES

## RELATED LINKS
