using WindowsActivator.Models;

namespace WindowsActivator.Services
{
    public class Kms38GenericKeyService
    {
        private static List<Kms38GenericKeyModel> _genericKeys = new List<Kms38GenericKeyModel>()
        {
            new Kms38GenericKeyModel {Edition = "Education", GenericKey = "NW6C2-QMPVW-D7KKK-3GKT6-VCFB2"},
            new Kms38GenericKeyModel {Edition = "Education N", GenericKey = "2WH4N-8QGBV-H22JP-CT43Q-MDWWJ"},
            new Kms38GenericKeyModel {Edition = "Enterprise", GenericKey = "NPPR9-FWDCX-D2C8J-H872K-2YT43"},
            new Kms38GenericKeyModel {Edition = "Enterprise N", GenericKey = "DPH2V-TTNVB-4X9Q3-TJR4H-KHJW4"},
            new Kms38GenericKeyModel {Edition = "Enterprise G", GenericKey = "YYVX9-NTFWV-6MDM3-9PT4T-4M68B"},
            new Kms38GenericKeyModel {Edition = "Enterprise G N", GenericKey = "44RPN-FTY23-9VTTB-MP9BX-T84FV"},
            new Kms38GenericKeyModel {Edition = "Enterprise LTSB 2016", GenericKey = "DCPHK-NFMTC-H88MJ-PFHPY-QJ4BJ"},
            new Kms38GenericKeyModel {Edition = "Enterprise LTSC 2019", GenericKey = "M7XTQ-FN8P6-TTKYV-9D4CC-J462D"},
            new Kms38GenericKeyModel {Edition = "Enterprise LTSC 2021", GenericKey = "M7XTQ-FN8P6-TTKYV-9D4CC-J462D"},
            new Kms38GenericKeyModel {Edition = "Enterprise LTSC 2024", GenericKey = "M7XTQ-FN8P6-TTKYV-9D4CC-J462D"},
            new Kms38GenericKeyModel {Edition = "Enterprise N LTSB 2016", GenericKey = "QFFDN-GRT3P-VKWWX-X7T3R-8B639"},
            new Kms38GenericKeyModel {Edition = "Enterprise N LTSC 2019", GenericKey = "92NFX-8DJQP-P6BBQ-THF9C-7CG2H"},
            new Kms38GenericKeyModel {Edition = "Enterprise N LTSC 2021", GenericKey = "92NFX-8DJQP-P6BBQ-THF9C-7CG2H"},
            new Kms38GenericKeyModel {Edition = "Enterprise N LTSC 2024", GenericKey = "92NFX-8DJQP-P6BBQ-THF9C-7CG2H"},
            new Kms38GenericKeyModel {Edition = "IoT Enterprise LTSC 2021", GenericKey = "KBN8V-HFGQ4-MGXVD-347P6-PDQGT"},
            new Kms38GenericKeyModel {Edition = "IoT Enterprise LTSC 2024", GenericKey = "NW6C2-QMPVW-D7KKK-3GKT6-VCFB2"},
            new Kms38GenericKeyModel {Edition = "Home", GenericKey = "TX9XD-98N7V-6WMQ6-BX7FG-H8Q99"},
            new Kms38GenericKeyModel {Edition = "Home N", GenericKey = "3KHY7-WNT83-DGQKR-F7HPR-844BM"},
            new Kms38GenericKeyModel {Edition = "Home China", GenericKey = "PVMJN-6DFY6-9CCP6-7BKTT-D3WVR"},
            new Kms38GenericKeyModel {Edition = "Home Single Language", GenericKey = "7HNRX-D7KGG-3K4RQ-4WPJ4-YTDFH"},
            new Kms38GenericKeyModel {Edition = "Pro", GenericKey = "W269N-WFGWX-YVC9B-4J6C9-T83GX"},
            new Kms38GenericKeyModel {Edition = "Pro N", GenericKey = "MH37W-N47XK-V7XM9-C7227-GCQG9"},
            new Kms38GenericKeyModel {Edition = "Pro Education", GenericKey = "6TP4R-GNPTD-KYYHQ-7B7DP-J447Y"},
            new Kms38GenericKeyModel {Edition = "Pro Education N", GenericKey = "YVWGF-BXNMC-HTQYQ-CPQ99-66QFC"},
            new Kms38GenericKeyModel {Edition = "Pro for Workstations", GenericKey = "NRG8B-VKK3Q-CXVCJ-9G2XF-6Q84J"},
            new Kms38GenericKeyModel {Edition = "Pro N for Workstations", GenericKey = "9FNHH-K3HBT-3W4TD-6383H-6XYWF"},
            new Kms38GenericKeyModel {Edition = "SE", GenericKey = "37D7F-N49CB-WQR8W-TBJ73-FM8RX"},
            new Kms38GenericKeyModel {Edition = "SE N", GenericKey = "6XN7V-PCBDC-BDBRH-8DQY7-G6R44"},

        };

        // Get the full list
        public static List<Kms38GenericKeyModel> GetAll() => _genericKeys;

        // Find a specific edition
        public static Kms38GenericKeyModel? GetByEdition(string edition)
        {
            return _genericKeys.Find(p => p.Edition.Equals(edition, StringComparison.OrdinalIgnoreCase));
        }

        // Add a new one
        public static void Add(Kms38GenericKeyModel item)
        {
            _genericKeys.Add(item);
        }
    }
}
