---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbendpoint
schema: 2.0.0
---

# Get-AzHorizonDbEndpoint

## SYNOPSIS
Gets information about a service-generated HorizonDB Cluster- or Pool-scoped Endpoint.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbEndpoint -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbEndpoint -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzHorizonDbEndpoint -Name <String> -ClusterInputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbEndpoint -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about a service-generated HorizonDB Cluster- or Pool-scoped Endpoint.

## EXAMPLES

### Example 1: List cluster endpoints
```powershell
Get-AzHorizonDbEndpoint -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, Scope, Role, FullyQualifiedDomainName
```

```output
Name                     : example-cluster
Scope                    : Cluster
Role                     : ReadWrite
FullyQualifiedDomainName : example-cluster.ffffffffffff.eastus2.horizondb.azure.com

Name                     : example-pool-01
Scope                    : Pool
Role                     : ReadOnly
FullyQualifiedDomainName : example-pool-01.example-cluster.ffffffffffff.eastus2.horizondb.azure.com
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a cluster endpoint
```powershell
Get-AzHorizonDbEndpoint -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-cluster' | Format-List -Property Name, Scope, Role, FullyQualifiedDomainName
```

```output
Name                     : example-cluster
Scope                    : Cluster
Role                     : ReadWrite
FullyQualifiedDomainName : example-cluster.ffffffffffff.eastus2.horizondb.azure.com
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Get a read-only pool endpoint
```powershell
Get-AzHorizonDbEndpoint -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' | Format-List -Property Name, Scope, Role, FullyQualifiedDomainName
```

```output
Name                     : example-pool-01
Scope                    : Pool
Role                     : ReadOnly
FullyQualifiedDomainName : example-pool-01.example-cluster.ffffffffffff.eastus2.horizondb.azure.com
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

## PARAMETERS

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The platform-assigned name of the HorizonDB endpoint.
A Cluster-scoped ReadWrite Endpoint has exactly the same name as its associated Cluster.
A Pool-scoped Endpoint has exactly the same name as its associated Pool.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCluster
Aliases: EndpointName

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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IEndpoint

## NOTES

## RELATED LINKS
