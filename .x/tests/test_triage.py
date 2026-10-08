# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------
import importlib
import sys
import types
from pathlib import Path
from unittest.mock import Mock, patch

import pytest

from x_engineering_agent.config import (
    BUG_ANALYSIS_DISPATCH_MARKER,
    BUG_ANALYSIS_MARKER,
)
from x_engineering_agent.config.identity import LEGACY_AGENT_BOT_LOGIN


PACKAGE = Path(__file__).resolve().parents[1]
TOOLS = PACKAGE / "tools"
module = sys.modules.get("repository_tools")
if module is None:
    module = types.ModuleType("repository_tools")
    module.__path__ = [str(TOOLS)]
    sys.modules["repository_tools"] = module
elif str(TOOLS) not in module.__path__:
    module.__path__.append(str(TOOLS))

triage = importlib.import_module("repository_tools.fixer.azure_powershell.triage")


BODY = "Trusted analysis\n\n**Suggested PR title:** `[Compute] Fix PowerShell`"


@patch("x_engineering_agent.tools.triage.analysis._finalize_bug_analysis")
@patch.object(triage, "update_comment")
@patch.object(triage, "start_copilot_fork_task")
@patch.object(triage, "post_comment")
@patch.object(triage, "get_issue_comments", return_value=[])
@patch.object(triage, "_ensure_issue_not_sensitive")
@patch.object(triage, "_require_fix_workflow")
def test_powershell_dispatch_records_completion_after_assignment(
    _require, _sensitive, _comments, post, assign, update, finalize,
):
    post.return_value = {
        "id": 12,
        "body": f"{BODY}\n\n{BUG_ANALYSIS_DISPATCH_MARKER}",
    }
    assign.return_value = {"started": True, "job": {"id": "a" * 64}}
    update.return_value = {"id": 12, "body": f"{BODY}\n\n{BUG_ANALYSIS_MARKER}"}

    result = triage.dispatch_powershell_copilot(
        "Azure", "azure-powershell", 30047, BODY, token="app-token",
    )

    assert result["dispatched"]
    assign.assert_called_once_with(
        "Azure", "azure-powershell", 30047, BODY,
        "[Compute] Fix PowerShell", token="app-token",
    )
    completed_body = update.call_args.args[3]
    assert BUG_ANALYSIS_MARKER in completed_body
    assert BUG_ANALYSIS_DISPATCH_MARKER not in completed_body
    finalize.assert_called_once_with(
        "Azure", "azure-powershell", 30047, token="app-token",
    )


@patch("x_engineering_agent.tools.triage.analysis._finalize_bug_analysis")
@patch.object(triage, "update_comment")
@patch.object(triage, "start_copilot_fork_task", side_effect=RuntimeError("assignment"))
@patch.object(triage, "post_comment")
@patch.object(triage, "get_issue_comments", return_value=[])
@patch.object(triage, "_ensure_issue_not_sensitive")
@patch.object(triage, "_require_fix_workflow")
def test_powershell_dispatch_keeps_pending_state_on_assignment_failure(
    _require, _sensitive, _comments, post, _assign, update, finalize,
):
    post.return_value = {
        "id": 12,
        "body": f"{BODY}\n\n{BUG_ANALYSIS_DISPATCH_MARKER}",
    }

    with pytest.raises(RuntimeError, match="assignment"):
        triage.dispatch_powershell_copilot(
            "Azure", "azure-powershell", 30047, BODY, token="app-token",
        )

    update.assert_not_called()
    finalize.assert_not_called()


@patch("x_engineering_agent.tools.triage.analysis._finalize_bug_analysis")
@patch.object(triage, "update_comment")
@patch.object(
    triage,
    "start_copilot_fork_task",
    return_value={"started": False, "job": {"id": "a" * 64}},
)
@patch.object(triage, "post_comment")
@patch.object(triage, "get_issue_comments")
@patch.object(triage, "_ensure_issue_not_sensitive")
@patch.object(triage, "_require_fix_workflow")
def test_powershell_dispatch_retries_existing_pending_state(
    _require, _sensitive, comments, post, assign, update, finalize,
):
    comments.return_value = [{
        "id": 12,
        "user": {"login": LEGACY_AGENT_BOT_LOGIN},
        "body": f"{BODY}\n\n{BUG_ANALYSIS_DISPATCH_MARKER}",
    }]
    update.return_value = {"id": 12}

    result = triage.dispatch_powershell_copilot(
        "Azure", "azure-powershell", 30047, BODY, token="app-token",
    )

    assert result["dispatched"] is False
    post.assert_not_called()
    assign.assert_called_once_with(
        "Azure", "azure-powershell", 30047, BODY,
        "[Compute] Fix PowerShell", token="app-token",
    )
    assert BUG_ANALYSIS_MARKER in update.call_args.args[3]
    finalize.assert_called_once()


@patch("x_engineering_agent.tools.triage.analysis._finalize_bug_analysis")
@patch(
    "repository_tools.fixer.azure_powershell.triage.start_copilot_fork_task",
    return_value={"started": True, "job": {"id": "a" * 64}},
)
@patch.object(triage, "get_issue_comments")
@patch.object(triage, "_ensure_issue_not_sensitive")
@patch.object(triage, "_require_fix_workflow")
def test_powershell_dispatch_retries_finalization_after_completion(
    _require, _sensitive, comments, assign, finalize,
):
    comments.return_value = [{
        "id": 12,
        "user": {"login": LEGACY_AGENT_BOT_LOGIN},
        "body": f"{BODY}\n\n{BUG_ANALYSIS_MARKER}",
    }]

    result = triage.dispatch_powershell_copilot(
        "Azure", "azure-powershell", 30047, BODY, token="app-token",
    )

    assert result["dispatched"]
    assert not result["skipped"]
    assign.assert_called_once_with(
        "Azure", "azure-powershell", 30047, BODY,
        "[Compute] Fix PowerShell", token="app-token",
    )
    finalize.assert_called_once_with(
        "Azure", "azure-powershell", 30047, token="app-token",
    )


@patch.object(triage, "_ensure_issue_not_sensitive")
@patch.object(triage, "_require_fix_workflow")
def test_powershell_dispatch_rejects_reserved_markers(_require, _sensitive):
    with pytest.raises(ValueError, match="reserved state marker"):
        triage.dispatch_powershell_copilot(
            "Azure",
            "azure-powershell",
            30047,
            f"{BODY}\n{BUG_ANALYSIS_DISPATCH_MARKER}",
            token="app-token",
        )
