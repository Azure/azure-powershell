---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewscan
schema: 2.0.0
---

# Get-AzPurviewScan

## SYNOPSIS
Gets a scan information

## SYNTAX

### List (Default)
```
Get-AzPurviewScan -Endpoint <String> -DataSourceName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPurviewScan -Endpoint <String> -DataSourceName <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

<<<<<<< HEAD
### GetViaIdentity
```
Get-AzPurviewScan -Endpoint <String> -InputObject <IPurviewdataIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## DESCRIPTION
Gets a scan information

## EXAMPLES

### Example 1: Get scan instance within a data source
```powershell
<<<<<<< HEAD
Get-AzPurviewScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -Name 'ScanTest'
```

```output
=======
PS C:\> Get-AzPurviewScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -Name 'ScanTest'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CollectionLastModifiedAt  : 2/15/2022 3:49:23 PM
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 : 2/15/2022 3:49:23 PM
CredentialReferenceName   : datascantestdataparv-accountkey
CredentialType            : AccountKey
Id                        : datasources/DataScanTestData-Parv/scans/ScanTest
Kind                      : AzureStorageCredential
LastModifiedAt            : 2/15/2022 11:46:29 PM
Name                      : ScanTest
Result                    :
ScanRulesetName           : AzureStorage
ScanRulesetType           : System
Worker                    :
```

Get scan instance named 'ScanTest' within a data source

### Example 2: Get all scan instances within a data source
```powershell
<<<<<<< HEAD
Get-AzPurviewScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv'
```

```output
=======
PS C:\>  Get-AzPurviewScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CollectionLastModifiedAt  : 2/13/2022 3:16:24 PM
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 : 2/13/2022 3:16:24 PM
CredentialReferenceName   : datascantestdataparv-accountkey
CredentialType            : AccountKey
Id                        : datasources/DataScanTestData-Parv/scans/Scan1ForDemo
Kind                      : AzureStorageCredential
LastModifiedAt            : 2/13/2022 3:16:24 PM
Name                      : Scan1ForDemo
Result                    :
ScanRulesetName           : AzureStorage
ScanRulesetType           : System
Worker                    :

CollectionLastModifiedAt  : 2/15/2022 3:49:23 PM
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 : 2/15/2022 3:49:23 PM
CredentialReferenceName   : datascantestdataparv-accountkey
CredentialType            : AccountKey
Id                        : datasources/DataScanTestData-Parv/scans/ScanTest
Kind                      : AzureStorageCredential
LastModifiedAt            : 2/15/2022 11:46:29 PM
Name                      : ScanTest
Result                    :
ScanRulesetName           : AzureStorage
ScanRulesetType           : System
Worker                    :
```

Get all scan instances within a data source

## PARAMETERS

### -DataSourceName
.

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: Get, List
=======
Parameter Sets: (All)
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IPurviewdataIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
### -Name
.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ScanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

<<<<<<< HEAD
### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IPurviewdataIdentity

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IScan

## NOTES

ALIASES

<<<<<<< HEAD
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IPurviewdataIdentity>: Identity Parameter
  - `[ClassificationRuleName <String>]`: 
  - `[ClassificationRuleVersion <Int32?>]`: 
  - `[DataSourceName <String>]`: 
  - `[DataSourceType <DataSourceType?>]`: 
  - `[Id <String>]`: Resource identity path
  - `[KeyVaultName <String>]`: 
  - `[RunId <String>]`: 
  - `[ScanName <String>]`: 
  - `[ScanRulesetName <String>]`: 
  - `[Version <Int32?>]`: 

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## RELATED LINKS

