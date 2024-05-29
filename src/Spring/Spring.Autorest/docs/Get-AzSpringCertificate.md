---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringcertificate
schema: 2.0.0
---

# Get-AzSpringCertificate

## SYNOPSIS
Get the certificate resource.

## SYNTAX

### List (Default)
```
Get-AzSpringCertificate -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringCertificate -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCertificate -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringCertificate -Name <String> -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the certificate resource.

## EXAMPLES

### Example 1: Get the certificate resource.
```powershell
Get-AzSpringCertificate -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/certificates/azps-cert
Name                         : azps-cert
Property                     : {
                                 "type": "KeyVaultCertificate",
                                 "thumbprint": "841adf23c53e377c5f37f716740ea96a870da937",
                                 "issuer": "mydomain.com",
                                 "expirationDate": "2025-05-29T12:27:04.000+00:00",
                                 "activateDate": "2024-05-29T12:17:04.000+00:00",
                                 "subjectName": "mydomain.com",
                                 "dnsNames": [ ],
                                 "provisioningState": "Succeeded",
                                 "vaultUri": "https://azps-kv.vault.azure.net",
                                 "keyVaultCertName": "mycert",
                                 "certVersion": "xxxxxxxxxxxxxxxxxxxxxxxxx",
                                 "excludePrivateKey": false,
                                 "autoSync": "Disabled"
                               }
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-05-29 下午 12:28:24
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-29 下午 12:37:35
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/certificates
```

Get the certificate resource.

### Example 2: Get the certificate resource.
```powershell
Get-AzSpringCertificate -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -Name azps-cert
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/certificates/azps-cert
Name                         : azps-cert
Property                     : {
                                 "type": "KeyVaultCertificate",
                                 "thumbprint": "841adf23c53e377c5f37f716740ea96a870da937",
                                 "issuer": "mydomain.com",
                                 "expirationDate": "2025-05-29T12:27:04.000+00:00",
                                 "activateDate": "2024-05-29T12:17:04.000+00:00",
                                 "subjectName": "mydomain.com",
                                 "dnsNames": [ ],
                                 "provisioningState": "Succeeded",
                                 "vaultUri": "https://azps-kv.vault.azure.net",
                                 "keyVaultCertName": "mycert",
                                 "certVersion": "xxxxxxxxxxxxxxxxxxxxxxxxx",
                                 "excludePrivateKey": false,
                                 "autoSync": "Disabled"
                               }
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-05-29 下午 12:28:24
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-29 下午 12:37:35
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/certificates
```

Get the certificate resource.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the certificate resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring
Aliases: CertificateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -ServiceName
The name of the Service resource.

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

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ICertificateResource

## NOTES

## RELATED LINKS

