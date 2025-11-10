using System;
using System.Security.Cryptography;

namespace ArsX.PublicPortal.Services
{
    public class CsrfService
    {
        private string? _csrfToken;

        public string GetOrCreateToken()
        {
            if (string.IsNullOrEmpty(_csrfToken))
            {
                _csrfToken = GenerateToken();
            }

            return _csrfToken;
        }

        public void InvalidateToken()
        {
            _csrfToken = null;
        }

        private string GenerateToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var tokenData = new byte[32];
                rng.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }
    }
}