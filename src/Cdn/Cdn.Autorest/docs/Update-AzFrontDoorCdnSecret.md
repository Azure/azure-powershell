---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azfrontdoorcdnsecret
schema: 2.0.0
---

# Update-AzFrontDoorCdnSecret

## SYNOPSIS
Update a new Secret within the specified profile.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoorCdnSecret -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Parameter <ISecretParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoorCdnSecret -InputObject <ICdnIdentity> [-Parameter <ISecretParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProfile
```
Update-AzFrontDoorCdnSecret -Name <String> -ProfileInputObject <ICdnIdentity> -Secret <ISecret>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProfileExpanded
```
Update-AzFrontDoorCdnSecret -Name <String> -ProfileInputObject <ICdnIdentity> [-Parameter <ISecretParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a new Secret within the specified profile.

## EXAMPLES

### Example 1: Update an AzureFrontDoor Secret within the specified AzureFrontDoor profile
```powershell
$secretSourceId = "xxxxxxxx"
$certificateParameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate" -SecretSourceId $secretSourceId  
Update-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001 -Parameter $certificateParameter
```

```output
Name      ResourceGroupName
----      -----------------
secret001 testps-rg-da16jm
```

Update an AzureFrontDoor Secret within the specified AzureFrontDoor profile

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Secret under the profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityProfile, UpdateViaIdentityProfileExpanded
Aliases: SecretName

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

### -Parameter
object which contains secret parameters

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecretParameters
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityProfile, UpdateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Secret
Friendly Secret name mapping to the any Secret or secret related information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecret
Parameter Sets: UpdateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecret

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecret

## NOTES

## RELATED LINKS

