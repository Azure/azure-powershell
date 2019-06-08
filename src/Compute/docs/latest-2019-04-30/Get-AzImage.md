---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/get-azimage
schema: 2.0.0
---

# Get-AzImage

## SYNOPSIS
Gets an image.

## SYNTAX

### List3 (Default)
```
Get-AzImage -SubscriptionId <String[]> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzImage -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzImage -ResourceGroupName <String> -SubscriptionId <String[]> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzImage -InputObject <IComputeIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an image.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Expand
The expand expression to apply on the operation.

```yaml
Type: System.String
Parameter Sets: Get1, GetViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the image.

```yaml
Type: System.String
Parameter Sets: Get1
Aliases: ImageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get1, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List3, Get1, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IImage

## ALIASES

## RELATED LINKS

