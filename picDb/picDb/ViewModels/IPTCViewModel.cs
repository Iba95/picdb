using picDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.ViewModels
{
    public class IPTCViewModel
    {
        public string Title { get; set; }
        public string Caption { get; set; }
        public string CopyrightNotice { get; set; }
        public string Creator { get; set; }
        public string Keywords { get; set; }

        public IPTCViewModel(IPTCModel iptc)
        {
            Title = iptc.Title;
            Caption = iptc.Caption;
            CopyrightNotice = iptc.CopyrightNotice;
            Creator = iptc.Creator;
            Keywords = iptc.Keywords;
        }
    }
}
