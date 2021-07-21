#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
# ENV ASPNETCORE_URLS=http://+:5000
# ENV ASPNETCORE_ENVIRONMENT=”development”
EXPOSE 5000
# RUN chmod +x entrypoint.sh
# CMD /bin/bash entrypoint.sh
ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000"]

