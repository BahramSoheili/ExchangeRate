using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Testing;
using FluentAssertions;
using Query.Api;
using QueryManagement.DeviceManager.Events.Pendings.Created;
using QueryManagement.DeviceManager.SearchObjects;
using Xunit;
using Xunit.Extensions.Ordering;

namespace Query.IntegrationTests.Area
{
    public class CreateAreaPendingFixture : ApiFixture<Startup>
    {
        public const string queryAddress = "Query.Api";
        public override string ApiUrl { get; } = QueryUrls.AreasUrl;

        public readonly Guid Id = Guid.NewGuid();
        public readonly AreaData Data = new AreaData()
        {
            areaName = "area1",
            areaType = AreaType.areaType0,
            devision = "HR",
            SegmentId = TestAsset.SegmentId,
            description = "this is test description"
        };
        public override async Task InitializeAsync()
        {
            // prepare event
            var @event = new AreaCreatedPending(
                Id,
                Data,
                true,
                DateTime.Now,
                DateTime.Now
            );

            // send meeting created event to internal event bus
            await Sut.PublishInternalEvent(@event);
        }
    }
}
