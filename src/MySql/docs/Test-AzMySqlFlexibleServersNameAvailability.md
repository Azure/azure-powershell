---
external help file:
Module Name: Az.MySql
online version: https://docs.microsoft.com/en-us/powershell/module/az.mysql/test-azmysqlflexibleserversnameavailability
schema: 2.0.0
---

# Test-AzMySqlFlexibleServersNameAvailability

## SYNOPSIS
Check the availability of name for server

## SYNTAX

### TestExpanded (Default)
```
Test-AzMySqlFlexibleServersNameAvailability -Name <String> [-SubscriptionId <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Test
```
Test-AzMySqlFlexibleServersNameAvailability -NameAvailabilityRequest <INameAvailabilityRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentity
```
Test-AzMySqlFlexibleServersNameAvailability -InputObject <IMySqlIdentity>
 -NameAvailabilityRequest <INameAvailabilityRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TestViaIdentityExpanded
```
Test-AzMySqlFlexibleServersNameAvailability -InputObject <IMySqlIdentity> -Name <String> [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check the availability of name for server

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
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.IMySqlIdentity
Parameter Sets: TestViaIdentity, TestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Resource name to verify.

```yaml
Type: System.String
Parameter Sets: TestExpanded, TestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameAvailabilityRequest
Request from client to check resource name availability.
To construct, see NOTES section for NAMEAVAILABILITYREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.INameAvailabilityRequest
Parameter Sets: Test, TestViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Resource type used for verification.

```yaml
Type: System.String
Parameter Sets: TestExpanded, TestViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.INameAvailabilityRequest

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.IMySqlIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.INameAvailability

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMySqlIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: The name of the server configuration.
  - `[DatabaseName <String>]`: The name of the database.
  - `[FirewallRuleName <String>]`: The name of the server firewall rule.
  - `[Id <String>]`: Resource identity path
  - `[KeyName <String>]`: The name of the server key.
  - `[LocationName <String>]`: The name of the location.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SecurityAlertPolicyName <SecurityAlertPolicyName?>]`: The name of the security alert policy.
  - `[ServerName <String>]`: The name of the server.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VirtualNetworkRuleName <String>]`: The name of the virtual network rule.

NAMEAVAILABILITYREQUEST <INameAvailabilityRequest>: Request from client to check resource name availability.
  - `Name <String>`: Resource name to verify.
  - `[Type <String>]`: Resource type used for verification.

## RELATED LINKS

