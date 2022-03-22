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
    /// <summary> A class representing collection of Application and their operations over its parent. </summary>
    public partial class ApplicationCollection : ArmCollection, IEnumerable<Application>, IAsyncEnumerable<Application>
    {
        private readonly ClientDiagnostics _applicationClientDiagnostics;
        private readonly ApplicationsRestOperations _applicationRestClient;

        /// <summary> Initializes a new instance of the <see cref="ApplicationCollection"/> class for mocking. </summary>
        protected ApplicationCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ApplicationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ApplicationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _applicationClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", Application.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(Application.ResourceType, out string applicationApiVersion);
            _applicationRestClient = new ApplicationsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, applicationApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="parameters"> Parameters supplied to the create or update a managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<Application>> CreateOrUpdateAsync(WaitUntil waitUntil, string applicationName, ApplicationData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _applicationRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<Application>(new ApplicationOperationSource(Client), _applicationClientDiagnostics, Pipeline, _applicationRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, applicationName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a new managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="parameters"> Parameters supplied to the create or update a managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<Application> CreateOrUpdate(WaitUntil waitUntil, string applicationName, ApplicationData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _applicationRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, applicationName, parameters, cancellationToken);
                var operation = new ResourcesArmOperation<Application>(new ApplicationOperationSource(Client), _applicationClientDiagnostics, Pipeline, _applicationRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, applicationName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual async Task<Response<Application>> GetAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.Get");
            scope.Start();
            try
            {
                var response = await _applicationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Application(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<Application> Get(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.Get");
            scope.Start();
            try
            {
                var response = _applicationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Application(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all the applications within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications
        /// Operation Id: Applications_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Application" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Application> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Application>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _applicationRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Application>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _applicationRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the applications within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications
        /// Operation Id: Applications_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Application" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Application> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Application> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _applicationRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Application> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _applicationRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(applicationName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<bool> Exists(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(applicationName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual async Task<Response<Application>> GetIfExistsAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _applicationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Application>(null, response.GetRawResponse());
                return Response.FromValue(new Application(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<Application> GetIfExists(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _applicationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Application>(null, response.GetRawResponse());
                return Response.FromValue(new Application(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Application> IEnumerable<Application>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Application> IAsyncEnumerable<Application>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
