---
external help file: Az.MongoDB-help.xml
Module Name: Az.MongoDB
online version: https://learn.microsoft.com/powershell/module/az.mongodb/get-azmongodbcluster
schema: 2.0.0
---

# Get-AzMongoDBCluster

## SYNOPSIS
Get a Cluster

## SYNTAX

### List (Default)
```
Get-AzMongoDBCluster -OrganizationName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityProject
```
Get-AzMongoDBCluster -Name <String> -ProjectInputObject <IMongoDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzMongoDBCluster -Name <String> -ProjectName <String> -OrganizationInputObject <IMongoDbIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMongoDBCluster -Name <String> -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMongoDBCluster -InputObject <IMongoDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Cluster

## EXAMPLES

### Example 1: List all Clusters under a Project
```powershell
Get-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1
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

Lists all clusters that belong to the given project.

### Example 2: Get a specific Cluster
```powershell
Get-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 -Name test-cluster-free | Format-List
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

Gets the details of a single cluster by name.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the MongoDB Atlas Cluster resource.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityProject, GetViaIdentityOrganization, Get
Aliases: ClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: GetViaIdentityOrganization
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
Parameter Sets: List, Get
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
Parameter Sets: GetViaIdentityProject
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
Parameter Sets: List, GetViaIdentityOrganization, Get
Aliases:

Required: True
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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
