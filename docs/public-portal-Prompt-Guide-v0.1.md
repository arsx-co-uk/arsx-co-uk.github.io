# Prompt Guide for Generating Markdown Documentation

This document describes how to prompt the AI to generate markdown files for cataloging and documenting project files, as demonstrated in the creation of the `CS`, `Razor`, `Other`, `Background`, and `Uncatalogued` markdown files.

## Step-by-Step Prompting Guide

### 1. **Categorizing Files into Markdown Logs**

#### Prompt:
"Log all code files into markdown files categorized as `CS`, `Razor`, and `Other`."

#### Expected Outcome:
- The AI will analyze the project structure and identify files to be categorized.
- Files will be grouped into:
  - `CS`: C# files.
  - `Razor`: Razor files.
  - `Other`: Text-based files that do not fit into the above categories.
- Markdown files will be created for each category, e.g., `public-portal-CS-v0.1.md`, `public-portal-Razor-v0.1.md`, `public-portal-Other-v0.1.md`.

### 2. **Identifying Uncatalogued Files**

#### Prompt:
"List all files left uncatalogued after creating the markdown logs."

#### Expected Outcome:
- The AI will identify files that were not included in the `CS`, `Razor`, or `Other` categories.
- These files are typically non-text files (e.g., images, binaries) or placeholders.

### 3. **Describing Uncatalogued Files**

#### Prompt:
"Create a markdown file describing the uncatalogued files, their locations, and types."

#### Expected Outcome:
- A markdown file (e.g., `public-portal-Uncatalogued-v0.1.md`) will be created.
- The file will include:
  - File names.
  - Locations.
  - Descriptions of file types and purposes.

### 4. **Documenting Configuration and Background Files**

#### Prompt:
"Create a markdown file with code blocks for configuration files, sample data, component-specific CSS, and build artifacts."

#### Expected Outcome:
- A markdown file (e.g., `public-portal-Background-v0.1.md`) will be created.
- The file will include:
  - Configuration files (e.g., `launchSettings.json`).
  - Sample data (e.g., `weather.json`).
  - Component-specific CSS.
  - Build artifacts.

### 5. **Creating a Prompt Guide**

#### Prompt:
"Create a markdown file describing how to prompt the AI to generate all the markdown files created so far."

#### Expected Outcome:
- A markdown file (e.g., `public-portal-Prompt-Guide-v0.1.md`) will be created.
- The file will document the steps and prompts used to generate the markdown files.

### 6. **Handling Null References in API Calls**

#### Prompt:
"Add null checks to handle possible null reference returns from `JsonSerializer.Deserialize` and `ReadFromJsonAsync`."

#### Expected Outcome:
- Null checks are added to ensure deserialization failures are handled gracefully.
- Exceptions are thrown if `null` values are encountered.

#### Example Code:
```csharp
var userInfo = JsonSerializer.Deserialize<UserInfo>(result.GetRawText());
if (userInfo == null)
{
    throw new InvalidOperationException("Failed to deserialize user info from the fake API.");
}

var userInfoFromApi = await response.Content.ReadFromJsonAsync<UserInfo>();
if (userInfoFromApi == null)
{
    throw new InvalidOperationException("Failed to deserialize user info from the API response.");
}
```

### 7. **Testing and Verification**

#### Prompt:
"Run the application and verify routing and functionality of all pages."

#### Expected Outcome:
- The homepage loads successfully and displays user information.
- Navigation to other pages works without issues.
- No errors are observed in the browser console.

#### Example Command:
```powershell
# Run the application
> dotnet run --project src/ArsX.PublicPortal --urls https://localhost:5201;http://localhost:5200
```

## Notes
- Be specific in your prompts to ensure accurate categorization and documentation.
- Use clear and concise language to describe the desired outcome.
- If additional files or categories are needed, adjust the prompts accordingly.

By following this guide, you can efficiently prompt the AI to generate comprehensive markdown documentation for your project.