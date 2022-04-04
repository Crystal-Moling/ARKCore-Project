using System;

namespace ARKCore.Authentication.Microsoft
{
    public class MsAuthResult
    {
        public String AccessToken { get; set; }
        public String RefreshToken { get; set; }
        public bool ERROR { get; set; }
    }
}