# Jan22_CodeChallenge1

## API Endpoints

### GET

http://localhost:35000/api/albums
http://localhost:35000/api/albums?search=<filter>

#### GET /api/albums

Retrieves the list of albums from a [JSONPlaceHolder endpoint](https://jsonplaceholder.typicode.com/albums) and returns all 100 results in list form.

**Response**
```
[
    {
        "userId": 1,
        "id": 1,
        "title": "quidem molestiae enim"
    },
    ...
    {
        "userId": 10,
        "id": 100,
        "title": "enim repellat iste"
    }
]
```

#### GET /api/albums?search=<filter>

Retrieves the list of albums from a [JSONPlaceHolder endpoint](https://jsonplaceholder.typicode.com/albums) and returns only the results with a title containing the search filter string. Search is not case-sensitive.

**Parameters**
string search (optional): Adds filter term to search through albums with.

**Response**
```
// Using search term "quidem"
[
    {
        "userId": 1,
        "id": 1,
        "title": "quidem molestiae enim"
    },
    {
        "userId": 8,
        "id": 79,
        "title": "ipsa quae voluptas natus ut suscipit soluta quia quidem"
    }
]
```

### PUT

http://localhost:35000/api/cups/swap

#### PUT /api/cups/swap

Initializes a system of three cups (A, B, and C) and places a ball under Cup B. The function then takes a series of "swaps" to move the ball's position and returns the final Cup entity that contains the ball. 

**Parameters**
Array[string] (required): An array of "swaps" (each of which is a two-letter string containing 'A', 'B', or 'C') which dictate the position on a ball within a three cup system. 

**Response**
```
// Using swaps ["AB", "AC"]
{
    "Id": 2,
    "CupId": C,
    "HasBall":true
}
```

