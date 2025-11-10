# ArsX Public Portal Background Files v0.1

## Configuration Files

### launchSettings.json
```json
{
  "profiles": {
    "ArsX.PublicPortal": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5200",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

### project.assets.json
```json
{
  "version": 3,
  "targets": {
    "net9.0": {
      "Microsoft.NETCore.App.Ref/9.0.0": {
        "type": "package",
        "compile": {
          "ref/net9.0/System.Runtime.dll": {}
        },
        "runtime": {
          "lib/net9.0/System.Runtime.dll": {}
        }
      }
    }
  },
  "libraries": {
    "Microsoft.NETCore.App.Ref/9.0.0": {
      "sha512": "...",
      "type": "package",
      "path": "microsoft.netcore.app.ref/9.0.0",
      "files": ["ref/net9.0/System.Runtime.dll"]
    }
  }
}
```

## Sample Data

### weather.json
```json
[
  {
    "date": "2025-11-10T00:00:00",
    "temperatureC": 10,
    "temperatureF": 50,
    "summary": "Chilly"
  },
  {
    "date": "2025-11-11T00:00:00",
    "temperatureC": 12,
    "temperatureF": 54,
    "summary": "Cool"
  }
]
```

## Component-Specific CSS

### NavMenu.razor.css
```css
.nav-scrollable {
  overflow-y: auto;
  max-height: calc(100vh - 56px);
}
.nav-link {
  color: #fff;
  padding: 8px 16px;
  text-decoration: none;
}
.nav-link:hover {
  background-color: #1c2638;
}
```

### MainLayout.razor.css
```css
.page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}
.sidebar {
  background-color: #10131a;
  color: #d9e6ff;
  padding: 16px;
}
.main-content {
  flex: 1;
  padding: 16px;
}
footer {
  background-color: #10131a;
  color: #7a8596;
  text-align: center;
  padding: 16px;
}
```

## Build Artifacts

### ArsX.PublicPortal.csproj.nuget.g.targets
```xml
<Project>
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
  </PropertyGroup>
</Project>
```

### ArsX.PublicPortal.csproj.nuget.g.props
```xml
<Project>
  <PropertyGroup>
    <RestorePackages>true</RestorePackages>
  </PropertyGroup>
</Project>
```

### ArsX.PublicPortal.csproj.nuget.dgspec.json
```json
{
  "restore": {
    "projectName": "ArsX.PublicPortal",
    "framework": "net9.0"
  }
}
```