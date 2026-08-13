### Example 1: List all Projects under an Organization
```powershell
Get-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest
```

```output
Name           SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----           ------------------- ------------------- -----------------------
asdfsadf
mavarsh-test-1
mavarsh-test2
tesgin
```

Lists all projects that belong to the given organization in the resource group.

### Example 2: Get a specific Project
```powershell
Get-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -Name mavarsh-test-1 | Format-List
```

```output
ClusterCount                 : 0
Id                           : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/sharmaanuTest/providers/MongoDB.Atlas/organizations/KanedaTest/projects/mavarsh-test-1
Name                         : mavarsh-test-1
OrganizationId               : 6a2b114e620de528f66a43eb
ProjectId                    : 6a39281864733305129a1678
ProjectName                  : mavarsh-test-1
ProvisioningState            : Succeeded
ResourceGroupName            : sharmaanuTest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : MongoDB.Atlas/organizations/projects
```

Gets the details of a single project by name.
