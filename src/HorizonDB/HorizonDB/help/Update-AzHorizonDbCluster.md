---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/update-azhorizondbcluster
schema: 2.0.0
---

# Update-AzHorizonDbCluster

## SYNOPSIS
Replace a new HorizonDB cluster or replaces an existing cluster.
PointInTimeRestore replace the new Cluster resource and hydrates its service-owned database storage from an available source backup.
It does not clone source pools, Pool-scoped endpoints, firewall rules, parameter-group associations, or other child resources.
The new Cluster receives its service-generated Cluster-scoped Endpoint named cluster.
For restore, postgreSqlVersion must be omitted because the service obtains it from backup metadata.
During restore creation, the service ignores the requested backup.geoRedundancy value and configures the new cluster with the same geo-redundancy setting as the source cluster; this applies to both same-location and cross-location restores.
All remaining new-cluster configuration comes from the request or service defaults.
Same-location restore requires and honors pointInTimeUtc and allows creationSourceClusterLocation to be omitted.
Cross-location restore requires creationSourceClusterLocation to identify the source cluster's Azure location and requires pointInTimeUtc, but ignores the supplied timestamp and restores the latest available backup.
Cross-location responses omit pointInTimeUtc.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHorizonDbCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AiModelManagement <String>] [-BackupRetentionDay <Int32>] [-DataEncryptionPrimaryKeyUri <String>]
 [-DataEncryptionPrimaryUserAssignedIdentityId <String>] [-DataEncryptionType <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-NetworkPublicAccess <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHorizonDbCluster -InputObject <IHorizonDbIdentity> [-AiModelManagement <String>]
 [-BackupRetentionDay <Int32>] [-DataEncryptionPrimaryKeyUri <String>]
 [-DataEncryptionPrimaryUserAssignedIdentityId <String>] [-DataEncryptionType <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-NetworkPublicAccess <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Replace a new HorizonDB cluster or replaces an existing cluster.
PointInTimeRestore replace the new Cluster resource and hydrates its service-owned database storage from an available source backup.
It does not clone source pools, Pool-scoped endpoints, firewall rules, parameter-group associations, or other child resources.
The new Cluster receives its service-generated Cluster-scoped Endpoint named cluster.
For restore, postgreSqlVersion must be omitted because the service obtains it from backup metadata.
During restore creation, the service ignores the requested backup.geoRedundancy value and configures the new cluster with the same geo-redundancy setting as the source cluster; this applies to both same-location and cross-location restores.
All remaining new-cluster configuration comes from the request or service defaults.
Same-location restore requires and honors pointInTimeUtc and allows creationSourceClusterLocation to be omitted.
Cross-location restore requires creationSourceClusterLocation to identify the source cluster's Azure location and requires pointInTimeUtc, but ignores the supplied timestamp and restores the latest available backup.
Cross-location responses omit pointInTimeUtc.

## EXAMPLES

### Example 1: Update cluster networking, backup retention, and tags
```powershell
$tags = @{
    environment = 'production'
    team = 'data-platform'
}
Update-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'example-cluster' -NetworkPublicAccess 'Disabled' -BackupRetentionDay 21 -Tag $tags | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 21
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Update the customer-managed encryption key reference
```powershell
Update-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'example-cluster' -DataEncryptionPrimaryKeyUri 'https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay, DataEncryptionType, DataEncryptionPrimaryKeyUri
```

```output
Name                        : example-cluster
Location                    : eastus2
PostgreSqlVersion           : 17
CreationMode                : Create
State                       : Ready
ProvisioningState           : Succeeded
BackupGeoRedundancy         : Disabled
BackupRetentionDay          : 14
DataEncryptionType          : AzureKeyVault
DataEncryptionPrimaryKeyUri : https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

## PARAMETERS

### -AiModelManagement
Specifies whether AI Model Management is enabled for the cluster.

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

### -AsJob
Run the command as a job

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

### -BackupRetentionDay
The number of days that automatic backups are retained.
The service defaults to 7 days when this property is omitted.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionPrimaryKeyUri
The versionless Azure Key Vault key URI used to encrypt the cluster's primary storage.
Key version paths are not supported.
During initial cluster creation, this property can be provided together with primaryUserAssignedIdentityId.
For updates to an existing cluster through PUT or PATCH, this property and primaryUserAssignedIdentityId cannot both change in the same request; the first update must complete before submitting a separate update for the other property.

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

### -DataEncryptionPrimaryUserAssignedIdentityId
The Azure resource ID of the user-assigned managed identity used to access the primary encryption key.
The identity must also be assigned to the Cluster through its top-level identity property.
During initial cluster creation, this property can be provided together with primaryKeyUri.
For updates to an existing cluster through PUT or PATCH, this property and primaryKeyUri cannot both change in the same request; the first update must complete before submitting a separate update for the other property.

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

### -DataEncryptionType
The type of data encryption used by the cluster.
When the data encryption configuration is supplied during initial cluster creation, this property is required.
For PUT updates of an existing cluster, this property may be omitted; if provided, it must match the existing encryption type.
This value is selected at cluster creation and cannot later be changed from SystemManaged to AzureKeyVault or from AzureKeyVault to SystemManaged.

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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the HorizonDB cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkPublicAccess
Specifies whether public access is enabled for the cluster.
The service defaults to Disabled when this property is omitted.

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

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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
Resource tags.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.ICluster

## NOTES

## RELATED LINKS
