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

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of ServerDnsAlias and their operations over its parent. </summary>
    public partial class ServerDnsAliasCollection : ArmCollection, IEnumerable<ServerDnsAlias>, IAsyncEnumerable<ServerDnsAlias>
    {
        private readonly ClientDiagnostics _serverDnsAliasClientDiagnostics;
        private readonly ServerDnsAliasesRestOperations _serverDnsAliasRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServerDnsAliasCollection"/> class for mocking. </summary>
        protected ServerDnsAliasCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServerDnsAliasCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServerDnsAliasCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverDnsAliasClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ServerDnsAlias.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ServerDnsAlias.ResourceType, out string serverDnsAliasApiVersion);
            _serverDnsAliasRestClient = new ServerDnsAliasesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, serverDnsAliasApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlServer.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlServer.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a server DNS alias.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual async Task<ArmOperation<ServerDnsAlias>> CreateOrUpdateAsync(WaitUntil waitUntil, string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _serverDnsAliasRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ServerDnsAlias>(new ServerDnsAliasOperationSource(Client), _serverDnsAliasClientDiagnostics, Pipeline, _serverDnsAliasRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a server DNS alias.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual ArmOperation<ServerDnsAlias> CreateOrUpdate(WaitUntil waitUntil, string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _serverDnsAliasRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName, cancellationToken);
                var operation = new SqlArmOperation<ServerDnsAlias>(new ServerDnsAliasOperationSource(Client), _serverDnsAliasClientDiagnostics, Pipeline, _serverDnsAliasRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a server DNS alias.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual async Task<Response<ServerDnsAlias>> GetAsync(string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.Get");
            scope.Start();
            try
            {
                var response = await _serverDnsAliasRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDnsAlias(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a server DNS alias.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual Response<ServerDnsAlias> Get(string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.Get");
            scope.Start();
            try
            {
                var response = _serverDnsAliasRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDnsAlias(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of server DNS aliases for a server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases
        /// Operation Id: ServerDnsAliases_ListByServer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServerDnsAlias" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServerDnsAlias> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ServerDnsAlias>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverDnsAliasRestClient.ListByServerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDnsAlias(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ServerDnsAlias>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverDnsAliasRestClient.ListByServerNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDnsAlias(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of server DNS aliases for a server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases
        /// Operation Id: ServerDnsAliases_ListByServer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServerDnsAlias" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServerDnsAlias> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ServerDnsAlias> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverDnsAliasRestClient.ListByServer(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDnsAlias(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ServerDnsAlias> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverDnsAliasRestClient.ListByServerNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDnsAlias(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(dnsAliasName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual Response<bool> Exists(string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(dnsAliasName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual async Task<Response<ServerDnsAlias>> GetIfExistsAsync(string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serverDnsAliasRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServerDnsAlias>(null, response.GetRawResponse());
                return Response.FromValue(new ServerDnsAlias(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="dnsAliasName"> The name of the server dns alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dnsAliasName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsAliasName"/> is null. </exception>
        public virtual Response<ServerDnsAlias> GetIfExists(string dnsAliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dnsAliasName, nameof(dnsAliasName));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serverDnsAliasRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dnsAliasName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServerDnsAlias>(null, response.GetRawResponse());
                return Response.FromValue(new ServerDnsAlias(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ServerDnsAlias> IEnumerable<ServerDnsAlias>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServerDnsAlias> IAsyncEnumerable<ServerDnsAlias>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
