using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Styleholic.DataManager
{
    public class StyleInfo
    {
        private String _StoreId = String.Empty;
        private String _StyleNo = String.Empty;
        private String _ImageUrl = String.Empty;
        private byte[] _StyleImage = null;
        private String _VenderCode = String.Empty;
        private String _VenderName = String.Empty;
        private DateTime _Created;
        private DateTime _LastModified;
        private bool _OnSale = true;

        public String StoreId { get; set; }
        public String StyleNo { get; set; }
        public String ImageUrl { get; set; }
        public byte[] StyleImage { get; set; }
        public String VenderCode { get; set; }
        public String VenderName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public bool OnSale { get; set; }
    }
}
