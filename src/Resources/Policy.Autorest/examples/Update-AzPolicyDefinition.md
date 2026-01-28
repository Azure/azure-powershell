### Example 1: Update the description of a policy definition
```powershell
$PolicyDefinition = Get-AzPolicyDefinition -Name 'VMPolicyDefinition'
Update-AzPolicyDefinition -Id $PolicyDefinition.Id -Description 'Updated policy to not allow virtual machine creation'
```

The first command gets a policy definition named VMPolicyDefinition by using the Get-AzPolicyDefinition cmdlet.
The command stores that object in the $PolicyDefinition variable.
The second command updates the description of the policy definition identified by the **Id** property of $PolicyDefinition.

### Example 2: Update the mode of a policy definition
```powershell
Update-AzPolicyDefinition -Name 'VMPolicyDefinition' -Mode 'All'
```

This command updates the policy definition named VMPolicyDefinition by using the Update-AzPolicyDefinition cmdlet to 
set its mode property to 'All'.

### Example 3: Update the metadata of a policy definition
```powershell
Update-AzPolicyDefinition -Name 'VMPolicyDefinition' -Metadata '{"category":"Virtual Machine"}'
```

This command updates the metadata of a policy definition named VMPolicyDefinition to indicate its category is "Virtual Machine".

### Example 4: Update a policy definition to add an older version by using a policy file

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
Update-AzPolicyDefinition -Name 'LocationDefinition' -Policy C:\LocationPolicy.json -Version '1.1.0'
```

This command updates the existing policy definition named LocationDefinition by adding a new older version 1.1.0 that contains the policy rule specified in C:\LocationPolicy.json. Example content for the LocationPolicy.json file is provided above.