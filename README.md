# MealMate

# Services

## User

### Get list of user

> GET https://localhost:7296/api/users

- if success, response 200 OK as below

```
{
  "user_name": "Jolly bear",
  "user_password": "password123",
  "user_telephone": "011234",
  "user_img": "user.jpg",
  "user_created_date": "2023-05-02T18:32:36.717219Z",
  "user_updated_date": null
}
```

---

### Create user

> POST https://localhost:7296/api/users/create

- body

```
{
  "user_name": "Jolly bear",
  "user_password": "password123",
  "user_telephone": "011234",
  "user_img": "user.jpg",
  "user_created_date": "2023-05-02T18:32:36.717219Z",
  "user_updated_date": null
}
```

---

### Get user by id

> GET https://localhost:7296/api/users/3

---

---

## Post

### Create post

> POST https://localhost:7296/api/post/create

- body

```
{
  "poster_id": 1,
  "quantity": 8
}
```

- if success, response 201 Created as below

```
{
    "post_id": 2,
    "poster_id": 1,
    "quantity": 8,
    "start_date": "2023-05-02T20:12:52.527133Z",
    "end_date": null,
    "status": null
}
```

---

### Update post

> PUT https://localhost:7296/api/post/1

- body

```
{
    "post_id": 1,
    "poster_id": 1,
    "start_date": "2023-05-02T21:12:52.527133Z",
    "end_date": null,
    "status": null
}
```

- if success, response 200 OK

---

---

## Order

### Create order

> POST https://localhost:7296/api/orders/create

- body

```
{
  "post_id": 1,
  "poster_id": 1,
  "food_name": "kaproa",
  "quantity": 2,
  "order_owner_id": 3
}
```

- if success, response 201 Created as below

```
{
  "order_id": 1,
  "post_id": 1,
  "poster_id": 1,
  "food_name": "kaproa",
  "notes": null,
  "quantity": 2,
  "order_owner_id": 3,
  "status": null,
  "latest_update": "2023-05-02T20:20:17.619129Z"
}
```

---

---

## Activity Logs
