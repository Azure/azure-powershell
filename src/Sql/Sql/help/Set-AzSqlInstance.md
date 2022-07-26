---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/set-azsqlinstance
schema: 2.0.0
---

# Set-AzSqlInstance

## SYNOPSIS
Sets properties for an Azure SQL Managed Instance.

## SYNTAX

### SetInstanceFromInputParameters (Default)
```
Set-AzSqlInstance [-Name] <String> [-ResourceGroupName] <String> [-AdministratorPassword <SecureString>]
 [-Edition <String>] [-SubnetId <String>] [-LicenseType <String>] [-StorageSizeInGB <Int32>] [-VCore <Int32>]
 [-PublicDataEndpointEnabled <Boolean>] [-ProxyOverride <String>] [-Tag <Hashtable>] [-AssignIdentity]
 [-InstancePoolName <String>] [-MinimalTlsVersion <String>] [-PrimaryUserAssignedIdentityId <String>]
 [-KeyId <String>] [-Force] [-ComputeGeneration <String>] [-MaintenanceConfigurationId <String>]
 [-UserAssignedIdentityId <System.Collections.Generic.List`1[System.String]>] [-IdentityType <String>]
 [-BackupStorageRedundancy <String>] [-AsJob] [-ZoneRedundant] [-ServicePrincipalType <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
```
Set-AzSqlInstance [-InputObject] <AzureSqlManagedInstanceModel> [-AdministratorPassword <SecureString>]
 [-Edition <String>] [-SubnetId <String>] [-LicenseType <String>] [-StorageSizeInGB <Int32>] [-VCore <Int32>]
 [-PublicDataEndpointEnabled <Boolean>] [-ProxyOverride <String>] [-Tag <Hashtable>] [-AssignIdentity]
 [-InstancePoolName <String>] [-MinimalTlsVersion <String>] [-PrimaryUserAssignedIdentityId <String>]
 [-KeyId <String>] [-Force] [-ComputeGeneration <String>] [-MaintenanceConfigurationId <String>]
 [-UserAssignedIdentityId <System.Collections.Generic.List`1[System.String]>] [-IdentityType <String>]
 [-BackupStorageRedundancy <String>] [-AsJob] [-ZoneRedundant] [-ServicePrincipalType <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetInstanceFromAzureResourceId
```
Set-AzSqlInstance [-ResourceId] <String> [-AdministratorPassword <SecureString>] [-Edition <String>]
 [-SubnetId <String>] [-LicenseType <String>] [-StorageSizeInGB <Int32>] [-VCore <Int32>]
 [-PublicDataEndpointEnabled <Boolean>] [-ProxyOverride <String>] [-Tag <Hashtable>] [-AssignIdentity]
 [-InstancePoolName <String>] [-MinimalTlsVersion <String>] [-PrimaryUserAssignedIdentityId <String>]
 [-KeyId <String>] [-Force] [-ComputeGeneration <String>] [-MaintenanceConfigurationId <String>]
 [-UserAssignedIdentityId <System.Collections.Generic.List`1[System.String]>] [-IdentityType <String>]
 [-BackupStorageRedundancy <String>] [-AsJob] [-ZoneRedundant] [-ServicePrincipalType <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSqlInstance** cmdlet modifies properties of an Azure SQL Managed instance.

## EXAMPLES

### Example 1: Set existing instance using new values for -AdministratorPassword, -LicenseType, -StorageSizeInGB, -VCore and -Edition
```powershell
$InstancePassword = "Newpassword1234"
$SecureString = ConvertTo-SecureString $InstancePassword -AsPlainText -Force
Set-AzSqlInstance -Name "managedinstance1" -ResourceGroupName "ResourceGroup01" -AdministratorPassword $SecureString -LicenseType LicenseIncluded -StorageSizeInGB 1024 -VCore 16 -Edition BusinessCritical
```

```output
Location                 : westcentralus
Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName        : resourcegroup01
ManagedInstanceName      : managedInstance1
Tags                     :
Identity                 : Microsoft.Azure.Management.Sql.Models.ResourceIdentity
Sku                      : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName : managedInstance1.wcusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin       : adminLogin1
AdministratorPassword    :
SubnetId                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
LicenseType              : LicenseIncluded
VCores                   : 16
StorageSizeInGB          : 1024
InstancePoolName         :
```

### Example 2: Change existing instance hardware generation using new value for -ComputeGeneration
```powershell
Set-AzSqlInstance -Name "managedinstance1" -ResourceGroupName "ResourceGroup01" -ComputeGeneration Gen5
```

```output
Location                 : westcentralus
Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName        : resourcegroup01
ManagedInstanceName      : managedInstance1
Tags                     :
Identity                 : Microsoft.Azure.Management.Sql.Models.ResourceIdentity
Sku                      : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName : managedInstance1.wcusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin       : adminLogin1
AdministratorPassword    :
SubnetId                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
LicenseType              : LicenseIncluded
VCores                   : 16
StorageSizeInGB          : 1024
InstancePoolName         :
```

This command sets existing instance using new values for -AdministratorPassword, -LicenseType, -StorageSizeInGB and -VCore

### Example 3: Set existing instance using new values for -AdministratorPassword, -LicenseType, -StorageSizeInGB and -VCore for an instance within an instance pool
```powershell
$InstancePassword = "Newpassword1234"
$SecureString = ConvertTo-SecureString $InstancePassword -AsPlainText -Force
Set-AzSqlInstance -Name "managedinstance1" -ResourceGroupName "ResourceGroup01" -AdministratorPassword $SecureString -LicenseType LicenseIncluded -StorageSizeInGB 1024 -VCore 2 -InstancePoolName instancePool0
```

```output
Location                 : westcentralus
Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName        : resourcegroup01
ManagedInstanceName      : managedInstance1
Tags                     :
Identity                 : Microsoft.Azure.Management.Sql.Models.ResourceIdentity
Sku                      : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName : managedInstance1.wcusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin       : adminLogin1
AdministratorPassword    :
SubnetId                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
LicenseType              : LicenseIncluded
VCores                   : 2
StorageSizeInGB          : 1024
InstancePoolName         : instancePool0
```

This command sets existing instance using new values for -AdministratorPassword, -LicenseType, -StorageSizeInGB and -VCore for an instance within an instance pool

### Example 4: Update maintenance configuration for existing instance
```powershell
Set-AzSqlInstance -Name "managedInstance1" -ResourceGroupName "resourcegroup01" -MaintenanceConfigurationId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_WestUS_MI_2"
```

```output
Location                   : westus
Id                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName          : resourcegroup01
ManagedInstanceName        : managedInstance1
Tags                       :
Identity                   :
Sku                        : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName   : managedInstance1.wusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin         : adminLogin1
AdministratorPassword      :
SubnetId                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
LicenseType                : LicenseIncluded
VCores                     : 8
StorageSizeInGB            : 256
Collation                  : SQL_Latin1_General_CP1_CI_AS
PublicDataEndpointEnabled  : False
ProxyOverride              :
TimezoneId                 : UTC
DnsZonePartner             :
DnsZone                    : ad35cna0mw
InstancePoolName           :
MinimalTlsVersion          :
BackupStorageRedundancy    : Geo
CurrentBackupStorageRedundancy    : Geo
MaintenanceConfigurationId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_WestUS_MI_2
```

This command updates existing instance with maintenance configuration MI_2

### Example 5: Remove maintenance configuration from existing instance
```powershell
Set-AzSqlInstance -Name "managediInstance1" -ResourceGroupName "Resourcegroup01" -MaintenanceConfigurationId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default"
```

```output
Location                   : westus
Id                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName          : resourcegroup01
ManagedInstanceName        : managedInstance1
Tags                       :
Identity                   :
Sku                        : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName   : managedInstance1.wusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin         : adminLogin1
AdministratorPassword      :
SubnetId                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/subnet_name
LicenseType                : LicenseIncluded
VCores                     : 8
StorageSizeInGB            : 256
Collation                  : SQL_Latin1_General_CP1_CI_AS
PublicDataEndpointEnabled  : False
ProxyOverride              :
TimezoneId                 : UTC
DnsZonePartner             :
DnsZone                    : ad35cna0mw
InstancePoolName           :
MinimalTlsVersion          :
BackupStorageRedundancy    : Geo
CurrentBackupStorageRedundancy    : Geo
MaintenanceConfigurationId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default
```

This command resets maintenance configuration to default for existing instance

### Example 6: Move managed instance to another subnet
```powershell
Set-AzSqlInstance -Name "managediInstance1" -ResourceGroupName "Resourcegroup01" -SubnetId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/target_subnet_name"
```

```output
Location                   : westus
Id                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName          : resourcegroup01
ManagedInstanceName        : managedInstance1
Tags                       :
Identity                   :
Sku                        : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName   : managedInstance1.wusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin         : adminLogin1
AdministratorPassword      :
SubnetId                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/target_subnet_name
LicenseType                : LicenseIncluded
VCores                     : 8
StorageSizeInGB            : 256
Collation                  : SQL_Latin1_General_CP1_CI_AS
PublicDataEndpointEnabled  : False
ProxyOverride              :
TimezoneId                 : UTC
DnsZonePartner             :
DnsZone                    : ad35cna0mw
InstancePoolName           :
MinimalTlsVersion          :
BackupStorageRedundancy    : Geo
CurrentBackupStorageRedundancy    : Geo
MaintenanceConfigurationId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default
```

This command updates an existing instance to be zone - redundant

### Example 7: Update an existing instance to be zone - redundant
```powershell
Set-AzSqlInstance -Name "managediInstance1" -ResourceGroupName "Resourcegroup01" -SubnetId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/target_subnet_name" -ZoneRedundant
```

```output
Location                   : westus
Id                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName          : resourcegroup01
ManagedInstanceName        : managedInstance1
Tags                       :
Identity                   :
Sku                        : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName   : managedInstance1.wusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin         : adminLogin1
AdministratorPassword      :
SubnetId                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/target_subnet_name
LicenseType                : LicenseIncluded
VCores                     : 8
StorageSizeInGB            : 256
Collation                  : SQL_Latin1_General_CP1_CI_AS
PublicDataEndpointEnabled  : False
ProxyOverride              :
TimezoneId                 : UTC
DnsZonePartner             :
DnsZone                    : ad35cna0mw
InstancePoolName           :
MinimalTlsVersion          :
BackupStorageRedundancy    : Geo
CurrentBackupStorageRedundancy    : Geo
MaintenanceConfigurationId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default
ZoneRedundant              : true
```

This command moves managed instance to another subnet

### Example 8: Update backup storage redundancy on existing instance
```powershell
Set-AzSqlInstance -Name "managediInstance1" -ResourceGroupName "Resourcegroup01" -BackupStorageRedundancy Local -Force
```

```output
Location                         : westus
Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/managedInstance1
ResourceGroupName                : resourcegroup01
ManagedInstanceName              : managedInstance1
Tags                             :
Identity                         :
Sku                              : Microsoft.Azure.Management.Internal.Resources.Models.Sku
FullyQualifiedDomainName         : managedInstance1.wusxxxxxxxxxxxxx.database.windows.net
AdministratorLogin               : adminLogin1
AdministratorPassword            :
SubnetId                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Network/virtualNetworks/vnet_name/subnets/target_subnet_name
LicenseType                      : LicenseIncluded
VCores                           : 8
StorageSizeInGB                  : 256
Collation                        : SQL_Latin1_General_CP1_CI_AS
PublicDataEndpointEnabled        : False
ProxyOverride                    :
TimezoneId                       : UTC
DnsZonePartner                   :
DnsZone                          : ad35cna0mw
InstancePoolName                 :
MinimalTlsVersion                :
BackupStorageRedundancy          : Geo
CurrentBackupStorageRedundancy   : Geo
RequestedBackupStorageRedundancy : Local
MaintenanceConfigurationId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default
ZoneRedundant                    : False
```

This command changes backups storage redundancy type for managed instance

## PARAMETERS

### -AdministratorPassword
The new SQL administrator password for the instance.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AssignIdentity
Generate and assign an Azure Active Directory Identity for this instance for use with key management services like Azure KeyVault.

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

### -BackupStorageRedundancy
The Backup storage redundancy used to store backups for the Sql Azure Managed Instance. Options are: Local, Zone and Geo

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Local, Zone, Geo, GeoZone

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeGeneration
The compute generation for the instance.

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

### -Edition
The edition to assign to the instance.

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

### -Force
Skip confirmation message for performing the action

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

### -IdentityType
Type of identity to be assigned to the server. Possible values are SystemAsssigned, UserAssigned, 'SystemAssigned,UserAssigned' and None.

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

### -InputObject
The AzureSqlManagedInstanceModel object to remove

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: SetInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
Aliases: SqlInstance

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstancePoolName
The instance pool name.

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

### -KeyId
The Azure Key Vault URI that is used for encryption.

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

### -LicenseType
Determines which License Type to use. Possible values are:
- BasePrice - Azure Hybrid Benefit (AHB) discounted pricing for existing SQL Server license owners is applied. Managed Instance service price will be discounted for existing SQL Server license owners.
- LicenseIncluded - Azure Hybrid Benefit (AHB) discount pricing for existing SQL Server license owners is not applied. Managed Instance service price will include a new SQL Server license costs.

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
The Maintenance configuration id for the Sql Azure Managed Instance.

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

### -MinimalTlsVersion
The minimal TLS version to enforce for Managed instance 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: None, 1.0, 1.1, 1.2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Instance name.

```yaml
Type: System.String
Parameter Sets: SetInstanceFromInputParameters
Aliases: InstanceName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryUserAssignedIdentityId
The primary User Managed Identity(UMI) id.

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

### -ProxyOverride
The connection type used for connecting to the instance.

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

### -PublicDataEndpointEnabled
Whether or not the public data endpoint is enabled for the instance.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: SetInstanceFromInputParameters
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of instance to remove

```yaml
Type: System.String
Parameter Sets: SetInstanceFromAzureResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServicePrincipalType
Type of Service Principal to be used. Possible values are SystemAssigned and None.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: None, SystemAssigned

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSizeInGB
Determines how much Storage size to associate with instance

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
The Subnet Id to use for instance update.

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

### -Tag
The tags to associate with the instance.

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

### -UserAssignedIdentityId
The list of user assigned identities.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VCore
Determines how much VCore to associate with instance

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundant
Use zone redundant storage

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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

## NOTES

## RELATED LINKS
