// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of TenantPolicySetDefinition and their operations over its parent. </summary>
    public partial class TenantPolicySetDefinitionCollection : ArmCollection, IEnumerable<TenantPolicySetDefinition>, IAsyncEnumerable<TenantPolicySetDefinition>
    {
        private readonly ClientDiagnostics _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics;
        private readonly PolicySetDefinitionsRestOperations _tenantPolicySetDefinitionPolicySetDefinitionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantPolicySetDefinitionCollection"/> class for mocking. </summary>
        protected TenantPolicySetDefinitionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantPolicySetDefinitionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TenantPolicySetDefinitionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", TenantPolicySetDefinition.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TenantPolicySetDefinition.ResourceType, out string tenantPolicySetDefinitionPolicySetDefinitionsApiVersion);
            _tenantPolicySetDefinitionPolicySetDefinitionsRestClient = new PolicySetDefinitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, tenantPolicySetDefinitionPolicySetDefinitionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Tenant.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Tenant.ResourceType), nameof(id));
        }

        /// <summary>
        /// This operation retrieves the built-in policy set definition with the given name.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetBuiltIn
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual async Task<Response<TenantPolicySetDefinition>> GetAsync(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.GetBuiltInAsync(policySetDefinitionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the built-in policy set definition with the given name.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetBuiltIn
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual Response<TenantPolicySetDefinition> Get(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.GetBuiltIn(policySetDefinitionName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves a list of all the built-in policy set definitions that match the optional given $filter. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all built-in policy set definitions whose category match the {value}.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions
        /// Operation Id: PolicySetDefinitions_ListBuiltIn
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantPolicySetDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantPolicySetDefinition> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantPolicySetDefinition>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.ListBuiltInAsync(filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantPolicySetDefinition>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.ListBuiltInNextPageAsync(nextLink, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// This operation retrieves a list of all the built-in policy set definitions that match the optional given $filter. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all built-in policy set definitions whose category match the {value}.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions
        /// Operation Id: PolicySetDefinitions_ListBuiltIn
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantPolicySetDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantPolicySetDefinition> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<TenantPolicySetDefinition> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.ListBuiltIn(filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantPolicySetDefinition> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.ListBuiltInNextPage(nextLink, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetBuiltIn
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(policySetDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetBuiltIn
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual Response<bool> Exists(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(policySetDefinitionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetBuiltIn
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual async Task<Response<TenantPolicySetDefinition>> GetIfExistsAsync(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.GetBuiltInAsync(policySetDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TenantPolicySetDefinition>(null, response.GetRawResponse());
                return Response.FromValue(new TenantPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetBuiltIn
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual Response<TenantPolicySetDefinition> GetIfExists(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _tenantPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("TenantPolicySetDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantPolicySetDefinitionPolicySetDefinitionsRestClient.GetBuiltIn(policySetDefinitionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TenantPolicySetDefinition>(null, response.GetRawResponse());
                return Response.FromValue(new TenantPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantPolicySetDefinition> IEnumerable<TenantPolicySetDefinition>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantPolicySetDefinition> IAsyncEnumerable<TenantPolicySetDefinition>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
