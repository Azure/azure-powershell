---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/new-azsqlvmgroup
schema: 2.0.0
---

# New-AzSqlVMGroup

## SYNOPSIS
Creates or updates a SQL virtual machine group.

## SYNTAX

```
New-AzSqlVMGroup -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-ClusterBootstrapAccount <String>] [-ClusterOperatorAccount <String>]
 [-ClusterSubnetType <ClusterSubnetType>] [-DomainFqdn <String>] [-FileShareWitnessPath <String>]
 [-Offer <String>] [-OuPath <String>] [-Sku <SqlVMGroupImageSku>] [-SqlServiceAccount <String>]
 [-StorageAccountPrimaryKey <SecureString>] [-StorageAccountUrl <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a SQL virtual machine group.

## EXAMPLES

### Example
```powershell
# $accessKey is a valid access key for the storage account
$storageAccountPrimaryKey = ConvertTo-SecureString -String $accessKey -AsPlainText -Force
New-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01' -Location 'eastus' -Offer 'SQL2022-WS2022' -Sku 'Developer' -DomainFqdn 'yourdomain.com' -ClusterOperatorAccount 'operatoruser@yourdomain.com' -ClusterBootstrapAccount 'bootstrapuser@yourdomain.com' -StorageAccountUrl 'https://yourstorageaccount.blob.core.windows.net/' -StorageAccountPrimaryKey $storageAccountPrimaryKey -SqlServiceAccount 'sqladmin@yourdomain.com' -ClusterSubnetType 'SingleSubnet'
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
```

Creates a Azure SQL virtual machine group "sqlvmgroup01" in the resource group "ResourceGroup01".

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

### -ClusterBootstrapAccount
Account name used for creating cluster (at minimum needs permissions to 'Create Computer Objects' in domain).

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

### -ClusterOperatorAccount
Account name used for operating cluster i.e.
will be part of administrators group on all the participating virtual machines in the cluster.

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

### -ClusterSubnetType
Cluster subnet type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.ClusterSubnetType
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

### -DomainFqdn
Fully qualified name of the domain.

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

### -FileShareWitnessPath
Optional path for fileshare witness.

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

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the SQL virtual machine group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SqlVirtualMachineGroupName, SqlVMGroupName

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

### -Offer
SQL image offer.
Examples may include SQL2016-WS2016, SQL2017-WS2016.

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

### -OuPath
Organizational Unit path in which the nodes and cluster will be present.

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
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
SQL image sku.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.SqlVMGroupImageSku
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlServiceAccount
Account name under which SQL service will run on all participating SQL virtual machines in the cluster.

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

### -StorageAccountPrimaryKey
Primary key of the witness storage account.

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

### -StorageAccountUrl
Fully qualified ARM resource id of the witness storage account.

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
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.ISqlVirtualMachineGroup

## NOTES

ALIASES

## RELATED LINKS

