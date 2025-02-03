# Number Information API

## Overview

The **Number Information API** provides details about a given number, including its primality, perfection status, properties, digit sum, and a fun fact.
The properties of the number include whether it is an _Armstrong Number_ and also checks if the number is _even_ or _odd_.
The funfact is retrieved from the [Numbers API]("http://numbersapi.com/371/math).

## Endpoint

`GET /api/classify-number/`

## Query Parameters

| Parameter | Type   | Required | Description |
|-----------|--------|----------|-------------|
| number    | int    | Yes      | The number to retrieve information about. |

## Response Format

The API returns a JSON response with the following structure:

```json
{
    "number": 371,
    "is_prime": false,
    "is_perfect": false,
    "properties": [
      "armstrong",
      "odd"
    ],
    "digit_sum": 11,
    "fun_fact": "371 is a narcissistic number."
}
```

## Example Request

```http
GET /api/classify-number/?number=371
```

## Example Response

```json
{
    "number": 371,
    "is_prime": false,
    "is_perfect": false,
    "properties": [
      "armstrong",
      "odd"
    ],
    "digit_sum": 11,
    "fun_fact": "371 is a narcissistic number."
}
```

## Error Handling

If an invalid number parameter is provided, the API returns an appropriate error response:

```json
{
    "number": "alphabet",
    "error": true
}
```
