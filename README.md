# Introduction 
Aplicação de teste usando Docker e Kubernetes

# Docker Help

Criar a imagem docker

```
docker build -f .\ContosoUniversity.WebApplication\Dockerfile -t contosouniversity-web .
docker build -f .\ContosoUniversity.API\Dockerfile -t contosouniversity-api .
```

Executar o Docker Compose

```
docker-compose up
```