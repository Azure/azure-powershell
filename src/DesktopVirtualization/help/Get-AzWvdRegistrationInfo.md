---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdregistrationinfo
schema: 2.0.0
---

# Get-AzWvdRegistrationInfo

## SYNOPSIS
Get the Windows virtual desktop registration info.

## SYNTAX

```
Get-AzWvdRegistrationInfo -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the Windows virtual desktop registration info.

## EXAMPLES

### Example 1: Get Existing Registration Info from Hostpool
```powershell
Get-AzWvdRegistrationInfo -ResourceGroupName rgName -HostPoolName hpName
```

```output
ExpirationTime        RegistrationTokenOperation Token
--------------        -------------------------- -----
5/10/2023 12:00:00 PM None                       <base64 encoded string>

```

Retrieves Registration Info for the chosen hostpool.

### Example 2: Get Empty Registration Info from HostPool 
```powershell
Get-AzWvdRegistrationInfo -ResourceGroupName rgName -HostPoolname hpName
```

```output
ExpirationTime RegistrationTokenOperation Token
-------------- -------------------------- -----
               None
```

Returns an empty Registration Info for the chosen Hostpool if the Hostpool doesn't have any Registration Info.

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
```

### -HostPoolName
Host Pool Name

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

### -ResourceGroupName
Resource Group Name

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
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.RegistrationInfo

## NOTES

ALIASES

## RELATED LINKS

