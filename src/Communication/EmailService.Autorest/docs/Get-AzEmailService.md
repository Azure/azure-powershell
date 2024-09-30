---
external help file:
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/get-azemailservice
schema: 2.0.0
---

# Get-AzEmailService

## SYNOPSIS
Get the EmailService and its properties.

## SYNTAX

### List (Default)
```
Get-AzEmailService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEmailService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEmailService -InputObject <IEmailServiceIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzEmailService -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the EmailService and its properties.

## EXAMPLES

### Example 1: List existing Email Services for a Subscription
```powershell
Get-AzCommunicationService -SubscriptionId 73fc3592-3cef-4300-5e19-8d18b65ce0e8
```

```output
Location Name                                         SystemDataCreatedAt SystemDataCreatedBy         SystemDataCreated
                                                                                                      ByType
-------- ----                                         ------------------- -------------------         -----------------
global   ContosoResource1                             06-12-2021 20:19:45 test@microsoft.com        User
global   ContosoResource2                             06-12-2021 20:22:48 test@microsoft.com        User
```

Returns a list of all ACS resources under that subscription.

### Example 2: Get infomation on specified Azure Email services resource
```powershell
Get-AzEmailService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
DataLocation                 : unitedstates
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers
                               /Microsoft.Communication/emailServices/ContosoAcsResource1
Location                     : global
Name                         : ContosoAcsResource1
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 08-12-2023 05:24:48
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12-02-2024 10:35:26
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "UpdatedTagValue"
                               }
Type                         : microsoft.communication/emailservices
```

Returns the information on an ACS resource, if one matching provided parameters is found.

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

### -InputObject
Identity Parameter

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
The name of the EmailService resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EmailServiceName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailService.Models.IEmailServiceResource

## NOTES

## RELATED LINKS

