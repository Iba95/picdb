using picDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace picDb.Models
{
    public class IPTCModel
    {
        public string Title { get; set; }
        public string Caption { get; set; }
        public string CopyrightNotice { get; set; }
        public string Creator { get; set; }
        public string Keywords { get; set; }

        public IPTCModel()
        {
            Title = "";
            Caption = "";
            CopyrightNotice = "";
            Creator = "";
            Keywords = "";
        }
        public IPTCModel(IPTCViewModel iptcvm)
        {
            Title = iptcvm.Title;
            Caption = iptcvm.Caption;
            CopyrightNotice = iptcvm.CopyrightNotice;
            Creator = iptcvm.Creator;
            Keywords = iptcvm.Keywords;
        }

        public static implicit operator IPTCModel(IPTCViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
