FROM microsoft/dotnet:2.0-sdk
COPY . /app/src/
WORKDIR /app/src
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5000
EXPOSE 5600
COPY ./docker-entrypoint.sh /
RUN ["chmod", "+x", "/docker-entrypoint.sh"]
ENTRYPOINT ["/docker-entrypoint.sh"]