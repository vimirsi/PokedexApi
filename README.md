# PokedexApi .NET 7

## DER

- https://app.diagrams.net/#G1mm6mWGa6mGQSLw6jiIx_VUHNfQONdM1H

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
dotnet watch --project PokedexApi.Web run
```


## Adding package to a project

```bash
dotnet add PokedexApi.Web package Npgsql
```


# Troubleshooting

If having an error message like 'System.IO.IOException : The configured user limit (128) on the number of inotify instances has been reached, or the per-process limit on the number of open file descriptors has been reached', runs the following command, and run the test command again:

```bash
echo fs.inotify.max_user_instances=524288 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p
```
