# BEWalks API

BEWalks API is a RESTful API built with **.NET 9** for managing walking trails and their difficulty levels across Belgian regions. It provides endpoints for creating, updating, and retrieving walk data, making it easy to explore and organize outdoor activities in Belgium.

## Features

- **User Authentication**: Register and login to access protected endpoints.
- **Region Management**: Create, update, delete, and retrieve regions in Belgium.
- **Walk Management**: Create, update, delete, and retrieve walking trails with details like difficulty levels.
- **Image Upload**: Upload images associated with walks or regions.
- **Student Data**: Retrieve student-related data (if applicable).

## Endpoints

### Authentication

- **POST** `/api/auth/register`  
  Register a new user.

- **POST** `/api/auth/login`  
  Login and receive an authentication token.

### Images

- **POST** `/api/images/upload`  
  Upload an image.

### Regions

- **GET** `/api/regions`  
  Retrieve all regions.

- **POST** `/api/regions`  
  Create a new region.

- **GET** `/api/regions/{id}`  
  Retrieve a specific region by ID.

- **PUT** `/api/regions/{id}`  
  Update a specific region by ID.

- **DELETE** `/api/regions/{id}`  
  Delete a specific region by ID.

### Walks

- **POST** `/api/walks`  
  Create a new walk.

- **GET** `/api/walks`  
  Retrieve all walks.

- **GET** `/api/walks/{id}`  
  Retrieve a specific walk by ID.

- **PUT** `/api/walks/{id}`  
  Update a specific walk by ID.

- **DELETE** `/api/walks/{id}`  
  Delete a specific walk by ID.

### Students

- **GET** `/api/Students`  
  Retrieve student-related data (if applicable).

## Schemas

The API uses the following schemas for data representation:

### Region Schema
```json
{
  "id": "string",
  "name": "string",
  "code": "string",
  "regionImageUrl": "string"
}