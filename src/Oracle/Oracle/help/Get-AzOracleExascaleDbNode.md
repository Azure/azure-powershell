---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracleexascaledbnode
schema: 2.0.0
---

# Get-AzOracleExascaleDbNode

## SYNOPSIS
Get a ExascaleDbNode

## SYNTAX

### List (Default)
```
Get-AzOracleExascaleDbNode -ExadbVMClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleExascaleDbNode -ExadbVMClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleExascaleDbNode -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityExadbVMCluster
```
Get-AzOracleExascaleDbNode -ExadbVMClusterInputObject <IOracleIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a ExascaleDbNode

## EXAMPLES

### Example 1: Get a list of the Database Nodes for a ExaScale db VM Cluster resource
```powershell
Get-AzOracleExascaleDbNode -Exadbvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg"
```

```output
Name                                                                              SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                              ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz22lazevdaoiye7bh4iy2nwfa                                                                                                                                                PowerShellTestRg
ocid1.dbnode.oc1.iad.anuwcljrnirvylqaqm24luvmhsaaz2wtiq3ggddpsemx6gn66vff5rulsgnq                                                                                                                                                PowerShellTestRg
```

Get a list of the Database Nodes for a Cloud VM Cluster resource.
For more information, execute `Get-Help Get-AzOracleExascaleDbNode`

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

### -ExadbVMClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentityExadbVMCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ExadbVMClusterName
The name of the ExadbVmCluster

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ExascaleDbNode

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityExadbVMCluster
Aliases: ExascaleDbNodeName

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IExascaleDbNode

## NOTES

## RELATED LINKS

