# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Run this package's engine hooks through the X Engineering Agent broker."""

from pathlib import Path

import pytest

from x_engineering_agent.repository import testing

REPOSITORY = "Azure/azure-powershell"
PACKAGE = Path(__file__).resolve().parents[1]


@pytest.fixture(autouse=True)
def pinned(monkeypatch, tmp_path):
    testing.pin(monkeypatch, tmp_path, testing.local(PACKAGE, REPOSITORY))


def hook(name, *args, **kwargs):
    return testing.hook(REPOSITORY, name, *args, **kwargs)


def test_titles_use_powershell_style():
    assert hook("pr_title", component="Compute", summary="Fix Get-AzVM") == "[Compute] Fix Get-AzVM"
    assert "azure-powershell" in hook("pr_format_guidance", component="Compute")


def test_codegen_guidance_names_the_module():
    assert "`src/Compute/`" in hook("codegen_guidance", "Compute")


def test_live_tests_select_service_test_projects():
    files = ["src/Compute/Compute.Test/ScenarioTests/VirtualMachineTests.ps1", "src/Compute/Compute/Cmdlet.cs"]
    assert hook("changed_test_files", files) == files[:1]
    assert hook("live_test_plan", files)["runnable"] == files[:1]
    assert hook("live_test_plan", files[1:])["skipped_reason"]


def test_title_failure_plan_repairs_without_writing():
    plan = hook("title_failure_plan", {"title": "fix vm", "body": ""}, [], component="Compute")
    assert plan["title"].startswith("[Compute]")
    assert plan["title_updated"] is True


def test_readiness_is_ownership_only():
    pr = {"body": "", "head": {"sha": "a" * 40, "repo": {"full_name": "fork/azure-powershell"}}}
    changes = [{"filename": "src/Compute/Compute/Cmdlet.cs", "status": "modified", "patch": "+x"}]
    assert hook("readiness_policy", pr, changes) == {"blocked": None, "validation_required": False}


def test_definitions_reference_existing_engine_helpers_and_tools():
    assert testing.definition_problems(testing.local(PACKAGE, REPOSITORY)) == []
