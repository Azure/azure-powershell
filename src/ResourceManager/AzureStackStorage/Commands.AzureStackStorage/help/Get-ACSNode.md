---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 01ABD0AC-5D2F-4F1B-9482-3EFCC674DD43
---

# Get-ACSNode

## SYNOPSIS
Gets a list of nodes in Azure Consistent Storage.

## SYNTAX

```
Get-ACSNode [-FarmName] <String> [[-NodeName] <String>] [[-SubscriptionId] <String>] [[-Token] <String>]
 [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation] [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSNode** cmdlet get a list of nodes in Azure Consistent Storage.
An Azure Consistent Storage (ACS) node can be either a Blob Server type or a Service Fabric node type.

## EXAMPLES

### Example 1: Get a list of nodes
```
PS C:\>$Global:AdminUri = "https://srp.yourdomainFQDN:30020"
PS C:\> $SubscriptId = "SubID"
PS C:\> $Token = "Token001"
PS C:\> $ResourceGroup = System"
PS C:\> $Farm = Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup

PS C:\> Get-ACSNode -SubscriptionId $subscriptId -Token $token -AdminUri $adminUri -ResourceGroupName $resourceGroup -SkipCertificateValidation -FarmName $farm.Name
Properties : Microsoft.AzureStack.Management.StorageAdmin.Models.Node
Id         : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourceGroups/System/providers/Microsoft.Storage.Admi
             n/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/nodes/431217D10-31
Location   : eastasia
Name       : 415adecd-1944-46d2-8f61-66d53cdc75d0/431217D10-31
Tags       : {}
Type       : Microsoft.Storage.Admin/farms/nodes

Properties : Microsoft.AzureStack.Management.StorageAdmin.Models.Node
Id         : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourceGroups/System/providers/Microsoft.Storage.Admi
             n/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/nodes/WOSSVM
Location   : eastasia
Name       : 415adecd-1944-46d2-8f61-66d53cdc75d0/WOSSVM
Tags       : {}
Type       : Microsoft.Storage.Admin/farms/nodes
```

The first command gets the specified ACS farm and stores the result in the $Farm variable.
This final command gets a list of nodes from the farm.

## PARAMETERS

### -FarmName
Specifies the name of the ACS farm.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NodeName
Specifies the name of the node.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the service administrator subscription ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Token
Specifies the service administrator token.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AdminUri
Specifies the location of the Resource Manager endpoint.
If you configured your environment by using the Set-AzureRMEnvironment cmdlet, you do not have to specify this parameter.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the ACS resource group from which this cmdlet gets the node from.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipCertificateValidation
Indicates that this cmdlet skips certificate validation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse,
Output from Get-ACSFarm can be piped to this cmdlet.

## OUTPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.NodeResponse

## NOTES

## RELATED LINKS

[Enable-ACSNode](./Enable-ACSNode.md)

[Disable-ACSNode](./Disable-ACSNode.md)

[Get-ACSFarm](./Get-ACSFarm.md)


