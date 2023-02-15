### Example 1: Create AmazonS3 data source object
```powershell
PS C:\> New-AzPurviewAmazonS3DataSourceObject -Kind 'AmazonS3' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ServiceUrl s3://multicloud-e2e-2
PS C:\repos\az-pwsh-3\azure-powershell\src\Purview> New-AzPurviewDataSource -Endpoint 'https://parv-brs-2.purview.azure.com/' -Name 'DS4' -Body $obj

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

