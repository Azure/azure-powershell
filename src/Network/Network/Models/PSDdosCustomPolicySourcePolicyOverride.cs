// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSDdosCustomPolicySourcePolicyOverride
    {
        public PSDdosCustomPolicySourcePolicyAction PolicyAction { get; set; }

        public PSDdosCustomPolicySourceMatchConditions Conditions { get; set; }
    }

    public class PSDdosCustomPolicySourcePolicyAction
    {
        public string ActionType { get; set; }
    }

    public class PSDdosCustomPolicySourceMatchConditions
    {
        public List<string> IpPrefixes { get; set; }

        public List<PSDdosCustomPolicyGeoMatch> GeoMatches { get; set; }
    }
}
