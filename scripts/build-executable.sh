#!/bin/sh

echo 'Building multi platform to ../bin '

cd ..

echo 'Building linux-x64'
dotnet publish src/orsus-opengl -r linux-x64 -c Release -o bin/linux-x64 --self-contained

echo 'Building windows-x64'
dotnet publish src/orsus-opengl -r win-x64 -c Release -o bin/win-x64 --self-contained 

echo 'Build finished!'