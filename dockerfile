# STAGE - BUILD
FROM microsoft/aspnetcore-build:2.0 as build
WORKDIR /docker
COPY src/ServiceHub.Room.Context/*.csproj ServiceHub.Room.Context/
COPY src/ServiceHub.Room.Library/*.csproj ServiceHub.Room.Library/
COPY src/ServiceHub.Room.Service/*.csproj ServiceHub.Room.Service/
RUN dotnet restore *.Service
COPY src ./
RUN dotnet publish *.Service --no-restore -o ../www

# STAGE - DEPLOY
FROM microsoft/aspnetcore:2.0 as deploy
WORKDIR /webapi
COPY --from=build /docker/www ./
ENV ASPNETCORE_URLS=http://+:80/
EXPOSE 80
CMD [ "dotnet", "ServiceHub.Room.Service.dll" ]
