---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Update-AzureRmSqlManagedInstance

## SYNOPSIS
Modifies properties of a SQL Database Managed instance. Only properties that are explicitly set will be updated.

## SYNTAX

### UpdateManagedInstanceFromInputParameters
```
Update-AzureRmSqlManagedInstance [-ManagedInstanceName] <String> [-ResourceGroupName] <String>
 [-AdministratorPassword <SecureString>] [-LicenseType <String>] [-StorageSizeInGB <Int32>] [-Vcore <Int32>]
 [-Tags <Hashtable>] [-AssignIdentity] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateManagedInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
```
Update-AzureRmSqlManagedInstance [-AdministratorPassword <SecureString>] [-LicenseType <String>]
 [-StorageSizeInGB <Int32>] [-Vcore <Int32>] [-Tags <Hashtable>] [-AssignIdentity]
 -InputObject <AzureSqlManagedInstanceModel> [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateManagedInstanceFromAzureResourceId
```
Update-AzureRmSqlManagedInstance [-AdministratorPassword <SecureString>] [-LicenseType <String>]
 [-StorageSizeInGB <Int32>] [-Vcore <Int32>] [-Tags <Hashtable>] [-AssignIdentity] -ResourceId <String>
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmSqlManagedInstance** cmdlet modifies properties of an Azure SQL Database Managed instance. Only properties that are explicitly set will be updated.

## EXAMPLES

### Example 1: Reset the administrator password
```
PS C:\>$ManagedInstancePassword = "Newpassword1234"
PS C:\> $SecureString = ConvertTo-SecureString $ManagedInstancePassword -AsPlainText -Force
PS C:\> Set-AzureRmSqlManagedInstance -ResourceGroupName "ResourceGroup01" -ManagedInstanceName "managedinstance1" -AdministratorPassword $SecureString
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
```

This command resets the administrator password on the AzureSQL managed instance named managedinstance1.

## PARAMETERS

### -AdministratorPassword
The new SQL administrator password for the Managed instance.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignIdentity
Generate and assign an Azure Active Directory Identity for this Managed instance for use with key management services like Azure KeyVault.

```yaml
Type: SwitchParameter
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Skip confirmation message for performing the action

```yaml
Type: SwitchParameter
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
Type: AzureSqlManagedInstanceModel
Parameter Sets: UpdateManagedInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
Aliases: ManagedInstance

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LicenseType
Determines which License Type of Sql Azure Managed Instance to use

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedInstanceName
SQL Database Managed instance name.

```yaml
Type: String
Parameter Sets: UpdateManagedInstanceFromInputParameters
Aliases: Name

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: UpdateManagedInstanceFromInputParameters
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the Managed instance to remove

```yaml
Type: String
Parameter Sets: UpdateManagedInstanceFromAzureResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageSizeInGB
Determines how much Storage size to associate with Managed instance

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
The tags to associate with the Managed instance.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tag

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vcore
Determines how much VCore to associate with Managed instance

```yaml
Type: Int32
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
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
