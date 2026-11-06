# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Validate this package's scheduled automation settings against the engine schema."""

from pathlib import Path

import yaml

from x_engineering_agent.automation import settings

REPOSITORY = "Azure/azure-powershell"
PACKAGE = Path(__file__).resolve().parents[1]


def test_automation_settings_are_valid():
    section = yaml.safe_load((PACKAGE / "x.yml").read_text())["automation"]
    parsed = settings.parse(REPOSITORY, section)
    assert parsed.pipelines and parsed.pruning_label and parsed.reopen
