# PokedexApi .NET 7

## DER

- https://viewer.diagrams.net/index.html?tags=%7B%7D&highlight=0000ff&edit=_blank&layers=1&nav=1&title=Pokedex%20Der#Uhttps%3A%2F%2Fdrive.google.com%2Fuc%3Fid%3D1mm6mWGa6mGQSLw6jiIx_VUHNfQONdM1H%26export%3Ddownload

## Design

- https://www.canva.com/design/DAFZRp-p8eg/eZqrjDMPyNtwggAZlFoQTA/view?utm_content=DAFZRp-p8eg&utm_campaign=designshare&utm_medium=link&utm_source=publishsharelink

## Documentação

- https://docs.google.com/document/d/166f4apjQerg56iSA5b9tBFOJmkK8XuGLAhOwUeyTWiw/edit?usp=sharing

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
