using System;

namespace RMA70_LauncherLib.Core.Authentication
{
    public class AuthResult
    {
        public string Username { get; set; }
        public string Uuid { get; set; }
        public string AccessToken { get; set; }
        public string ClientToken { get; set; }
        
        public string Error { get; set; }
        public string ErrorMessage { get; set; }

        public bool Verified { get; set; }

        public static implicit operator AuthResult(string name)
        {
            return new AuthResult
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