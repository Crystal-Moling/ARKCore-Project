using System;

namespace ARKCore.Authentication.Yggdrasil
{
    public class YggAuthResult
    {
        public string Username { get; set; }
        public string Uuid { get; set; }
        public string AccessToken { get; set; }
        public string ClientToken { get; set; }
        
        public string Error { get; set; }
        public string ErrorMessage { get; set; }

        public bool Verified { get; set; }

        public static implicit operator YggAuthResult(string name)
        {
            return new YggAuthResult
            {
                Username = name,
                Uuid = Guid.NewGuid().ToString("N"),
                AccessToken = Guid.NewGuid().ToString("N"),
                ClientToken = Guid.NewGuid().ToString("N"),
                Verified = true
            };
        }
    }
}