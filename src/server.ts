import express from 'express';
import { fetchRestaurantData, fetchAutocomplete } from './scraper.js';
import { extractRestaurantId } from './utils.js';
import * as dotenv from 'dotenv';

dotenv.config();

const app = express();
const port = process.env.PORT || 3000;

app.use(express.json());

// Endpoint to scrape restaurant data
// Usage: GET /scrape?input=https://www.yemeksepeti.com/restaurant/y30u/kofteci-yusuf-y30u
//    or: GET /scrape?input=y30u
app.get('/scrape', async (req, res) => {
    const input = req.query.input as string;

    if (!input) {
        return res.status(400).json({ error: "Missing 'input' query parameter (URL or ID)." });
    }

    const restaurantId = extractRestaurantId(input);

    if (!restaurantId) {
        return res.status(400).json({ error: "Could not extract restaurant ID from input." });
    }

    try {
        const result = await fetchRestaurantData(restaurantId);

        if (result && result.data) {
            return res.json(result);
        } else {
            return res.status(404).json({ error: "Failed to scrape restaurant data or restaurant not found." });
        }
    } catch (error) {
        console.error("Error during scraping:", error);
        return res.status(500).json({ error: "An internal error occurred during scraping." });
    }
});

// Endpoint for autocomplete based on coordinates
// Usage: GET /autocomplete?lat=41.0627474&lng=28.993111
app.get('/autocomplete', async (req, res) => {
    const lat = parseFloat(req.query.lat as string);
    const lng = parseFloat(req.query.lng as string);

    if (isNaN(lat) || isNaN(lng)) {
        return res.status(400).json({ error: "Missing or invalid 'lat' or 'lng' query parameters." });
    }

    try {
        const result = await fetchAutocomplete(lat, lng);

        if (result) {
            return res.json(result);
        } else {
            return res.status(404).json({ error: "Failed to fetch autocomplete suggestions." });
        }
    } catch (error) {
        console.error("Error during autocomplete fetch:", error);
        return res.status(500).json({ error: "An internal error occurred during autocomplete fetch." });
    }
});

app.listen(port, () => {
    console.log(`Yemeksepeti Scraper Engine listening at http://localhost:${port}`);
});
