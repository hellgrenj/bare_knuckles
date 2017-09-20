#!/bin/bash
dotnet ef database update && dotnet run

exec "$@"