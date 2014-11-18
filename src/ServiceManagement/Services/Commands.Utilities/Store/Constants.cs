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

using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Utilities.Store
{
    public class StoreConstants
    {
        //
        // Non-Microsoft Providers
        //
        public static HashSet<Guid> NonMicrosoftProviderIds = new HashSet<Guid>() { 
             new Guid("e110fba1-0c8a-45a4-b64e-0bebb3fcb85e"),
             new Guid("e768350e-c209-49a9-8bb8-ae17fb5c385c"),
             new Guid("b5e616d3-34f4-4ebe-a02d-c56a62a4a2f2"),
             new Guid("059afc24-07de-4126-b004-4e42a51816fe"),
             new Guid("92a1dc5a-1115-4a2c-b56d-19653801105d"),
             new Guid("5443b7fb-4b02-4735-b71e-193621b50f9a"),
             new Guid("059afc24-07de-4126-b004-4e42a51816fe"),
             new Guid("e6660c79-4b33-45f9-9254-1d7f7d2b6000"),
             new Guid("1a3087ba-2878-4315-a4fd-e63d4d24d2a2"),
             new Guid("0eea7a6a-7c54-421e-aed9-46a3ffffead1"),
             new Guid("03a65029-6919-46d7-a899-d0e40cfe575e"),
             new Guid("d7c05a21-94e6-4a05-939c-bfd0f5499e6e"),
             new Guid("2ccb99d2-1c71-46e3-9d81-f5465b0ccbea"),
             new Guid("723138c2-0676-4bf6-80d4-0af31479dac4"),
             new Guid("2f4108db-8ecb-473c-833e-589f5a1c234b"),
             new Guid("1a3087ba-2878-4315-a4fd-e63d4d24d2a2"),
             new Guid("1c1fc291-5f02-463a-9967-8591442ab653"),
             new Guid("e6660c79-4b33-45f9-9254-1d7f7d2b6000"),
             new Guid("1441f7f7-33a1-4dcf-aeea-8ed8bc1b2e3d"),
             new Guid("4880c467-1dfd-4e16-bd09-ebea6924cd29"),
             new Guid("c1cad069-086c-42e4-9e01-de8a1eab75e2"),
             new Guid("3a9a3dff-5d25-4a4e-850f-559f0bc8f706"),
             new Guid("385dbf8e-3c0c-4b62-b425-7f01b19c9764"),
             new Guid("95dc44c2-7516-480b-9246-a636fcdb9bb5"),
             new Guid("d79f5602-33a6-4538-9376-d1ca9c2b4521"),
             new Guid("da8888b8-2418-499b-9c0e-38d328f9a0b2"),
             new Guid("d653a682-cba2-456a-87b2-e9f01db09078"),
             new Guid("7fdf958a-4bec-4904-aa89-42d678ebfc38")
        };

        //
        // Microsoft Providers
        //
        public static HashSet<Guid> MicrosoftProviderIds = new HashSet<Guid>() { 
            // Bing
             new Guid("f8ede0df-591f-4722-b646-e5eb86f0ae52"),
 
            // Microsoft
            new Guid("43e059fd-14ba-4297-939f-d428bbc74d0a"),
 
            // Microsoft Research
            new Guid("b5e616d3-34f4-4ebe-a02d-c56a62a4a2f2"),
 
            // Microsoft Translator
            new Guid("059afc24-07de-4126-b004-4e42a51816fe"),

            // MetricsHub
            new Guid("2f4108db-8ecb-473c-833e-589f5a1c234b")
        };
    }
}
