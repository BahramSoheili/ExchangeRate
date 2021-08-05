using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Extensions.Ordering;

namespace Query.IntegrationTests.Area
{   
    [Order(0)]
    public class CreateAreaPendingTests : IClassFixture<CreateAreaPendingFixture>
    {
        private readonly CreateAreaPendingFixture fixture;
        public CreateAreaPendingTests(CreateAreaPendingFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        [Trait("Category", "Exercise")]
        public async Task AreaCreated_ShouldUpdateReadModel()
        {
            //send query
            await Task.Delay(1000);
            var queryResponse = await fixture.Client.GetAsync($"{QueryUrls.AreasUrl}");
            queryResponse.EnsureSuccessStatusCode();
            var queryResult = await queryResponse.Content.ReadAsStringAsync();
            queryResult.Should().NotBeNull();
            var areas = queryResult.FromJson<IReadOnlyCollection<QueryManagement.DeviceManager.Area>>();
            areas.Should().Contain(area => area.Id == fixture.Id &&
            area.Data.areaName == fixture.Data.areaName &&
            area.Data.areaType == fixture.Data.areaType &&
            area.Data.devision == fixture.Data.devision &&
            area.Data.SegmentId == fixture.Data.SegmentId &&
            area.Data.description == fixture.Data.description);
        }
    }
}
