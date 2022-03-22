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
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    /// <summary> A class representing collection of CdnCustomDomain and their operations over its parent. </summary>
    public partial class CdnCustomDomainCollection : ArmCollection, IEnumerable<CdnCustomDomain>, IAsyncEnumerable<CdnCustomDomain>
    {
        private readonly ClientDiagnostics _cdnCustomDomainClientDiagnostics;
        private readonly CdnCustomDomainsRestOperations _cdnCustomDomainRestClient;

        /// <summary> Initializes a new instance of the <see cref="CdnCustomDomainCollection"/> class for mocking. </summary>
        protected CdnCustomDomainCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CdnCustomDomainCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal CdnCustomDomainCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _cdnCustomDomainClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Cdn", CdnCustomDomain.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(CdnCustomDomain.ResourceType, out string cdnCustomDomainApiVersion);
            _cdnCustomDomainRestClient = new CdnCustomDomainsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, cdnCustomDomainApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != CdnEndpoint.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, CdnEndpoint.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new custom domain within an endpoint.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="customDomainProperties"> Properties required to create a new custom domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> or <paramref name="customDomainProperties"/> is null. </exception>
        public virtual async Task<ArmOperation<CdnCustomDomain>> CreateOrUpdateAsync(WaitUntil waitUntil, string customDomainName, CustomDomainOptions customDomainProperties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));
            Argument.AssertNotNull(customDomainProperties, nameof(customDomainProperties));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _cdnCustomDomainRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, customDomainProperties, cancellationToken).ConfigureAwait(false);
                var operation = new CdnArmOperation<CdnCustomDomain>(new CdnCustomDomainOperationSource(Client), _cdnCustomDomainClientDiagnostics, Pipeline, _cdnCustomDomainRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, customDomainProperties).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a new custom domain within an endpoint.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="customDomainProperties"> Properties required to create a new custom domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> or <paramref name="customDomainProperties"/> is null. </exception>
        public virtual ArmOperation<CdnCustomDomain> CreateOrUpdate(WaitUntil waitUntil, string customDomainName, CustomDomainOptions customDomainProperties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));
            Argument.AssertNotNull(customDomainProperties, nameof(customDomainProperties));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _cdnCustomDomainRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, customDomainProperties, cancellationToken);
                var operation = new CdnArmOperation<CdnCustomDomain>(new CdnCustomDomainOperationSource(Client), _cdnCustomDomainClientDiagnostics, Pipeline, _cdnCustomDomainRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, customDomainProperties).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing custom domain within an endpoint.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Get
        /// </summary>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> is null. </exception>
        public virtual async Task<Response<CdnCustomDomain>> GetAsync(string customDomainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.Get");
            scope.Start();
            try
            {
                var response = await _cdnCustomDomainRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CdnCustomDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing custom domain within an endpoint.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Get
        /// </summary>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> is null. </exception>
        public virtual Response<CdnCustomDomain> Get(string customDomainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.Get");
            scope.Start();
            try
            {
                var response = _cdnCustomDomainRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CdnCustomDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the existing custom domains within an endpoint.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains
        /// Operation Id: CdnCustomDomains_ListByEndpoint
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CdnCustomDomain" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CdnCustomDomain> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CdnCustomDomain>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _cdnCustomDomainRestClient.ListByEndpointAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CdnCustomDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<CdnCustomDomain>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _cdnCustomDomainRestClient.ListByEndpointNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CdnCustomDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all of the existing custom domains within an endpoint.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains
        /// Operation Id: CdnCustomDomains_ListByEndpoint
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CdnCustomDomain" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CdnCustomDomain> GetAll(CancellationToken cancellationToken = default)
        {
            Page<CdnCustomDomain> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _cdnCustomDomainRestClient.ListByEndpoint(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CdnCustomDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<CdnCustomDomain> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _cdnCustomDomainRestClient.ListByEndpointNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CdnCustomDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Get
        /// </summary>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string customDomainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(customDomainName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Get
        /// </summary>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> is null. </exception>
        public virtual Response<bool> Exists(string customDomainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(customDomainName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Get
        /// </summary>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> is null. </exception>
        public virtual async Task<Response<CdnCustomDomain>> GetIfExistsAsync(string customDomainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _cdnCustomDomainRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<CdnCustomDomain>(null, response.GetRawResponse());
                return Response.FromValue(new CdnCustomDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}
        /// Operation Id: CdnCustomDomains_Get
        /// </summary>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> is null. </exception>
        public virtual Response<CdnCustomDomain> GetIfExists(string customDomainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));

            using var scope = _cdnCustomDomainClientDiagnostics.CreateScope("CdnCustomDomainCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _cdnCustomDomainRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<CdnCustomDomain>(null, response.GetRawResponse());
                return Response.FromValue(new CdnCustomDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<CdnCustomDomain> IEnumerable<CdnCustomDomain>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CdnCustomDomain> IAsyncEnumerable<CdnCustomDomain>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
