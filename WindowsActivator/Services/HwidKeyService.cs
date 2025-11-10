using WindowsActivator.Models;

namespace WindowsActivator.Services
{
    public class HwidKeyService
    {
        private static List<HwidKeyInfo> _productKeys = new List<HwidKeyInfo>
        {
            new HwidKeyInfo {Edition = "Education", Key = "YNMGQ-8RYV3-4PGQ3-C8XTP-7CFBY", Ticket = "./Tickets/Education.xml"},

            new HwidKeyInfo {Edition = "Education N", Key = "84NGF-MHBT6-FXBX8-QWJK7-DRR8H", Ticket = $"./Tickets/Education N.xml"},

            new HwidKeyInfo {Edition = "Enterprise", Key = "XGVPP-NMH47-7TTHJ-W3FW7-8HV2C", Ticket = "./Tickets/Enterprise.xml"},

            new HwidKeyInfo {Edition = "Enterprise N", Key = "3V6Q6-NQXCX-V8YXR-9QCYV-QPFCT", Ticket = "./Tickets/Enterprise N.xml"},

            new HwidKeyInfo {Edition = "Enterprise LTSB 2015", Key = "FWN7H-PF93Q-4GGP8-M8RF3-MDWWW", Ticket = "./Tickets/Enterprise LTSB 2015.xml"},

            new HwidKeyInfo {Edition = "Enterprise LTSB 2016", Key = "NK96Y-D9CD8-W44CQ-R8YTK-DYJWX", Ticket = "./Tickets/Enterprise LTSB 2016.xml"},

            new HwidKeyInfo {Edition = "Enterprise LTSC 2019", Key = "43TBQ-NH92J-XKTM7-KT3KK-P39PB", Ticket = "./Tickets/Enterprise LTSC 2019.xml"},

            new HwidKeyInfo {Edition = "Enterprise N LTSB 2015", Key = "NTX6B-BRYC2-K6786-F6MVQ-M7V2X", Ticket = "./Tickets/Enterprise N LTSB 2015.xml"},

            new HwidKeyInfo {Edition = "Enterprise N LTSB 2016", Key = "2DBW3-N2PJG-MVHW3-G7TDK-9HKR4", Ticket = "./Tickets/Enterprise N LTSB 2016.xml"},

            new HwidKeyInfo {Edition = "Home", Key = "YTMG3-N6DKC-DKB77-7M9GH-8HVX7", Ticket = "./Tickets/Home.xml"},

            new HwidKeyInfo {Edition = "Home N", Key = "4CPRK-NM3K3-X6XXQ-RXX86-WXCHW", Ticket = "./Tickets/Home N.xml"},

            new HwidKeyInfo {Edition = "Home China", Key = "N2434-X9D7W-8PF6X-8DV9T-8TYMD", Ticket = "./Tickets/Home China.xml"},

            new HwidKeyInfo {Edition = "Home Single Language", Key = "BT79Q-G7N6G-PGBYW-4YWX6-6F4BT", Ticket = "./Tickets/Home Single Language.xml"},

            new HwidKeyInfo {Edition = "IoT Enterprise", Key = "XQQYW-NFFMW-XJPBH-K8732-CKFFD", Ticket = "./Tickets/IoT Enterprise.xml"},

            new HwidKeyInfo {Edition = "IoT Enterprise Subscription", Key = "P8Q7T-WNK7X-PMFXY-VXHBG-RRK69", Ticket = "./Tickets/IoT Enterprise Subscription.xml"},

            new HwidKeyInfo {Edition = "IoT Enterprise LTSC 2021", Key = "QPM6N-7J2WJ-P88HH-P3YRH-YY74H", Ticket = "./Tickets/IoT Enterprise LTSC 2021.xml"},

            new HwidKeyInfo {Edition = "IoT Enterprise LTSC 2024", Key = "CGK42-GYN6Y-VD22B-BX98W-J8JXD", Ticket = "./Tickets/IoT Enterprise LTSC 2024.xml"},

            new HwidKeyInfo {Edition = "IoT Enterprise LTSC Subscription 2024", Key = "N979K-XWD77-YW3GB-HBGH6-D32MH", Ticket = "./Tickets/IoT Enterprise LTSC Subscription 2024.xml"},

            new HwidKeyInfo {Edition = "Pro", Key = "VK7JG-NPHTM-C97JM-9MPGT-3V66T", Ticket = "./Tickets/Pro.xml"},
            new HwidKeyInfo {Edition = "Pro N", Key = "2B87N-8KFHP-DKV6R-Y2C8J-PKCKT", Ticket = "./Tickets/Pro N.xml"},

            new HwidKeyInfo {Edition = "Pro Education", Key = "8PTT6-RNW4C-6V7J2-C2D3X-MHBPB", Ticket = "./Tickets/Pro Education.xml"},

            new HwidKeyInfo {Edition = "Pro Education N", Key = "GJTYN-HDMQY-FRR76-HVGC7-QPF8P", Ticket = "./Tickets/Pro Education N.xml"},

            new HwidKeyInfo {Edition = "Pro for Workstations", Key = "DXG7C-N36C4-C4HTG-X4T3X-2YV77", Ticket = "./Tickets/Pro for Workstations.xml"},

            new HwidKeyInfo {Edition = "Pro N for Workstations", Key = "WYPNQ-8C467-V2W6J-TX4WX-WT2RQ", Ticket = "./Tickets/Pro N for Workstations.xml"},

            new HwidKeyInfo {Edition = "S", Key = "V3WVW-N2PV2-CGWC3-34QGF-VMJ2C", Ticket = "./Tickets/S.xml"},

            new HwidKeyInfo {Edition = "S N", Key = "NH9J3-68WK7-6FB93-4K3DF-DJ4F6", Ticket = "./Tickets/S N.xml"},

            new HwidKeyInfo {Edition = "SE", Key = "KY7PN-VR6RX-83W6Y-6DDYQ-T6R4W", Ticket = "./Tickets/SE.xml"},

            new HwidKeyInfo {Edition = "SE N", Key = "K9VKN-3BGWV-Y624W-MCRMQ-BHDCD", Ticket = "./Tickets/SE N.xml"},

            new HwidKeyInfo {Edition = "Team", Key = "XKCNC-J26Q9-KFHD2-FKTHY-KD72Y", Ticket = "./Tickets/Team.xml"},

        };

        // Get the full list
        public static List<HwidKeyInfo> GetAll() => _productKeys;

        // Find a specific edition
        public static HwidKeyInfo? GetByEdition(string edition)
        {
            return _productKeys.Find(p => p.Edition.Equals(edition, StringComparison.OrdinalIgnoreCase));
        }

        // Add a new one
        public static void Add(HwidKeyInfo item)
        {
            _productKeys.Add(item);
        }
    }
}
