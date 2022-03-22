// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a LogsSiteSlotConfig along with the instance operations that can be performed on it. </summary>
    public partial class LogsSiteSlotConfig : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="LogsSiteSlotConfig"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _logsSiteSlotConfigWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _logsSiteSlotConfigWebAppsRestClient;
        private readonly SiteLogsConfigData _data;

        /// <summary> Initializes a new instance of the <see cref="LogsSiteSlotConfig"/> class for mocking. </summary>
        protected LogsSiteSlotConfig()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "LogsSiteSlotConfig"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal LogsSiteSlotConfig(ArmClient client, SiteLogsConfigData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="LogsSiteSlotConfig"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal LogsSiteSlotConfig(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _logsSiteSlotConfigWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string logsSiteSlotConfigWebAppsApiVersion);
            _logsSiteSlotConfigWebAppsRestClient = new WebAppsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, logsSiteSlotConfigWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/slots/config";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SiteLogsConfigData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Gets the logging configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs
        /// Operation Id: WebApps_GetDiagnosticLogsConfigurationSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LogsSiteSlotConfig>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _logsSiteSlotConfigWebAppsClientDiagnostics.CreateScope("LogsSiteSlotConfig.Get");
            scope.Start();
            try
            {
                var response = await _logsSiteSlotConfigWebAppsRestClient.GetDiagnosticLogsConfigurationSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LogsSiteSlotConfig(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the logging configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs
        /// Operation Id: WebApps_GetDiagnosticLogsConfigurationSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LogsSiteSlotConfig> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _logsSiteSlotConfigWebAppsClientDiagnostics.CreateScope("LogsSiteSlotConfig.Get");
            scope.Start();
            try
            {
                var response = _logsSiteSlotConfigWebAppsRestClient.GetDiagnosticLogsConfigurationSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LogsSiteSlotConfig(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Updates the logging configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs
        /// Operation Id: WebApps_UpdateDiagnosticLogsConfigSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="siteLogsConfig"> A SiteLogsConfig JSON object that contains the logging configuration to change in the &quot;properties&quot; property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteLogsConfig"/> is null. </exception>
        public virtual async Task<ArmOperation<LogsSiteSlotConfig>> CreateOrUpdateAsync(WaitUntil waitUntil, SiteLogsConfigData siteLogsConfig, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteLogsConfig, nameof(siteLogsConfig));

            using var scope = _logsSiteSlotConfigWebAppsClientDiagnostics.CreateScope("LogsSiteSlotConfig.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _logsSiteSlotConfigWebAppsRestClient.UpdateDiagnosticLogsConfigSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteLogsConfig, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<LogsSiteSlotConfig>(Response.FromValue(new LogsSiteSlotConfig(Client, response), response.GetRawResponse()));
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
        /// Description for Updates the logging configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs
        /// Operation Id: WebApps_UpdateDiagnosticLogsConfigSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="siteLogsConfig"> A SiteLogsConfig JSON object that contains the logging configuration to change in the &quot;properties&quot; property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteLogsConfig"/> is null. </exception>
        public virtual ArmOperation<LogsSiteSlotConfig> CreateOrUpdate(WaitUntil waitUntil, SiteLogsConfigData siteLogsConfig, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteLogsConfig, nameof(siteLogsConfig));

            using var scope = _logsSiteSlotConfigWebAppsClientDiagnostics.CreateScope("LogsSiteSlotConfig.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _logsSiteSlotConfigWebAppsRestClient.UpdateDiagnosticLogsConfigSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteLogsConfig, cancellationToken);
                var operation = new AppServiceArmOperation<LogsSiteSlotConfig>(Response.FromValue(new LogsSiteSlotConfig(Client, response), response.GetRawResponse()));
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
    }
}
