FROM microsoft/dotnet:2.2-sdk-alpine as build
WORKDIR /src
ENV solution=Testes.sln

#copia o codigo para a imagem
COPY ./Agibank ./
#efetua o build e test
RUN dotnet restore ${solution} && \
    dotnet build ${solution} && \
    dotnet test ${solution} 

#cria uma imagem final para executar o relatorio do teste
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

#copia os arquivos html resultantes do teste para o nginx
COPY --from=build /src/TestesStarWars/bin/Debug/netcoreapp2.2/*.html /usr/share/nginx/html/
EXPOSE 80