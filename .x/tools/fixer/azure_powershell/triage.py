# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Azure PowerShell issue analysis dispatch to durable Foundry execution."""

import re

from x_engineering_agent.config import (
    BUG_ANALYSIS_DISPATCH_MARKER,
    BUG_ANALYSIS_MARKER,
)
from x_engineering_agent.tools.copilot.tasks import start_copilot_fork_task
from x_engineering_agent.tools.github.api import _require_fix_workflow
from x_engineering_agent.tools.github.issues import (
    _trusted_agent_comment_has_marker,
    get_issue_comments,
    post_comment,
    update_comment,
)
from x_engineering_agent.tools.sensitive.scanning import (
    _ensure_issue_not_sensitive,
)


def dispatch_powershell_copilot(owner, repo, issue_number, body, token=None):
    """Post trusted analysis and queue implementation as one recoverable operation."""
    from x_engineering_agent.tools.triage.analysis import (
        _finalize_bug_analysis,
    )

    _require_fix_workflow(owner, repo, "PowerShell Foundry dispatch")
    _ensure_issue_not_sensitive(owner, repo, issue_number, token=token)
    if (
        BUG_ANALYSIS_MARKER in body
        or BUG_ANALYSIS_DISPATCH_MARKER in body
    ):
        raise ValueError(
            "PowerShell analysis body contains a reserved state marker"
        )
    title_match = re.search(
        r"\*\*(?:Suggested|Use this EXACT) PR title:\*\*\s*`([^`]+)`",
        body,
    )
    if title_match is None or not title_match.group(1).strip():
        raise ValueError("PowerShell analysis requires a trusted suggested PR title")
    title = title_match.group(1).strip()
    if "\n" in title or "\r" in title:
        raise ValueError("PowerShell suggested PR title must be a single line")
    comments = get_issue_comments(owner, repo, issue_number, token=token)
    completed = next(
        (
            comment for comment in reversed(comments)
            if _trusted_agent_comment_has_marker(
                comment, BUG_ANALYSIS_MARKER,
            )
        ),
        None,
    )
    if completed:
        assignment = start_copilot_fork_task(
            owner, repo, issue_number, body, title, token=token,
        )
        _finalize_bug_analysis(
            owner, repo, issue_number, token=token,
        )
        return {
            "dispatched": assignment["started"],
            "skipped": not assignment["started"],
            "reason": "bug analysis already posted",
            "assignment": assignment,
            "comment": completed,
        }

    pending = next(
        (
            comment for comment in reversed(comments)
            if _trusted_agent_comment_has_marker(
                comment, BUG_ANALYSIS_DISPATCH_MARKER,
            )
        ),
        None,
    )
    if pending is None:
        pending = post_comment(
            owner,
            repo,
            issue_number,
            f"{body.rstrip()}\n\n{BUG_ANALYSIS_DISPATCH_MARKER}",
            token=token,
            role="Fixer",
        )

    assignment = start_copilot_fork_task(
        owner, repo, issue_number, body, title, token=token,
    )
    pending_body = pending.get("body") or ""
    if BUG_ANALYSIS_DISPATCH_MARKER not in pending_body:
        raise RuntimeError(
            "Pending PowerShell dispatch comment lost its state marker"
        )
    completed_body = pending_body.replace(
        BUG_ANALYSIS_DISPATCH_MARKER,
        BUG_ANALYSIS_MARKER,
        1,
    )
    if (
        BUG_ANALYSIS_DISPATCH_MARKER in completed_body
        or completed_body.count(BUG_ANALYSIS_MARKER) != 1
    ):
        raise RuntimeError(
            "PowerShell dispatch comment has inconsistent state markers"
        )
    comment = update_comment(
        owner,
        repo,
        pending["id"],
        completed_body,
        token=token,
    )
    _finalize_bug_analysis(
        owner, repo, issue_number, token=token,
    )
    return {
        "dispatched": assignment["started"],
        "skipped": not assignment["started"],
        "assignment": assignment,
        "comment": comment,
    }