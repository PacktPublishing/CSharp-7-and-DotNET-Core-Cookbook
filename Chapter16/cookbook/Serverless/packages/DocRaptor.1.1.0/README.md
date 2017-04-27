# DocRaptor C# Native Client Library

This is a DLL and NuGet package for using [DocRaptor API](https://docraptor.com/documentation) to convert [HTML to PDF and XLSX](https://docraptor.com).

## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later


## Installation

**Command line**:

```powershell
nuget.exe install DocRaptor
```

**[Package Manager Console](http://docs.nuget.org/consume/package-manager-console)**:

```powershell
Install-Package DocRaptor
```

**Download DLLs**: get `DocRaptor.dll` from [GitHub](https://github.com/DocRaptor/docraptor-csharp/releases)


## Usage

See [examples](examples/) for runnable examples with file output, error handling, etc.

```csharp
using DocRaptor.Client;
using DocRaptor.Model;
using DocRaptor.Api;
using System.IO;

class Example {
  static void Main(string[] args) {
    Configuration.Default.Username = "YOUR_API_KEY_HERE"; // this key works for test documents
    DocApi docraptor = new DocApi();

    Doc doc = new Doc(
      Test: true,                                                    // test documents are free but watermarked
      DocumentContent: "<html><body>Hello World</body></html>",      // supply content directly
      // DocumentUrl: "http://docraptor.com/examples/invoice.html",  // or use a url
      Name: "docraptor-csharp.pdf",                                  // help you find a document later
      DocumentType: Doc.DocumentTypeEnum.Pdf                         // pdf or xls or xlsx
      // Javascript: true,                                           // enable JavaScript processing
      // PrinceOptions: new PrinceOptions(
      //   Media: "screen",                                          // use screen styles instead of print styles
      //   Baseurl: "http://hello.com"                               // pretend URL when using document_content
      // )
    );

    byte[] create_response = docraptor.CreateDoc(doc);
  }
}
```

Docs created like this are limited to 60 seconds to render, check out the [async example](examples/async.cs) which allows 10 minutes.

We have guides for doing some of the common things:

* [Headers and Footers](https://docraptor.com/documentation/style#pdf-headers-footers) including page skipping
* [CSS Media Selector](https://docraptor.com/documentation/api#api_basic_pdf) to make the page look exactly as it does in your browser
* Protect content with [HTTP authentication](https://docraptor.com/documentation/api#api_http_user) or [proxies](https://docraptor.com/documentation/api#api_http_proxy) so only DocRaptor can access them


## More Help

DocRaptor has a lot of more [styling](https://docraptor.com/documentation/style) and [implementation options](https://docraptor.com/documentation/api).

Stuck? We're experts at using DocRaptor so please [email us](mailto:support@docraptor.com) if you run into trouble.


## Development

The majority of the code in this repo is generated using swagger-codegen on [docraptor.yaml](docraptor.yaml). You can modify this file and regenerate the client using `script/generate_language csharp`.

The generated client needed a few fixes
- https://github.com/swagger-api/swagger-codegen/issues/2368
- https://github.com/swagger-api/swagger-codegen/issues/2367


## Release Process

1. Pull latest master
2. Merge feature branch(es) into master
3. `script/test`
4. Increment version in code:
  - `swagger-config.json`
  - `DocRaptor.nuspec`
  - `src/main/csharp/DocRaptor/Properties/AssemblyInfo.cs`
  - `src/main/csharp/DocRaptor/Client/Configuration.cs` (2 places)
5. Update [CHANGELOG.md](CHANGELOG.md)
6. Commit "Release vX.Y.Z"
7. Push to GitHub
8. Tag version: `git tag 'vX.Y.Z' && git push --tags`
9. Build package using `script/build`
10. `script/nuget push bin/DocRaptor.X.Y.Z.nupkg`
11. Open https://github.com/DocRaptor/docraptor-csharp/tags and make a new release for the version. Use the git tag as the name, CHANGELOG entries as the description, and attach `bin/*.dll` and `bin/*.xml` to the release
12. Refresh documentation on docraptor.com


## Version Policy

This library follows [Semantic Versioning 2.0.0](http://semver.org).
