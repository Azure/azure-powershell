---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabaseautonomousdatabasecharacterset
schema: 2.0.0
---

# Get-AzOracleDatabaseAutonomousDatabaseCharacterSet

## SYNOPSIS
Get a AutonomousDatabaseCharacterSet

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseAutonomousDatabaseCharacterSet -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseAutonomousDatabaseCharacterSet -Adbscharsetname <String> -Location <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseAutonomousDatabaseCharacterSet -InputObject <IOracleDatabaseIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDatabaseAutonomousDatabaseCharacterSet -Adbscharsetname <String>
 -LocationInputObject <IOracleDatabaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a AutonomousDatabaseCharacterSet

## EXAMPLES

### Example 1: Get a list of the Autonomous Database Character Sets by location
```powershell
(Get-AzOracleDatabaseAutonomousDatabaseCharacterSet -Location "eastus").CharacterSet
```

```output
AL32UTF8
AR8ADOS710
AR8ADOS720
AR8APTEC715
AR8ARABICMACS
AR8ASMO8X
AR8ISO8859P6
AR8MSWIN1256
AR8MUSSAD768
AR8NAFITHA711
AR8NAFITHA721
AR8SAKHR706
AR8SAKHR707
AZ8ISO8859P9E
BG8MSWIN
BG8PC437S
BLT8CP921
BLT8ISO8859P13
BLT8MSWIN1257
BLT8PC775
BN8BSCII
CDN8PC863
CEL8ISO8859P14
CL8ISO8859P5
CL8ISOIR111
CL8KOI8R
CL8KOI8U
CL8MACCYRILLICS
CL8MSWIN1251
EE8ISO8859P2
EE8MACCES
EE8MACCROATIANS
EE8MSWIN1250
EE8PC852
EL8DEC
EL8ISO8859P7
EL8MACGREEKS
EL8MSWIN1253
EL8PC437S
EL8PC851
EL8PC869
ET8MSWIN923
HU8ABMOD
HU8CWI2
IN8ISCII
IS8PC861
IW8ISO8859P8
IW8MACHEBREWS
IW8MSWIN1255
IW8PC1507
JA16EUC
JA16EUCTILDE
JA16SJIS
JA16SJISTILDE
JA16VMS
KO16KSC5601
KO16KSCCS
KO16MSWIN949
LA8ISO6937
LA8PASSPORT
LT8MSWIN921
LT8PC772
LT8PC774
LV8PC1117
LV8PC8LR
LV8RST104090
N8PC865
NE8ISO8859P10
NEE8ISO8859P4
RU8BESTA
RU8PC855
RU8PC866
SE8ISO8859P3
TH8MACTHAIS
TH8TISASCII
TR8DEC
TR8MACTURKISHS
TR8MSWIN1254
TR8PC857
US7ASCII
US8PC437
UTF8
VN8MSWIN1258
VN8VN3
WE8DEC
WE8DG
WE8ISO8859P1
WE8ISO8859P15
WE8ISO8859P9
WE8MACROMAN8S
WE8MSWIN1252
WE8NCR4970
WE8NEXTSTEP
WE8PC850
WE8PC858
WE8PC860
WE8ROMAN8
ZHS16CGB231280
ZHS16GBK
ZHT16BIG5
ZHT16CCDC
ZHT16DBT
ZHT16HKSCS
ZHT16HKSCS31
ZHT16MSWIN950
ZHT32EUC
ZHT32SOPS
ZHT32TRIS
```

Get a list of the Autonomous Database Character Sets by location.
For more information, execute `Get-Help Get-AzOracleDatabaseAutonomousDatabaseCharacterSet`.

## PARAMETERS

### -Adbscharsetname
AutonomousDatabaseCharacterSet name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentityLocation
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IAutonomousDatabaseCharacterSet

## NOTES

## RELATED LINKS

