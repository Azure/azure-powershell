### Example 1: Get a specified Application Gateway for Containers association resource
```powershell
Get-AzAlbSecurityPolicy -Name test-securityPolicy -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name          ResourceGroupName Location       PolicyType WafPolicyId                                                                                                                                                     ProvisioningState
----          ----------------- --------       ---------- -----------                                                                                                                                                     -----------------
test-frontend test-rg           northcentralus waf        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/test-rg/providers/Microsoft.Networking/applicationGatewayWebApplicationFirewallPolicies/wp-0 Succeeded
```

This command shows a specific Application Gateway for Containers frontend resource.

### Example 2: List associations for a given Application Gateway for Containers resource
```powershell
Get-AzAlbSecurityPolicy -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name          ResourceGroupName Location       PolicyType WafPolicyId                                                                                                                                                     ProvisioningState
----          ----------------- --------       ---------- -----------                                                                                                                                                     -----------------
test-frontend test-rg           northcentralus waf        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/test-rg/providers/Microsoft.Networking/applicationGatewayWebApplicationFirewallPolicies/wp-0 Succeeded
```

This command lists all Application Gateway for Containers frontend resources belonging to a specific Application Gateway for Containers resource.
