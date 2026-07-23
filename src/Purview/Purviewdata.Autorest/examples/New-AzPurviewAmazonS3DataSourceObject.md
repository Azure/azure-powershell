### Example 1: Create AmazonS3 data source object
```powershell
New-AzPurviewAmazonS3DataSourceObject -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ServiceUrl s3://multicloud-e2e-2
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AmazonS3
LastModifiedAt           :
Name                     :
RoleArn                  :
Scan                     :
ServiceUrl               : s3://multicloud-e2e-2
```

Create AmazonS3 data source object