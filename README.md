# Introduction 

The Contoso University sample web app demonstrates how to create an ASP.NET Core MVC web app using Entity Framework (EF) Core and Visual Studio.

The sample app is a web site for a fictional Contoso University. It includes functionality such as student admission, course creation, and instructor assignments. This is the first in a series of tutorials that explain how to build the Contoso University sample app.

For more details [Contoso University Docs](https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-7.0).

# Docker Help

Criar a imagem docker

```ps
docker build -f .\ContosoUniversity.WebApplication\Dockerfile -t contosouniversity-web .
docker build -f .\ContosoUniversity.API\Dockerfile -t contosouniversity-api .
```

Executar o Docker Compose

```ps
docker-compose up
```

# Git Help 

Alguns comandos para o GIT

## Multiple Remotes

```ps
# Adicionando um novo repo como remote
git remote add bkp https://github.com/lsprado/ContosoUniversity.git
git remote -v
git push bkp master

# Criando um ALIAS para dar push em todos os remotes
git config --global --list
git config --global alias.pushall '!f(){ for var in $(git remote show); do echo "pushing to $var"; git push $var; done; }; f'
git pushall
```
test