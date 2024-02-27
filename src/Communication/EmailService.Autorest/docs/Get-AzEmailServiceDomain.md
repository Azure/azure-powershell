---
external help file:
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/get-azemailservicedomain
schema: 2.0.0
---

# Get-AzEmailServiceDomain

## SYNOPSIS
Get the Domains resource and its properties.

## SYNTAX

### List (Default)
```
Get-AzEmailServiceDomain -EmailServiceName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEmailServiceDomain -EmailServiceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEmailServiceDomain -InputObject <IEmailServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityEmailService
```
Get-AzEmailServiceDomain -EmailServiceInputObject <IEmailServiceIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the Domains resource and its properties.

## EXAMPLES

### Example 1: List existing Email Service domains for a Subscription
```powershell
Get-AzEmailServiceDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
Location Name                                           SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                                                                        odifiedBy
-------- ----                                           ------------------- -------------------        ----------------------- ------------------------ ---------------
global   AzureManagedDomain                             08-12-2023 05:34:31 test@microsoft.com         User                    28-01-2024 13:58:25      test@microsoft.com
global   customdomain.net                               07-02-2024 06:11:24 test@microsoft.com         User                    14-02-2024 06:25:26      test@microsoft.com
```

Returns a list of all domain resources under that email services.

### Example 2: Get infomation on specified Azure Email services resource
```powershell
Get-AzEmailServiceDomain -Name AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
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
FromSenderDomain             : a3d08608-7f9d-4d33-9c79-8b635d9220ab.azurecomm.net
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers
                               /Microsoft.Communication/emailServices/ContosoAcsResource1/domains/AzureManaged
                               Domain
Location                     : global
MailFromSenderDomain         : a3d08608-7f9d-4d33-9c79-8b635d9220ab.azurecomm.net
Name                         : AzureManagedDomain
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SpfErrorCode                 :
SpfStatus                    : Verified
SystemDataCreatedAt          : 08-12-2023 05:34:31
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 28-01-2024 13:58:25
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "ExampleValue1"
                               }
Type                         : microsoft.communication/emailservices/domains
UserEngagementTracking       : Disabled
VerificationRecord           : {
                               }
```

Returns the information on an domain resource, if one matching provided parameters is found.

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

### -EmailServiceInputObject
Identity Parameter
To construct, see NOTES section for EMAILSERVICEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
Parameter Sets: GetViaIdentityEmailService
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Domains resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityEmailService
Aliases: DomainName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IDomainResource

## NOTES

## RELATED LINKS

