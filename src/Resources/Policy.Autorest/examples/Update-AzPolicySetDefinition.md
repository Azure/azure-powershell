### Example 1: Update the description of a policy set definition
```powershell
$PolicySetDefinition = Get-AzPolicySetDefinition -Id '/subscriptions/mySub/Microsoft.Authorization/policySetDefinitions/myPSSetDefinition'
Update-AzPolicySetDefinition -Id $PolicySetDefinition.Id -Description 'Updated policy to not allow virtual machine creation'
```

The first command gets a policy set definition by using the Get-AzPolicySetDefinition cmdlet.
The command stores that object in the $PolicySetDefinition variable.
The second command updates the description of the policy set definition identified by the **Id** property of $PolicySetDefinition.

### Example 2: Update the metadata of a policy set definition
```powershell
Update-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -Metadata '{"category":"Virtual Machine"}'
```

This command updates the metadata of a policy set definition named VMPolicySetDefinition to indicate its category is "Virtual Machine".

### Example 3: Update the groups of a policy set definition
```powershell
Update-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -GroupDefinition '[{ "name": "group1", "displayName": "Virtual Machine Security" }, { "name": "group2" }]'
```

This command updates the groups of a policy set definition named VMPolicySetDefinition.

### Example 4: Update the groups of a policy set definition using a hash table
```powershell
$groupsJson = ConvertTo-Json @{ name = "group1"; displayName = "Virtual Machine Security" }, @{ name = "group2" }
Update-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -GroupDefinition $groupsJson
```

This command updates the groups of a policy set definition named VMPolicySetDefinition from a hash table.

### Example 5: Update a policy set definition to add an older version by using a policy set file

```powershell
[
   {
      "policyDefinitionId": "/providers/Microsoft.Authorization/policyDefinitions/2a0e14a6-b0a6-4fab-991a-187a4f81c498",
      "parameters": {
         "tagName": {
            "value": "Business Unit"
         },
         "tagValue": {
            "value": "Finance"
         }
      }
   },
   {
      "policyDefinitionId": "/providers/Microsoft.Authorization/policyDefinitions/464dbb85-3d5f-4a1d-bb09-95a9b5dd19cf"
   }
]

Update-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -PolicyDefinition C:\VMPolicySet.json -Version '1.1.0'
```

This command updates the existing policy set definition named VMPolicySetDefinition by adding a new older version 1.1.0 that contains the policy definitions specified in C:\VMPolicySet.json. Example content of the VMPolicySet.json is provided above.