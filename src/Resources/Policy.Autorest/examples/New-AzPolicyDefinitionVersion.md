### Example 1: Create a policy definition version by using a policy file

```powershell
{
   "if": {
      "field": "location",
      "notIn": ["eastus", "westus", "centralus"]
   },
   "then": {
      "effect": "audit"
   }
}

New-AzPolicyDefinitionVersion -Name 'LocationDefinition' -Policy C:\LocationPolicy.json -Version '1.1.0'
```

This command creates an old policy definition version for the policy definition named LocationDefinition that contains the policy rule specified in C:\LocationPolicy.json. Example content for the LocationPolicy.json file is provided above.