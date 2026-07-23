---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/get-azcommunicationservicesmtpusername
schema: 2.0.0
---

# Get-AzCommunicationServiceSmtpUsername

## SYNOPSIS
Get a SmtpUsernameResource.

## SYNTAX

### List (Default)
```
Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName <String> -ResourceGroupName <String>
 -SmtpUsername <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCommunicationService
```
Get-AzCommunicationServiceSmtpUsername -SmtpUsername <String>
 -CommunicationServiceInputObject <ICommunicationServiceSmtpUsernameIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCommunicationServiceSmtpUsername -InputObject <ICommunicationServiceSmtpUsernameIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a SmtpUsernameResource.

## EXAMPLES

### Example 1: List existing SMTP Usernames for a Communication Service resource
```powershell
Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
EntraApplicationId           : aaaa1111-bbbb-2222-3333-aaaa1111abcd
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourcegroups/ContosoResourceProvider1/providers/microsoft.communicati
                               on/communicationservices/ContosoAcsResource1/SmtpUsernames/ContosoSmtpUsernameResource1
Name                         : ContosoSmtpUsernameResource1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TenantId                     : 72f988bf-86f1-41af-91ab-2d7cd011db47
Type                         : communicationservices/smtpusernames
Username                     : ContosoUsername1
 
EntraApplicationId           : 1e1e1d1a-1111-1111-1111-11ad111bf111
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourcegroups/ContosoResourceProvider1/providers/microsoft.communicati
                               on/communicationservices/ContosoAcsResource1/SmtpUsernames/ContosoSmtpUsernameResource2
Name                         : ContosoSmtpUsernameResource2
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TenantId                     : aaaa1111-bbbb-2222-3333-aaaa11112222
Type                         : communicationservices/smtpusernames
Username                     : ContosoUsername2
```

Returns a list of all SMTP Username resources under the specified Communication Services resource.

### Example 2: Get the information if single SMTP Username resource is present
```powershell
Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
EntraApplicationId           : 1e1e1d1a-1111-1111-1111-11ad111bf111
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourcegroups/ContosoResourceProvider1/pro
                               viders/microsoft.communication/communicationservices/ContosoAcsResource1/SmtpUsernames/ContosoSmtpUsernameResource1
Name                         : ContosoSmtpUsernameResource1
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TenantId                     : aaaa1111-bbbb-2222-3333-aaaa11112222
Type                         : communicationservices/smtpusernames
Username                     : ContosoUsername1
```

Returns information if single SMTP Username resource is present.

## PARAMETERS

### -CommunicationServiceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ICommunicationServiceSmtpUsernameIdentity
Parameter Sets: GetViaIdentityCommunicationService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CommunicationServiceName
The name of the CommunicationService resource.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ICommunicationServiceSmtpUsernameIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmtpUsername
The name of the SmtpUsernameResource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCommunicationService
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ICommunicationServiceSmtpUsernameIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ISmtpUsernameResource

## NOTES

## RELATED LINKS
