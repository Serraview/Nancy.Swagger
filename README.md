# Nancy.Swagger [![Build status](https://ci.appveyor.com/api/projects/status/jm2q8t8y4u18n03r)](https://ci.appveyor.com/project/yahehe/nancy-swagger)

Nancy plugin for generated API documentation in Swagger format.

The Swagger specification (v2.0) can be found [here](https://github.com/OAI/OpenAPI-Specification/blob/master/versions/2.0.md).

## Building & Releasing

- Build the project(s) you've made changes to in Release
- On the command line, navigate to the source folder of the project you're releasing (for example, /src/Nancy.Swagger)
- Run `nuget pack -IncludeReferencedProjects -Prop Configuration=Release`
- Upload the resulting .nupkg to http://svdev01:8181/packages

### NuGet Packages

The code in this repository contains the code for the following NuGet packages:
 - https://www.nuget.org/packages/Swagger.ObjectModel
 - https://www.nuget.org/packages/Nancy.Swagger
 - https://www.nuget.org/packages/Nancy.Swagger.Annotations

### CI NuGet Feed

The [CI NuGet feed](https://www.myget.org/gallery/nancy-swagger) can be found at https://www.myget.org/F/nancy-swagger/
