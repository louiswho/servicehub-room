FROM microsoft/dotnet:2.0-sdk as build
WORKDIR /docker
COPY ./src .
RUN dotnet build ServiceHub.Apartment.sln
RUN dotnet publish ServiceHub.Apartment.Service/ServiceHub.Apartment.Service.csproj --output ../www

FROM microsoft/aspnetcore:2.0 as deploy
WORKDIR /webapi
COPY --from=build /docker/www .
ENV ASPNETCORE_URLS=http://+:80/
EXPOSE 80
CMD [ "dotnet", "ServiceHub.Apartment.Service.dll" ]
