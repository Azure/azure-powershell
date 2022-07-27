---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Batch.dll-Help.xml
Module Name: Az.Batch
online version: https://docs.microsoft.com/powershell/module/az.batch/get-azbatchcommandnodeextension
schema: 2.0.0
---

# Get-AzBatchComputeNodeExtension

## SYNOPSIS
Gets Batch compute node extensions from a compute node.

## SYNTAX

### Id (Default)
```
Get-AzBatchComputeNodeExtension [-PoolId] <String> [-ComputeNodeId] <String> [[-Name] <String>]
 [-Select <String>] [-MaxCount <Int32>] -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ParentObject
```
Get-AzBatchComputeNodeExtension [-Pool] <PSCloudPool> [-ComputeNodeId] <String> [[-Name] <String>]
 [-Select <String>] [-MaxCount <Int32>] -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
If an extension name is provided, a single extension with a matching name is returned from the provided compute node (if found). Otherwise, all extensions on teh compute node is returned. Further extension details can be found on the extension's VmExtension Property.

## EXAMPLES

### Example 1 Get all extensions from a compute node.
```powershell
Get-AzBatchComputeNodeExtension "testPool" "testNode" -BatchContext $context
```

```output
InstanceView                                                    ProvisioningState VmExtension
------------                                                    ----------------- -----------
Microsoft.Azure.Commands.Batch.Models.PSVMExtensionInstanceView Succeeded         Microsoft.Azure.Commands.Batch.Models.PSVMExtension
Microsoft.Azure.Commands.Batch.Models.PSVMExtensionInstanceView Failed            Microsoft.Azure.Commands.Batch.Models.PSVMExtension
```

### Example 2 Get a specific extension from a compute node.

```powershell
Get-AzBatchComputeNodeExtension "testPool" "testNode" "secretext" -BatchContext $context
```

```output
InstanceView                                                    ProvisioningState VmExtension
------------                                                    ----------------- -----------
Microsoft.Azure.Commands.Batch.Models.PSVMExtensionInstanceView Failed            Microsoft.Azure.Commands.Batch.Models.PSVMExtension
```

## PARAMETERS

### -BatchContext
The BatchAccountContext instance to use when interacting with the Batch service.
If you use the Get-AzBatchAccount cmdlet to get your BatchAccountContext, then Azure Active Directory authentication will be used when interacting with the Batch service.
To use shared key authentication instead, use the Get-AzBatchAccountKeys cmdlet to get a BatchAccountContext object with its access keys populated.
When using shared key authentication, the primary access key is used by default.
To change the key to use, set the BatchAccountContext.KeyInUse property.

```yaml
Type: Microsoft.Azure.Commands.Batch.BatchAccountContext
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ComputeNodeId
The id of the compute node to which the extension belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -MaxCount
Specifies the maximum number of compute node extensions to return.

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

### -Name
The name of the extension to get.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pool
The pool to which the extension's compute node belongs.

```yaml
Type: Microsoft.Azure.Commands.Batch.Models.PSCloudPool
Parameter Sets: ParentObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PoolId
The id of the pool to which the extension's compute node belongs.

```yaml
Type: System.String
Parameter Sets: Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Select
Specifies an OData select clause.
Specify a value for this parameter to get specific properties rather than all object properties.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Batch.Models.PSCloudPool

### Microsoft.Azure.Commands.Batch.BatchAccountContext

## OUTPUTS

### Microsoft.Azure.Commands.Batch.Models.PSNodeVMExtension

## NOTES

## RELATED LINKS
