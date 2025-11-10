# ArsX Public Portal v0.1

## Overview
The ArsX Public Portal is a Blazor WebAssembly application designed to provide a secure and user-friendly interface for authentication and user information retrieval.

## Features Implemented

### Pages
1. **Login.razor**
   - Numeric keypad login interface with a "Continue" button.

2. **VerifyTotp.razor**
   - 6-digit TOTP input with a "Verify" button.

3. **Home.razor**
   - Displays user information retrieved from `/api/session/whoami` once logged in.

### Services
1. **ApiClient.cs**
   - Handles REST calls to the API.
   - Base address set to `http://localhost:5000` for local testing.

2. **SessionStore.cs**
   - Keeps JWT and DPoP keys in memory only.

3. **CsrfService.cs**
   - Manages request protection tokens.

### Configuration
- `Program.cs` updated to:
  - Register `ApiClient`, `SessionStore`, and `CsrfService`.
  - Remove redundant `HttpClient` registration.
  - Enable logging for debugging purposes.

### Routing
- `App.razor` updated to:
  - Set `Login.razor` as the default page.
  - Fix invalid `DefaultLayout` property in the `Router` component.

## Testing
- Application built and run successfully.
- Verified functionality of `Login.razor` page.
- Browser confirmed the application is live and operational.

## Test Results

### Homepage
- **Status**: Successfully loaded.
- **Details**: The homepage displayed user information and role-based cards as expected.
- **Screenshot**: [Homepage Screenshot](../attachments/homepage.png)

### Routing
- **Status**: Functional.
- **Details**: Navigation to other pages (e.g., `Counter`, `Weather`) worked without issues.

### HTTPS and HTTP
- **Status**: Enabled.
- **Details**: The application was accessible via both `https://localhost:5201` and `http://localhost:5200`.

### Observations
- No errors were observed in the browser console.
- The application shut down manually after testing.

## Next Steps
- Finalize documentation.
- Prepare for deployment.

---
Generated on November 10, 2025.