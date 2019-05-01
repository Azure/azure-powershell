---
external help file: Az.Dns-help.xml
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnsresourcereference
schema: 2.0.0
---

# Get-AzDnsResourceReference

## SYNOPSIS
Returns the DNS records specified by the referencing targetResourceIds.

## SYNTAX

### GetSubscriptionIdViaHost (Default)
```
Get-AzDnsResourceReference [-Parameter <IDnsResourceReferenceRequest>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### GetExpanded
```
Get-AzDnsResourceReference -SubscriptionId <String> [-TargetResource <ISubResource[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get
```
Get-AzDnsResourceReference -SubscriptionId <String> [-Parameter <IDnsResourceReferenceRequest>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetSubscriptionIdViaHostExpanded
```
Get-AzDnsResourceReference [-TargetResource <ISubResource[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the DNS records specified by the referencing targetResourceIds.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -Parameter
Represents the properties of the Dns Resource Reference Request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IDnsResourceReferenceRequest
Parameter Sets: GetSubscriptionIdViaHost, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: GetExpanded, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResource
A list of references to azure resources for which referencing dns records need to be queried.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180301Preview.ISubResource[]
Parameter Sets: GetExpanded, GetSubscriptionIdViaHostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IDnsResourceReferenceResultProperties
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnsresourcereference](https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnsresourcereference)

