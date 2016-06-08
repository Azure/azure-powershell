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

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    public abstract partial class RdsCmdlet
    {
        protected const string NameValidatorStringWithWildCards = @"^[?*A-Za-z0-9\u007F-\uFFFF]{1,13}$";

        protected const string NameValidatorString = @"^[A-Za-z][A-Za-z0-9\u007F-\uFFFF]{2,12}$";

        protected const string VNetNameValidatorStringWithWildCards = @"^[?*A-Za-z][?*-A-Za-z0-9]{3,49}(?<!-)$";

        protected const string VNetNameValidatorString = @"^[A-Za-z][-A-Za-z0-9]{3,49}(?<!-)$";

        protected const string DomainNameValidatorString = @"[^,~:@#$%\^&'.(){}_\s]+([.][^,~:@#$%\^&'.(){}_\s]+)+";

        protected const string UserNameValidatorString = @"[^@\""/\[\]:;|=,+*?<>\s]+";

        protected const string UserPrincipalValdatorString = UserNameValidatorString + "@" + DomainNameValidatorString;

        protected const string ListTemplateImageNameValidatorString = @"^[()A-Za-z][() ._\-A-Za-z0-9]{1,61}[A-Z-a-z0-9()]$";

        protected const string TemplateImageNameValidatorString = @"^[A-Za-z][ ._\-A-Za-z0-9]{1,61}[A-Z-a-z0-9]$";

        protected const string IPv4ValidatorString = @"^(?:(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.){3}(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])$";

        protected const string IPv6ValidatorString = @"(?<![:.\w])(?:[A-F0-9]{1,4}:){7}[A-F0-9]{1,4}(?![:.\w])";

        protected const string IPv4CIDR = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])(\/(\d|[1-2]\d|3[0-2]))$";

        protected const string IPv6CIDR = @"^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))\s*(\/(1[01][0-9]|12[0-8]|[0-9]{1,2}))$";

        // uppercase key code, must begin with a letter, then letters, numbers, and hyphens, for e.g. STREET or DC-9
        protected const string keyRegexPattern = @"[A-Z][A-Z0-9\-]*";

        // explicit key name for OU element
        protected const string ouKeyRegexPattern = @"OU";

        // used to separate entities, , or + followed by 0 or more spaces
        protected const string delimiterRegexPattern = @"[\+,]\s*";

        // an entity value, consists of characters other than , <CR> < > " # ; + =
        protected const string entityRegexPattern = @"([^,<>""#;+=\r\n])+";

        // a key/entity pair, e.g DC=foo-bar.com
        protected const string keyEntityRegexPattern = @"(" + keyRegexPattern + @"=" + entityRegexPattern + @")";

        // an OU key/entity pair, e.g OU=MyOu, but only matches an OU entity
        protected const string ouKeyEntityRegexPattern = @"(" + ouKeyRegexPattern + @"=" + entityRegexPattern + @")";

        protected const string OrgIDValidatorString = @"^(" + keyEntityRegexPattern + @"[\+,]\s*)*" + ouKeyEntityRegexPattern + @"([\+,]\s*" + keyEntityRegexPattern + @")*$";

        /* OrganizationalUnit in DN format: OU=MyOu, CN=MyDomain, CN=Com
         * 
         * The following pattern is designed to accept an RFC 4514 compliant distinguished name wich contains at least 1 OU element
         * e.g OU=MyOu, CN=MyDomain, CN=Com
         * 
         * The pattern can be broken down into 3 main components
         * 
         * The first component is 0 or more entities that are not OU entities, followed by a + or + delimiter
         *  ^(
         *      (
         * The entity begins with a key which must begin with a letter and contains letters, digits, or hyphens
         *          [A-Z][A-Z0-9\-]*=
         *          (
         * The entity value contains one or more characters except for the special chars , \ <CR> = < > " # ; or +
         *              [^,<>""#;\+=\r\n]
         * There will be 1 or more characters matching this pattern
         *          )+
         * Followed by a delimeter, either , or +
         *      [\+,]\s*
         * There may be 0 or more entities matching this pattern
         *  )*
         * 
         * The second part or the pattern must match an OU entity
         * This is identical to the first part, except it must only match the OU entity key
         * and does not include a delimiter.  If present, a trailing delimiter is matched by the preceding part of the pattern
         *  (
         * The entity key must match OU exactly.  This guarantees the overall pattern contains at least oen OU element
         *      OU=
         *      (
         * The entity value contains one or more characters except for the special chars , \ <CR> = < > " # ; or +
         *              [^,<>""#;\+=\r\n]
         * There will be 1 or more characters matching this pattern
         *      )+
         *  )
         * 
         * The final component of the pattern matches 0 or more additional elements, almost identical to the 
         * first component of the pattern, except the delimeters are now leading
         *  (
         * This compoennt of the pattern begins with a , or + delimiter
         *      [\+,]\s*
         *      (
         * The entity begins with a key which must begin with a  letter and contains letters, digits, or hyphens
         *          [A-Z][A-Z0-9\-]*=
         *          (
         * The entity value contains one or more characters except for the special chars , \ <CR> = < > " # ; or +
         *              [^,<>""#;\+=\r\n]
         * There will be 1 or more characters matching this pattern
         *          )+
         *      )
         * There may be 0 or more entities matching this pattern, and then the end of the string
         *  )*$
         * 
         */

        protected const string FullYearPattern = @"^(19|20)\d\d$";

        protected const string TwoDigitMonthPattern = @"^(0[1-9]|1[0-2])$";
    }
}