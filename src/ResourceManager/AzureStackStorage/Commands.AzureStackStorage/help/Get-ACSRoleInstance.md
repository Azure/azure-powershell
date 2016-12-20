---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 8F12FE28-0C72-402A-8155-BC239F9806FF
---

# Get-ACSRoleInstance

## SYNOPSIS
Get a list of a specific type of role instances.

## SYNTAX

```
Get-ACSRoleInstance [-FarmName] <String> [-RoleType] <RoleType> [[-InstanceId] <String>]
 [[-SubscriptionId] <String>] [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String>
 [-SkipCertificateValidation] [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSRoleInstance** cmdlet get a list of specific type of role instances.

## EXAMPLES

### Example 1: Get a list of Blob front-end instances
```
PS C:\>$Global:AdminUri = "https://srp.yourdomainFQDN:30020"
PS C:\> $SubscriptId = "SubID004"
PS C:\> $Token = "Token"
PS C:\> $ResourceGroup = "System"
PS C:\> $Farm = Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup
PS C:\> Get-ACSRoleInstance -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -SkipCertificateValidation -FarmName $Farm.Name -RoleType BlobFrontend           
Properties : Microsoft.AzureStack.Management.StorageAdmin.Models.BlobFrontEndRoleInstance
Id         : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourceGroups/System/providers/Microsoft.Storage.Admi
             n/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/blobfrontendinstances/WOSSVM
Location   : eastasia
Name       : 415adecd-1944-46d2-8f61-66d53cdc75d0/WOSSVM
Tags       : {}
Type       : Microsoft.Storage.Admin/farms/blobfrontendinstances
```

The first command gets the specified ACS farm and stores the result in the $Farm variable.
This final command gets a list of Blob front-end instances in the specified farm.

### Example 2: Get a specific Blob front-end instances
```
PS C:\>$BlobFrontend = Get-ACSRoleInstance -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -SkipCertificateValidation -FarmName $Farm.Name -RoleType BlobFrontend
PS C:\> $BlobFrontend[0].Properties

Settings       : Microsoft.AzureStack.Management.StorageAdmin.Models.BlobFrontEndRoleInstanceEffectiveSettings
HealthStatus   : Healthy
HistoryInfos   : {Microsoft.AzureStack.Management.StorageAdmin.Models.RoleInstanceHistoricEntry}
NodeUri        : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourcegroups/System/providers/Microsoft.Storage. 

                 Admin/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/nodes/WOSSVM
RoleIdentifier : WOSSVM
Status         : Active
Version        : 2014-12-01-preview
```

This command gets the properties of a specific Blob Front-end role instance and then outputs the property information.

### Example 3: Get a list of Blob server role instances
```
PS C:\>Get-ACSRoleInstance -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -SkipCertificateValidation -FarmName $Farm.Name -RoleType BlobServer
Properties : Microsoft.AzureStack.Management.StorageAdmin.Models.BlobServerRoleInstance
Id         : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourceGroups/System/providers/Microsoft.Storage.Admi
             n/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/blobserverinstances/431217D10-31
Location   : eastasia
Name       : 415adecd-1944-46d2-8f61-66d53cdc75d0/431217D10-31
Tags       : {}
Type       : Microsoft.Storage.Admin/farms/blobserverinstances
```

This command gets a list of the BlobServer role instances from the specified ACS farm.

### Example 4: Get the properties of the TableMaster role instance
```
PS C:\>Get-ACSRoleInstance -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -SkipCertificateValidation -FarmName $Farm.Name -RoleType TableMaster | Select-Object -ExpandProperty Properties | fl

Settings       : Microsoft.AzureStack.Management.StorageAdmin.Models.TableMasterRoleInstanceEffectiveSettings
HealthStatus   : Healthy
HistoryInfos   : {}
NodeUri        : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourcegroups/System/providers/Microsoft.Storage. 
                 Admin/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/nodes/WOSSVM
RoleIdentifier : WOSSVM
Status         : Active
Version        : 2014-12-01-preview
```

This command gets the properties of the TableMaster role instance.

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

### -RoleType
Specifies the type of the role instance.
The acceptable values for this parameter are:

- TableServer 
- BlobServer 
- TableMaster 
- AccountContainerserver 
- TableFrontend 
- BlobFrontend 
- MetricsServer 
- HealthMonitoringserver

```yaml
Type: RoleType
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InstanceId
Specifies the instance ID of a specific role instance.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Service Admin's subscription ID

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
Specifies the service administrator subscription ID.

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
Specifies the name of the resource group from which this cmdlet gets the ACS role instance.

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

### Microsoft.AzureStack.Commands.StorageAdmin.AccountContainerRoleInstanceResponse

## NOTES

## RELATED LINKS

[Restart-ACSRoleInstance](./Restart-ACSRoleInstance.md)

[Update-ACSRoleInstance](./Update-ACSRoleInstance.md)

[Get-ACSFarm](./Get-ACSFarm.md)


