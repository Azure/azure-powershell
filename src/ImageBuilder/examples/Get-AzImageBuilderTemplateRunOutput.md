### Example 1: List all run results under a template
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName test-img-temp -ResourceGroupName bez-rg
```

```output
Name          
----          
image_lucas_1 
```

This command lists all run results under a template.

### Example 2: Get a run result under a template
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName test-img-temp -ResourceGroupName bez-rg -Name runout-template-name-u7gjq
```

```output
Name                       
----                       
runout-template-name-u7gjqx
```
This command gets a run result under a template.

