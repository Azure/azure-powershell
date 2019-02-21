﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Automation.Model.UpdateManagement
{
    public enum WindowsUpdateClasses
    {
        Unclassified = 0x00,
        Critical = 0x01,
        Security = 0x02,
        UpdateRollup = 0x04,
        FeaturePack = 0x08,
        ServicePack = 0x10,
        Definition = 0x20,
        Tools = 0x40,
        Updates = 0x80
    }
}
