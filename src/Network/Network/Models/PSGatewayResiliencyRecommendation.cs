// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSGatewayResiliencyRecommendation : PSChildResource
    {
        public string RecommendationTitle { get; set; }

        public string RecommendationId { get; set; }

        public string Severity { get; set; }

        public string RecommendationText { get; set; }

        public string CallToActionText { get; set; }

        public string CallToActionLink { get; set; }
    }
}
