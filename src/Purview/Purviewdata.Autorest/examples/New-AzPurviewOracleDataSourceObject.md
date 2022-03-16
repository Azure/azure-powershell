### Example 1: Create Azure Synapse workspace data source object
```powershell
New-AzPurviewOracleDataSourceObject -Kind 'Oracle' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -Host '13.1.0.46' -Port 1521 -Service 'xe'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Host                     : 13.1.0.46
Id                       :
Kind                     : Oracle
LastModifiedAt           :
Name                     :
Port                     : 1521
Scan                     :
Service                  : xe
```

Create Azure Synapse workspace data source object

