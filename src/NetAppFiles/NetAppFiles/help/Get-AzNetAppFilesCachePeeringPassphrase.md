---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilescachepeeringpassphrase
schema: 2.0.0
---

# Get-AzNetAppFilesCachePeeringPassphrase

## SYNOPSIS
Gets the cluster-peering and vserver-peering commands and passphrases required to complete peering between an Azure NetApp Files (ANF) Cache and its on-prem ONTAP origin.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesCachePeeringPassphrase -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesCachePeeringPassphrase -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzNetAppFilesCachePeeringPassphrase -InputObject <PSNetAppFilesCache>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetAppFilesCachePeeringPassphrase** cmdlet returns the cluster peering command, the cluster peering passphrase, and the vserver peering command that must be executed on the external ONTAP origin cluster to complete FlexCache peering. If any critical warnings apply to the peering operation, they are returned in the `CriticalWarning` property.

## EXAMPLES

### Example 1: Retrieve peering commands for a Cache
```powershell
Get-AzNetAppFilesCachePeeringPassphrase -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfCache"
```

```output
ClusterPeeringCommand    : cluster peer create -address-family ipv4 -peer-addrs ...
ClusterPeeringPassphrase : ****************
VserverPeeringCommand    : vserver peer create -vserver onprem-svm -peer-vserver ...
CriticalWarning          :
```

Returns the commands and passphrase needed to accept cluster peering on the origin ONTAP cluster.

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
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
The cache object

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesCache
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ANF cache

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases: CacheName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
The name of the ANF capacity pool

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF cache

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesCache

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesCachePeeringPassphrase

## NOTES

## RELATED LINKS
