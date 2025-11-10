# Copilot Context — arsX Public Frontend

## Project Identity
**Name:** arsX Co-UK — Public Frontend  
**Purpose:** Public-facing website + portal for the arsX initiative.  
**Contains:**
- `/index.html`, `/forge.html`, `/styles.css` — static publishing site (Orbital Forge, etc.)
- `/src/ArsX.PublicPortal/` — Blazor WebAssembly login and TOTP portal  
- `.github/` — workflows and Copilot instructions  

## Copilot Behaviour
When generating or editing code:
- Use **.NET 9.0 / Blazor WASM** for `/src/ArsX.PublicPortal/`
- Keep **HTML/CSS** minimal and semantic for root site
- All backend/API calls go to `https://api.arsx.co.uk`
- Do **not** include L5 or admin endpoints (this repo is public)
- Use **DPoP-bound JWT** tokens stored in memory only
- Respect **CSP**, **SRI**, and **no-PII logging**

## Copilot Tasks
- Scaffold Blazor pages: `Login.razor`, `VerifyTotp.razor`, `Home.razor`
- Build service layer: `ApiClient.cs`, `SessionStore.cs`, `CsrfService.cs`
- Generate markdown docs when asked: `PORTAL_USER_GUIDE.md`, etc.
- Never modify files in `/assets` or `/downloads` unless explicitly requested.
- All new static builds should output to `/portal/`.

## Output Style
- Concise, readable code with comments.
- Markdown docs use `##` headers and short lists.
- When unsure, ask before overwriting.

*(Last updated: 2025-11-10, Thomas Willis / arsX)*
