---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/enable-azfrontdoorfrontendendpointhttps
schema: 2.0.0
---

# Enable-AzFrontDoorFrontendEndpointHttps

## SYNOPSIS
Enables a frontendEndpoint for HTTPS traffic

## SYNTAX

### EnableExpanded (Default)
```
Enable-AzFrontDoorFrontendEndpointHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> -CertificateSource <String> -MinimumTlsVersion <String>
 [-SubscriptionId <String>] [-FrontDoorCertificateSourceParameterCertificateType <String>]
 [-KeyVaultCertificateSourceParameterSecretName <String>]
 [-KeyVaultCertificateSourceParameterSecretVersion <String>] [-VaultId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Enable
```
Enable-AzFrontDoorFrontendEndpointHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> -CustomHttpsConfiguration <ICustomHttpsConfiguration> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentity
```
Enable-AzFrontDoorFrontendEndpointHttps -InputObject <IFrontDoorIdentity>
 -CustomHttpsConfiguration <ICustomHttpsConfiguration> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentityExpanded
```
Enable-AzFrontDoorFrontendEndpointHttps -InputObject <IFrontDoorIdentity> -CertificateSource <String>
 -MinimumTlsVersion <String> [-FrontDoorCertificateSourceParameterCertificateType <String>]
 [-KeyVaultCertificateSourceParameterSecretName <String>]
 [-KeyVaultCertificateSourceParameterSecretVersion <String>] [-VaultId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentityFrontDoor
```
Enable-AzFrontDoorFrontendEndpointHttps -FrontDoorInputObject <IFrontDoorIdentity>
 -FrontendEndpointName <String> -CustomHttpsConfiguration <ICustomHttpsConfiguration>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentityFrontDoorExpanded
```
Enable-AzFrontDoorFrontendEndpointHttps -FrontDoorInputObject <IFrontDoorIdentity>
 -FrontendEndpointName <String> -CertificateSource <String> -MinimumTlsVersion <String>
 [-FrontDoorCertificateSourceParameterCertificateType <String>]
 [-KeyVaultCertificateSourceParameterSecretName <String>]
 [-KeyVaultCertificateSourceParameterSecretVersion <String>] [-VaultId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaJsonFilePath
```
Enable-AzFrontDoorFrontendEndpointHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaJsonString
```
Enable-AzFrontDoorFrontendEndpointHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Enables a frontendEndpoint for HTTPS traffic

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

### -CertificateSource
Defines the source of the SSL certificate

```yaml
Type: System.String
Parameter Sets: EnableExpanded, EnableViaIdentityExpanded, EnableViaIdentityFrontDoorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHttpsConfiguration
Https settings for a domain

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICustomHttpsConfiguration
Parameter Sets: Enable, EnableViaIdentity, EnableViaIdentityFrontDoor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -FrontDoorCertificateSourceParameterCertificateType
Defines the type of the certificate used for secure connections to a frontendEndpoint

```yaml
Type: System.String
Parameter Sets: EnableExpanded, EnableViaIdentityExpanded, EnableViaIdentityFrontDoorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontDoorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
Parameter Sets: EnableViaIdentityFrontDoor, EnableViaIdentityFrontDoorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FrontDoorName
Name of the Front Door which is globally unique.

```yaml
Type: System.String
Parameter Sets: Enable, EnableExpanded, EnableViaJsonFilePath, EnableViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendEndpointName
Name of the Frontend endpoint which is unique within the Front Door.

```yaml
Type: System.String
Parameter Sets: Enable, EnableExpanded, EnableViaIdentityFrontDoor, EnableViaIdentityFrontDoorExpanded, EnableViaJsonFilePath, EnableViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
Parameter Sets: EnableViaIdentity, EnableViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Enable operation

```yaml
Type: System.String
Parameter Sets: EnableViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Enable operation

```yaml
Type: System.String
Parameter Sets: EnableViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCertificateSourceParameterSecretName
The name of the Key Vault secret representing the full certificate PFX

```yaml
Type: System.String
Parameter Sets: EnableExpanded, EnableViaIdentityExpanded, EnableViaIdentityFrontDoorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCertificateSourceParameterSecretVersion
The version of the Key Vault secret representing the full certificate PFX

```yaml
Type: System.String
Parameter Sets: EnableExpanded, EnableViaIdentityExpanded, EnableViaIdentityFrontDoorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumTlsVersion
The minimum TLS version required from the clients to establish an SSL handshake with Front Door.

```yaml
Type: System.String
Parameter Sets: EnableExpanded, EnableViaIdentityExpanded, EnableViaIdentityFrontDoorExpanded
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

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Enable, EnableExpanded, EnableViaJsonFilePath, EnableViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: Enable, EnableExpanded, EnableViaJsonFilePath, EnableViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
Resource ID.

```yaml
Type: System.String
Parameter Sets: EnableExpanded, EnableViaIdentityExpanded, EnableViaIdentityFrontDoorExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICustomHttpsConfiguration

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

