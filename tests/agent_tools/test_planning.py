"""Standalone regressions for the repository-owned pure planning hooks."""

import ast
from pathlib import Path
import re
from unittest.mock import Mock

import yaml


ROOT = Path(__file__).resolve().parents[2] / ".x"
REPOSITORY = yaml.safe_load((ROOT / "x.yml").read_text())["repository"]
IS_PS = REPOSITORY == "Azure/azure-powershell"
DOMAIN = "azure_powershell" if IS_PS else "azure_cli"


def function(path, name, values=None):
    tree = ast.parse((ROOT / path).read_text())
    node = next(item for item in tree.body if isinstance(item, ast.FunctionDef) and item.name == name)
    namespace = dict(values or {})
    exec(compile(ast.Module([node], type_ignores=[]), str(ROOT / path), "exec"), namespace)
    return namespace[name]


def pattern(name):
    node = next(
        item for item in ast.parse((ROOT / "tools/settings.py").read_text()).body
        if isinstance(item, ast.Assign)
        and any(isinstance(target, ast.Name) and target.id == name for target in item.targets)
    )
    return eval(compile(ast.Expression(node.value), str(ROOT / "tools/settings.py"), "eval"), {"re": re})


def live_plan():
    path = f"tools/tester/{DOMAIN}/live_tests.py"
    if IS_PS:
        values = {"_PS_TEST_FILE_PATTERN": pattern("_PS_TEST_FILE_PATTERN")}
        values["changed_ps_test_files"] = function(path, "changed_ps_test_files", values)
    else:
        values = {"_TEST_FILE_PATTERN": pattern("_TEST_FILE_PATTERN")}
    return function(path, "_live_test_plan", values)


def test_live_selection_and_honest_skip_explanation():
    plan = live_plan()
    test = "src/Compute/Compute.Test/Scenario.cs" if IS_PS else "src/example/tests/test_regression.py"
    assert plan([test])["runnable"] == [test]
    assert plan([test])["skipped_reason"] is None
    skipped = plan(["src/example/custom.py"])
    assert skipped["runnable"] == []
    assert skipped["skipped_reason"]
    assert "Skipping" in skipped["comment"]
    assert plan(None)["runnable"] == []
    if not IS_PS:
        core = plan(["src/azure-cli-core/tests/test_util.py"])
        assert core["paths"]
        assert core["runnable"] == []
        assert "azure-cli-core" in core["skipped_reason"]
        assert "upstream" in core["comment"]


def test_live_target_keeps_explicit_target_and_repository_default():
    path = f"tools/fixer/{DOMAIN}/targets.py"
    resolver = Mock(return_value={"kind": "unknown", "name": None, "repo": None})
    values = {"infer_ps_target": resolver} if IS_PS else {
        "resolve_target": resolver, "infer_target": resolver,
    }
    plan = function(path, "_live_test_target", values)
    result = plan("text", [], module="example")
    default = "psmodule" if IS_PS else (
        "extension" if REPOSITORY.endswith("extensions") else "module"
    )
    assert result == {"module": "example", "target_kind": default}
    assert plan("text", [], module="example", target_kind="explicit")["target_kind"] == "explicit"
    if IS_PS:
        resolver.assert_not_called()


def test_metadata_plan_is_pure_and_only_returns_changed_fields():
    if REPOSITORY.endswith("extensions"):
        return
    repaired = Mock(return_value="Repaired title")
    values = {
        "repaired_pr_title": repaired,
        "expected_cli_title_component": Mock(return_value="Network"),
        "_repaired_cli_history_notes": Mock(return_value=("Repaired body", 1)),
    }
    plan = function("tools/fixer/title_gate/title_repair.py", "_failed_metadata_plan", values)
    result = plan({"title": "Original title", "body": "Original body"}, [])
    assert result["metadata"]["title"] == "Repaired title"
    assert result["title_updated"] is True
    assert result["history_notes_updated"] == (0 if IS_PS else 1)
    assert ("body" in result["metadata"]) is not IS_PS
    assert repaired.call_args.args[0] == REPOSITORY
