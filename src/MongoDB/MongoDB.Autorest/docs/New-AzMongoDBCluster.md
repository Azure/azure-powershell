---
external help file:
Module Name: Az.MongoDB
online version: https://learn.microsoft.com/powershell/module/az.mongodb/new-azmongodbcluster
schema: 2.0.0
---

# New-AzMongoDBCluster

## SYNOPSIS
Create a Cluster

## SYNTAX

### CreateExpanded (Default)
```
New-AzMongoDBCluster -Name <String> -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ClusterTier <String>] [-RegionName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityOrganizationExpanded
```
New-AzMongoDBCluster -Name <String> -OrganizationInputObject <IMongoDbIdentity> -ProjectName <String>
 [-ClusterTier <String>] [-RegionName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProjectExpanded
```
New-AzMongoDBCluster -Name <String> -ProjectInputObject <IMongoDbIdentity> [-ClusterTier <String>]
 [-RegionName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMongoDBCluster -Name <String> -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMongoDBCluster -Name <String> -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a Cluster

## EXAMPLES

### Example 1: Create a new FREE-tier Cluster
```powershell
New-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 -Name test-cluster-free -ClusterTier FREE -RegionName eastus2 | Format-List
```

```output
Backup                       : False
ClusterName                  : test-cluster-free
Id                           : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/sharmaanuTest/providers/MongoDB.Atlas/organizations/KanedaTest/projects/test-project-1/clusters/test-cluster-free
MongoDbVersion               : 8.0.24-patch-6a3992052eafe5000797a34e
Name                         : test-cluster-free
ProvisioningState            : Succeeded
RegionName                   : eastus2
ResourceGroupName            : sharmaanuTest
State                        : IDLE
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tier                         : FREE
Type                         : MongoDB.Atlas/organizations/projects/clusters
```

Creates a FREE-tier MongoDB Atlas cluster in `eastus2` under the given project.
Valid tiers are FREE, FLEX, M10, M30.
Use `Get-AzMongoDBProjectClusterTierRegion` first to confirm the chosen tier is available in the target region.

### Example 2: Create a paid (M10) Cluster
```powershell
New-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 -Name test-cluster-m10 -ClusterTier M10 -RegionName westus2
```

Creates a dedicated M10 cluster.
M10/M30 tiers incur metered billing through the MongoDB Atlas marketplace offer linked to the organization.

## PARAMETERS

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

### -ClusterTier
Cluster tier (FREE, FLEX, M10, M30).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityProjectExpanded
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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the MongoDB Atlas Cluster resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
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

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: CreateViaIdentityOrganizationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Name of the Organization resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: CreateViaIdentityProjectExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
Name of the MongoDB Atlas Project resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegionName
Azure region where the cluster is deployed.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityProjectExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.ICluster

## NOTES

## RELATED LINKS

