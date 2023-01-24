# PokedexApi .NET 7

## Solution Structure

- PokedexApi.Core - Entities, Exceptions, etc.
- PokedexApi.Domain - Business Rules, General Helper classes, CQRS pattern classes.
- PokedexApi.Infra- Data access implementations (DbContext, Repositories), Seeds.
- PokedexApi.Web - ASP.NET MVC application for public website.

## Run projects with dotnet cli

* Run Site API

```bash
dotnet run --project PokedexApi.Web
```

* Run Site API watching changes

```bash
dotnet watch --project source/All.Signature.Web.Site run
```

### Running migrations explicit with dotnet cli

The migrations will run automatically when running the projects *All.Signature.Web.Site* or *All.Signature.Web.Admin* in development environment.
If need to run migrations explicitly, you can do that running the console project *All.Signature.Infrastructure.Data.Migrations*.

* Edit the source/All.Signature.Infrastructure.Data.Migrations/appsettings.json file to set the db connection string if required.

## Adding package to a project

```bash
dotnet add source/All.Signature.Infrastructure.Data.Migrations package Npgsql
```


# Troubleshooting

If having an error message like 'System.IO.IOException : The configured user limit (128) on the number of inotify instances has been reached, or the per-process limit on the number of open file descriptors has been reached', runs the following command, and run the test command again:

```bash
echo fs.inotify.max_user_instances=524288 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p
```
