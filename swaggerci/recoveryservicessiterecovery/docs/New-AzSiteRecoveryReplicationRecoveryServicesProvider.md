---
external help file:
Module Name: Az.SiteRecovery
online version: https://docs.microsoft.com/en-us/powershell/module/az.siterecovery/new-azsiterecoveryreplicationrecoveryservicesprovider
schema: 2.0.0
---

# New-AzSiteRecoveryReplicationRecoveryServicesProvider

## SYNOPSIS
The operation to add a recovery services provider.

## SYNTAX

```
New-AzSiteRecoveryReplicationRecoveryServicesProvider -FabricName <String> -ProviderName <String>
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SiteRecovery.Models.Api20220301.IRecoveryServicesProvider

## NOTES

ALIASES

## RELATED LINKS

