using System;

namespace ArsX.PublicPortal.Services
{
    public class SessionStore
    {
        public string? JwtToken { get; private set; }
        public string? DPoPKey { get; private set; }

        public event EventHandler? OnSessionChanged;

        public void SetSession(string jwtToken, string dPoPKey)
        {
            JwtToken = jwtToken;
            DPoPKey = dPoPKey;
            OnSessionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ClearSession()
        {
            JwtToken = null;
            DPoPKey = null;
        }

        public bool IsSessionActive()
        {
            return !string.IsNullOrEmpty(JwtToken) && !string.IsNullOrEmpty(DPoPKey);
        }
    }
}