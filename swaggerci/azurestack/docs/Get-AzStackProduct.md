---
external help file:
Module Name: Az.Stack
online version: https://docs.microsoft.com/en-us/powershell/module/az.stack/get-azstackproduct
schema: 2.0.0
---

# Get-AzStackProduct

## SYNOPSIS
Returns the specified product.

## SYNTAX

### List (Default)
```
Get-AzStackProduct -RegistrationName <String> -ResourceGroup <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStackProduct -Name <String> -RegistrationName <String> -ResourceGroup <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzStackProduct -Name <String> -RegistrationName <String> -ResourceGroup <String>
 -DeviceConfiguration <IDeviceConfiguration> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get2
```
Get-AzStackProduct -Name <String> -RegistrationName <String> -ResourceGroup <String>
 -DeviceConfiguration <IDeviceConfiguration> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetExpanded
```
Get-AzStackProduct -Name <String> -RegistrationName <String> -ResourceGroup <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetExpanded1
```
Get-AzStackProduct -Name <String> -RegistrationName <String> -ResourceGroup <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStackProduct -InputObject <IStackIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzStackProduct -InputObject <IStackIdentity> -DeviceConfiguration <IDeviceConfiguration>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity2
```
Get-AzStackProduct -InputObject <IStackIdentity> -DeviceConfiguration <IDeviceConfiguration>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzStackProduct -InputObject <IStackIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentityExpanded1
```
Get-AzStackProduct -InputObject <IStackIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the specified product.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
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
```

### -DeviceConfiguration
Device Configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.Api20200601Preview.IDeviceConfiguration
Parameter Sets: Get1, Get2, GetViaIdentity1, GetViaIdentity2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.IStackIdentity
Parameter Sets: GetViaIdentity, GetViaIdentity1, GetViaIdentity2, GetViaIdentityExpanded, GetViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the product.

```yaml
Type: System.String
Parameter Sets: Get, Get1, Get2, GetExpanded, GetExpanded1
Aliases: ProductName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationName
Name of the Azure Stack registration.

```yaml
Type: System.String
Parameter Sets: Get, Get1, Get2, GetExpanded, GetExpanded1, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, Get1, Get2, GetExpanded, GetExpanded1, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, Get1, Get2, GetExpanded, GetExpanded1, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.Api20200601Preview.IDeviceConfiguration

### Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.IStackIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.Api20200601Preview.IProduct

### Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.Api20200601Preview.IProductList

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IStackIdentity>: Identity Parameter
  - `[CustomerSubscriptionName <String>]`: Name of the product.
  - `[Id <String>]`: Resource identity path
  - `[LinkedSubscriptionName <String>]`: Name of the Linked Subscription resource.
  - `[ProductName <String>]`: Name of the product.
  - `[RegistrationName <String>]`: Name of the Azure Stack registration.
  - `[ResourceGroup <String>]`: Name of the resource group.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VerificationVersion <String>]`: Signing verification key version.

## RELATED LINKS

