# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Azure PowerShell implementations of the X Engineering Agent engine hooks."""

from repository_tools.fixer.azure_powershell import guidance, targets
from repository_tools.fixer.formatting import guidance as formatting
from repository_tools.fixer.title_gate import title_repair
from repository_tools.reviewer.policy import analysis
from repository_tools.settings import _AAZ_OUTPUT_PATTERN
from repository_tools.tester.azure_powershell import live_tests
from x_engineering_agent.tools.reviews.inspection import _verified_generation_source_prs

REPOSITORY = "Azure/azure-powershell"


def infer_target(text=None, pr_files=None):
    return targets.infer_ps_target(text=text, pr_files=pr_files)


def resolve_target(name):
    return targets.resolve_ps_target(name)


def live_test_target(text, pr_files, module=None, target_kind=None):
    return targets._live_test_target(text, pr_files, module, target_kind)


def codegen_guidance(component=None):
    return guidance._codegen_execution_guidance(component)


def pr_title(component=None, issue_number=None, command=None, summary=None, customer_facing=True):
    return formatting.pr_title_for(
        component=component, issue_number=issue_number, command=command,
        summary=summary, customer_facing=customer_facing, style="powershell",
    )


def pr_format_guidance(component=None, issue_number=None, customer_facing=True,
                       command=None, issue_repo=None, summary=None):
    return formatting.pr_format_guidance(
        component=component, issue_number=issue_number, customer_facing=customer_facing,
        command=command, issue_repo=issue_repo, summary=summary, style="powershell",
    )


def title_failure_plan(pr, pr_files, component=None, issue_number=None, issue_title=None):
    return title_repair._failed_metadata_plan(
        pr, pr_files, component=component, issue_number=issue_number, issue_title=issue_title,
    )


def changed_test_files(pr_files):
    return live_tests.changed_ps_test_files(pr_files)


def live_test_plan(pr_files):
    return live_tests._live_test_plan(pr_files)


def analyze_review(pr, file_changes, head_repo=None, head_sha=None, generation_source_prs=None):
    return analysis.analyze_review_tools(
        REPOSITORY, pr, file_changes, head_repo=head_repo, head_sha=head_sha,
        generation_source_prs=generation_source_prs,
    )


def readiness_policy(pr, file_changes):
    return {"blocked": _ownership_block(pr, file_changes), "validation_required": False}


def _ownership_block(pr, file_changes):
    has_aaz_output = any(
        _AAZ_OUTPUT_PATTERN.search(change.get("filename") or "") for change in file_changes
    )
    sources = _verified_generation_source_prs(pr.get("body") or "") if has_aaz_output else None
    head = pr.get("head") or {}
    findings, _ = analysis._generated_ownership_check(
        REPOSITORY, pr, file_changes, file_changes,
        (head.get("repo") or {}).get("full_name"), head.get("sha"), sources,
    )
    if not findings:
        return None
    return {
        "reason": "codegen ownership preflight failed",
        "findings": [finding["summary"] for finding in findings],
    }
