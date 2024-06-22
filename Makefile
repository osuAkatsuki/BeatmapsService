#!/usr/bin/make

build:
	docker build -t legacy-beatmaps-service:latest -t registry.digitalocean.com/akatsuki/legacy-beatmaps-service:latest .

run:
	docker-compose up legacy-beatmaps-service

run-bg:
	docker-compose up -d legacy-beatmaps-service

stop:
	docker-compose down

logs:
	docker-compose logs -f
