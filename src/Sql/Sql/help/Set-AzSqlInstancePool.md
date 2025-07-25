---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/set-azsqlinstancepool
schema: 2.0.0
---

# Set-AzSqlInstancePool

## SYNOPSIS
Sets properties for an Azure SQL Instance pool.

## SYNTAX

### DefaultSetInstancePoolParameterSet (Default)
```
Set-AzSqlInstancePool [-ResourceGroupName] <String> [-Name] <String> [-LicenseType <String>] [-Tag <Hashtable>]
 -VCore <Int32> -Edition <String> -ComputeGeneration <String> -MaintenanceConfigurationId <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectSetInstancePoolParameterSet
```
Set-AzSqlInstancePool [-InputObject] <AzureSqlInstancePoolModel> [-LicenseType <String>] [-Tag <Hashtable>]
 -VCore <Int32> -Edition <String> -ComputeGeneration <String> -MaintenanceConfigurationId <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdSetInstancePoolParameterSet
```
Set-AzSqlInstancePool [-ResourceId] <String> [-LicenseType <String>] [-Tag <Hashtable>]
 -VCore <Int32> -Edition <String> -ComputeGeneration <String> -MaintenanceConfigurationId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSqlInstancePool** cmdlet modifies properties of an Azure SQL Instance pool.

## EXAMPLES

### Example 1 : Set an instance pool license type
```powershell
Set-AzSqlInstancePool -ResourceGroupName resourcegroup01 -Name instancePool0 -LicenseType LicenseIncluded
```

```output
ResourceGroupName          : resourcegroup01
Type                       : Microsoft.Sql/instancePools
Id                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/instancePools/instancePool0
InstancePoolName           : instancePool0
SubnetId                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
VCores                     : 8
ComputeGeneration          : Gen5
Edition                    : GeneralPurpose
Tags                       :
Sku                        : Microsoft.Azure.Management.Sql.Models.Sku
Location                   : canadacentral
LicenseType                : LicenseIncluded
DnsZone                    : 1234567890
MaintenanceConfigurationId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_canadacentral_MI_1
```

This command sets the license type and/or tags for an instance pool named instancePool0.

### Example 2 : Set an instance pool license type using an instance pool object
```powershell
$instancePool = Get-AzSqlInstancePool -ResourceGroupName resourcegroup01 -Name instancePool0
Set-AzSqlInstancePool -InputObject $instancePool -LicenseType LicenseIncluded
```

```output
ResourceGroupName : resourcegroup01
Type              : Microsoft.Sql/instancePools
Id                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/instancePools/instancePool0
InstancePoolName  : instancePool0
SubnetId          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
VCores            : 8
ComputeGeneration : Gen5
Edition           : GeneralPurpose
Tags              :
Sku               : Microsoft.Azure.Management.Sql.Models.Sku
Location          : canadacentral
LicenseType       : LicenseIncluded
DnsZone                    : 1234567890
MaintenanceConfigurationId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_canadacentral_MI_1
```

This command sets the license type and/or tags for an instance pool using an instance pool object.

### Example 3 : Set an instance pool license type using an instance pool resource id
```powershell
Set-AzSqlInstancePool -ResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/instancePools/instancePool0" -LicenseType LicenseIncluded
```

```output
ResourceGroupName : resourcegroup01
Type              : Microsoft.Sql/instancePools
Id                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/instancePools/instancePool0
InstancePoolName  : instancePool0
SubnetId          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
VCores            : 8
ComputeGeneration : Gen5
Edition           : GeneralPurpose
Tags              :
Sku               : Microsoft.Azure.Management.Sql.Models.Sku
Location          : canadacentral
LicenseType       : LicenseIncluded
DnsZone                    : 1234567890
MaintenanceConfigurationId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_canadacentral_MI_1
```

This command sets the license type and/or tags for an instance pool named instancePool0.

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

### -InputObject
The instance pool input object.

```yaml
Type: Microsoft.Azure.Commands.Sql.Instance_Pools.Model.AzureSqlInstancePoolModel
Parameter Sets: InputObjectSetInstancePoolParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LicenseType
Determines which License Type to use.
Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).

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

### -Name
The name of the instance pool.

```yaml
Type: System.String
Parameter Sets: DefaultSetInstancePoolParameterSet
Aliases: InstancePoolName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DefaultSetInstancePoolParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The instance pool resource identifier.

```yaml
Type: System.String
Parameter Sets: ResourceIdSetInstancePoolParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
The tags to associate with the instance

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### Microsoft.Azure.Commands.Sql.Instance_Pools.Model.AzureSqlInstancePoolModel

### System.String

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
