---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesreplicationrecoveryservicesprovider
schema: 2.0.0
---

# New-AzRecoveryServicesReplicationRecoveryServicesProvider

## SYNOPSIS
The operation to add a recovery services provider.

## SYNTAX

### CreateExpanded (Default)
```
New-AzRecoveryServicesReplicationRecoveryServicesProvider -FabricName <String> -ProviderName <String>
 -ResourceGroupName <String> -ResourceName <String> -AuthenticationIdentityInputAadAuthority <String>
 -AuthenticationIdentityInputApplicationId <String> -AuthenticationIdentityInputAudience <String>
 -AuthenticationIdentityInputObjectId <String> -AuthenticationIdentityInputTenantId <String>
 -MachineName <String> -ResourceAccessIdentityInputAadAuthority <String>
 -ResourceAccessIdentityInputApplicationId <String> -ResourceAccessIdentityInputAudience <String>
 -ResourceAccessIdentityInputObjectId <String> -ResourceAccessIdentityInputTenantId <String>
 [-SubscriptionId <String>] [-BiosId <String>] [-DataPlaneAuthenticationIdentityInputAadAuthority <String>]
 [-DataPlaneAuthenticationIdentityInputApplicationId <String>]
 [-DataPlaneAuthenticationIdentityInputAudience <String>]
 [-DataPlaneAuthenticationIdentityInputObjectId <String>]
 [-DataPlaneAuthenticationIdentityInputTenantId <String>] [-MachineId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzRecoveryServicesReplicationRecoveryServicesProvider -FabricName <String> -ProviderName <String>
 -ResourceGroupName <String> -ResourceName <String> -AddProviderInput <IAddRecoveryServicesProviderInput>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to add a recovery services provider.

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

### -AddProviderInput
Input required to add a provider.
To construct, see NOTES section for ADDPROVIDERINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IAddRecoveryServicesProviderInput
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationIdentityInputAadAuthority
The base authority for Azure Active Directory authentication.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationIdentityInputApplicationId
The application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationIdentityInputAudience
The intended Audience of the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationIdentityInputObjectId
The object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationIdentityInputTenantId
The tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BiosId
The Bios Id of the machine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPlaneAuthenticationIdentityInputAadAuthority
The base authority for Azure Active Directory authentication.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPlaneAuthenticationIdentityInputApplicationId
The application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPlaneAuthenticationIdentityInputAudience
The intended Audience of the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPlaneAuthenticationIdentityInputObjectId
The object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPlaneAuthenticationIdentityInputTenantId
The tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -FabricName
Fabric name.

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

### -MachineId
The Id of the machine where the provider is getting added.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineName
The name of the machine where the provider is getting added.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderName
Recovery services provider name.

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

### -ResourceAccessIdentityInputAadAuthority
The base authority for Azure Active Directory authentication.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceAccessIdentityInputApplicationId
The application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceAccessIdentityInputAudience
The intended Audience of the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceAccessIdentityInputObjectId
The object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceAccessIdentityInputTenantId
The tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

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

### -ResourceName
The name of the recovery services vault.

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
The subscription Id.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IAddRecoveryServicesProviderInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRecoveryServicesProvider

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ADDPROVIDERINPUT <IAddRecoveryServicesProviderInput>`: Input required to add a provider.
  - `AuthenticationIdentityInputAadAuthority <String>`: The base authority for Azure Active Directory authentication.
  - `AuthenticationIdentityInputApplicationId <String>`: The application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `AuthenticationIdentityInputAudience <String>`: The intended Audience of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `AuthenticationIdentityInputObjectId <String>`: The object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `AuthenticationIdentityInputTenantId <String>`: The tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `MachineName <String>`: The name of the machine where the provider is getting added.
  - `ResourceAccessIdentityInputAadAuthority <String>`: The base authority for Azure Active Directory authentication.
  - `ResourceAccessIdentityInputApplicationId <String>`: The application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `ResourceAccessIdentityInputAudience <String>`: The intended Audience of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `ResourceAccessIdentityInputObjectId <String>`: The object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `ResourceAccessIdentityInputTenantId <String>`: The tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `[BiosId <String>]`: The Bios Id of the machine.
  - `[DataPlaneAuthenticationIdentityInputAadAuthority <String>]`: The base authority for Azure Active Directory authentication.
  - `[DataPlaneAuthenticationIdentityInputApplicationId <String>]`: The application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `[DataPlaneAuthenticationIdentityInputAudience <String>]`: The intended Audience of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `[DataPlaneAuthenticationIdentityInputObjectId <String>]`: The object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `[DataPlaneAuthenticationIdentityInputTenantId <String>]`: The tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  - `[MachineId <String>]`: The Id of the machine where the provider is getting added.

## RELATED LINKS

