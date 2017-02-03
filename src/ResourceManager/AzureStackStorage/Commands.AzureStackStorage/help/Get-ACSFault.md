---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 8D70F5E0-C1C3-4776-9C8B-D1DC7F819946
---

# Get-ACSFault

## SYNOPSIS
Gets faults in the Azure Consistent Storage system.

## SYNTAX

### GetCurrentFault (Default)
```
Get-ACSFault [-FarmName] <String> [-ResourceUri <String>] [[-SubscriptionId] <String>] [[-Token] <String>]
 [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation] [<CommonParameters>]
```

### GetFault
```
Get-ACSFault [-FarmName] <String> -FaultId <String> [[-SubscriptionId] <String>] [[-Token] <String>]
 [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation] [<CommonParameters>]
```

### GetHistoryFault
```
Get-ACSFault [-FarmName] <String> -StartTime <DateTime> -EndTime <DateTime> [[-SubscriptionId] <String>]
 [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSFault** cmdlet returns a list of Azure Consistent Storage (ACS) faults in the system.
It supports several parameter sets: 
The default parameter set is the *GetCurrentFaults* parameter, which returns a list of current active fault objects.
If the *ResourceUri* parameter is specified, the cmdlet returns a list of current active fault objects on this resource. 
 The **GetHistoryFaults** parameter returns a list of active fault objects within specified time range.
The **Get-ACSFault** cmdlet returns one fault object with the specified fault ID.

## EXAMPLES

### Example 1: Get a list of fault messages
```
PS C:\>$Global:AdminUri = "https://srp.yourdomainFQDN:30020"
$SubscriptId = "SubID"
$Token = "Token001"
$ResourceGroup = "System" 

$Farm = Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup
Get-ACSFault -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -SkipCertificateValidation -FarmName $Farm.Name
Properties : Microsoft.AzureStack.Management.StorageAdmin.Models.Fault
Id         : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourceGroups/System/providers/Microsoft.Storage.Admi
             n/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/faults/9c327c1ca0e241c69ad56a9658882a40
Location   : eastasia
Name       : 415adecd-1944-46d2-8f61-66d53cdc75d0/9c327c1ca0e241c69ad56a9658882a40
Tags       : {}
Type       : Microsoft.Storage.Admin/farms/faults

Properties : Microsoft.AzureStack.Management.StorageAdmin.Models.Fault
Id         : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourceGroups/System/providers/Microsoft.Storage.Admi
             n/farms/415adecd-1944-46d2-8f61-66d53cdc75d0/faults/562aff58d5af4abe89b0e551c406be62
Location   : eastasia
Name       : 415adecd-1944-46d2-8f61-66d53cdc75d0/562aff58d5af4abe89b0e551c406be62
Tags       : {}
Type       : Microsoft.Storage.Admin/farms/faults
```

The first command gets the specified ACSFarm and stores the result in the variable named $Farm.
This final command gets a list of the fault messages in the Azure Consistent Storage system.

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

### -ResourceUri
Specifies the URI of a resource.

```yaml
Type: String
Parameter Sets: GetCurrentFault
Aliases: Id

Required: False
Position: Named
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
Specifies the name of the resource group that this cmdlet gets the ACS fault from.

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

### -FaultId
Specifies the ID of a fault.

```yaml
Type: String
Parameter Sets: GetFault
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartTime
Specifies the start time of the time duration.

```yaml
Type: DateTime
Parameter Sets: GetHistoryFault
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
Specifies the end time of the time duration.

```yaml
Type: DateTime
Parameter Sets: GetHistoryFault
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse,
Output from Get-ACSFarm can be piped to this cmdlet's input.

## OUTPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.FaultResponse

## NOTES

## RELATED LINKS

[Resolve-ACSFault](./Resolve-ACSFault.md)

[Get-ACSFarm](./Get-ACSFarm.md)


