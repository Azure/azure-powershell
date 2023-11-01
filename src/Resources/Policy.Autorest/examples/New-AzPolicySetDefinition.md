### Example 1: Create a policy set definition with metadata by using a policy set file

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

New-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -Metadata '{"category":"Virtual Machine"}' -PolicyDefinition C:\VMPolicySet.json
```

This command creates a policy set definition named VMPolicySetDefinition with metadata indicating its category is "Virtual Machine" that contains the policy definitions specified in C:\VMPolicy.json. Example content of the VMPolicy.json is provided above.

### Example 2: Create a parameterized policy set definition

```powershell
[
   {
      "policyDefinitionId": "/providers/Microsoft.Authorization/policyDefinitions/2a0e14a6-b0a6-4fab-991a-187a4f81c498",
      "parameters": {
         "tagName": {
            "value": "Business Unit"
         },
         "tagValue": {
            "value": "[parameters('buTagValue')]"
         }
      }
   },
   {
      "policyDefinitionId": "/providers/Microsoft.Authorization/policyDefinitions/464dbb85-3d5f-4a1d-bb09-95a9b5dd19cf"
   }
]

New-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -PolicyDefinition C:\VMPolicySet.json -Parameter '{ "buTagValue": { "type": "string" } }'
```

This command creates a parameterized policy set definition named VMPolicySetDefinition that contains the policy definitions specified in C:\VMPolicy.json. Example content of the VMPolicy.json is provided above.

### Example 3: Create a policy set definition with policy definition groups

```powershell
[
   {
      "policyDefinitionId": "/providers/Microsoft.Authorization/policyDefinitions/2a0e14a6-b0a6-4fab-991a-187a4f81c498",
      "groupNames": [ "group1" ]
   },
   {
      "policyDefinitionId": "/providers/Microsoft.Authorization/policyDefinitions/464dbb85-3d5f-4a1d-bb09-95a9b5dd19cf",
      "groupNames": [ "group2" ]
   }
]

$groupsJson = ConvertTo-Json @{ name = "group1" }, @{ name = "group2" }
New-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -GroupDefinition $groupsJson -PolicyDefinition C:\VMPolicySet.json
```

This command creates a policy set definition named VMPolicySetDefinition with grouping of policy definitions specified in C:\VMPolicy.json. Example content of the VMPolicy.json is provided above.
