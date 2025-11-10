# ArsX Public Portal Razor Files v0.1

## Code Overview

### Home.razor
```aspnetcorerazor
@page "/home"

<h3>Home</h3>

<div class="user-info">
    <p>Welcome, <span id="user-name">Loading...</span></p>
</div>

<p>Your role: @userRole</p>

<div class="role-cards">
    @foreach (var card in roleCards)
    {
        <div class="card">
            <h5>@card.Title</h5>
            <p>@card.Description</p>
        </div>
    }
</div>

@inject ArsX.PublicPortal.Services.ApiClient ApiClient

@code {
    private string userName = "";
    private string userRole = "Administrator";

    private List<RoleCard> roleCards = new()
    {
        new RoleCard { Title = "Manage Users", Description = "Add, edit, or remove users." },
        new RoleCard { Title = "View Reports", Description = "Access detailed analytics and reports." },
        new RoleCard { Title = "Settings", Description = "Configure application settings." }
    };

    private class RoleCard
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            userName = await ApiClient.GetAsync<string>("/api/session/whoami") ?? "Unknown user";
        }
        catch (Exception ex)
        {
            userName = $"Error: {ex.Message}";
        }
    }
}
```

### Login.razor
```aspnetcorerazor
@page "/login"

<h3>Login</h3>

<div class="numeric-keypad">
    <p>Enter your numeric code:</p>
    <input type="password" maxlength="6" />
    <button>Continue</button>
</div>

<div class="keypad">
    @for (int i = 1; i <= 9; i++)
    {
        <button class="keypad-button" @onclick="() => AddDigit(i)">@i</button>
        if (i % 3 == 0)
        {
            <br />
        }
    }
    <button class="keypad-button" @onclick="ClearCode">Clear</button>
    <button class="keypad-button" @onclick="() => AddDigit(0)">0</button>
    <button class="keypad-button" @onclick="SubmitCode">Enter</button>
</div>
<p>Code: @codeInput</p>

@code {
    private string codeInput = "";

    private void AddDigit(int digit)
    {
        if (codeInput.Length < 6)
        {
            codeInput += digit;
        }
    }

    private void ClearCode()
    {
        codeInput = "";
    }

    private void SubmitCode()
    {
        if (codeInput.Length == 6)
        {
            // Simulate navigation or validation
            Console.WriteLine("Code submitted: " + codeInput);
        }
        else
        {
            Console.WriteLine("Invalid code length.");
        }
    }
}

<style>
    .numeric-keypad {
        display: flex;
        flex-direction: column;
        align-items: center;
        margin-top: 50px;
    }

    .numeric-keypad input {
        font-size: 1.5rem;
        text-align: center;
        margin-bottom: 20px;
    }

    .numeric-keypad button {
        font-size: 1.2rem;
        padding: 10px 20px;
    }

    .keypad {
        display: grid;
        grid-template-columns: repeat(3, 1fr);
        gap: 10px;
        margin-top: 20px;
    }

    .keypad-button {
        font-size: 1.5rem;
        padding: 20px;
    }
</style>
```

### VerifyTotp.razor
```aspnetcorerazor
@page "/verify-totp"

<h3>Verify TOTP</h3>

<div class="totp-verification">
    <p>Enter the 6-digit code:</p>
    <input type="text" maxlength="6" @bind="totpCode" class="totp-input" />
    <button @onclick="VerifyCode" class="verify-button">Verify</button>
    <p>@verificationMessage</p>
</div>

<style>
    .totp-verification {
        display: flex;
        flex-direction: column;
        align-items: center;
        margin-top: 50px;
    }

    .totp-verification input {
        font-size: 1.5rem;
        text-align: center;
        margin-bottom: 20px;
    }

    .totp-verification button {
        font-size: 1.2rem;
        padding: 10px 20px;
    }
</style>

@code {
    private string totpCode = "";
    private string verificationMessage = "";

    private void VerifyCode()
    {
        if (totpCode.Length == 6 && int.TryParse(totpCode, out _))
        {
            // Simulate verification logic
            verificationMessage = "Code verified successfully!";
        }
        else
        {
            verificationMessage = "Invalid code. Please try again.";
        }
    }
}
```

### NavMenu.razor
```aspnetcorerazor
<div class="top-row ps-3 navbar navbar-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="">ArsX.PublicPortal</a>
        <button title="Navigation menu" class="navbar-toggler" @onclick="ToggleNavMenu">
            <span class="navbar-toggler-icon"></span>
        </button>
    </div>
</div>

<div class="@NavMenuCssClass nav-scrollable" @onclick="ToggleNavMenu">
    <nav class="nav flex-column">
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
                <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Home
            </NavLink>
        </div>
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="counter">
                <span class="bi bi-plus-square-fill-nav-menu" aria-hidden="true"></span> Counter
            </NavLink>
        </div>
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="weather">
                <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Weather
            </NavLink>
        </div>
    </nav>
</div>

@code {
    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}

```

### MainLayout.razor
```aspnetcorerazor
@inherits LayoutComponentBase
<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <header>
        <nav>
            <a href="/">Home</a>
            <a href="/about">About</a>
        </nav>
    </header>

    <main class="main-content">
        @Body
    </main>

    <footer>
        <p>&copy; 2025 ArsX Public Portal</p>
    </footer>
</div>

```

### App.razor
```aspnetcorerazor
@using ArsX.PublicPortal.Pages
@inject NavigationManager NavigationManager

<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
    <NotFound>
        <PageTitle>Not Found</PageTitle>
        <LayoutView Layout="@typeof(MainLayout)">
            <p>Sorry, the page could not be found.</p>
        </LayoutView>
    </NotFound>
</Router>

@code {
    protected override void OnInitialized()
    {
        NavigationManager.NavigateTo("/home");
    }
}

```

### _Imports.razor
```aspnetcorerazor
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.AspNetCore.Components.WebAssembly.Http
@using Microsoft.JSInterop
@using ArsX.PublicPortal
@using ArsX.PublicPortal.Layout

```