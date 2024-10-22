FROM mcr.microsoft.com/dotnet/sdk:8.0

EXPOSE 5114

COPY . /app

WORKDIR /app

RUN dotnet restore && dotnet build

CMD [ "dotnet","run","--urls","http://0.0.0.0:5000","--project","./Attelas.WebApi" ]
