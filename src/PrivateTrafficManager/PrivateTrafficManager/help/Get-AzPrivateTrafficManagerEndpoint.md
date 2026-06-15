---
external help file: Az.PrivateTrafficManager-help.xml
Module Name: Az.PrivateTrafficManager
online version: https://learn.microsoft.com/powershell/module/az.privatetrafficmanager/get-azprivatetrafficmanagerendpoint
schema: 2.0.0
---

# Get-AzPrivateTrafficManagerEndpoint

## SYNOPSIS
Gets a Private Traffic Manager endpoint.

## SYNTAX

### List (Default)
```
Get-AzPrivateTrafficManagerEndpoint -PrivateTrafficManagerProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateTrafficManagerProfile
```
Get-AzPrivateTrafficManagerEndpoint -Name <String>
 -PrivateTrafficManagerProfileInputObject <IPrivateTrafficManagerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPrivateTrafficManagerEndpoint -Name <String> -PrivateTrafficManagerProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPrivateTrafficManagerEndpoint -InputObject <IPrivateTrafficManagerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Private Traffic Manager endpoint.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Private Traffic Manager endpoint.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPrivateTrafficManagerProfile, Get
Aliases: EndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateTrafficManagerProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: GetViaIdentityPrivateTrafficManagerProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateTrafficManagerProfileName
The name of the Private Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IEndpoint

## NOTES

## RELATED LINKS
