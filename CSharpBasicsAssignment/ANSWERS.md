# Part G — Short Answers

## 1. .csproj Contents

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

The four properties are present:
- `OutputType`: `Exe`
- `TargetFramework`: `net10.0`
- `ImplicitUsings`: `enable`
- `Nullable`: `enable`

## 2. #region and #endregion

No, `#region` and `#endregion` do not change the compiled output. They help organize code and allow sections to be collapsed in the editor.

## 3. XML Documentation Comments

I use `///` XML documentation comments to document public classes, methods, and properties. They support IntelliSense and can be used to generate XML documentation. Plain `//` comments are used for general explanations in the code.

## 4. Global Variables in C#

C# has no true global variables because variables belong to specific scopes or types. The closest equivalent is a `public static` field or property inside a class, which can be accessed using the class name.