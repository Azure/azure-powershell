using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test {
    public class RoleAssignmentUnitTests
    {
        private void VerifyInvalidScope(string scope, string error)
        {
            try
            {
                AuthorizationClient.ValidateScope(scope, false);
                Assert.True(false);
            }
            catch(ArgumentException ex)
            {
                Assert.Equal(ex.Message, error);
            }
        }

        private void VerifyValidScope(string scope) 
        {
            AuthorizationClient.ValidateScope(scope, false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyInvalidScopes()
        {
            Dictionary<string, string> scopeAndErrors = new Dictionary<string, string>();
            scopeAndErrors.Add("test", "Scope 'test' should begin with '/subscriptions' or '/providers'.");
            scopeAndErrors.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name", "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name' should begin with '/subscriptions/<subid>/resourceGroups'.");
            scopeAndErrors.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups", "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts.");
            scopeAndErrors.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/", "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/' should not have any empty part.");
            scopeAndErrors.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name", "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name' should begin with '/subscriptions/<subid>/resourceGroups/<groupname>/providers'.");
            scopeAndErrors.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername", "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername' should have at least one pair of resource type and resource name. e.g. '/subscriptions/<subid>/resourceGroups/<groupname>/providers/<providername>/<resourcetype>/<resourcename>'.");
            foreach (var kvp in scopeAndErrors)
            {
                VerifyInvalidScope(kvp.Key, kvp.Value);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyValidScopes() 
        {
            List<string> validScopes = new List<string>();
            validScopes.Add("/");
            validScopes.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab");
            validScopes.Add("/providers/providername");
            validScopes.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname");
            validScopes.Add("/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername/type/typename");

            foreach (var scope in validScopes) 
            {
                VerifyValidScope(scope);
            }

            // verify empty scope

            AuthorizationClient.ValidateScope(null, true);
        }
    }
}
