### Example 1: {{ Add title here }}
```powershell
Get-AzApplicationInsightsWorkbookRevision -ResourceGroupName appinsights-hkrs2v-test -Name f7d7151e-7907-4f46-8a5e-6bf4a4cfedec | fl
```

```output
Category                     : workbook
Description                  :
DisplayName                  : f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display
Etag                         : "0900e1c6-0000-0600-0000-63632a540000"
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/appinsights-hkrs2v-test/providers/microsoft.insights/workbooks/f7d7151e-7907-4f46-8a5e-6bf4a4cfedec        
Identity                     : {
                               }
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Kind                         : shared
Location                     : westus2
Name                         : f7d7151e-7907-4f46-8a5e-6bf4a4cfedec
PropertiesTag                :
ResourceGroupName            : appinsights-hkrs2v-test
Revision                     : 91788fbfb8384ea5998ac73b9fa3e6eb
SerializedData               :
SourceId                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/appinsights-hkrs2v-test/providers/microsoft.insights/components/appinsights-48mah3-pwsh
StorageUri                   :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                                 "hidden-title": "f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display"
                               }
TimeModified                 : 11/3/2022 2:41:24 AM
Type                         :
UserId                       : 97deab6c-e478-40b4-b4da-e7d9353dc1e8
Version                      :
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzApplicationInsightsWorkbookRevision -ResourceGroupName appinsights-hkrs2v-test -Name f7d7151e-7907-4f46-8a5e-6bf4a4cfedec -RevisionId "91788fbfb8384ea5998ac73b9fa3e6eb"
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workbook
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
Get-AzApplicationInsightsWorkbookRevision -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/appinsights-hkrs2v-test/providers/microsoft.insights/workbooks/f7d7151e-7907-4f46-8a5e-6bf4a4cfedec/revisions/91788fbfb8384ea5998ac73b9fa3e6eb"
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workbook
```

{{ Add description here }}