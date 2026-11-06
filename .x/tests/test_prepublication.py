# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Pre-publication gates this package's hooks contribute for Azure/azure-powershell."""

from pathlib import Path

import pytest

from x_engineering_agent.repository import testing
from x_engineering_agent.tools.copilot import prepublication

REPOSITORY = "Azure/azure-powershell"
PACKAGE = Path(__file__).resolve().parents[1]
VALIDATION = {"status": "passed", "reports": [{"status": "passed"}]}
_CMDLET = "src/Network/Network/Cmdlets/GetThing.cs"
_LOG = "src/Network/Network/ChangeLog.md"
_BASE = {_CMDLET: "class A {}\n", _LOG: "## Upcoming Release\n\n## Version 1.0.0\n* Old\n"}
_CMDLET_HEAD = "[Cmdlet(VerbsCommon.Get, \"Thing\")]\nclass A {}\n"


@pytest.fixture(autouse=True)
def pinned(monkeypatch, tmp_path):
    testing.pin(monkeypatch, tmp_path, testing.local(PACKAGE, REPOSITORY))


def _job(title="[Network] Add Get-Thing"):
    return {"id": "a" * 64, "repository": REPOSITORY, "title": title,
            "base_branch": "main", "source_kind": "issue"}


def _evaluate(base, head):
    return prepublication.evaluate_candidate(_job(), base, head, read_file=head.get, validation=VALIDATION)


def _status(record, gate):
    return next(item["status"] for item in record["checks"] if item["gate"] == gate)


@pytest.mark.parametrize(("log", "expected"), [
    ("## Upcoming Release\n\n## Version 1.0.0\n* Old\n* New\n", "blocked"),
    ("## Upcoming Release\n* New\n\n## Version 1.0.0\n* Old\n", "passed"),
], ids=["changelog-misplaced", "changelog-upcoming"])
def test_release_artifact_gate(log, expected):
    record = _evaluate(_BASE, {_CMDLET: _CMDLET_HEAD, _LOG: log})
    assert _status(record, "release-artifact") == expected


def test_placeholder_cmdlet_help_is_blocked():
    path = "src/Network/Network/help/Get-Thing.md"
    record = _evaluate({path: "# Get-Thing\n"}, {path: "# Get-Thing\n{{ Fill in the Synopsis }}\n"})
    assert any(item["gate"] == "command-help" for item in record["findings"])


def test_valid_powershell_title_passes():
    record = prepublication.evaluate_metadata(_job("[Network] Fix Get-AzVirtualNetwork paging"))
    assert record["status"] == "passed", record["findings"]


PS_SRC = "src/Communication/Communication.Autorest"
PS_GEN = "generated/Communication/Communication.Autorest"
INFO_BASE = '{"generate_Id": "11111111-1111-1111-1111-111111111111"}\n'
INFO_HEAD = '{"generate_Id": "22222222-2222-2222-2222-222222222222"}\n'
_PS_MODEL = f"{PS_GEN}/generated/api/Models/Thing.cs"
_PS_EXPORT = f"{PS_GEN}/exports/New-AzThing.ps1"
_PS_INFO = (f"{PS_SRC}/generate-info.json", f"{PS_GEN}/generate-info.json")
_PS_REGEN_BASE = {_PS_EXPORT: "a\n", **dict.fromkeys(_PS_INFO, INFO_BASE)}
_PS_REGEN_HEAD = {_PS_EXPORT: "b\n", **dict.fromkeys(_PS_INFO, INFO_HEAD)}
_PS_README = f"{PS_SRC}/README.md"


@pytest.mark.parametrize(("base", "head", "status", "problem"), [
    ({_PS_MODEL: "class A {}\n"}, {_PS_MODEL: "class A { int X; }\n"}, "blocked", "directive"),
    (_PS_REGEN_BASE, _PS_REGEN_HEAD, "blocked", "README.md"),
    ({**_PS_REGEN_BASE, _PS_README: "# x\n"},
     {**_PS_REGEN_HEAD, _PS_README: "# x\ndirective:\n  - where: {parameter-name: Foo}\n"}, "passed", None),
], ids=["ps-generated-hand-edit", "ps-regen-without-source", "ps-regen-with-directive"])
def test_generated_ownership_gate(base, head, status, problem):
    changes = prepublication.changes_from_contents(base, head)
    result, findings = prepublication.generated_ownership_gate(REPOSITORY, _job(), changes, base, head)

    assert result == status
    if status == "passed":
        assert findings == []
    if problem:
        assert any(problem in item["summary"] or problem in item["remediation"] for item in findings), findings
