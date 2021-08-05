using System;
using System.Collections.Generic;

namespace Query.IntegrationTests
{
    public static class TestAsset
    {
        public static Guid SegmentId { get; set; }
        public static Guid PanelId { get; set; }
        public static Guid AreaId { get; set; }

        public static List<Guid> readerIds = new List<Guid>();
        public static List<Guid> panelIds = new List<Guid>();
        public static List<Guid> biometricReaderIds = new List<Guid>();
        public static List<Guid> accessLevelIds = new List<Guid>();
        public static Guid TimezoneId { get; set; }
        public static Guid CardholderId { get; set; }


    }
}
