### Example 1: Create SAPS4Hana data source object
```powershell
New-AzPurviewSapS4HanaDataSourceObject -Kind 'SapS4Hana' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ApplicationServer '12.13.14.12' -SystemNumber 32
```

```output
ApplicationServer        : 12.13.14.12
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : SapS4Hana
LastModifiedAt           :
Name                     :
Scan                     :
SystemNumber             : 32
```

Create SAPS4 data source object

