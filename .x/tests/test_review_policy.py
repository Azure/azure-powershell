# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Deterministic review policy this package contributes for Azure/azure-powershell."""

import importlib
import sys
import types
from pathlib import Path

PACKAGE = Path(__file__).resolve().parents[1]
TOOLS = PACKAGE / "tools"
module = sys.modules.get("repository_tools")
if module is None:
    module = types.ModuleType("repository_tools")
    module.__path__ = [str(TOOLS)]
    sys.modules["repository_tools"] = module
elif str(TOOLS) not in module.__path__:
    module.__path__.append(str(TOOLS))

analysis = importlib.import_module("repository_tools.reviewer.policy.analysis")

REPOSITORY = "Azure/azure-powershell"


def _change(filename, patch=""):
    additions = sum(1 for line in patch.splitlines() if line.startswith("+") and not line.startswith("+++"))
    return {"filename": filename, "patch": patch, "additions": additions, "deletions": 0}


def _assert_release_artifact_blocks(changes, production, summary):
    findings, target = analysis._release_artifact_check(
        REPOSITORY, {"title": "Fix ssh port"}, changes, production, "fork/repo", "abc123",
    )

    assert any(summary in finding["summary"] for finding in findings)
    assert all(finding["severity"] == "blocking" and finding["tool"] == "release-artifact"
               for finding in findings)
    assert target["tool"] == "release-artifact"
    assert findings[0]["url"].startswith("https://github.com/fork/repo/blob/abc123/")


def test_generated_changelog_must_not_be_edited():
    changelog = _change(
        "src/Accounts/ChangeLog.md",
        "@@ -1,2 +1,3 @@\n <!-- This file is auto-generated. Do not edit. -->\n+* Manual entry\n",
    )

    _assert_release_artifact_blocks([changelog], [], "generated and must not be edited")
