#!/usr/bin/make

build:
	docker build -t BeatmapsService:latest -t registry.digitalocean.com/akatsuki/BeatmapsService:latest .

run:
	docker-compose up BeatmapsService

run-bg:
	docker-compose up -d BeatmapsService

stop:
	docker-compose down

logs:
	docker-compose logs -f
