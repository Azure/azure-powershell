---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/enable-azfrontdoorcustomdomainhttps
schema: 2.0.0
---

# Enable-AzFrontDoorCustomDomainHttps

## SYNOPSIS
Enables a frontendEndpoint for HTTPS traffic

## SYNTAX

### EnableExpanded (Default)
```
Enable-AzFrontDoorCustomDomainHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-MinimumTlsVersion <String>] [-SecretName <String>]
 [-SecretVersion <String>] [-VaultId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Enable
```
Enable-AzFrontDoorCustomDomainHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableViaJsonFilePath
```
Enable-AzFrontDoorCustomDomainHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableViaJsonString
```
Enable-AzFrontDoorCustomDomainHttps -FrontDoorName <String> -FrontendEndpointName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EnableViaIdentityFrontDoor
```
Enable-AzFrontDoorCustomDomainHttps -FrontendEndpointName <String> -FrontDoorInputObject <IFrontDoorIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### EnableViaIdentity
```
Enable-AzFrontDoorCustomDomainHttps -InputObject <IFrontDoorIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceIdWithVaultParameterSet
```
Enable-AzFrontDoorCustomDomainHttps [-MinimumTlsVersion <String>] [-SecretName <String>]
 [-SecretVersion <String>] [-VaultId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Enables a frontendEndpoint for HTTPS traffic

## EXAMPLES

### Example 1: Enable HTTPS for a custom domain with FrontDoorName and ResourceGroupName using Front Door managed certificate.
```powershell
Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -FrontendEndpointName "frontendpointname1-custom-xyz" -MinimumTlsVersion "1.2"
```

```output
$true
```

Enable HTTPS for a custom domain "frontendpointname1-custom-xyz" that is part of Front Door "frontdoor1" in resource group "resourcegroup1" using Front Door managed certificate.

Enable HTTPS for a custom domain "frontendpointname1-custom-xyz" that is part of Front Door "frontdoor1" in resource group "resourcegroup1" using customer's own certificate in Key Vault with the specific version.

### Example 2: Enable HTTPS for a custom domain with PSFrontendEndpoint object using Front Door managed certificate.
```powershell
Get-AzFrontDoorFrontendEndpoint -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -Name "frontendpointname1-custom-xyz" | Enable-AzFrontDoorCustomDomainHttps
```

```output
$true
```

Enable HTTPS for a custom domain with PSFrontendEndpoint object using Front Door managed certificate.

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

### -FrontDoorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
Parameter Sets: EnableViaIdentityFrontDoor
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
Parameter Sets: EnableExpanded, Enable, EnableViaJsonFilePath, EnableViaJsonString
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
Parameter Sets: EnableExpanded, Enable, EnableViaJsonFilePath, EnableViaJsonString, EnableViaIdentityFrontDoor
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
Parameter Sets: EnableViaIdentity
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

### -MinimumTlsVersion
The minimum TLS version required from the clients to establish an SSL handshake with Front Door.

```yaml
Type: System.String
Parameter Sets: EnableExpanded, ByResourceIdWithVaultParameterSet
Aliases:

Required: False
Position: Named
Default value: 1.2
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
Parameter Sets: EnableExpanded, Enable, EnableViaJsonFilePath, EnableViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretName
The name of the Key Vault secret representing the full certificate PFX

```yaml
Type: System.String
Parameter Sets: EnableExpanded, ByResourceIdWithVaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretVersion
The version of the Key Vault secret representing the full certificate PFX

```yaml
Type: System.String
Parameter Sets: EnableExpanded, ByResourceIdWithVaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: EnableExpanded, Enable, EnableViaJsonFilePath, EnableViaJsonString
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
Parameter Sets: EnableExpanded, ByResourceIdWithVaultParameterSet
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
