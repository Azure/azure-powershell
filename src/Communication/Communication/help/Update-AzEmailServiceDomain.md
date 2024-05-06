---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/update-azemailservicedomain
schema: 2.0.0
---

# Update-AzEmailServiceDomain

## SYNOPSIS
Operation to Update an existing Domains resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEmailServiceDomain -EmailServiceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-UserEngagementTracking <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzEmailServiceDomain -EmailServiceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzEmailServiceDomain -EmailServiceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityEmailServiceExpanded
```
Update-AzEmailServiceDomain -Name <String> -EmailServiceInputObject <IEmailServiceIdentity> [-Tag <Hashtable>]
 [-UserEngagementTracking <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityEmailService
```
Update-AzEmailServiceDomain -Name <String> -EmailServiceInputObject <IEmailServiceIdentity>
 -Parameter <IUpdateDomainRequestParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEmailServiceDomain -InputObject <IEmailServiceIdentity> [-Tag <Hashtable>]
 [-UserEngagementTracking <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Operation to Update an existing Domains resource.

## EXAMPLES

### Example 1: Updates email service custom domain.
```powershell
Update-AzEmailServiceDomain -Name testcustomdomain2.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleUpdatedValue"} -UserEngagementTracking 1
```

```output
DataLocation                 : unitedstates
Dkim2ErrorCode               :
Dkim2Status                  : NotStarted
DkimErrorCode                :
DkimStatus                   : NotStarted
DmarcErrorCode               :
DmarcStatus                  : NotStarted
DomainErrorCode              :
DomainManagement             : CustomerManaged
DomainStatus                 : NotStarted
FromSenderDomain             : testcustomdomain2.net
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/testcustomdomain2.net
Location                     : global
MailFromSenderDomain         : testcustomdomain2.net
Name                         : testcustomdomain2.net
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SpfErrorCode                 :
SpfStatus                    : NotStarted
SystemDataCreatedAt          : 21-02-2024 07:30:12
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 09:06:45
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "ExampleUpdatedValue"
                               }
Type                         : microsoft.communication/emailservices/domains
UserEngagementTracking       : Enabled
VerificationRecord           : {
                                 "Domain": {
                                   "type": "TXT",
                                   "name": "testcustomdomain2.net",
                                   "value": "ms-domain-verification=1ff18540-e0c0-422b-b956-5b4cfa13613b",
                                   "ttl": 3600
                                 },
                                 "SPF": {
                                   "type": "TXT",
                                   "name": "testcustomdomain2.net",
                                   "value": "v=spf1 include:spf.protection.outlook.com -all",
                                   "ttl": 3600
                                 },
                                 "DKIM": {
                                   "type": "CNAME",
                                   "name": "selector1-azurecomm-prod-net._domainkey",
                                   "value": "selector1-azurecomm-prod-net._domainkey.azurecomm.net",
                                   "ttl": 3600
                                 },
                                 "DKIM2": {
                                   "type": "CNAME",
                                   "name": "selector2-azurecomm-prod-net._domainkey",
                                   "value": "selector2-azurecomm-prod-net._domainkey.azurecomm.net",
                                   "ttl": 3600
                                 }
                               }
```

Updates email service custom domain with the provided parameters.

### Example 2: Updates email service azure managed domain.
```powershell
Update-AzEmailServiceDomain -Name AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleValue1updated"} -UserEngagementTracking 1
```

```output
DataLocation                 : unitedstates
Dkim2ErrorCode               :
Dkim2Status                  : Verified
DkimErrorCode                :
DkimStatus                   : Verified
DmarcErrorCode               :
DmarcStatus                  : Verified
DomainErrorCode              :
DomainManagement             : AzureManaged
DomainStatus                 : Verified
FromSenderDomain             : fb0053ef-c684-4028-81eb-a582c1330d87.azurecomm.net
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/AzureManagedDomain
Location                     : global
MailFromSenderDomain         : fb0053ef-c684-4028-81eb-a582c1330d87.azurecomm.net
Name                         : AzureManagedDomain
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SpfErrorCode                 :
SpfStatus                    : Verified
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     : 21-02-2024 09:07:35
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "ExampleValue1updated"
                               }
Type                         : microsoft.communication/emailservices/domains
UserEngagementTracking       : Enabled
VerificationRecord           : {
                               }
```

Updates email service azure managed domain with the provided parameters.

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

### -EmailServiceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
Parameter Sets: UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityEmailService
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Domains resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityEmailService
Aliases: DomainName

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
A class that describes the PATCH request parameters of a Domains resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IUpdateDomainRequestParameters
Parameter Sets: UpdateViaIdentityEmailService
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags of the service which is a list of key value pairs that describe the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEngagementTracking
Describes whether user engagement tracking is enabled or disabled.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityEmailServiceExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IUpdateDomainRequestParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IDomainResource

## NOTES

## RELATED LINKS
