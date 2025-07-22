### Example 1: Create a new Application Gateway for Containers security policy resource
```powershell
New-AzAlbSecurityPolicyWaf -Name test-securityPolicy -AlbName test-alb -ResourceGroupName test-rg -Location NorthCentralUS
```

```output
Name          ResourceGroupName Location       PolicyType WafPolicyId                                                                                                                                                     ProvisioningState
----          ----------------- --------       ---------- -----------                                                                                                                                                     -----------------
test-frontend test-rg           northcentralus waf        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/test-rg/providers/Microsoft.Networking/applicationGatewayWebApplicationFirewallPolicies/wp-0 Succeeded
```

This command creates a new Application Gateway for Containers security policy resource.

