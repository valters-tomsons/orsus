#!/bin/sh
echo "Building orsus..."
dotnet publish -p -r linux-x64 /p:PublishSingleFile=true -o "artifacts/linux-x64"

echo "Copying resources..."
cp "src/orsus-engine/Shaders" "artifacts/linux-x64/" -r