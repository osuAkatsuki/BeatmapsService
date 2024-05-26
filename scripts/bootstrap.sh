#!/usr/bin/env bash
set -eo pipefail

# catch vault secrets
if [ -n "$KUBERNETES" ]; then
  source /vault/secrets/secrets.txt
fi


cd /app
dotnet BeatmapsService.dll