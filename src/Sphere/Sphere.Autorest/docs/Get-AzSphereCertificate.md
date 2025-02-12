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

### Example 1: List for the specified catalog with resource group
```powershell
Get-AzSphereCertificate -CatalogName test2024 -ResourceGroupName group-test
```

```output
ExpiryUtc                    : 4/30/2024 10:51:54 PM
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/certificates/'serial number'
Name                         : 'serial number'
NotBeforeUtc                 : 1/31/2024 10:51:54 PM
PropertiesCertificate        : 'certificate information'
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
Status                       : Active
Subject                      : CN=Microsoft Azure Sphere INT 11111111-2222-3333-4444-123456789101, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Thumbprint                   : ****************
Type                         : Microsoft.AzureSphere/catalogs/certificates
```

This command get a list of certificate for the specified catalog with resource group.

## PARAMETERS

### -CatalogInputObject
Identity Parameter

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

