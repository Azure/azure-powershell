"""Own recoverable Azure PowerShell analysis and Copilot dispatch."""


def dispatch_powershell_copilot(
    issue_number,
    body,
    memory_usage_purposes,
    memory_usage_target_revision,
):
    """Post analysis and assign Copilot as one scope-bound operation."""
    return dispatch_copilot_with_analysis(
        repository="Azure/azure-powershell",
        issue_number=issue_number,
        body=body,
        memory_usage_purposes=memory_usage_purposes,
        memory_usage_target_revision=memory_usage_target_revision,
    )
