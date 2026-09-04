---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/update-azdocumentdbmongocluster
schema: 2.0.0
---

# Update-AzDocumentDBMongoCluster

## SYNOPSIS
Update a mongo cluster.
update overwrites all properties for the resource.
To only modify some of the properties, use PATCH.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDocumentDBMongoCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AdministratorPassword <SecureString>] [-AdministratorUserName <String>] [-AuthConfigAllowedMode <String[]>]
 [-ComputeTier <String>] [-CustomerManagedKeyEncryptionKeyUrl <String>] [-DataApiMode <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-HighAvailabilityTargetMode <String>]
 [-KeyEncryptionKeyIdentityType <String>] [-KeyEncryptionKeyIdentityUserAssignedIdentityResourceId <String>]
 [-NetworkBypassMode <String>] [-PreviewFeature <String[]>] [-PublicNetworkAccess <String>]
 [-ServerVersion <String>] [-ShardingShardCount <Int32>] [-StorageSizeGb <Int64>] [-StorageType <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDocumentDBMongoCluster -InputObject <IDocumentDbIdentity> [-AdministratorPassword <SecureString>]
 [-AdministratorUserName <String>] [-AuthConfigAllowedMode <String[]>] [-ComputeTier <String>]
 [-CustomerManagedKeyEncryptionKeyUrl <String>] [-DataApiMode <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-HighAvailabilityTargetMode <String>]
 [-KeyEncryptionKeyIdentityType <String>] [-KeyEncryptionKeyIdentityUserAssignedIdentityResourceId <String>]
 [-NetworkBypassMode <String>] [-PreviewFeature <String[]>] [-PublicNetworkAccess <String>]
 [-ServerVersion <String>] [-ShardingShardCount <Int32>] [-StorageSizeGb <Int64>] [-StorageType <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a mongo cluster.
update overwrites all properties for the resource.
To only modify some of the properties, use PATCH.

## EXAMPLES

### Example 1: Update the tags of a mongo cluster
```powershell
Update-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup -Tag @{ env = 'test'; owner = 'cli' }
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Update a mongo cluster to apply resource tags.

### Example 2: Enable the Mongo data API on a mongo cluster
```powershell
Update-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup -DataApiMode Enabled
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Enable the Mongo data API.
The data API can only be toggled once the cluster is
provisioned and while public network access is enabled.

### Example 3: Add a user-assigned managed identity
```powershell
$cluster = Get-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup
$identityIds = @($cluster.IdentityUserAssignedIdentity.Keys) + $identityId
$cluster | Update-AzDocumentDBMongoCluster -UserAssignedIdentity $identityIds
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Get the existing identities, add another identity to the collection, and apply the
updated collection to the cluster. This preserves identities that are already assigned.

## PARAMETERS

### -AdministratorPassword
The administrator password.

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

### -AdministratorUserName
The administrator user name.

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

### -AuthConfigAllowedMode
Allowed authentication modes for data access on the cluster.

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

### -ComputeTier
The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size.
Example values: 'M30', 'M40'.

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

### -CustomerManagedKeyEncryptionKeyUrl
The URI of the key vault key used for encryption.

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

### -DataApiMode
The mode to indicate whether the Mongo Data API is enabled for a cluster.

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

### -HighAvailabilityTargetMode
The target high availability mode requested for the cluster.

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
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyEncryptionKeyIdentityType
The type of identity.
Only 'UserAssignedIdentity' is supported.

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

### -KeyEncryptionKeyIdentityUserAssignedIdentityResourceId
The user assigned identity resource id.

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
The name of the mongo cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: MongoClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkBypassMode
The network bypass mode for the cluster.
Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.

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

### -PreviewFeature
List of private endpoint connections.

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

### -PublicNetworkAccess
Whether or not public endpoint access is allowed for this mongo cluster.

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

### -ServerVersion
The Mongo DB server version.
Defaults to the latest available version if not specified.

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

### -ShardingShardCount
Number of shards to provision on the cluster.

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

### -StorageSizeGb
The size of the data disk assigned to each server.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageType
The type of storage to provision the cluster servers with.

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

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster

## NOTES

## RELATED LINKS
