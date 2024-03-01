FROM mcr.microsoft.com/dotnet/sdk:8.0.201-alpine3.18


WORKDIR /app

COPY . . 


ENV KESTREL__ENDPOINTS__HTTP__URL http://+:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "watch", "--non-interactive"]

