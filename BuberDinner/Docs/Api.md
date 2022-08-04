#  API

- [API](#api)
  - [Auth](#auth)
    - [Register Request](#register-request)
    - [Register Response](#register-response)
    - [Login Request](#login-request)
    - [Login Response](#login-response)

## Auth 

### Register Request

```js
POST {{host}}/auth/register
```

```json
{
    "firstName": "Vegan",
    "lastName": "Sunshine",
    "email": "vegan.sunshine@domain.com",
    "password": "example@2023",
}
```

### Register Response

```js
200 OK
```
```json
{
    "id": "4406fa24-fd7c-4b2d-89cf-f55f870d8d3d",
    "firstName": "Vegan",
    "lastName": "Sunshine",
    "email": "vegan.sunshine@domain.com",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
}
```
### Login Request

```js
POST {{host}}/auth/login
```

```json
{
    "email": "vegan.sunshine@domain.com",
    "password": "example@2023",
}
```

### Login Response

```js
200 OK
```
```json
{
    "id": "4406fa24-fd7c-4b2d-89cf-f55f870d8d3d",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
}
```