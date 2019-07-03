#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-runtime-nanoserver-1803 AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY Signal.Simulator/Signal.Simulator.csproj Signal.Simulator/
COPY CS.DAL/CS.DAL.csproj CS.DAL/
RUN dotnet restore Signal.Simulator/Signal.Simulator.csproj
COPY . .
WORKDIR /src/Signal.Simulator
RUN dotnet build Signal.Simulator.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Signal.Simulator.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Signal.Simulator.dll"]
