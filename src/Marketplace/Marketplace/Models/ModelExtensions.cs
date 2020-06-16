// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Marketplace.Models
{
    using Microsoft.Azure.Commands.Marketplace.Models.PrivateStore;
    using Microsoft.Azure.Management.Marketplace.Models;

    public static class ModelExtensions
    {
        public static PSPrivateStore ToPSPrivateStore(this Management.Marketplace.Models.PrivateStore ps)
        {
            return new PSPrivateStore
            {
                Availability = ps.Availability,
                ETag = ps.ETag,
                Id = ps.Id,
                Name = ps.Name,
                PrivateStoreId = ps.PrivateStoreId,
                Type = ps.Type
            };
        }

        public static PSPrivateStoreOffer ToPSPrivateStoreOffer(this Offer psf)
        {
            return new PSPrivateStoreOffer
            {
                Id = psf.Id,
                Name = psf.Name,
                Type = psf.Type,
                PrivateStoreId = psf.PrivateStoreId,
                ETag = psf.ETag,
                CreatedBy = psf.CreatedBy,
                CreatedDate = psf.CreatedDate,
                OfferDisplayName = psf.OfferDisplayName,
                PublisherDisplayName = psf.PublisherDisplayName,
                SpecificPlanIdsLimitation = psf.SpecificPlanIdsLimitation,
                UniqueOfferId = psf.UniqueOfferId
            };
        }
    }
}
