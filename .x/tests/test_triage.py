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
from x_engineering_agent.repository import testing


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


REPOSITORY = "Azure/azure-powershell"
BODY = "Trusted analysis\n\n**Suggested PR title:** `[Compute] Fix PowerShell`"
TITLE = "[Compute] Fix PowerShell"
ANALYSIS = {
    "summary": (
        "`New-AzVM -SecurityType TrustedLaunch` ignores `-EnableSecureBoot` "
        "and creates the VM with secure boot disabled."
    ),
    "affected_code": [{
        "path": "src/Compute/Compute/VirtualMachine/Operation/NewAzureVMCommand.cs",
        "symbol": "NewAzureVMCommand.ExecuteCmdlet",
    }],
    "root_cause": {
        "hypothesis": (
            "In the simple parameter set ExecuteCmdlet builds SecurityProfile "
            "before EnableSecureBoot is read, so the flag is never applied."
        ),
        "evidence": [
            "NewAzureVMCommand.ExecuteCmdlet sets UefiSettings only in the "
            "default parameter set branch.",
        ],
    },
    "ruled_out": {
        "configuration": "The VM size in the issue supports Trusted Launch.",
        "environment": "Reproduces with Az.Compute 7.1.0 on PowerShell 7.4.",
        "by_design": "The cmdlet help documents -EnableSecureBoot for this parameter set.",
    },
    "proposed_change": (
        "Apply EnableSecureBoot and EnableVtpm to UefiSettings in the simple "
        "parameter set branch."
    ),
    "test_plan": "Extend the Trusted Launch scenario test; a new recording is needed.",
    "confidence": 0.6,
    "generated_code": {
        "classification": "handwritten",
        "evidence": "Az.Compute cmdlets are handwritten SDK-based code, not AutoRest output.",
    },
}


@pytest.fixture(autouse=True)
def pinned(monkeypatch, tmp_path):
    testing.pin(monkeypatch, tmp_path, testing.local(PACKAGE, REPOSITORY))


def _dispatch():
    return triage.dispatch_powershell_copilot(
        "Azure", "azure-powershell", 30047, analysis=ANALYSIS, pr_title=TITLE, token="app-token",
    )


def _assert_assigned(assign):
    assign.assert_called_once()
    args, kwargs = assign.call_args
    assert args[:3] == ("Azure", "azure-powershell", 30047)
    assert "NewAzureVMCommand.ExecuteCmdlet" in args[3]
    assert args[4] == TITLE
    assert kwargs == {"token": "app-token"}


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

    result = _dispatch()

    assert result["dispatched"]
    _assert_assigned(assign)
    public = post.call_args.args[3]
    assert "NewAzureVMCommand.ExecuteCmdlet" in public
    assert TITLE not in public
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
        _dispatch()

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

    result = _dispatch()

    assert result["dispatched"] is False
    post.assert_not_called()
    _assert_assigned(assign)
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

    result = _dispatch()

    assert result["dispatched"]
    assert not result["skipped"]
    _assert_assigned(assign)
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
