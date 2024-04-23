---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlservicevmsize
schema: 2.0.0
---

# Get-AzMLServiceVMSize

## SYNOPSIS
Returns supported VM Sizes in a location

## SYNTAX

```
Get-AzMLServiceVMSize -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns supported VM Sizes in a location

## EXAMPLES

### Example 1: Returns supported VM Sizes in a location
```powershell
Get-AzMLServiceVMSize -Location eastus
```

```output
Family                      Gpu LowPriorityCapable MaxResourceVolumeMb MemoryGb Name                      OSVhdSizeMb PremiumIo SupportedComputeType                         VCpUs
------                      --- ------------------ ------------------- -------- ----                      ----------- --------- --------------------                         -----
standardDFamily             0   True               51200               3.5      Standard_D1               1047552     False     {AmlCompute}                                 1
standardDFamily             0   True               102400              14       Standard_D11              1047552     False     {AmlCompute}                                 2
standardDv2Family           0   True               102400              14       Standard_D11_v2           1047552     False     {AmlCompute, ComputeInstance}                2
standardDFamily             0   True               204800              28       Standard_D12              1047552     False     {AmlCompute}                                 4
standardDv2Family           0   True               204800              28       Standard_D12_v2           1047552     False     {AmlCompute, ComputeInstance}                4
```

Returns supported VM Sizes in a location.

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

### -Location
The location upon which virtual-machine-sizes is queried.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IVirtualMachineSize

## NOTES

## RELATED LINKS

