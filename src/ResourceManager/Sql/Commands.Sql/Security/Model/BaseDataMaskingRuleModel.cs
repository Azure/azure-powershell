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

namespace Microsoft.Azure.Commands.Sql.Security.Model
{

    public enum MaskingFunction { Number, Text, CreditCardNumber, SocialSecurityNumber, Email, Default, NoMasking };

    public class BaseDataMaskingRuleModel
    {
        
        public string ResourceGroupName { get; set; }

        public string ServerName { get; set; }

        public string RuleId { get; set; }

        public string TableName { get; set; }
       
        public string ColumnName { get; set; }

        public string AliasName { get; set; }

        public MaskingFunction MaskingFunction { get; set; }

        public uint? PrefixSize { get; set; }

        public uint? SuffixSize { get; set; }

        public string ReplacementString { get; set; }

        public double? NumberFrom { get; set; }

        public double? NumberTo { get; set; }
    }
}