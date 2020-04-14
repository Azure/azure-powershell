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

namespace Microsoft.Azure.Commands.Cdn.Models.Profile
{
    public enum PSSkuName
    {
        Standard_Verizon,
        Premium_Verizon,
        Custom_Verizon,
        Standard_Akamai,
        Standard_Microsoft,
        Standard_ChinaCdn,
        Premium_ChinaCdn,
        Standard_955BandWidth_ChinaCdn,
        Standard_AvgBandWidth_ChinaCdn,
        StandardPlus_ChinaCdn,
        StandardPlus_955BandWidth_ChinaCdn,
        StandardPlus_AvgBandWidth_ChinaCdn,
    }
}