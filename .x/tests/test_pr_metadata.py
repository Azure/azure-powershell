# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""PR body rendered from a job report follows this repository's PR template."""

from pathlib import Path
from unittest.mock import patch

import pytest

from x_engineering_agent.config import repository_pr_conventions
from x_engineering_agent.repository import testing
from x_engineering_agent.tools.copilot import prepublication, publisher

PACKAGE = Path(__file__).resolve().parents[1]
TEMPLATE = Path(__file__).parent / "fixtures" / "pr_template.md"
REPORT = {
    "decision": "fix",
    "root_cause": "The pager stopped after the first page because next_link was ignored.",
    "reproduction": {"reproduced": True, "steps": "python -m pytest", "before_output": "AssertionError"},
    "change_summary": "Follow next_link until exhausted in the list command.",
    "alternatives": ["Raise the page size; rejected because the service caps it."],
    "tests_added": [],
    "tests_run": [{"command": "MODEL-CLAIMED-COMMAND", "result": "passed"}],
    "evidence_tests": [],
    "risks": ["Large subscriptions return more items than before."],
    "confidence": 0.8,
    "generated_code": {"present": False, "notes": ""},
}
RECEIPT = {
    "status": "passed",
    "test_evidence": {
        "kind": "new_test_fail_before_pass_after", "tests": ["tests/test_list.py::test_pages"],
        "fails_on_base": True,
    },
    "unit_tests": {"executed": 4, "skipped": 1},
    "playback_tests": {"status": "passed", "executed": 2},
    "lint": {"flake8": {"status": "passed"}, "pylint": {"status": "passed"}},
    "repository_ci_required": True,
}

REPOSITORY = "Azure/azure-powershell"
TITLE = "[Network] Fix Get-AzVirtualNetwork paging"
FILES = ["src/Network/Network/VirtualNetwork/GetAzureVirtualNetwork.cs"]
TICKED = []
UNTICKED = ["General release", "No need for a release", "Check this box to confirm"]
MUTATIONS = [
    (lambda body: "\n".join(line for line in body.splitlines() if "No need for a release" not in line),
     "No need for a release"),
    (lambda body: body.replace("- [ ] [General release]", "- [x] [General release]"), "ticked without"),
]


@pytest.fixture(autouse=True)
def pinned(monkeypatch, tmp_path):
    testing.pin(monkeypatch, tmp_path, testing.local(PACKAGE, REPOSITORY))


def _job():
    return {
        "id": "a" * 64, "repository": REPOSITORY, "issue_number": 7, "source_kind": "issue",
        "title": TITLE, "base_branch": "main",
        "artifact": {"files": [{"path": path} for path in FILES]},
        "prompt": "Trusted analysis.", "report": REPORT,
        "validation": {"status": "passed", "commands": 2, "reports": [RECEIPT]},
        "prepublication": {"status": "passed", "checks": [
            {"gate": gate, "status": "passed"} for gate in prepublication.CANDIDATE_GATES
        ]},
    }


def _render(job):
    client = publisher.GitHubPublisher(token="t", login="a0x1ab", label_token="l")
    with patch.object(client, "_pr_template", return_value=TEMPLATE.read_text(encoding="utf-8")):
        return client._body(job, "base-sha")


def _line(body, text):
    return next(line for line in body.splitlines() if text.casefold() in line.casefold())


def test_rendered_body_follows_template_and_passes_gates():
    job = _job()
    body = _render(job)
    record = prepublication.evaluate_metadata(job, body=body)
    assert record["status"] == "passed", record["findings"]
    sections = prepublication.template_sections(body)
    for section in repository_pr_conventions(REPOSITORY)["sections"]:
        assert prepublication.heading_key(f"## {section['name']}") in sections
    assert f"Fixes https://github.com/{REPOSITORY}/issues/7." in body
    assert "**Root cause:** The pager stopped" in body
    assert "**Fix:** Follow next_link" in body
    for text in TICKED:
        assert "[x]" in _line(body, text)
    for text in UNTICKED:
        assert "[ ]" in _line(body, text)
    assert sum(ticked for ticked, _ in prepublication.checkboxes(body)) == len(TICKED)


@pytest.mark.parametrize(("mutate", "summary"), MUTATIONS)
def test_body_that_breaks_the_repository_template_is_blocked(mutate, summary):
    job = _job()
    record = prepublication.evaluate_metadata(job, body=mutate(_render(job)))
    assert record["status"] == "blocked"
    assert any(summary in item["summary"] for item in record["findings"]), record["findings"]
