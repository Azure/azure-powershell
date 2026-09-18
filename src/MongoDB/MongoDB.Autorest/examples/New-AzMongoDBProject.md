### Example 1: Create a new Project under an Organization
```powershell
New-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -Name test-project-1 | Format-List
```

```output
ClusterCount                 : 0
Id                           : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/sharmaanuTest/providers/MongoDB.Atlas/organizations/KanedaTest/projects/test-project-1
Name                         : test-project-1
OrganizationId               : 6a2b114e620de528f66a43eb
ProjectId                    : 6a3d3a7fee32a7a117663313
ProjectName                  : test-project-1
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

Creates a new MongoDB Atlas project under the given organization. Project name is the only required body parameter; the partner assigns the projectId.
