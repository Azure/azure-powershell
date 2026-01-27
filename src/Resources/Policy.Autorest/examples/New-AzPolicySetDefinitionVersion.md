### Example 1: Create a policy set definition version by using a policy set file

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

New-AzPolicySetDefinitionVersion -Name 'VMPolicySetDefinition' -PolicyDefinition C:\VMPolicySet.json -Version '1.1.0'
```

This command creates an old policy set definition version for the policy set definition named VMPolicySetDefinition that contains the policy definitions specified in C:\VMPolicy.json. Example content of the VMPolicy.json is provided above.