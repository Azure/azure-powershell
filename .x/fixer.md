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

For sufficient reports, resolve the current `src/<Service>` module with the
repository-owned `infer_ps_target` custom skill using only the sanitized
issue text and an empty `pr_files` list. Build a clear `[Module] Summary`
suggestion with `pr_title_for(style="powershell")` and include
`pr_format_guidance(style="powershell")`. Require a complete PR template,
`Fixes #N`, focused tests, and the appropriate `ChangeLog.md` entry; there is
no Azure CLI-style enforced title gate.

If target inference returns `unknown` or `none`, request the affected module
as missing information and stop. Do not dispatch with a guessed module.

Include `codegen_execution_guidance` when generator-owned `*.Autorest` inputs
or generated commands are involved. The coding agent must run the repository
generator and provide its artifacts rather than hand-edit generated output.
Only after requirements, module, scope, verification, metadata guidance, and
the complete sanitized analysis are ready, call the repository-owned
`dispatch_powershell_copilot` custom skill exactly once. Pass the issue number,
analysis body, memory usage purposes (an empty list when memory was not used),
and memory target revision (null when memory was not used). This recoverable
compound action records pending analysis, assigns Copilot, and finalizes state
only after assignment succeeds. Do not post the analysis or assign Copilot
separately.

Never route this issue to Azure CLI or create an extension tracker. Never
present a hypothesis as confirmed root cause.
