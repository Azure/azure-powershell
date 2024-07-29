---
external help file:
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/invoke-azemailserviceinitiatedomainverification
schema: 2.0.0
---

# Invoke-AzEmailServiceInitiateDomainVerification

## SYNOPSIS
Initiate verification of DNS record.

## SYNTAX

### InitiateExpanded (Default)
```
Invoke-AzEmailServiceInitiateDomainVerification -DomainName <String> -EmailServiceName <String>
 -ResourceGroupName <String> -VerificationType <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Initiate
```
Invoke-AzEmailServiceInitiateDomainVerification -DomainName <String> -EmailServiceName <String>
 -ResourceGroupName <String> -Parameter <IVerificationParameter> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InitiateViaIdentity
```
Invoke-AzEmailServiceInitiateDomainVerification -InputObject <IEmailServiceIdentity>
 -Parameter <IVerificationParameter> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### InitiateViaIdentityEmailService
```
Invoke-AzEmailServiceInitiateDomainVerification -DomainName <String>
 -EmailServiceInputObject <IEmailServiceIdentity> -Parameter <IVerificationParameter>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InitiateViaIdentityEmailServiceExpanded
```
Invoke-AzEmailServiceInitiateDomainVerification -DomainName <String>
 -EmailServiceInputObject <IEmailServiceIdentity> -VerificationType <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InitiateViaIdentityExpanded
```
Invoke-AzEmailServiceInitiateDomainVerification -InputObject <IEmailServiceIdentity>
 -VerificationType <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### InitiateViaJsonFilePath
```
Invoke-AzEmailServiceInitiateDomainVerification -DomainName <String> -EmailServiceName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InitiateViaJsonString
```
Invoke-AzEmailServiceInitiateDomainVerification -DomainName <String> -EmailServiceName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Initiate verification of DNS record.

## EXAMPLES

### Example 1: Invoke initiate domain verification for domain resource.
```powershell
Invoke-AzEmailServiceInitiateDomainVerification -DomainName testcustomdomain1.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -VerificationType Domain
```

Invoke initiate domain verification for domain resource.

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

### -DomainName
The name of the Domains resource.

```yaml
Type: System.String
Parameter Sets: Initiate, InitiateExpanded, InitiateViaIdentityEmailService, InitiateViaIdentityEmailServiceExpanded, InitiateViaJsonFilePath, InitiateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailServiceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
Parameter Sets: InitiateViaIdentityEmailService, InitiateViaIdentityEmailServiceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EmailServiceName
The name of the EmailService resource.

```yaml
Type: System.String
Parameter Sets: Initiate, InitiateExpanded, InitiateViaJsonFilePath, InitiateViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
Parameter Sets: InitiateViaIdentity, InitiateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Initiate operation

```yaml
Type: System.String
Parameter Sets: InitiateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Initiate operation

```yaml
Type: System.String
Parameter Sets: InitiateViaJsonString
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

### -Parameter
Input parameter for verification APIs

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IVerificationParameter
Parameter Sets: Initiate, InitiateViaIdentity, InitiateViaIdentityEmailService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Initiate, InitiateExpanded, InitiateViaJsonFilePath, InitiateViaJsonString
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
Type: System.String
Parameter Sets: Initiate, InitiateExpanded, InitiateViaJsonFilePath, InitiateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VerificationType
Type of verification.

```yaml
Type: System.String
Parameter Sets: InitiateExpanded, InitiateViaIdentityEmailServiceExpanded, InitiateViaIdentityExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IVerificationParameter

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

