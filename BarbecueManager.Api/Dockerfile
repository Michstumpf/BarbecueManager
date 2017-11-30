FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 80
EXPOSE 1433
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "BarbecueManager.Api.dll"]
