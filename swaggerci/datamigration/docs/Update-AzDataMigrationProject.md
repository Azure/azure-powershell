---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/en-us/powershell/module/az.datamigration/update-azdatamigrationproject
schema: 2.0.0
---

# Update-AzDataMigrationProject

## SYNOPSIS
The project resource is a nested resource representing a stored migration project.
The PATCH method updates an existing project.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataMigrationProject -GroupName <String> -Name <String> -ServiceName <String>
 [-SubscriptionId <String>] [-AzureAuthenticationInfoAppKey <String>]
 [-AzureAuthenticationInfoApplicationId <String>] [-AzureAuthenticationInfoIgnoreAzurePermission]
 [-AzureAuthenticationInfoTenantId <String>] [-DatabasesInfo <IDatabaseInfo[]>] [-Etag <String>]
 [-Location <String>] [-SourceConnectionInfoPassword <String>] [-SourceConnectionInfoType <String>]
 [-SourceConnectionInfoUserName <String>] [-SourcePlatform <ProjectSourcePlatform>] [-Tag <Hashtable>]
 [-TargetConnectionInfoPassword <String>] [-TargetConnectionInfoType <String>]
 [-TargetConnectionInfoUserName <String>] [-TargetPlatform <ProjectTargetPlatform>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataMigrationProject -InputObject <IDataMigrationIdentity> [-AzureAuthenticationInfoAppKey <String>]
 [-AzureAuthenticationInfoApplicationId <String>] [-AzureAuthenticationInfoIgnoreAzurePermission]
 [-AzureAuthenticationInfoTenantId <String>] [-DatabasesInfo <IDatabaseInfo[]>] [-Etag <String>]
 [-Location <String>] [-SourceConnectionInfoPassword <String>] [-SourceConnectionInfoType <String>]
 [-SourceConnectionInfoUserName <String>] [-SourcePlatform <ProjectSourcePlatform>] [-Tag <Hashtable>]
 [-TargetConnectionInfoPassword <String>] [-TargetConnectionInfoType <String>]
 [-TargetConnectionInfoUserName <String>] [-TargetPlatform <ProjectTargetPlatform>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The project resource is a nested resource representing a stored migration project.
The PATCH method updates an existing project.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AzureAuthenticationInfoAppKey
Key used to authenticate to the Azure Active Directory Application

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

### -AzureAuthenticationInfoApplicationId
Application ID of the Azure Active Directory Application

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

### -AzureAuthenticationInfoIgnoreAzurePermission
Ignore checking azure permissions on the AAD app

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

### -AzureAuthenticationInfoTenantId
Tenant id of the customer

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

### -DatabasesInfo
List of DatabaseInfo
To construct, see NOTES section for DATABASESINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.IDatabaseInfo[]
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
HTTP strong entity tag value.
This is ignored if submitted.

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

### -GroupName
Name of the resource group

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
.

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
Name of the project

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
Name of the service

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceConnectionInfoPassword
Password credential.

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

### -SourceConnectionInfoType
Type of connection info

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

### -SourceConnectionInfoUserName
User name

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

### -SourcePlatform
Source platform for the project

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ProjectSourcePlatform
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Dictionary of \<string\>

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetConnectionInfoPassword
Password credential.

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

### -TargetConnectionInfoType
Type of connection info

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

### -TargetConnectionInfoUserName
User name

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

### -TargetPlatform
Target platform for the project

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ProjectTargetPlatform
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

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.IProject

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DATABASESINFO <IDatabaseInfo[]>: List of DatabaseInfo
  - `SourceDatabaseName <String>`: Name of the database

INPUTOBJECT <IDataMigrationIdentity>: Identity Parameter
  - `[FileName <String>]`: Name of the File
  - `[GroupName <String>]`: Name of the resource group
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The Azure region of the operation
  - `[ManagedInstanceName <String>]`: 
  - `[ProjectName <String>]`: Name of the project
  - `[ResourceGroupName <String>]`: Name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ServiceName <String>]`: Name of the service
  - `[SqlDbInstanceName <String>]`: 
  - `[SqlMigrationServiceName <String>]`: Name of the SQL Migration Service.
  - `[SqlVirtualMachineName <String>]`: 
  - `[SubscriptionId <String>]`: Subscription ID that identifies an Azure subscription.
  - `[TargetDbName <String>]`: The name of the target database.
  - `[TaskName <String>]`: Name of the Task

## RELATED LINKS

