### Example 1: Create an in-memory object for Vcf5License.
```powershell
New-AzVMwareVcf5LicenseObject -Core 16 -EndDate (Get-Date "2027-01-01") -LicenseKey (ConvertTo-SecureString "YOUR-LICENSE-KEY" -AsPlainText -Force) -BroadcomSiteId "site123" -BroadcomContractNumber "contract123"
```

```output
Core EndDate               Kind
---- -------               ----
  16 1/1/2027 12:00:00 AM  vcf5
```

Creates an in-memory VMware Cloud Foundation (VCF) 5.0 license object to pass to `New-AzVMwarePrivateCloud` via the `-VcfLicense` parameter.