# CTF Challenge Setup Instructions

This repository contains various challenges for a Capture The Flag (CTF) competition focused on web security vulnerabilities. Below are the instructions to get started with the challenges using Docker.

## Prerequisites

Before you start, make sure you have Docker installed on your machine. If Docker is not installed, you can set it up by following these steps:


```bash
sudo apt update
sudo apt install docker.io
sudo systemctl start docker
sudo systemctl enable docker
```


## Running the Challenges

Each challenge is containerized with Docker. Below are the instructions to run each challenge individually.

### Challenge 1: Open Redirect

To start the Open Redirect challenge, run the following command:

```bash
docker run -p 8000:80 appsechala/open-redirect
```
This will start the challenge on your local machine and make it accessible via `http://localhost:8000`or `http://0.0.0.0:8000`

### Challenge 2: Restracted File Uplpd

To start the File Uplpd challenge, run the following command:

```bash
docker run -p 8000:80 appsechala/upload-file
```
This will start the challenge on your local machine and make it accessible via `http://localhost:8000`or `http://0.0.0.0:8000`

### Challenge 3: Broken Access Control

To start the Broken Access Control challenge, run the following command:

```bash
docker run -p 8000:80 appsechala/broken-access
```
This will start the challenge on your local machine and make it accessible via `http://localhost:8000`or `http://0.0.0.0:8000`

### Challenge 4: Brute Force

To start the  Brute Force challenge, run the following command:

```bash
docker run -p 8000:80 appsechala/brute-force
```
The Password list file can see in (/password-list-top-100.txt)
This will start the challenge on your local machine and make it accessible via `http://localhost:8000`or `http://0.0.0.0:8000`

## Stopping and Cleaning Up
When you are done with the challenges and wish to stop and clean up, you can follow these steps:

#### Stopping a Challenge
```bash
docker ps  # List all running containers
docker stop <container_id>  # Replace <container_id> with the actual container ID from the list
```

#### Removing Docker Containers
After stopping the containers, you may want to remove them to free up system resources:

```bash
docker ps -a  # List all containers, not just running
docker rm <container_id>  # Replace <container_id> with the actual container ID
```

#### Removing Docker Images
If you decide that you no longer need the Docker images, you can remove them as well:

```bash
docker images  # List all images
docker rmi <image_id>  # Replace <image_id> with the actual image ID
```
