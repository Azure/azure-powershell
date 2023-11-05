### Example 1: Update the display name
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
 $PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -DisplayName 'Exempt VM creation limit'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The final command updates the display name on the policy exemption on the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 2: Update the expiration date time
```powershell
$NextMonth = (Get-Date).AddMonths(1)
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -ExpiresOn $NextMonth
```

The first command gets the current date time by using the Get-Date cmdlet and add 1 month to the current date time
The command stores that object in the $NextMonth variable.
The second command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The final command updates the expiration date time for the policy exemption on the default subscription.

### Example 3: Clear the expiration date time
```powershell
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -ClearExpiration
```

The first command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The second command clears the expiration date time for the policy exemption on the default subscription.
The updated exemption will never expire.

### Example 4: Update the expiration category
```powershell
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -ExemptionCategory Mitigated
```

The first command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The second command updates the expiration category for the policy exemption on the default subscription.
The updated exemption will never expire.

The first command gets the current date time by using the Get-Date cmdlet and add 1 month to the current date time
The command stores that object in the $NextMonth variable.
The second command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The final command updates the expiration date time for the policy exemption on the default subscription.

### Example 5: [Backcompat] Clear the expiration date time
```powershell
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Set-AzPolicyExemption -Id $PolicyExemption.ResourceId -ClearExpiration
```

The first command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The second command clears the expiration date time for the policy exemption on the default subscription.
The updated exemption will never expire.
