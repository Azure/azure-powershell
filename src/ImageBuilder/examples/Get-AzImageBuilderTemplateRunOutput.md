### Example 1: List all run results under a template
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName test-img-temp -ResourceGroupName bez-rg
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
testrunoutput                                                                                                                                          bez-rg
```

This command lists all run results under a template.

### Example 2: Get a run result under a template
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName test-img-temp -ResourceGroupName bez-rg -Name runout-template-name-u7gjq
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
runout-template-name-u7gjq  
```
This command gets a run result under a template.

