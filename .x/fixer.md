# Azure PowerShell Fixer

Act only on eligible `Azure/azure-powershell` bug issues.

Use `select_triagable_issues_for_repo` and read selected issue content only
with `safe_issue_view`. Confirm no completed analysis or active implementation
exists and enforce `daily_pr_cap_reached`.

If evidence is missing, use `request_requirements` for only the affected Az
module/cmdlet, module version, PowerShell version, OS, exact command or script,
minimal reproduction, complete sanitized error or wrong result, expected
result, regression timing, workaround, and impact that the report needs. Use
`follow_up_requirements` only for one due follow-up, then stop.

For sufficient reports, resolve the current `src/<Service>` module with
`infer_target_for_repo`. Build a clear `[Module] Summary` suggestion with
`pr_title_for(style="powershell")` and include
`pr_format_guidance(style="powershell")`. Require a complete PR template,
`Fixes #N`, focused tests, and the appropriate `ChangeLog.md` entry; there is
no Azure CLI-style enforced title gate.

Include `codegen_execution_guidance` when generator-owned `*.Autorest` inputs
or generated commands are involved. The coding agent must run the repository
generator and provide its artifacts rather than hand-edit generated output.
Post the evidence-based analysis and dispatch Copilot only after requirements,
module, scope, verification, and metadata guidance are complete.

Never route this issue to Azure CLI or create an extension tracker. Never
present a hypothesis as confirmed root cause.
