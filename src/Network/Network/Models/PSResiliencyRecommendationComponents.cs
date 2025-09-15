// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSResiliencyRecommendationComponents : PSChildResource
    {
        public new string Name { get; set; }

        public string CurrentScore { get; set; }

        public string MaxScore { get; set; }

        public List<PSGatewayResiliencyRecommendation> Recommendations { get; set; }
    }
}
