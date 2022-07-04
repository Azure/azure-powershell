### Example 1: Remove a image template
```powershell
Remove-AzImageBuilderTemplate -ImageTemplateName template-name-dmt6ze -ResourceGroupName wyunchi-imagebuilder
```

This command removes a image template.

### Example 2: Remove a image template
```powershell
$template = Get-AzImageBuilderTemplate -ImageTemplateName template-name-3uo8p6 -ResourceGroupName wyunchi-imagebuilder
Remove-AzImageBuilderTemplate -InputObject $template
```

This command removes a image template.

