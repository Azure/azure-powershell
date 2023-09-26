---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azspherecertificate
schema: 2.0.0
---

# Get-AzSphereCertificate

## SYNOPSIS
Get a Certificate

## SYNTAX

### List (Default)
```
Get-AzSphereCertificate -CatalogName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Maxpagesize <Int32>] [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSphereCertificate -CatalogName <String> -ResourceGroupName <String> -SerialNumber <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSphereCertificate -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCatalog
```
Get-AzSphereCertificate -CatalogInputObject <ISphereIdentity> -SerialNumber <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Certificate

## EXAMPLES

### Example 1: Get specific certificate with specified catalog
```powershell
Get-AzSphereCertificate -CatalogName "MyCEVtest" -ResourceGroupName "glumenCEVRG"
```

```output
ExpiryUtc                    : 5/15/2025 2:55:00 PM
Id                           : /subscriptions/82f138e0-1c79-4708-bda1-5e224cd688b2/resourceGroups/glumenCEVRG/providers/Microsoft.AzureSphere/catalogs/MyCEVtest/certificates/11D6501213A2B3987929F7909769F7B5
Name                         : 11D6501213A2B3987929F7909769F7B5
NotBeforeUtc                 : 5/16/2023 2:55:00 PM
PropertiesCertificate        : MIIDCzCCApGgAwIBAgIQEdZQEhOis5h5KfeQl2n3tTAKBggqhkjOPQQDAzBTMQswCQYDVQQGEwJVUzEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSQwIgYDVQQDExtBenVyZSBTcGhlcmUgUG9saWN5IENBIDIwMjIwHhcNMjM
                               wNTE2MTQ1NTAwWhcNMjUwNTE1MTQ1NTAwWjCBmjELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjFEMEIGA1UEAxM7TWljcm9zb2Z0IE
                               F6dXJlIFNwaGVyZSBiZTUxMDU3ZS1lNmViLTQ4N2QtODJjOC1hNzA0M2NjYWI5ZTEwdjAQBgcqhkjOPQIBBgUrgQQAIgNiAATrPradtPvdN46uvvSatOAWwuE7wdOGYTxtyWcG8+wEmDJjUhIYqFAfaEGA9SnPFZNJwJAqJvnaQ/XhzIiFL
                               8GvUDBiggAlJVLjYThPkC5Jc7kpOOFcpx8aRcSSaRsydIWjgeEwgd4wDgYDVR0PAQH/BAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wUgYDVR0fBEswSTBHoEWgQ4ZBaHR0cDovL2NybC5zcGhlcmUuYXp1cmUubmV0L01pY3Jvc29mdCBBenVy
                               ZSBTcGhlcmUgUG9saWN5MjAyMi5jcmwwZwYIKwYBBQUHAQEEWzBZMFcGCCsGAQUFBzAChktodHRwOi8vcGtpLnNwaGVyZS5henVyZS5uZXQvY2VydGlmaWNhdGVzL01pY3Jvc29mdEF6dXJlU3BoZXJlUG9saWN5MjAyMi5jZXIwCgYIKoZ
                               Izj0EAwMDaAAwZQIxALyiEKIYmCCDIjHVvjoNBeAz14DiTBWR3AWYePPG3oShXL/Je/yT8yOrimtRnrGnpAIwO07WVeqEeqRtyPbmJefdRtJ8/SF89z+wu1Y/CPO0ldDXavoLRQQyQq5yih6N9Cjl
ProvisioningState            : Succeeded
ResourceGroupName            : glumenCEVRG
Status                       : Active
Subject                      : CN=Microsoft Azure Sphere be51057e-e6eb-487d-82c8-a7043ccab9e1, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Thumbprint                   : BFF18CC17D19D7E3B7884091981E0190F8E84181
Type                         : Microsoft.AzureSphere/catalogs/certificatesExpiryUtc                    : 5/15/2025 2:55:00 PM
Id                           : /subscriptions/82f138e0-1c79-4708-bda1-5e224cd688b2/resourceGroups/glumenCEVRG/providers/Microsoft.AzureSphere/catalogs/MyCEVtest/certificates/11D6501213A2B3987929F7909769F7B5
Name                         : 11D6501213A2B3987929F7909769F7B5
NotBeforeUtc                 : 5/16/2023 2:55:00 PM
PropertiesCertificate        : MIIDCzCCApGgAwIBAgIQEdZQEhOis5h5KfeQl2n3tTAKBggqhkjOPQQDAzBTMQswCQYDVQQGEwJVUzEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSQwIgYDVQQDExtBenVyZSBTcGhlcmUgUG9saWN5IENBIDIwMjIwHhcNMjM
                               wNTE2MTQ1NTAwWhcNMjUwNTE1MTQ1NTAwWjCBmjELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjFEMEIGA1UEAxM7TWljcm9zb2Z0IE
                               F6dXJlIFNwaGVyZSBiZTUxMDU3ZS1lNmViLTQ4N2QtODJjOC1hNzA0M2NjYWI5ZTEwdjAQBgcqhkjOPQIBBgUrgQQAIgNiAATrPradtPvdN46uvvSatOAWwuE7wdOGYTxtyWcG8+wEmDJjUhIYqFAfaEGA9SnPFZNJwJAqJvnaQ/XhzIiFL
                               8GvUDBiggAlJVLjYThPkC5Jc7kpOOFcpx8aRcSSaRsydIWjgeEwgd4wDgYDVR0PAQH/BAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wUgYDVR0fBEswSTBHoEWgQ4ZBaHR0cDovL2NybC5zcGhlcmUuYXp1cmUubmV0L01pY3Jvc29mdCBBenVy
                               ZSBTcGhlcmUgUG9saWN5MjAyMi5jcmwwZwYIKwYBBQUHAQEEWzBZMFcGCCsGAQUFBzAChktodHRwOi8vcGtpLnNwaGVyZS5henVyZS5uZXQvY2VydGlmaWNhdGVzL01pY3Jvc29mdEF6dXJlU3BoZXJlUG9saWN5MjAyMi5jZXIwCgYIKoZ
                               Izj0EAwMDaAAwZQIxALyiEKIYmCCDIjHVvjoNBeAz14DiTBWR3AWYePPG3oShXL/Je/yT8yOrimtRnrGnpAIwO07WVeqEeqRtyPbmJefdRtJ8/SF89z+wu1Y/CPO0ldDXavoLRQQyQq5yih6N9Cjl
ProvisioningState            : Succeeded
ResourceGroupName            : glumenCEVRG
Status                       : Active
Subject                      : CN=Microsoft Azure Sphere be51057e-e6eb-487d-82c8-a7043ccab9e1, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Thumbprint                   : BFF18CC17D19D7E3B7884091981E0190F8E84181
Type                         : Microsoft.AzureSphere/catalogs/certificates
```

This command get specific certificate with specified catalog.

## PARAMETERS

### -CatalogInputObject
Identity Parameter
To construct, see NOTES section for CATALOGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityCatalog
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

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

### -Filter
Filter the result list using the given expression

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
The maximum number of result items per page.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
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

### -SerialNumber
Serial number of the certificate.
Use '.default' to get current active certificate.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ICertificate

## NOTES

## RELATED LINKS

