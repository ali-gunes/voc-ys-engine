# Yemeksepeti Scraper Engine API Documentation

The Yemeksepeti Scraper Engine provides a web interface to fetch restaurant data and autocomplete suggestions specifically from Yemeksepeti.

## Base URL
Default: `http://localhost:3000`

---

## Endpoints

### 1. Scrape Restaurant Data
Fetches detailed information about a specific restaurant, including menus, products, and pricing.

- **URL**: `/scrape`
- **Method**: `GET`
- **Query Parameters**:
    - `input` (Required): A Yemeksepeti restaurant ID (e.g., `y30u`) or a full restaurant URL.

**Example Request**:
```bash
curl "http://localhost:3000/scrape?input=https://www.yemeksepeti.com/restaurant/y30u/kofteci-yusuf-y30u"
```

**Example Response**:
```json
{
  "status_code": 200,
  "data": {
    "id": 127281,
    "name": "Köfteci Yusuf",
    "address": "...",
    "menus": [
      {
        "id": 1,
        "name": "Popüler",
        "menu_categories": [...]
      }
    ]
  }
}
```

---

### 2. Autocomplete Suggestions
Fetches popular search keywords and suggestions based on geographic coordinates.

- **URL**: `/autocomplete`
- **Method**: `GET`
- **Query Parameters**:
    - `lat` (Required): Latitude coordinate (e.g., `41.0627474`).
    - `lng` (Required): Longitude coordinate (e.g., `28.993111`).

**Example Request**:
```bash
curl "http://localhost:3000/autocomplete?lat=41.0627474&lng=28.993111"
```

**Example Response**:
```json
{
  "suggestions": {
    "items": [
      {
        "headline": "Popular",
        "suggestion_type": "popular",
        "items": [
          { "keyword": "burger", "tracking_code": "popular:burger" },
          { "keyword": "pizza", "tracking_code": "popular:pizza" }
        ]
      }
    ]
  },
  "deeplinks": { "vendors": [] }
}
```

---

### 3. Fetch Restaurant Listings (GraphQL)
Fetches a list of restaurants available in a specific geographic area using a GraphQL query.

- **URL**: `/restaurants`
- **Method**: `GET`
- **Query Parameters**:
    - `lat` (Required): Latitude coordinate (e.g., `41.0627474`).
    - `lng` (Required): Longitude coordinate (e.g., `28.993111`).

**Example Request**:
```bash
curl "http://localhost:3000/restaurants?lat=41.0627474&lng=28.993111"
```

**Example Response**:
```json
{
  "data": {
    "vendorListingPage": {
      "components": [
        {
          "__typename": "SwimlaneComponent",
          "headline": "Mutfaklar",
          "entities": [...]
        },
        {
          "__typename": "SwimlaneComponent",
          "headline": "Restoranlar",
          "entities": [
            {
              "__typename": "VendorData",
              "name": "Hey Döner",
              "urlKey": "hey-doner-kdr3",
              "availability": { "status": "OPEN", ... }
            }
          ]
        }
      ],
      "totalVendors": 4365
    }
  }
}
```

---

## Error Handling

| Status Code | Description |
|---|---|
| `400 Bad Request` | Missing or invalid parameters (e.g., missing `input`, invalid `lat`/`lng`). |
| `404 Not Found` | Restaurant or data not found for the provided input. |
| `500 Internal Server Error` | An error occurred during the scraping process. |
