---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabasedbnode
schema: 2.0.0
---

# Get-AzOracleDatabaseDbNode

## SYNOPSIS
Get a DbNode

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseDbNode -Cloudvmclustername <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseDbNode -Cloudvmclustername <String> -Ocid <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseDbNode -InputObject <IOracleDatabaseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCloudVMCluster
```
Get-AzOracleDatabaseDbNode -CloudVMClusterInputObject <IOracleDatabaseIdentity> -Ocid <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DbNode

## EXAMPLES

### Example 1: Gets a list of the Database Nodes for a Cloud VM Cluster resource
```powershell
Get-AzOracleDatabaseDbNode -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg"
```

```output
Name                                                                              SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                              ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz22lazevdaoiye7bh4iy2nwfa                                                                                                                                                PowerShellTestRg
ocid1.dbnode.oc1.iad.anuwcljrnirvylqaqm24luvmhsaaz2wtiq3ggddpsemx6gn66vff5rulsgnq                                                                                                                                                PowerShellTestRg
```

Gets a list of the Database Nodes for a Cloud VM Cluster resource.
For more information, execute `Get-Help Get-AzOracleDatabaseDbNode`

## PARAMETERS

### -CloudVMClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentityCloudVMCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Cloudvmclustername
CloudVmCluster name

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Ocid
DbNode OCID.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCloudVMCluster
Aliases: Dbnodeocid

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IDbNode

## NOTES

## RELATED LINKS

